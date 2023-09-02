using Discount.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Discount.Infrastructure.Extensions
{
    public static class DbExtensions
    {

        public static IHost MigrateDb<TContext>(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbConnFactoryHelper = services.GetRequiredService<DbConnFactoryHelper>();
            var logger = services.GetRequiredService<ILogger<TContext>>();
            try
            {
                logger.LogInformation("Discount Db Migration started");

                var conn = dbConnFactoryHelper.Create();
                conn.Open();
                var command = conn.CreateCommand();

                command.CommandText = "DROP TABLE IF EXISTS Coupon";
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY,
                                                                ProductName VARCHAR(500) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT)";
                command.ExecuteNonQuery();


                command.CommandText = @"
                                        INSERT INTO Coupon(ProductName, Description, Amount) 
                                          VALUES('Adidas Quick Force Indoor Badminton Shoes', 
                                                    'Designed for professional as well as amateur badminton players. These indoor shoes are crafted with synthetic upper that provides natural fit, while the EVA midsole provides lightweight cushioning. The shoes can be used for Badminton and Squash.', 
                                                    150);
                                       ";
                command.ExecuteNonQuery();


                command.CommandText = @"
                                        INSERT INTO Coupon(ProductName, Description, Amount) 
                                            VALUES('Asics Gel Rocket 8 Indoor Court Shoes', 
                                                    'The Asics Gel Rocket 8 Indoor Court Shoes (Orange/Silver) will keep you motivated and fired up to perform at your peak in volleyball, squash and other indoor sports. Beginner and intermediate players get cutting-edge technologies at an affordable price point.This entry level all-rounder has a durable upper and offers plenty of stability.', 
                                                    100);";
                command.ExecuteNonQuery();

                conn.Close();

                logger.LogInformation("Discount Db Migration completed");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the Discount Db");
            }
            return host;
        }
    }
}
