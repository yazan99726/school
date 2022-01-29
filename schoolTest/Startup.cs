using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using schoolTest.Models;
using schoolTest.Models.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest
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
            services.AddControllersWithViews();
            services.AddMvc();
            
            services.AddScoped<ISchoolRepository<Student>, StudentDbRepository>();
            services.AddScoped<ISchoolRepository<Teacher>, TeacherDbRepository>();
            services.AddScoped<ISchoolRepository<Course>, CourseDbRepository>();
            services.AddScoped<ISchoolRepository<Marks>, MarksDbRepository>();
            services.AddScoped<ISchoolRepository<Enrollment>, EnrollmentDbRepository>();
            services.AddScoped<ISchoolRepository<LoginAll>, LoginAllDbRepository>();
            services.AddScoped<ISchoolRepository<News>,NewsDbRepository>();

            services.AddDbContext<schoolTestDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
            });
            services.AddSession();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(route =>
            {
                route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
