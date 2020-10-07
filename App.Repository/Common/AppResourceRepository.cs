using Edura.Data;
using Edura.Data.UnitOfWork;
using Edura.Domain.Entity.Common;
using Edura.Model.SearchCriteria.Common;
using Edura.Repository.Common.Contract;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using Edura.Model.DTO.Common;
using Edura.Extentsons;
namespace Edura.Repository.Common
{
    public class AppResourceRepository: GenericRepository<AppResource>, IAppResourceRepository
    {
        public AppResourceRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<AppResource> GetAsQueryable(AppResourceSearchCriteria criteria, string includeProperties = "")
        {
            var outerpredicate = PredicateBuilder.New<AppResource>(true);

            var inner = PredicateBuilder.New<AppResource>(true);
            if (!string.IsNullOrWhiteSpace(criteria.SearchText))
            {
                criteria.SearchText = criteria.SearchText.ToLower().Trim();

            }

            if (criteria.Id != null)
            {
                outerpredicate = outerpredicate.And(d => d.Id == criteria.Id.Value);
            }

        
            outerpredicate = outerpredicate.And(inner);

            return Get(outerpredicate, includeProperties: includeProperties);
        }

  
    }
}
