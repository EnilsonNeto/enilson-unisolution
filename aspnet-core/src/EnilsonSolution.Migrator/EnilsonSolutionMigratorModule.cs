using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EnilsonSolution.Configuration;
using EnilsonSolution.EntityFrameworkCore;
using EnilsonSolution.Migrator.DependencyInjection;

namespace EnilsonSolution.Migrator
{
    [DependsOn(typeof(EnilsonSolutionEntityFrameworkModule))]
    public class EnilsonSolutionMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public EnilsonSolutionMigratorModule(EnilsonSolutionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(EnilsonSolutionMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                EnilsonSolutionConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EnilsonSolutionMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
