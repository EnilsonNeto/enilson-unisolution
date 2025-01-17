using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using EnilsonSolution.Configuration;
using EnilsonSolution.Web;

namespace EnilsonSolution.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class EnilsonSolutionDbContextFactory : IDesignTimeDbContextFactory<EnilsonSolutionDbContext>
    {
        public EnilsonSolutionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EnilsonSolutionDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            EnilsonSolutionDbContextConfigurer.Configure(builder, configuration.GetConnectionString(EnilsonSolutionConsts.ConnectionStringName));

            return new EnilsonSolutionDbContext(builder.Options);
        }
    }
}
