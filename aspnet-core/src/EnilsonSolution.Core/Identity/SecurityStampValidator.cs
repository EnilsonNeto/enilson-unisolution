using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using EnilsonSolution.Authorization.Roles;
using EnilsonSolution.Authorization.Users;
using EnilsonSolution.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace EnilsonSolution.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock)
            : base(options, signInManager, systemClock)
        {
        }
    }
}
