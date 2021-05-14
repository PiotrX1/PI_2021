using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PI_2021.Data;
using PI_2021.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PI_2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Missing");
        }

        public IActionResult Missing(int page = 1, char plec = ' ')
        {

            var temp = dbContext.People.AsQueryable();

            if (plec == 'K')
                temp = temp.Where(x => x.Gender == 'K');
            else if (plec == 'M')
                temp = temp.Where(x => x.Gender == 'M');


            int count = temp.Count();
            var people = temp.Skip(10*(page-1)).Take(10).ToList();

            int pages = (int)Math.Ceiling(((double)count / 10));

            ViewBag.People = people;
            ViewBag.Pages = pages;
            ViewBag.Page = page;
            ViewBag.Gender = plec;


            return View("Index");
        }


        public IActionResult Add()
        {
            var model = new PersonModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonModel personModel)
        {
            if(ModelState.IsValid)
            {

                if (!personModel.Picture.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("message", "Zdjęcie jest niepoprawne");
                }
                else
                {

                    var photosDir = Path.Combine(webHostEnvironment.WebRootPath, "photos");
                    var filename = Guid.NewGuid().ToString() + Path.GetExtension(personModel.Picture.FileName);

                    personModel.Picture.CopyTo(new FileStream(Path.Combine(photosDir, filename), FileMode.Create));



                    var person = new Person
                    {
                        FirstName = personModel.FirstName,
                        LastName = personModel.LastName,
                        Gender = personModel.Gender,
                        Age = personModel.Age,
                        Description = personModel.Description,
                        Picture = filename,
                        City = personModel.City
                    };

                    await dbContext.People.AddAsync(person);
                    await dbContext.SaveChangesAsync();


                    return RedirectToAction("Missing", new { page = (int)Math.Ceiling(((double)dbContext.People.Count() / 10)) });

                }


            }
            return View(personModel);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

}
