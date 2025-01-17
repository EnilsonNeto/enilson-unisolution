using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EnilsonSolution.Authorization.Roles;
using EnilsonSolution.Authorization.Users;
using EnilsonSolution.MultiTenancy;

namespace EnilsonSolution.EntityFrameworkCore
{
    using Tanks;

    public class EnilsonSolutionDbContext : AbpZeroDbContext<Tenant, Role, User, EnilsonSolutionDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Tank> Tanks { get; set; }

        public EnilsonSolutionDbContext(DbContextOptions<EnilsonSolutionDbContext> options)
            : base(options)
        {
        }
    }
}
