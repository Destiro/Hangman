using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static Microsoft.AspNetCore.Mvc.Razor.RazorPage;

namespace HangmanWeb
{
    public class HangmanWeb
    
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // public void WriteToHTML(ArrayList lines)
        // {
        //     string[] output = new string[4+lines.Count];
        //     output[0] = "<html>";
        //     output[1] = "<body>";
        //
        //     int index = 2;
        //     foreach (var line in lines)
        //     {
        //         output[index] = "\n<p>" + line + "</p>";
        //         index++;
        //     }
        //
        //     output[index+1] = "\n</body>";
        //     output[index+2] = "\n<html>";
        //
        //     OutputLines = output;
        // }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}