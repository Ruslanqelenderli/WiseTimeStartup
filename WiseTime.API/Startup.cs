using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseTime.Business.Abstract;
using WiseTime.Business.AutoMapper;
using WiseTime.Business.Concrete.Manager;
using WiseTime.Data.Abstract;
using WiseTime.Data.Concrete.EntityFramework.Context;
using WiseTime.Data.Concrete.EntityFramework.Repository;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.API
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
            services.AddAutoMapper(typeof(ProgramProfile));
            services.AddScoped<IUserProjectService, UserProjectManager>();
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddDbContext<WiseTimeDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Manage/Login/";
                options.SlidingExpiration = true;
            });
            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
               
            })
            .AddEntityFrameworkStores<WiseTimeDbContext>()
            .AddDefaultTokenProviders();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WiseTime.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WiseTime.API v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
