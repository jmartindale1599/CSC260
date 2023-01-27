using Microsoft.AspNetCore.Mvc;

namespace Routing
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

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");


			app.MapControllerRoute(

				name: "Chicken",

				pattern: "EatMoreChicken",

				defaults: new { controller = "Home", action = "Chicken" });

			app.MapControllerRoute(

				name: "Default",

				pattern: "{moo}",

				defaults: new { controller = "Home", action = "Default" });

			app.MapControllerRoute(

				name: "CowName",

				pattern: "{times}/{name}",

				defaults: new { controller = "Home", action = "CowName" });

			app.MapControllerRoute(

				name: "Gallery",

				pattern: "AllCows/Gallery/{perpage}",

				defaults: new { controller = "Home", action = "Gallery" });

			app.MapControllerRoute(

				name: "Gallery2",

				pattern: "AllCows/Gallery2/{perpage}/{page}",

				defaults: new { controller = "Home", action = "Gallery2" });

			app.MapControllerRoute(

				name: "Gallery3",

				pattern: "AllCows/Gallery3/{cows}/page{page}",

				defaults: new { controller = "Home", action = "Gallery3" });

			app.MapControllerRoute(//catch all point back to home?

				name: "Catchall",

				pattern: "{*anything}",

				defaults: new { controller = "Home", action = "index" });

			app.Run();
		}
	}
}