using Edura.Data;
using Edura.Data.UnitOfWork;
using Edura.Domain.Entity.Identity;
using Edura.Model.Support;
using Edura.Orchestrator.Identity;
using Edura.Repository.Identity;
using Edura.Repository.Identity.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Edura.Orchestrator.Tests
{
    public static class MockInitializer
    {
        private static Mock<IUserStore<ApplicationUser>> store;

        private static ApplicationUserManager applicationUserManager;


        private static IUnitOfWork<ApplicationDbContext> unitOfWork;
        private static IOptions<AppConfig> appConfigOptions;
        private static IApplicationUserRepository applicationUserRepository;
        private static IApplicationRoleRepository applicationRoleRepository;

        private static ApplicationUserOrch applicationUserOrch;


        public static ApplicationUserManager GetApplicationUserManager()
        {
            store = new Mock<IUserStore<ApplicationUser>>();
            var applicationUserManager = new ApplicationUserManager(store.Object, null, null, null,null,null,null,null,null) ;
            return applicationUserManager;
        }

        public static IOptions<AppConfig> GetAppConfigOptions()
        {
            appConfigOptions = Options.Create(new AppConfig());
            return appConfigOptions;
        }

        public static ApplicationUserOrch GetApplicationUserOrch()
        {

            unitOfWork = new UnitOfWork<ApplicationDbContext>();
            applicationUserRepository = new ApplicationUserRepository(unitOfWork);
            applicationRoleRepository = new ApplicationRoleRepository(unitOfWork);
            appConfigOptions = GetAppConfigOptions();
            applicationUserManager = GetApplicationUserManager();

            applicationUserOrch = new ApplicationUserOrch(unitOfWork, applicationUserRepository,
                appConfigOptions, applicationUserManager, applicationRoleRepository);
            return applicationUserOrch;
        }
    }
}
