using Edura.Domain.Entity.Common;
using Edura.Model.DTO.Common;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Graph.Types.Common
{
    public class CountryType: ObjectGraphType<CountryDTO>
    {
        public CountryType()
        {
            Name = "Country";
            Field(x => x.Id,  type: typeof(IdGraphType)) ;
            Field(x => x.Code, nullable:true);
            Field(x => x.CountryCode, nullable:true);
            Field(x => x.Name);
            Field(x => x.NameAr);
            Field(x => x.Description, nullable: true);
            Field(x => x.DescriptionAr, nullable: true);
            Field(x => x.Cities, type: typeof(ListGraphType < CityType >), nullable: true);
           // Field<>(
           //    "Cities",
           //    resolve: ctx => ctx.Source.Cities
           //);            
        }
    }
}
