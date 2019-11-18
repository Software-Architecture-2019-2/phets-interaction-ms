using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace interaction_ms {
    public class Program {
        public static void Main(string[] args) {
            // var defaultAddress = Environment.GetEnvironmentVariable("DEFAULT_ADDRESS");
            var defaultAddress = "https://0.0.0.0:4005/";
            CreateWebHostBuilder(args, defaultAddress).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string defaultAddress) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(defaultAddress);
    }
}
