using ABM.ServiceLayer.Implementation;
using ABM.ServiceLayer.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ABM.WebApi
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
            services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddScoped<IXmlOperations, XmlOperations>();
            services.AddScoped<IXmlParse, XmlParse>();
            services.AddScoped<IXmlValidation, XmlValidation>();
            services.AddCors(options => options.AddPolicy("AllowXmlClient", policy => policy.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowXmlClient");
            if (env.EnvironmentName != "Testing") app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
