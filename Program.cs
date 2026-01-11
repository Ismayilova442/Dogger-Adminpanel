using Microsoft.EntityFrameworkCore;
using WebApplication43.Data;

namespace WebApplication43
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DoggerDBContext>(options =>
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DoggerDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });
                
            var app = builder.Build();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}"
                );
            app.UseFileServer();
            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=Home}/{action=Index}"
                );

            app.Run();
        }
    }
}
