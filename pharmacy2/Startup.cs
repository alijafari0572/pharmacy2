using System;
using BE;
using DAL;
using IdentitySample.Security.PhoneTotp;
using IdentitySample.Security.PhoneTotp.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersianTranslation.Identity;
using pharmacy2.Repositories;

namespace pharmacy2
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
            services.AddDbContext<DB>(a => a.UseSqlServer(Configuration.GetConnectionString("CON1")));
            services.AddControllersWithViews();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddAuthentication()
                .AddGoogle(option =>
                {
                    option.ClientId = "1057646773398-qpdr8527ts9u1p1ej7tno32rqckgr835.apps.googleusercontent.com";
                    option.ClientSecret = "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";
                });
            services.AddIdentity<User, Role>(Option =>
                {
                    //configure identity options
                    Option.Password.RequireDigit = false;
                    Option.Password.RequireLowercase = false;
                    Option.Password.RequireUppercase = false;
                    Option.Password.RequireNonAlphanumeric = false;
                    Option.Password.RequiredUniqueChars = 0;
                    Option.Password.RequiredLength = 4;
                    Option.User.RequireUniqueEmail = true;
                    Option.SignIn.RequireConfirmedPhoneNumber = false;
                })
                .AddUserManager<UserManager<User>>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<DB>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<PersianIdentityErrorDescriber>();
            services.AddScoped<IMessageSender, MessageSender>();
            services.AddTransient<IPhoneTotpProvider, PhoneTotpProvider>();
            services.Configure<PhoneTotpOptions>(options =>
            {
                options.StepInSeconds = 60;
            });
            services.ConfigureApplicationCookie(Options =>
            {
                Options.AccessDeniedPath = "/Account/AccessDenied";
                Options.Cookie.Name = "WebAppIdentityCookie";
                Options.Cookie.HttpOnly = true;
                Options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                Options.LoginPath = "/Account/Login";
                Options.SlidingExpiration = true;
            });
            services.AddSession(option =>
            {
                option.IdleTimeout=TimeSpan.FromMinutes(60);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                ////app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}