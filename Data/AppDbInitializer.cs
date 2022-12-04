using Microsoft.AspNetCore.Identity;
using Projet_2022.Data.Static;
using Projet_2022.Models.Entities;
using System.Diagnostics.Tracing;
using System.Xml.Linq;

namespace Projet_2022.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand() { Id="1",Name="Brand1",Description="Brand1Description",Logo="https://c.static-nike.com/a/images/w_1920,c_limit/mdbgldn6yg1gg88jomci/image.jpg" },
                        new Brand() { Id="2",Name="Brand2",Description="Brand2Description",Logo="data:image/png;base64,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"} 
                    });
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Id="1",
                            Name="Category1",
                            Slug="Category1Slug",
                            Description="Category1Description",
                            Image="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMUAAAEACAMAAAA0tEJxAAAAb1BMVEX///8AAADNzc1gYGBBQUH8/PwdHR2/v7/Hx8eqqqr4+Pijo6P19fXV1dXY2Njy8vLn5+fh4eHs7OyEhIQMDAx9fX2Li4uamppnZ2c0NDS6urqkpKRvb2/l5eUpKSlVVVVMTEw7OzssLCyUlJRHR0eNMZJmAAADCklEQVR4nO3di1LaQBiG4SV2Cw3ZUxRiKdSi3v81doPMYC2HgGK+OO87gpJhnP9hDTjRIcYQERERERERERERERER0fuz+bKY7mpi3xOdXzZU09+j1xV9z3RB6Xb0puEo7MuncvHw1jA0hXXLu/8NQ1IYW9x+30cYhsK2q1AulgcEA1Hk3bnZsy8MSlEuZnt3hUEoXp6RivmfkwJlhSld862TQE6xfUkw9fhp3Vkgp8hVrtn/kjAQRfCT5v58QK8Ku/sypMl0fn/oBU1ZYU0ZYho385v179NDqiqMffyA4ftXvOsnCAUKFChQoECBAgUKFChQoECBAsUnKj4S0d9x2snpip/yii51/gMGiquHQicUOqHQCYVOKHRCoRMKnVDohEInFDqh0AmFTih0QqETCp1Q6IRCJxQ6odAJhU4odEKhEwqdUOiEQicUOqHQCYVOKHRCoRMKnVDohEInFDqh0AmFTih0QqETCp1Q6IRCJxQ6odAJhU4odEKhEwqdUOiEQicUOn0NxbqrYtL3pMfq/K6Ji74nPVbns6786HvSY3U+8c2vvic9UuiKGD31PeqRYmfFvO9RjzTurFj2PeqRnjor1n2PejBrup1bb1PZ97QH890Rwk9SZyyF6GJYa+bnIEYP5p/zxIlUHjtx6b6eazlG3VzwRuEz99ljWjve36KZLZ/PF2x7XM6mi73fdnUdxsWTXtZ1nsQ+9r3lT3ed33pRoECBAgUKFChQoECBAgUKFChOKO6+hOL+5jN7GF8FIXZIlYiIiIiIiIiIiIg+Ltv+X619cyR4cMeFyxDydVXubltTt7AQ7Ot7VdKyUNTO2lC1i5LaK2eNz7fsJBRmY2vHD67eLNf2YrdrKFPpau9WPkxqbydlcrao0yo4XxXBpRhXfpVc6aL3lUvWudL4OqXa+1URU9+z76rawUzMD7w3rkxF5YzLU1a2yGsSfV2HlJ3WpyyMebMpTP4oUr6f73v2XSHP4m2sfelfHua8EimkuNke82qEzTaftyWTYhljrOOqTsFXQgpq+wthNkUm2RfOcQAAAABJRU5ErkJggg==",
                        },
                        new Category()
                        {
                            Id = "2",
                            Name="Category2",
                            Slug="Category2Slug",
                            Description="Category2Description",
                            Image="data:image/jpeg;base64,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",
                        },
                        new Category()
                        {
                            Id="3",
                            Name="Category2",
                            Slug="Category2Slug",
                            Description="Category2Description",
                            Image="data:image/png;base64,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"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    { new Product()
                    {
                        Id="1",
                        Sku="Product1Sku",
                        Name="Product1",
                        Slug="Product1Slug",
                        PrincipalImage="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMUAAAEACAMAAAA0tEJxAAAAb1BMVEX///8AAADNzc1gYGBBQUH8/PwdHR2/v7/Hx8eqqqr4+Pijo6P19fXV1dXY2Njy8vLn5+fh4eHs7OyEhIQMDAx9fX2Li4uamppnZ2c0NDS6urqkpKRvb2/l5eUpKSlVVVVMTEw7OzssLCyUlJRHR0eNMZJmAAADCklEQVR4nO3di1LaQBiG4SV2Cw3ZUxRiKdSi3v81doPMYC2HgGK+OO87gpJhnP9hDTjRIcYQERERERERERERERER0fuz+bKY7mpi3xOdXzZU09+j1xV9z3RB6Xb0puEo7MuncvHw1jA0hXXLu/8NQ1IYW9x+30cYhsK2q1AulgcEA1Hk3bnZsy8MSlEuZnt3hUEoXp6RivmfkwJlhSld862TQE6xfUkw9fhp3Vkgp8hVrtn/kjAQRfCT5v58QK8Ku/sypMl0fn/oBU1ZYU0ZYho385v179NDqiqMffyA4ftXvOsnCAUKFChQoECBAgUKFChQoECBAsUnKj4S0d9x2snpip/yii51/gMGiquHQicUOqHQCYVOKHRCoRMKnVDohEInFDqh0AmFTih0QqETCp1Q6IRCJxQ6odAJhU4odEKhEwqdUOiEQicUOqHQCYVOKHRCoRMKnVDohEInFDqh0AmFTih0QqETCp1Q6IRCJxQ6odAJhU4odEKhEwqdUOiEQicUOn0NxbqrYtL3pMfq/K6Ji74nPVbns6786HvSY3U+8c2vvic9UuiKGD31PeqRYmfFvO9RjzTurFj2PeqRnjor1n2PejBrup1bb1PZ97QH890Rwk9SZyyF6GJYa+bnIEYP5p/zxIlUHjtx6b6eazlG3VzwRuEz99ljWjve36KZLZ/PF2x7XM6mi73fdnUdxsWTXtZ1nsQ+9r3lT3ed33pRoECBAgUKFChQoECBAgUKFChOKO6+hOL+5jN7GF8FIXZIlYiIiIiIiIiIiIg+Ltv+X619cyR4cMeFyxDydVXubltTt7AQ7Ot7VdKyUNTO2lC1i5LaK2eNz7fsJBRmY2vHD67eLNf2YrdrKFPpau9WPkxqbydlcrao0yo4XxXBpRhXfpVc6aL3lUvWudL4OqXa+1URU9+z76rawUzMD7w3rkxF5YzLU1a2yGsSfV2HlJ3WpyyMebMpTP4oUr6f73v2XSHP4m2sfelfHua8EimkuNke82qEzTaftyWTYhljrOOqTsFXQgpq+wthNkUm2RfOcQAAAABJRU5ErkJggg==",
                        Description="Product1Description",
                        Ratings=10,
                        Price=1,
                        AddedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        DeletedAt=DateTime.Now,
                        TotalSales=0,
                        StockStatus=10,
                        IdBrand="1",
                        IdCategory="1",
                    },new Product()
                    {
                        Id="2",
                        Sku="Product2Sku",
                        Name="Product2",
                        Slug="Product2Slug",
                        PrincipalImage="data:image/jpeg;base64,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",
                        Ratings=10,
                        Price=2,
                        AddedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        DeletedAt=DateTime.Now,
                        TotalSales=0,
                        StockStatus=10,
                        IdBrand="1",
                        Description="Description2",
                        IdCategory="2",

                    },new Product()
                    {
                        Id="3",
                        Sku="Product3Sku",
                        Name="Product3",
                        Slug="Product3Slug",
                        PrincipalImage="data:image/png;base64,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",
                        Description="Product3Description",
                        Ratings=10,
                        Price=2,
                        AddedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        DeletedAt=DateTime.Now,
                        TotalSales=0,
                        StockStatus=10,
                        IdBrand="1",
                        IdCategory="2"
                    }}) ;
                    context.SaveChanges();
                }
                if (!context.OrderItems.Any())
                {
                    context.OrderItems.AddRange(
                    new OrderItem(){
                        Id="1",
                        Amount=3,
                        Price=3,
                        IdProduct="1",
                        IdOrder="1",
                    },
                    new OrderItem()
                    {
                        Id="2",
                        Amount=4,
                        Price=8,
                        IdProduct="2",
                        IdOrder="1"
                    });
                }
                if (!context.Orders.Any())
                {
                    context.AddRange(new List<Order>
                    {
                        new Order()
                        {
                            Id="1",
                            ShipAddress="moghrib",
                            City="Oran",
                            ZipCode="3000",
                            Tax=18/100,
                            Shipped=0,
                            TrackingNumber=33,
                            DateOfOrder=DateTime.Now,
                            Email="Order1@order.com",
                            Phone="123",
                            IdUser="1"
                        },
                        new Order()
                        {
                            Id="2",

                            ShipAddress="moghrib",
                            City="Casablanca",
                            ZipCode="4000",
                            Tax=18/100,
                            Shipped=0,
                            TrackingNumber=34,
                            DateOfOrder=DateTime.Now,
                            Email="Order1@order.com",
                            Phone ="123",
                            IdUser="1"
                        }
                    });
                    context.SaveChanges();
                }

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                #region roles
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
                if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Client));

                #endregion

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                #region user1
                string user1Email = "user1@p22.com";

                var user1= await userManager.FindByEmailAsync(user1Email);
                if (user1 == null)
                {
                    var newUser1 = new User()
                    {
                        Id = "1",
                        FirstName = "User1FirstName",
                        LastName = "User1LastName",
                        Email = user1Email,
                        City = "User1City",
                        Zipcode = "User1Zipcode",
                        EmailVerification = false,
                        Phone = "12345678",
                        UserName = user1Email,
                        Address="Moghrib"
                    };
                    await userManager.CreateAsync(newUser1,"User1123@");
                    await userManager.AddToRoleAsync(newUser1, UserRoles.Client);
                }
                #endregion

                #region admin
                string useradminemail = "useradmin@p22.com";

                var useradmin = await userManager.FindByEmailAsync(useradminemail);
                if (useradmin==null)
                {
                    var newUser2 = new User()
                    {
                        Id = "2",
                        FirstName = "UserAdminFirstName",
                        LastName = "UserAdminLastName",
                        Email = useradminemail,
                        City = "UserAdminCity",
                        Zipcode = "UserAdminZipCode",
                        EmailVerification = false,
                        Phone = "123456789",
                        UserName = useradminemail,
                        Address = "Moghrib"
                    };
                    await userManager.CreateAsync(newUser2, "Useradmin123@");
                    await userManager.AddToRoleAsync(newUser2, UserRoles.Admin);
                }
                #endregion
            }
        }
    }
}
