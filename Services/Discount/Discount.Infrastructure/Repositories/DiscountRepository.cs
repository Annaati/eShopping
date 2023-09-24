using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _config;
        public DiscountRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            await using var conn = new NpgsqlConnection(_config.GetValue<string>("DatabaseSettings:ConnectionString"));

            var query = @"
                            SELECT * FROM Coupon WHERE ProductName=@ProductName;
                         ";

            var coupon = await conn.QueryFirstOrDefaultAsync<Coupon>(query, new { productName });

            if(coupon == null)
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount available" };

            return coupon;
        }



        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            await using var conn = new NpgsqlConnection(_config.GetValue<string>("DatabaseSettings:ConnectionString"));

            var query = @"
                            INSERT INTO Coupon (ProductName, Description, Amount) 
                                VALUES (@ProductName, @Description, @Amount);
                         ";

            var result = await conn.ExecuteAsync(query, coupon);

            return result > 0; 
        }



        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            await using var conn = new NpgsqlConnection(_config.GetValue<string>("DatabaseSettings:ConnectionString"));

            var query = @"
                            Update Coupon SET
                                    ProductName = @ProductName,
                                    Description = @Description,
                                    Amount = @Amount
                            WHERE Id = @Id;
                        ";

            var result = await conn.ExecuteAsync(query, coupon);

            return result > 0;
        }



        public async Task<bool> DeleteDiscount(string productName)
        {
            await using var conn = new NpgsqlConnection(_config.GetValue<string>("DatabaseSettings:ConnectionString"));

            var query = @"
                            DELETE FROM Coupon WHERE ProductName=@ProductName;
                        ";

            var result = await conn.ExecuteAsync(query, new { productName });

            return result > 0;
        }

       

        

    }
}
