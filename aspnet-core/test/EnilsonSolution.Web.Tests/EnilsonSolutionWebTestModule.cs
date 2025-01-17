using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EnilsonSolution.EntityFrameworkCore;
using EnilsonSolution.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EnilsonSolution.Web.Tests
{
    [DependsOn(
        typeof(EnilsonSolutionWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class EnilsonSolutionWebTestModule : AbpModule
    {
        public EnilsonSolutionWebTestModule(EnilsonSolutionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EnilsonSolutionWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(EnilsonSolutionWebMvcModule).Assembly);
        }
    }
}