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
    public class ApplicationUserRepository :GenericRepository<ApplicationUser>, IApplicationUserRepository
    {

        public ApplicationUserRepository(IUnitOfWork<ApplicationDbContext> unitOfWork):base(unitOfWork)
        {
                
        }

        public IQueryable<ApplicationUser> GetAsQueryable(ApplicationUserSearchCriteria criteria, string includeProperties = "")
        {
            var outerpredicate = PredicateBuilder.New<ApplicationUser>(true);

            var inner = PredicateBuilder.New<ApplicationUser>(true);
            if (!string.IsNullOrWhiteSpace(criteria.SearchText))
            {
                criteria.SearchText = criteria.SearchText.ToLower().Trim();
            }

            if (criteria.Id != null)
            {
                outerpredicate = outerpredicate.And(x => x.Id == criteria.Id.Value);
            }


            outerpredicate = outerpredicate.And(inner);
            return Get(outerpredicate, includeProperties: includeProperties);
        }
    }
}
