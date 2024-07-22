using Techcronus_Test.DataLayer;
using Techcronus_Test.ServiceLayer;

namespace Techcronus_Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddSingleton<INewsRepository, NewsRepository>();
            services.AddTransient<INewsService, NewsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseHttpsRedirection(); 
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
