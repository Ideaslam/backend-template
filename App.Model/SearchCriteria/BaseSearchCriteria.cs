using Edura.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Edura.Model
{
    /// <summary>
    /// Represents the base search criteria for all criterias
    /// </summary>
    public class BaseSearchCriteria
    {
        #region localization
        /// <summary>
        /// Gets or sets country id
        /// </summary>
        public int? CountryId { get; set; }
        /// <summary>
        /// Gets or sets city id
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// Gets or sets area id
        /// </summary>
        public int? AreaId { get; set; }
        /// <summary>
        /// Gets or sets language
        /// </summary>
        public string Lang { get; set; }
        #endregion

        #region paging
        /// <summary>
        /// Gets or sets a flag indicating if the paging is enabled
        /// </summary>
        public bool PagingEnabled { get; set; }
        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// Gets or sets the page number
        /// </summary>
        public int? PageNumber { get; set; }
        #endregion

        #region ordering
        /// <summary>
        /// Gets or sets the sort direction
        /// </summary>
        public OrderDirection? OrderByDirection { get; set; }
        /// <summary>
        /// Gets or sets the sort culture
        /// </summary>
        public OrderCulture? OrderByCulture { get; set; } = OrderCulture.Default;
        #endregion

        #region filteration
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets free text used for filtering
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// Gets or sets a flag indicating if it's for autocomplete
        /// </summary>
        public bool ForAutoComplete { get; set; }
        /// <summary>
        /// Gets or sets a flag indicating if it's for list view
        /// </summary>
        public bool ForListView { get; set; }
        #endregion

    }
}
