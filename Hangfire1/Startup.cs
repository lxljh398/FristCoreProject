using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire1
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
            services.AddHangfire(r => r.UseSqlServerStorage("Data Source=.;Initial Catalog=HangfireDemo;User ID=lixin;Password=123456"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            //app.Map("/index", r =>
            //{
            //    r.Run(context =>
            //    {
            //        //任务每分钟执行一次
            //        RecurringJob.AddOrUpdate(() => Console.WriteLine($"ASP.NET Core LineZero"), Cron.Minutely());
            //        return context.Response.WriteAsync("ok");
            //    });
            //});

            //app.Map("/one", r =>
            //{
            //    r.Run(context =>
            //    {
            //        //任务执行一次
            //        BackgroundJob.Enqueue(() => Console.WriteLine($"ASP.NET Core One Start LineZero{DateTime.Now}"));
            //        return context.Response.WriteAsync("ok");
            //    });
            //});

            //app.Map("/await", r =>
            //{
            //    r.Run(context =>
            //    {
            //        //任务延时两分钟执行
            //        BackgroundJob.Schedule(() => Console.WriteLine($"ASP.NET Core await LineZero{DateTime.Now}"), TimeSpan.FromMinutes(2));
            //        return context.Response.WriteAsync("ok");
            //    });
            //});


            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
            var jobId1 = BackgroundJob.Schedule(() => Console.WriteLine("Delayed!"), TimeSpan.FromDays(7));
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring!"), Cron.Daily);
            BackgroundJob.ContinueWith(jobId, () => Console.WriteLine("Continuation!"));


            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
