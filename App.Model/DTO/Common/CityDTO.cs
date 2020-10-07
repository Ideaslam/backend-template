using Edura.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.DTO.Common
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        [MapTo("ChildDetailCodes")]
        public List<AreaDTO> Areas { get; set; }
        [MapTo("ParentDetailCode")]
        public CountryDTO Country { get; set; }
    }
}
