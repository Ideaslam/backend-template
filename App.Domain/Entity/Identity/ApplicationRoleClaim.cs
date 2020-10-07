using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Identity
{
    /// <summary>
    /// Rpresents an application role claim
    /// </summary>
    [Table("RoleClaims")]
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
    }
}
