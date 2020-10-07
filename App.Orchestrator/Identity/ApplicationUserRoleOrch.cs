using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Edura.Data.UnitOfWork;
using Edura.Data;
using Edura.Model.Support;
using LinqKit;
using Edura.Domain.Entity.Identity;
using Edura.Model.SearchCriterias.Identity;
using Edura.Repository.Identity.Contracts;
using Edura.Orchestrator.Identity.Contracts;
namespace Edura.Orchestrator.Identity
{
    public class ApplicationUserRoleOrch : IApplicationUserRoleOrch
    {
        private RequestParams requestParams;

        private IUnitOfWork<ApplicationDbContext> unitOfWork;
        private readonly IApplicationUserRoleRepository applicationUserRoleRepository;

        public ApplicationUserRoleOrch(IUnitOfWork<ApplicationDbContext> _unitOfWork, IApplicationUserRoleRepository _applicationUserRoleRepository)
        {
            unitOfWork = _unitOfWork;
            applicationUserRoleRepository = _applicationUserRoleRepository;
        }

        public void AssignRequestParams(RequestParams _requestParams)
        {
            requestParams = _requestParams;
        }

    }
}
