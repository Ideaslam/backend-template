using Edura.Domain.Entity.Common;
using Edura.Model.DTO.Common;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Graph.Types.Common
{
    public class CityType: ObjectGraphType<CityDTO>
    {
        public CityType()
        {
            Name = "City";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Code, nullable: true);
            Field(x => x.Name);
            Field(x => x.NameAr);
            Field(x => x.Description, nullable: true);
            Field(x => x.DescriptionAr, nullable: true);
            Field<ListGraphType<AreaType>>(
              "Areas",
              resolve: ctx => ctx.Source.Areas
          );
            Field<CountryType>(
              "Country",
              resolve: ctx => ctx.Source.Country
          );
        }

    }
}
