using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EnilsonSolution.Authorization;

namespace EnilsonSolution
{
    [DependsOn(
        typeof(EnilsonSolutionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EnilsonSolutionApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EnilsonSolutionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EnilsonSolutionApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
