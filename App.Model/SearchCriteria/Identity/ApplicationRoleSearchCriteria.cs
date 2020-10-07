using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.SearchCriterias.Identity
{
    /// <summary>
    /// Represents the criteria used to filter <see cref="ApplicationRole"/>
    /// </summary>
    public class ApplicationRoleSearchCriteria : BaseSearchCriteria
    {
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets the role name
        /// </summary>
        public string Name { get; set; }

    }
}
