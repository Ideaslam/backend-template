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
    public class DetailCodeRepository: GenericRepository<DetailCode>, IDetailCodeRepository
    {
        public DetailCodeRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<DetailCode> GetAsQueryable(DetailCodeSearchCriteria criteria, string includeProperties = "")
        {
            var outerpredicate = PredicateBuilder.New<DetailCode>(true);

            var inner = PredicateBuilder.New<DetailCode>(true);
            if (!string.IsNullOrWhiteSpace(criteria.SearchText))
            {
                criteria.SearchText = criteria.SearchText.ToLower().Trim();

            }

            if (criteria.Id != null)
            {
                outerpredicate = outerpredicate.And(d => d.Id == criteria.Id.Value);
            }

            if (criteria.MasterCodeId != null)
            {
                outerpredicate = outerpredicate.And(d => d.MasterCodeId == criteria.MasterCodeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(criteria.Code))
            {
                outerpredicate = outerpredicate.And(d => d.Code == criteria.Code);
            }
            if (!string.IsNullOrWhiteSpace(criteria.CountryCode))
            {
                outerpredicate = outerpredicate.And(d => d.FieldOneValue == criteria.CountryCode);
            }
            outerpredicate = outerpredicate.And(inner);

            return Get(outerpredicate, includeProperties: includeProperties);
        }

        public IEnumerable<CountryDTO> GetCountries(DetailCodeSearchCriteria criteria, string props ="")
        {
            criteria = criteria == null ? new DetailCodeSearchCriteria() : criteria;
            criteria.MasterCodeId = 1;
            var countries = GetAsQueryable(criteria).SelectProps<DetailCode,CountryDTO>(props);
            return countries.ToList();
        }
        
        public IEnumerable<CityDTO> GetCities(DetailCodeSearchCriteria criteria, string props = "")
        {
            criteria = criteria == null ? new DetailCodeSearchCriteria() : criteria;
            criteria.MasterCodeId = 2;
            var cities = GetAsQueryable(criteria).SelectProps<DetailCode, CityDTO>(props);
            //.Select("new (Id,Name,NameAr, new (ParentDetailCode.Id,ParentDetailCode.Name) as ParentDetailCode)")
            //.ToDynamicList();
            return cities.ToList();
        }

        public IEnumerable<DetailCode> GetAreas(DetailCodeSearchCriteria criteria)
        {
            criteria.MasterCodeId = 3;
            return GetAsQueryable(criteria).ToList();
        }
    }
}
