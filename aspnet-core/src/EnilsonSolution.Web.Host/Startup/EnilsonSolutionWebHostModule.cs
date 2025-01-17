using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EnilsonSolution.Configuration;

namespace EnilsonSolution.Web.Host.Startup
{
    [DependsOn(
       typeof(EnilsonSolutionWebCoreModule))]
    public class EnilsonSolutionWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EnilsonSolutionWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EnilsonSolutionWebHostModule).GetAssembly());
        }
    }
}
