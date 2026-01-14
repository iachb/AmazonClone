using Ecommerce.Application.Models.Authorization;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.Infrastructure.Persistence
{
    public class EcommerceDbContextData
    {
        public static async Task LoadDataAsync(
            EcommerceDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerFactory loggerFactory,
            IConfiguration configuration
            )
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(Role.USER));
                }

                if(!userManager.Users.Any())
                {
                    var adminUser = new User 
                    { 
                        Name = "Ivan" ,
                        Surname = "Chavez",
                        Email = "ivanchavezbrb@gmail.com",
                        UserName = "iachb",
                        PhoneNumber = "1234567890",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24"
                    };
                    
                    await userManager.CreateAsync(adminUser, configuration["IdentityRole:AdminPassword"]!);
                    await userManager.AddToRoleAsync(adminUser, Role.ADMIN);

                    var user = new User 
                    { 
                        Name = "John" ,
                        Surname = "Doe",
                        Email = "johndoe@gmail.com",
                        UserName = "john.doe",
                        PhoneNumber = "1234567899",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
                    };

                    await userManager.CreateAsync(user, configuration["IdentityRole:UserPassword"]!);
                    await userManager.AddToRoleAsync(user, Role.USER);

                    if (!context.Categories!.Any())
                    {
                        var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                        var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                        await context.Categories!.AddRangeAsync(categories!);
                        await context.SaveChangesAsync();
                    }

                    if (!context.Products!.Any())
                    {
                        var productData = File.ReadAllText("../Infrastructure/Data/product.json");
                        var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                        await context.Products!.AddRangeAsync(products!);
                        await context.SaveChangesAsync();
                    }

                    if (!context.Images!.Any())
                    {
                        var imagesData = File.ReadAllText("../Infrastructure/Data/image.json");
                        var images = JsonConvert.DeserializeObject<List<Image>>(imagesData);
                        await context.Images!.AddRangeAsync(images!);
                        await context.SaveChangesAsync();
                    }

                    if (!context.Reviews!.Any())
                    {
                        var reviewsData = File.ReadAllText("../Infrastructure/Data/review.json");
                        var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewsData);
                        await context.Reviews!.AddRangeAsync(reviews!);
                        await context.SaveChangesAsync();
                    }

                    if (!context.Countries!.Any())
                    {
                        var countriesData = File.ReadAllText("../Infrastructure/Data/countries.json");
                        var countries = JsonConvert.DeserializeObject<List<Country>>(countriesData);
                        await context.Countries!.AddRangeAsync(countries!);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
                logger.LogError(ex.Message);
            }
        }
    }
}
