namespace Basket.API
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CreateHotstBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHotstBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}