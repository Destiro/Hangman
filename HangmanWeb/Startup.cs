using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HangmanWeb
{
    public class Startup
    {
        public static Game Game;
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var game = new Game();
            services.AddSingleton(game);
            services.AddRazorPages(c=>c.RootDirectory = "/PagesRootDir");
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapGet("/", async context =>
                // {
                //     // await context.Response.WriteAsync("Hello! Welcome to le hangman game.\n"+
                //     //                                   "To play you need to find the hidden word, Take a turn by " +
                //     //                                   "guessing a letter and once\nthe word is found, you win the " +
                //     //                                   "game. But if you run out of lives, you lose the game.\n" +
                //     //                                   "<a href='/game'>Click Me!</a>");
                // });
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}