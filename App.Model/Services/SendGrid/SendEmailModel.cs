using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Services.SendGrid
{
    /// <summary>
    /// Represents the sendgrid send email model
    /// </summary>
    public class SendEmailModel
    {
        /// <summary>
        /// Gets or sets the sender email
        /// </summary>
        public string SenderEmail { get; set; }
        /// <summary>
        /// Gets or sets the reciever email
        /// </summary>
        public string DeptEmail { get; set; }
        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the html content
        /// </summary>
        public string htmlContent { get; set; }
        /// <summary>
        /// Gets or sets the subject
        /// </summary>
        public string Subject { get; set; }

    }
}
