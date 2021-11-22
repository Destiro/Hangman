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
        private HangmanGamemode _lastGame;
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            if(_lastGame == null)
                _lastGame = new HangmanGamemode(true);
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    HangmanGamemode newGame = new HangmanGamemode(_lastGame, () => Configure(app, env));
                    _lastGame = newGame;
                    foreach(var line in _lastGame.WebLines)
                        await context.Response.WriteAsync("<p>"+line+"</p>");
                });
            });
        }
    }
}