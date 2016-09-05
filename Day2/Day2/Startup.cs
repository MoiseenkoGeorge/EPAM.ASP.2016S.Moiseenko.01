using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day2.Startup))]
namespace Day2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
