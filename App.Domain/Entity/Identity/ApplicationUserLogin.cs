using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Identity
{
    /// <summary>
    /// Rpresents an application user login
    /// </summary>
    [Table("UserLogins")]
    public class ApplicationUserLogin : IdentityUserLogin<int> { }
}
