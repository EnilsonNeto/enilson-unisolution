using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EnilsonSolution.EntityFrameworkCore
{
    public static class EnilsonSolutionDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EnilsonSolutionDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EnilsonSolutionDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
