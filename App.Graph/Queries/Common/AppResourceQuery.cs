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
using Edura.Model.DTO.Common;
using Edura.Extentsons;

namespace Edura.Graph.Queries.Common
{
    public class AppResourceQuery : ObjectGraphType
    {
        private IAppResourceRepository appResourceRepository;
        private IAppResourceOrch  appResourceOrch;

        public AppResourceQuery(IAppResourceRepository _appResourceRepository, IAppResourceOrch _appResourceOrch)
        {
            appResourceRepository = _appResourceRepository;
            appResourceOrch = _appResourceOrch;

            Field<ListGraphType<AppResourceType>>(
              "AppResource",
              arguments: new AppResourceArguments(),
              resolve: context =>
              {
                  var criteria = context.Arguments.GetPropertyValue<AppResourceSearchCriteria>();
                  var props = GraphQLHelper.GetRequestedFields(context);
                  var appResources = appResourceRepository.GetAsQueryable(criteria).SelectProps<AppResource, AppResourceDTO>(props).ToList();

                  return appResources ;
              });

            
        }
    }
}
