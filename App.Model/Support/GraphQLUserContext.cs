using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Edura.Model.Support
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
