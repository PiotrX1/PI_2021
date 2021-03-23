using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PI_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI_2021.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<IdentityUser>();


            string RoleId = Guid.NewGuid().ToString();
            string UserId = Guid.NewGuid().ToString();


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = RoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });


            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = UserId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
                EmailConfirmed = true
            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = RoleId,
                UserId = UserId
            });

            List<Person> SampleData = new List<Person>();
            for(int i = 0; i < 35; i++)
            {
                SampleData.Add(new Person
                {
                    PersonID = i+1,
                    FirstName = "Imie",
                    LastName = "Nazwisko",
                    Gender = 'K',
                    Age = 25,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.",
                    Picture = "sample.jpg",
                    City = "Warszawa"
                }); ;
            }


            builder.Entity<Person>().HasData(SampleData);




        }

    }
}
