using Edura.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Support
{
    /// <summary>
    /// Represents the request parameters
    /// </summary>
    public class RequestParams
    {
        #region localozation
        /// <summary>
        /// Gets or sets the country id
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// Gets or sets the city id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// Gets or sets the area id
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// Gets or sets the lang
        /// </summary>
        public string Lang { get; set; }
        /// <summary>
        /// Gets or sets the country code
        /// </summary>
        public string CountryCode { get; set; }

        #endregion

        #region identity
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName { get; set; }
        #endregion

        #region device and app
        /// <summary>
        /// Gets or sets the <see cref="DeviceType"/>
        /// </summary>
        public DeviceType DeviceType { get; set; }
        /// <summary>
        /// Gets or sets the operating system version
        /// </summary>
        public string OsVersion { get; set; }
        /// <summary>
        /// Gets or sets the application release version
        /// </summary>
        public string AppVersion { get; set; }
        #endregion

    }
}
