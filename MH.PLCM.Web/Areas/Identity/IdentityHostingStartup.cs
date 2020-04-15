using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MH.PLCM.Areas.Identity.IdentityHostingStartup))]
namespace MH.PLCM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}