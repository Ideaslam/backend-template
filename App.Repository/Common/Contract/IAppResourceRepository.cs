using Edura.Data;
using Edura.Domain.Entity.Common;
using Edura.Model.DTO.Common;
using Edura.Model.SearchCriteria.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Repository.Common.Contract
{
    public interface IAppResourceRepository : IGenericRepository<AppResource>
    {
        IQueryable<AppResource> GetAsQueryable(AppResourceSearchCriteria criteria, string includeProperties = "");
  
       
    }
}
