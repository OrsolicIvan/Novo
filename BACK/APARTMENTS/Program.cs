using APARTMENTS.Models;
using APARTMENTS.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APARTMENTS
{
    public class Program
    {


        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;



            //Dodavanje usermanagera i rolemangare iz IDENTITY
            
            var context = services.GetRequiredService<Context>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            await context.Database.MigrateAsync();
            await Seed.SeedUsers( roleManager);
            await host.RunAsync();
        }
        
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(WebHostBuilderOptions =>
            {
            WebHostBuilderOptions.UseStartup<Startup>();
            });
            
    }
}
