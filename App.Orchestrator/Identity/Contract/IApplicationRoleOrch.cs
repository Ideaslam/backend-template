using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Edura.Model.Support;

namespace Edura.Orchestrator.Identity.Contracts
{
    public interface IApplicationRoleOrch
    {
        void AssignRequestParams(RequestParams _requestParams);

    }
}