using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Services.OneSignal
{
    /// <summary>
    /// Represents onesignal add device api response
    /// </summary>
    public class OneSignalAddDeviceResponse
    {
        /// <summary>
        /// Gets or sets a flag indicating if the operation success
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// Gets or sets the onesignal id
        /// </summary>
        public string id { get; set; }
    }
}
