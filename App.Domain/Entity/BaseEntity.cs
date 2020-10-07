using Edura.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity
{
    /// <summary>
    /// Represents the base entity for all entities 
    /// </summary>
    public class BaseEntity 
    {
        /// <summary>
        /// Gets or sets the Id (primary key) 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the added date
        /// </summary>
        public DateTime AddedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the modified date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets the ip address
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// Gets or sets the id for the added user
        /// </summary>
        public int AddUserId { get; set; }
        /// <summary>
        /// Gets or sets thr id for the modified user
        /// </summary>
        public int ModifyUserId { get; set; }
        /// <summary>
        /// Gets or sets the activityStatus name
        /// </summary>
        public ResourceStatus RowStatus { get; set; }
    }
}
