using Edura.Domain.Entity.Common;
using Edura.Graph.Arguments.Common;
using Edura.Graph.Types.Common;
using Edura.Model.SearchCriteria.Common;
using Edura.Orchestrator.Common.Contract;
using Edura.Repository.Common.Contract;
using GraphQL;
using GraphQL.Types;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Edura.Utils.Helpers;

namespace Edura.Graph.Queries.Common
{
    public class DetailCodeQuery : ObjectGraphType
    {
        private IDetailCodeRepository detailCodeRepository;
        private IDetailCodeOrch detailCodeOrch;

        public DetailCodeQuery(IDetailCodeRepository _detailCodeRepository, IDetailCodeOrch _detailCodeOrch)
        {
            detailCodeRepository = _detailCodeRepository;
            detailCodeOrch = _detailCodeOrch;

            Field<ListGraphType<CountryType>>(
              "Countries",
              arguments: new CountryArguments(),
              resolve: context =>
              {
                  var criteria = context.Arguments.GetPropertyValue<DetailCodeSearchCriteria>();
                  var props = GraphQLHelper.GetRequestedFields(context);
                  var countries = detailCodeRepository.GetCountries(criteria, props);
                    return countries;
              });

            Field<ListGraphType<CityType>>(
             "Cities",
             arguments: new CityArguments(),
             resolve: context =>
             {
                 var criteria = context.Arguments.GetPropertyValue<DetailCodeSearchCriteria>();
                 var props = GraphQLHelper.GetRequestedFields(context);
                 var cities = detailCodeRepository.GetCities(criteria,props);
                 return cities;
             });
        }
    }
}
