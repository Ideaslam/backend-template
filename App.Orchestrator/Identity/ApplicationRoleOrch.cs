using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Edura.Data.UnitOfWork;
using Edura.Data;
using Edura.Model.Support;

using Edura.Repository.Identity.Contracts;
using Edura.Orchestrator.Identity.Contracts;
namespace Edura.Orchestrator.Identity
{
    public class ApplicationRoleOrch : IApplicationRoleOrch
    {
        private RequestParams requestParams;

        private readonly IUnitOfWork<ApplicationDbContext> unitOfWork;
        private readonly IApplicationRoleRepository myRoleRepository;
        public readonly IApplicationUserRoleRepository applicationUserRoleRepository;

        public ApplicationRoleOrch(IUnitOfWork<ApplicationDbContext> _unitOfWork, IApplicationRoleRepository _myRoleRepository,
            IApplicationUserRoleRepository _applicationUserRoleRepository)
        {
            unitOfWork = _unitOfWork;
            myRoleRepository = _myRoleRepository;
            applicationUserRoleRepository= _applicationUserRoleRepository;
        }

        public void AssignRequestParams(RequestParams _requestParams)
        {
            requestParams = _requestParams;
        }

    }
}
