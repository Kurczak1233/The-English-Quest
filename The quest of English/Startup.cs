using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using The_quest_of_English.Controllers;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories;
using TheEnglishQuestDatabase.Repositories.Interfaces;
using TheQuestOfEnglishDatabase;

namespace The_quest_of_English
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=FLUTTERSHY\\SQLEXPRESS;Database=TheQuestOfEnglish;Trusted_Connection=True;"));
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            //Db
            services.AddTransient<IEncouragementPositionRepository, EncouragementPositionRepository>();
            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddTransient<ISampleTestQARepostitory, SampleTestQARepository>();
            //Mapper
            services.AddTransient<DTOMapper<ApplicationUser, ApplicationUserDto>>();
            services.AddTransient<DTOMapper<EncouragementPosition, EncouragementPositionDto>>();
            services.AddTransient<DTOMapper<SampleTestQA, SampleTestQADto>>();
            services.AddTransient<ApplicationUserManager>();
            services.AddTransient<EncouragementPostitionManager>();
            services.AddTransient<SampleTestQAManager>();
            //Main ViewModel
            services.AddTransient<EncouragementPoisitonViewModelMapper>();
            services.AddTransient<ApplicationUserViewModelMapper>();
            services.AddTransient<SampleTestQAViewModelMapper>();
            // Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddDefaultTokenProviders() //Tokeny gdy kto� zapomni has�a
            .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        }
    }
}
