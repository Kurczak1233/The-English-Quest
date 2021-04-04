using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using The_quest_of_English.ViewModelMapper;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories;
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=FLUTTERSHY\\SQLEXPRESS;Database=TheQuestOfEnglishTest;Trusted_Connection=True;"));
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            //Db
            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddTransient<IPlacementTestTaskRepository, PlacementTestTaskRepository>();
            services.AddTransient<IGrammarQuizRepository, GrammarQuizRepository>();
            services.AddTransient<IGrammarTaskRepository, GrammarTaskRepository>();
            services.AddTransient<IReadingQuizRepository, ReadingQuizRepository>();
            services.AddTransient<IReadingTaskRepository, ReadingTaskRepository>();
            services.AddTransient<IListeningQuizRepository, ListeningQuizRepository>();
            services.AddTransient<IListeningTaskRepository, ListeningTaskRepository>();
            services.AddTransient<IWritingTaskRepository, WritingTaskRepository>();
            services.AddTransient<IWritingQuizRepository, WritingQuizRepository>();
            services.AddTransient<ISpeakingTaskRepository, SpeakingTaskRepository>();
            services.AddTransient<ISpeakingQuizRepository, SpeakingQuizRepository>();
            //Mapper
            services.AddTransient<DTOMapper<ApplicationUser, ApplicationUserDto>>();
            services.AddTransient<DTOMapper<PlacementTestTask, PlacementTestTaskDTO>>();
            services.AddTransient<GrammarQuizMapper>();
            services.AddTransient<DTOMapper<GrammarTask, GrammarTaskDto>>();
            services.AddTransient<ApplicationUserManager>();
            services.AddTransient<PlacementTestTaskManager>();
            services.AddTransient<GrammarTaskManager>();
            services.AddTransient<GrammarQuizManager>();
            //Reading mappers
            services.AddTransient<ReadingTaskManager>();
            services.AddTransient<ReadingQuizManager>();
            services.AddTransient<ReadingQuizMapper>();
            services.AddTransient<DTOMapper<ReadingTask, ReadingTaskDto>>();
            //Listening mappers
            services.AddTransient<ListeningTaskManager>();
            services.AddTransient<ListeningQuizManager>();
            services.AddTransient<ListeningQuizMapper>();
            services.AddTransient<DTOMapper<ListeningTask, ListeningTaskDto>>();
            //writing mappers
            services.AddTransient<WritingTaskManager>();
            services.AddTransient<WritingQuizManager>();
            services.AddTransient<WritingQuizMapper>();
            services.AddTransient<DTOMapper<WritingTask, WritingTaskDto>>();
            //speaking mappers
            services.AddTransient<SpeakingTaskManager>();
            services.AddTransient<SpeakingQuizManager>();
            services.AddTransient<SpeakingQuizMapper>();
            services.AddTransient<DTOMapper<SpeakingTask, SpeakingTaskDto>>();

            //Main ViewModel
            services.AddTransient<ApplicationUserViewModelMapper>();
            services.AddTransient<PlacementTestTaskViewModelMapper>();
            services.AddTransient<GrammarTaskViewModelMapper>();
            services.AddTransient<GrammarQuizViewModelMapper>();
            services.AddTransient<ReadingTaskViewModelMapper>();
            services.AddTransient<ReadingQuizViewModelMapper>();
            services.AddTransient<ListeningTaskViewModelMapper>();
            services.AddTransient<ListeningQuizViewModelMapper>();
            services.AddTransient<WritingTaskViewModelMapper>();
            services.AddTransient<WritingQuizViewModelMapper>();
            services.AddTransient<SpeakingTaskViewModelMapper>();
            services.AddTransient<SpeakingQuizViewModelMapper>();
            services.AddTransient<IDbInitializer, DbInitializer>();
            // Identity
            //services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddDefaultTokenProviders() //Tokens in case somebody forget their password
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;

                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IDbInitializer dbInitializer)
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
            dbInitializer.Initialize();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Unregistered}/{controller=Home}/{action=Index}");
            });

            serviceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        }
    }
}
