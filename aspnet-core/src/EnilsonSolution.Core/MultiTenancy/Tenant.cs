﻿using Abp.MultiTenancy;
using EnilsonSolution.Authorization.Users;

namespace EnilsonSolution.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
