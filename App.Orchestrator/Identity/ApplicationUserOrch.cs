using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Edura.Data.UnitOfWork;
using Edura.Data;
using Edura.Model.Support;
using LinqKit;

using Edura.Repository.Identity.Contracts;
using Edura.Orchestrator.Identity.Contracts;

using Microsoft.Extensions.Options;
using Edura.Repository.Identity;
using Edura.Domain.Entity.Identity;

namespace Edura.Orchestrator.Identity
{
    public class ApplicationUserOrch : IApplicationUserOrch
    {
        private RequestParams requestParams;
        private readonly AppConfig appSettings;

        private readonly IUnitOfWork<ApplicationDbContext> unitOfWork;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly ApplicationUserManager applicationUserManager;
        private readonly IApplicationRoleRepository applicationRoleRepository;

        public ApplicationUserOrch(IUnitOfWork<ApplicationDbContext> _unitOfWork, IApplicationUserRepository _applicationUserRepository, 
            IOptions<AppConfig> _appSettings, ApplicationUserManager _applicationUserManager,
            IApplicationRoleRepository _applicationRoleRepository
            )
        {
            unitOfWork = _unitOfWork;
            applicationUserRepository = _applicationUserRepository;
            applicationUserManager = _applicationUserManager;
            appSettings = _appSettings.Value;
            applicationRoleRepository = _applicationRoleRepository;
           

        }
        public void AssignRequestParams(RequestParams _requestParams)
        {
            requestParams = _requestParams;
        }

        public IEnumerable<ApplicationUser> Get()
        {
            return applicationUserRepository.Get().ToList();
        }


    }
}
