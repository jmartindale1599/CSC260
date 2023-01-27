namespace Movies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseRouting();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute( 
                
                name: "pizzaRouteTest", 
                
                //pattern: "pizza", 
                
                //pattern: "pizza{id}", 
                
                pattern: "pizza/{id?}/{name}", 
                
                //pattern: "*RAGE", 

                defaults: new {Controller = "Home", action = "RouteTest"});

            app.MapControllerRoute(

                name: "Colors",

                pattern: "home/colors/{*colors}", 

                defaults: new { Controller = "Home", action = "Colors" });

            app.MapControllerRoute(

                name: "Catchall",

                pattern: "{*anything}",

                defaults: new { controller = "Home", action = "error" });

            app.Run();
        }
    }
}