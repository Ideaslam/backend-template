using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Identity
{
    /// <summary>
    /// Rpresents an application user claim
    /// </summary>
    [Table("UserClaims")]
    public class ApplicationUserClaim : IdentityUserClaim<int> { }
}
