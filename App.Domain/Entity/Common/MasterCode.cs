using Edura.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Common
{
    /// <summary>
    /// Represents a master code
    /// </summary>
    [Table("MasterCodes")]
    public class MasterCode:BaseEntity
    {
        #region common
        /// <summary>
        /// Gets or sets the code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the english name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the arabic name
        /// </summary>
        public string NameAr { get; set; }
        /// <summary>
        /// Gets or sets the english description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the arabic description
        /// </summary>
        public string DescriptionAr { get; set; }
        #endregion

        #region relations
        /// <summary>
        /// Gets or sets the id for the parent mastercode
        /// </summary>
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual MasterCode ParentMasterCode { get; set; }
        [InverseProperty("ParentMasterCode")]
        public virtual IList<MasterCode> ChildMasterCodes { get; set; }
        public virtual IList<DetailCode> DetailCodes { get; set; }
        #endregion

        #region custom fields
        /// <summary>
        /// Gets or sets the english field one title
        /// </summary>
        public string FieldOneTitle { get; set; }

        /// <summary>
        /// Gets or sets the arabic field one title
        /// </summary>
        public string FieldOneTitleAr { get; set; }
        /// <summary>
        /// Gets or sets the english field one visibilty status
        /// </summary>
        public bool FieldOneIsVisible { get; set; }
        /// <summary>
        /// Gets or sets the english field tow title
        /// </summary>
        public string FieldTwoTitle { get; set; }
        /// <summary>
        /// Gets or sets the arabic field tow title
        /// </summary>
        public string FieldTwoTitelAr { get; set; }
        /// <summary>
        /// Gets or sets field two visibilty status
        /// </summary>
        public bool FieldTwoIsVisible { get; set; }
        /// <summary>
        /// Gets or sets the english field three title
        /// </summary>
        public string FieldThreeTitle { get; set; }
        /// <summary>
        /// Gets or sets the arabic field three title
        /// </summary>
        public string FieldThreeTitleAr { get; set; }
        /// <summary>
        /// Gets or sets  field three visibilty status
        /// </summary>
        public bool FieldThreeIsVisible { get; set; }
        /// <summary>
        /// Gets or sets the english field four title
        /// </summary>
        public string FieldFourTitle { get; set; }
        /// <summary>
        /// Gets or sets the arabic field four title
        /// </summary>
        public string FieldFourTitleAr { get; set; }
        /// <summary>
        /// Gets or sets field four visibilty status
        /// </summary>
        public bool FieldFourIsVisible { get; set; }
        #endregion

    }
}
