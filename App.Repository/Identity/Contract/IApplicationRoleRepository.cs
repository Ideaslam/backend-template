
using Edura.Data;
using Edura.Domain.Entity.Identity;
using Edura.Model.SearchCriterias.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Repository.Identity.Contracts
{
    public interface IApplicationRoleRepository : IGenericRepository<ApplicationRole>
    {
      IQueryable<ApplicationRole> GetAsQueryable(ApplicationRoleSearchCriteria criteria, string includeProperties = "");
    }
}
