using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PI_2021.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Gender = table.Column<char>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f62d2ac-781b-483e-b9b8-4d2e3d148a88", "a6b534ba-6aa7-4a2b-86dc-6899b80bf947", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1678e85f-dbf8-499a-8ee3-9d1ba87d8e03", 0, "5b6f8e03-03ee-4731-9911-d161b35bb974", null, true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEE4jhZijduz6WcIziS40yYByUMECFCOvw131uzXslCAiKyiFsgG9vAsB/ejWbr6Qzg==", null, false, "111e4a54-d769-4ccd-8f9f-17afaba7e508", false, "Admin" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 20, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 21, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 22, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 23, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 24, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 25, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 26, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 27, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 28, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 29, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 30, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 31, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 32, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 33, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 19, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 18, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 17, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 16, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 1, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 2, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 3, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 4, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 5, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 6, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 7, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 8, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 9, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 10, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 11, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 12, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 13, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 14, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 15, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 34, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Age", "City", "Description", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[] { 35, 25, "Warszawa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nisl massa, vestibulum euismod magna non, iaculis rutrum quam. Donec eget feugiat libero, vitae consectetur ante. Morbi pretium efficitur felis ac rutrum. Curabitur interdum viverra augue, vitae eleifend lorem tristique sit amet. Donec aliquet pretium magna, fermentum consequat orci consequat nec. Sed a velit non libero mollis vehicula in ac orci. Mauris vel velit finibus, lacinia urna vestibulum, scelerisque elit. Donec at odio ipsum. Maecenas vehicula quam ut leo efficitur, quis ornare tortor posuere. Nam suscipit dapibus pretium.", "Imie", 'K', "Nazwisko", "sample.jpg" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7f62d2ac-781b-483e-b9b8-4d2e3d148a88", "1678e85f-dbf8-499a-8ee3-9d1ba87d8e03" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
