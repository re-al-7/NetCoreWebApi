using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Integrate.SisMed.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Build a customized MVC implementation, without using the default AddMvc(), instead use AddMvcCore().
            // https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs

            services
                .AddMvcCore(options =>
                {
                    options.RequireHttpsPermanent = true; // does not affect api requests
                    options.RespectBrowserAcceptHeader = true; // false by default
                    //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();

                    //remove these two below, but added so you know where to place them...
                    //options.OutputFormatters.Add(new YourCustomOutputFormatter());
                    //options.InputFormatters.Add(new YourCustomInputFormatter());
                })
                //.AddApiExplorer()
                //.AddAuthorization()
                .AddFormatterMappings()
                //.AddCacheTagHelper()
                //.AddDataAnnotations()
                //.AddCors()
                .AddJsonFormatters(); // JSON, or you can build your own custom one (above)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
