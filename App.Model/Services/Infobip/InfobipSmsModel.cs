using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Services.Infobip
{
    /// <summary>
    /// Represents infobip create sms model
    /// </summary>
    public class InfobipSmsModel
    {
        /// <summary>
        /// Gets or sets the text message
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Gets or sets the sender Id
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// Gets or sets thre reciever number(s)
        /// </summary>
        public string to { get; set; }
    }
}
