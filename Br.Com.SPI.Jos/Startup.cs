using Br.Com.SPI.Core;
using Br.Com.SPI.Core.Models.DAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Common;
using System.Data.SqlClient;

namespace Br.Com.SPI.Jos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy("local", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddControllersWithViews();
            services.AddSwaggerGen();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            services.AddScoped<IMotivoN1DAO, MotivoN1DAOImpl>();
            services.AddScoped<IDTOMedicao, DTOMedicaoDAOImpl>();
            services.AddScoped<IPlanoInspecaoCabDAO, PlanoInspecaoCabDAOImpl>();
            services.AddScoped<IOrdemProducaoDAO, OrdemProducaoDAOImpl>();
            services.AddScoped<IConnectionDAO, ConnectionDAOImpl>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureSwagger();
            app.ConfigureExceptions(env);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseCors("local");
            app.ConfigureEndPoints();
            app.ConfigureSPA(env);
            app.ConfigureInternalSecrets(Configuration);
        }
    }

    public static class ServicesExtensions
    {

    }

    public static class ApplicationExtensions
    {
        public static void ConfigureExceptions(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
        }

        public static void ConfigureEndPoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }

        public static void ConfigureSPA(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(op =>
            {
                op.SwaggerEndpoint("/swagger/v1/swagger.json", "Test JOST App");
                op.RoutePrefix = "api/doc";
            });
        }

        public static void ConfigureInternalSecrets(this IApplicationBuilder app, IConfiguration config)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            SecurityConfig.GetInstance()
                .AddSqlServer(config["SqlConnection:Server"])
                .AddSqlUID(config["SqlConnection:uid"])
                .AddSqlPWD(config["SqlConnection:pwd"])
                .AddSqlDatabase(config["SqlConnection:database"])
                .AddSqlTimeout(config["SqlConnection:timeout"])
                .AddSqlProvider(config["SqlConnection:provider"]);
        }
    }
}
