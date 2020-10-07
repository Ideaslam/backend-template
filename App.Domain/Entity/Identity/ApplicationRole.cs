using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Edura.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Identity;
namespace Edura.Domain.Entity.Identity
{
    /// <summary>
    /// Represents an application role
    /// </summary>
    [Table("Roles")]
    public class ApplicationRole : IdentityRole<int>
    {

        #region common
        /// <summary>
        /// Gets or sets the arabic name 
        /// </summary>
        public string NameAr { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the arabic description
        /// </summary>
        public string DescriptionAr { get; set; }
        /// <summary>
        /// Gets or sets the id of the parent role
        /// </summary>
        public int? ParentRoleId { get; set; }
        /// <summary>
        /// Gets or sets the level of the role
        /// </summary>
        public int? GrantLevel { get; set; }
        /// <summary>
        /// Gets or sets the activation status for the role
        /// </summary>
        public ResourceStatus RowStatus { get; set; }
        #endregion
        


       

    }

}
