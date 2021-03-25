using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ScheduleWebApp.Areas.Identity.IdentityHostingStartup))]
namespace ScheduleWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                services.AddDbContext<dfkg9ojh16b4rdContext>(options =>
                {
                    options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection"));
                });

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<dfkg9ojh16b4rdContext>();
            });
        }
    }
}