using Edura.Data;
using Edura.Domain.Entity.Identity;
using Edura.Model.SearchCriterias.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Repository.Identity.Contracts
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        IQueryable<ApplicationUser> GetAsQueryable(ApplicationUserSearchCriteria criteria, string includeProperties = "");
    }
}
