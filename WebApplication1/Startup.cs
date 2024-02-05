using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.mocks;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Repository;
using WebApplication1.Data.Models;


// This method gets called by the runtime. Use this method to add services to the container.
// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

namespace WebApplication1
{
    public class Startup
    {
        // ����� ���������� 
        private IConfigurationRoot _confString;

		// ����������� ��� ��������� ������ �� dbsettings.json 
		public Startup(IHostEnvironment hostEnv)
        {
            // ��� ������ �������� � �������� ���������� 
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}



        // ����������� � ����� ��������
		public void ConfigureServices(IServiceCollection services)
        {
            // ����������� ����
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            // ������ � ����� �� ���� �����������
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();

            // ������ ������� �������� ��� �������� � ���������
            services.AddSingleton<IHttpContextAccessor,  HttpContextAccessor>();

            // ������ �������� ������� ��� ������ ������� ��� ���� ������ ������
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
			services.AddMvc(options => options.EnableEndpointRouting = false);

            // ������ ��� ������������� ����
            services.AddMemoryCache();

            // ������ ��� ������������� ������ 
            services.AddSession();
		}


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // show error page
            app.UseDeveloperExceptionPage();

            // show status code, error codes
            app.UseStatusCodePages();

            // use static files (HTML, CSS)
            app.UseStaticFiles();

            // ��������� ��� ���������� ������
            app.UseSession();

			// use MVC
			app.UseMvcWithDefaultRoute();


			// ���������� ���� ������� 
			
			using (var scope = app.ApplicationServices.CreateScope())
			{
				AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
				DBObjects.Initial(content);
			}
			
		}
    }
}
