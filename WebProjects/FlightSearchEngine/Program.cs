namespace FlightSearchEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to container
            builder.Services.AddControllersWithViews();

            // ✅ Register DatabaseHelper in Dependency Injection
            builder.Services.AddScoped<DatabaseHelper>();

            var app = builder.Build();

            // Middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Default Route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Flight}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
