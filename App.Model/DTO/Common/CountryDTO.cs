using Edura.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Model.DTO.Common
{
    public class CountryDTO
    {
       
        public int Id { get; set; }
        public string Code { get; set; }
        [MapTo("FieldFourValue")]
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        [MapTo("ChildDetailCodes")]
        public List<CityDTO> Cities { get; set; }

    }
}
