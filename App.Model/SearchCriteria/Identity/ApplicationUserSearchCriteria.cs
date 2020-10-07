using Edura.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.SearchCriterias.Identity
{
    /// <summary>
    /// Represents the criteria used to filter <see cref="ApplicationUser"/>
    /// </summary>
    public class ApplicationUserSearchCriteria : BaseSearchCriteria
    {
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the activation status
        /// </summary>
        public ResourceStatus RowStatus { get; set; }
    }
}
