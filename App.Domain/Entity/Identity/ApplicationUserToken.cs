using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Identity
{
    /// <summary>
    /// Rpresents an application user token
    /// </summary>
    [Table("UserTokens")]
    public class ApplicationUserToken : IdentityUserToken<int>
    {
    }
}
