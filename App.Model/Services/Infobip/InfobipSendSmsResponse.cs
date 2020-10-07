using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Services.Infobip
{
    /// <summary>
    /// Represents the ressponse for infobip send sms api
    /// </summary>
    public class InfobipSendSmsResponse
    {
        /// <summary>
        /// Gets or sets the list of <see cref="InfobipMessageResponse"/>
        /// </summary>
        public List<InfobipMessageResponse> messages { get; set; }

    }
    
    /// <summary>
    /// Represents infobip message response
    /// </summary>
    public class InfobipMessageResponse
    {
        /// <summary>
        /// Gets or sets the reciever number(s)
        /// </summary>
        public string to { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="InfobipMessageResponseStatus"/>
        /// </summary>
        public InfobipMessageResponseStatus status { get; set; }
        /// <summary>
        /// Gets or sets the sms count
        /// </summary>
        public int smsCount { get; set; }
        /// <summary>
        /// Gets or sets the message id
        /// </summary>
        public string messageId { get; set; }

    }

    /// <summary>
    /// Represents infobip message response status
    /// </summary>
    public class InfobipMessageResponseStatus
    {
        /// <summary>
        /// Gets or sets the group id
        /// </summary>
        public int groupId { get; set; }
        /// <summary>
        /// Gets or sets the group name
        /// </summary>
        public string groupName { get; set; }
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string description { get; set; }
    }
}
