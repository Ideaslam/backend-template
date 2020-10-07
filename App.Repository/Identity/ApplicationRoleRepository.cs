using Edura.Data;
using Edura.Data.UnitOfWork;
using Edura.Domain.Entity.Identity;
using Edura.Model.SearchCriterias.Identity;
using Edura.Repository.Identity.Contracts;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Repository.Identity
{
    public class ApplicationRoleRepository :GenericRepository<ApplicationRole>, IApplicationRoleRepository
    {

        public ApplicationRoleRepository(IUnitOfWork<ApplicationDbContext> unitOfWork):base(unitOfWork)
        {
                
        }

        public IQueryable<ApplicationRole> GetAsQueryable(ApplicationRoleSearchCriteria criteria, string includeProperties = "")
        {
            var predicate = PredicateBuilder.New<ApplicationRole>(true);

            if (criteria.Id != null)
            {
                predicate = predicate.And(x => x.Id == criteria.Id);
            }

            if (!string.IsNullOrWhiteSpace(criteria.Name))
            {
                predicate = predicate.And(x => x.Name.Contains(criteria.Name));
            }

            return Get(predicate, includeProperties: includeProperties);

        }
    }
}
