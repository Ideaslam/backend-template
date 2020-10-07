using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Services.OneSignal
{
    /// <summary>
    /// Represents the onesignal create device model
    /// </summary>
    public class OneSignalDeviceModel
    {
        /// <summary>
        /// Gets or sets the application id
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// Gets or sets the device type
        /// </summary>
        public int device_type { get; set; }
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string identifier { get; set; }
    }
}
