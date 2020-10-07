using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.SearchCriteria.Common
{
    public class DetailCodeSearchCriteria:BaseSearchCriteria
    {
        public int? MasterCodeId { get; set; }
        public string Code { get; set; }
        public string CountryCode { get; set; }
    }
}
