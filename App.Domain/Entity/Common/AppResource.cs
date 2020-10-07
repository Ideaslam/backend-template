using Edura.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Edura.Domain.Entity.Common
{
    /// <summary>
    /// Represents an app resource
    /// </summary>
    [Table("AppResources")]
    public class AppResource:BaseEntity
    {
        #region common
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the english value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the arabic value
        /// </summary>
        public string ValueAr { get; set; }
        /// <summary>
        /// Gets or sets the value type
        /// </summary>
        public ResourceValueType ValueType { get; set; }
        /// <summary>
        /// Gets or sets the english description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the arabic description
        /// </summary>
        public string DescriptionAr { get; set; }
        /// <summary>
        /// Gets or sets the resource relation
        /// </summary>
        public ResourceRelation RelatedTo { get; set; }
        #endregion

        #region relations
        /// <summary>
        /// Gets or sets the country id
        /// </summary>
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual DetailCode Country { get; set; }

        /// <summary>
        /// Gets or sets the city id
        /// </summary>
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual DetailCode City { get; set; }

        /// <summary>
        /// Gets or sets the area id
        /// </summary>
        public int? AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual DetailCode Area { get; set; }
        #endregion

        #region custom fields
        /// <summary>
        /// Gets or sets custom field one key
        /// </summary>
        public string CustomFieldOneKey { get; set; }
        /// <summary>
        /// Gets or sets custom field one value
        /// </summary>
        public string CustomFieldOneValue { get; set; }
        /// <summary>
        /// Gets or sets custom field two key
        /// </summary>
        public string CustomFieldTwoKey { get; set; }
        /// <summary>
        /// Gets or sets custom field two value
        /// </summary>
        public string CustomFieldTwoValue { get; set; }
        /// <summary>
        /// Gets or sets custom field three key
        /// </summary>
        public string CustomFieldThreeKey { get; set; }
        /// <summary>
        /// Gets or sets custom field three value
        /// </summary>
        public string CustomFieldThreeValue { get; set; }
        /// <summary>
        /// Gets or sets custom field four key
        /// </summary>
        public string CustomFieldFourKey { get; set; }
        /// <summary>
        /// Gets or sets custom field four value
        /// </summary>
        public string CustomFieldFourValue { get; set; }
        /// <summary>
        /// Gets or sets custom field five key
        /// </summary>
        public string CustomFieldFiveKey { get; set; }
        /// <summary>
        /// Gets or sets custom field five value
        /// </summary>
        public string CustomFieldFiveValue { get; set; }
        /// <summary>
        /// Gets or sets custom field six key
        /// </summary>
        public string CustomFieldSixKey { get; set; }
        /// <summary>
        /// Gets or sets custom field six value
        /// </summary>
        public string CustomFieldSixValue { get; set; }
        /// <summary>
        /// Gets or sets custom field seven key
        /// </summary>
        public string CustomFieldSevenKey { get; set; }
        /// <summary>
        /// Gets or sets custom field seven value
        /// </summary>
        public string CustomFieldSevenValue { get; set; }
        /// <summary>
        /// Gets or sets custom field eight key
        /// </summary>
        public string CustomFieldEightKey { get; set; }
        /// <summary>
        /// Gets or sets custom field eight value
        /// </summary>
        public string CustomFieldEightValue { get; set; }
        /// <summary>
        /// Gets or sets custom field nine key
        /// </summary>
        public string CustomFieldNineKey { get; set; }
        /// <summary>
        /// Gets or sets custom field nine value
        /// </summary>
        public string CustomFieldNineValue { get; set; }
        /// <summary>
        /// Gets or sets custom field ten key
        /// </summary>
        public string CustomFieldTenKey { get; set; }
        /// <summary>
        /// Gets or sets custom field ten value
        /// </summary>
        public string CustomFieldTenValue { get; set; }
        #endregion
    }
}
