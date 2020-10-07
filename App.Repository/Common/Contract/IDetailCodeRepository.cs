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
    public interface IDetailCodeRepository : IGenericRepository<DetailCode>
    {
        IQueryable<DetailCode> GetAsQueryable(DetailCodeSearchCriteria criteria, string includeProperties = "");
        IEnumerable<CountryDTO> GetCountries(DetailCodeSearchCriteria criteria, string props = "" );
        IEnumerable<CityDTO> GetCities(DetailCodeSearchCriteria criteria, string props = "");
        IEnumerable<DetailCode> GetAreas(DetailCodeSearchCriteria criteria);
       
    }
}
