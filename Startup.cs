using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TigerGraphLib;

namespace TigergraphCoreAPI
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
            services.AddControllers();
            services.Configure<ConfigSettings>(o =>
            {
                o.TG_GSQL_SERVER_URL= Configuration.GetSection("ConfigurationSettings:TG_GSQL_SERVER_URL").Value;
                o.TG_REST_SERVER_URL = Configuration.GetSection("ConfigurationSettings:TG_REST_SERVER_URL").Value;
                o.TG_Token = Configuration.GetSection("ConfigurationSettings:TG_Token").Value;
                o.TG_USER = Configuration.GetSection("ConfigurationSettings:TG_USER").Value;
                o.TG_PSW = Configuration.GetSection("ConfigurationSettings:TG_PSW").Value;
            });
            ApiOptions apiOptions = new ApiOptions() { 
                GsqlServerUrl = Configuration.GetSection("ConfigurationSettings:TG_GSQL_SERVER_URL").Value,
                RestServerUrl = Configuration.GetSection("ConfigurationSettings:TG_REST_SERVER_URL").Value,
                Token = Configuration.GetSection("ConfigurationSettings:TG_Token").Value,
                User = Configuration.GetSection("ConfigurationSettings:TG_USER").Value,
                Pass = Configuration.GetSection("ConfigurationSettings:TG_PSW").Value,

            } ;
            
            services.AddSingleton<TgClient>(x=> new TgClient(apiOptions));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Get parameters
        static string GetToken(ApiOptions o)
        {
            var token = string.IsNullOrEmpty(o.Token) ? Environment.GetEnvironmentVariable("TG_TOKEN") : o.Token;
            if (string.IsNullOrEmpty(token))
            {
            }
            
            return token;
        }

        static string GetUser(ApiOptions o)
        {
            var user = string.IsNullOrEmpty(o.User) ? Environment.GetEnvironmentVariable("TG_USER") : o.User;
            if (string.IsNullOrEmpty(user))
            {
            }
            
            return user;
        }

        static string GetPass(ApiOptions o)
        {
            var pass = string.IsNullOrEmpty(o.GsqlServerUrl) ? Environment.GetEnvironmentVariable("TG_PASS") : o.Pass;
            if (string.IsNullOrEmpty(pass))
            {
            }
            
            return pass;
        }

        static Uri GetRestServerUrl(ApiOptions o)
        {
            var url = string.IsNullOrEmpty(o.RestServerUrl) ? Environment.GetEnvironmentVariable("TG_REST_SERVER_URL") : o.RestServerUrl;
            if (string.IsNullOrEmpty(url))
            {
               
                return null;
            }
            else if (!Uri.TryCreate(url, UriKind.Absolute, out Uri u))
            {
               
                return null;
            }
            else
            {
                
                return u;
            }
        }

        static Uri GetGsqlServerUrl(ApiOptions o)
        {
            var gurl = string.IsNullOrEmpty(o.GsqlServerUrl) ? Environment.GetEnvironmentVariable("TG_GSQL_SERVER_URL") : o.GsqlServerUrl;
            if (string.IsNullOrEmpty(gurl))
            {
                return null;
            }
            else if (!Uri.TryCreate(gurl, UriKind.Absolute, out Uri u))
            {
                return null;
            }
            else
            {
                return u;
            }
        }
        #endregion
    }
}
