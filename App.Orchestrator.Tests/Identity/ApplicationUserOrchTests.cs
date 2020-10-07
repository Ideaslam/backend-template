using Edura.Domain.Entity.Identity;
using Edura.Orchestrator.Identity.Contracts;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Edura.Orchestrator.Tests.Identity
{
    public class ApplicationUserOrchTests
    {
        
        private IApplicationUserOrch applicationUserOrch;

        public ApplicationUserOrchTests()
        {
            applicationUserOrch = MockInitializer.GetApplicationUserOrch();

        }

        [Fact]
        public void Test()
        {

            var users = applicationUserOrch.Get();
            Assert.Empty(users);
        }

    }
}
