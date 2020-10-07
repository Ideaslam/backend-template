using Edura.Data;
using Edura.Data.UnitOfWork;
using Edura.Domain.Entity.Identity;
using Edura.Repository.Identity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Repository.Identity
{
    public class ApplicationUserRoleRepository :GenericRepository<ApplicationUserRole>, IApplicationUserRoleRepository
    {

        public ApplicationUserRoleRepository(IUnitOfWork<ApplicationDbContext> unitOfWork):base(unitOfWork)
        {
                
        }
         
    }
}
