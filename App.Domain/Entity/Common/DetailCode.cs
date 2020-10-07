using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Common
{
    /// <summary>
    /// Represents a detail code
    /// </summary>
    [Table("DetailCodes")]
    public class DetailCode:BaseEntity
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
        /// <summary>
        /// Gets or sets the row index in order
        /// </summary>
        public int? OrderedIndex { get; set; }
        #endregion

        #region relations
        /// <summary>
        /// Gets or sets the id for the parent mastercode
        /// </summary>
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual DetailCode ParentDetailCode { get; set; }
        [InverseProperty("ParentDetailCode")]
        public virtual IList<DetailCode> ChildDetailCodes { get; set; }

        public int MasterCodeId { get; set; }
        [ForeignKey("MasterCodeId")]
        public virtual MasterCode MasterCode { get; set; }

        /// <summary>
        /// Gets or sets the country id
        /// </summary>
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual DetailCode Country { get; set; }
        [InverseProperty("Country")]
        public virtual IList<DetailCode> CountryDetailCodes { get; set; }

        /// <summary>
        /// Gets or sets the city id
        /// </summary>
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual DetailCode City { get; set; }
        [InverseProperty("City")]
        public virtual IList<DetailCode> CityDetailCodes { get; set; }


        /// <summary>
        /// Gets or sets the area id
        /// </summary>
        public int? AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual DetailCode Area { get; set; }
        [InverseProperty("Area")]
        public virtual IList<DetailCode> AreaDetailCodes { get; set; }

        [InverseProperty("Country")]
        public virtual IList<AppResource> CountryAppResources { get; set; }
        [InverseProperty("City")]
        public virtual IList<AppResource> CityAppResources { get; set; }
        [InverseProperty("Area")]
        public virtual IList<AppResource> AreaAppResources { get; set; }
        #endregion

        #region custom fields
        /// <summary>
        /// Gets or sets field one value
        /// </summary>
        public string FieldOneValue { get; set; }
        /// <summary>
        /// Gets or sets field two value
        /// </summary>
        public string FieldTwoValue { get; set; }
        /// <summary>
        /// Gets or sets field three value
        /// </summary>
        public string FieldThreeValue { get; set; }
        /// <summary>
        /// Gets or sets field four value
        /// </summary>
        public string FieldFourValue { get; set; }
        #endregion

    }
}
