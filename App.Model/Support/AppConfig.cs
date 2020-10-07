using Edura.Model.Services.BranchIo;
using Edura.Model.Services.Firebase;
using Edura.Model.Services.Infobip;
using Edura.Model.Services.OneSignal;
using Edura.Model.Services.SendGrid;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Support
{
    /// <summary>
    /// Represents the app configuration
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets the <see cref="JwtConfig"/>
        /// </summary>
        public JwtConfig Jwt { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Cors"/>
        /// </summary>
        public CorsConfig Cors { get; set; }
        /// <summary>
        /// Gets or sets the upload folder path
        /// </summary>
        public string UploadFolderPath { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="InfobipConfig"/>
        /// </summary>
        public InfobipConfig Infobip { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="SendGridConfig"/>
        /// </summary>
        public SendGridConfig SendGrid { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="BranchIoConfig"/>
        /// </summary>
        public BranchIoConfig BranchIo { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="OneSignalConfig"/>
        /// </summary>
        public OneSignalConfig OneSignal { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="FirebaseConfig"/>
        /// </summary>
        public FirebaseConfig Firebase { get; set; }
        

    }

    /// <summary>
    /// Represents the json web token configuration
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// Gets or sets the secret key
        /// </summary>
        public string SecretKey { get; set; }
    }

    /// <summary>
    /// Represents the cors configuration
    /// </summary>
    public class CorsConfig
    {
        public string[] AllowedCorsDomains { get; set; }
        public string CorsPolicy { get; set; }

    }

}
