using Edura.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Edura.Domain.Entity.Identity
{
    /// <summary>
    /// Represents an application user
    /// </summary>
    [Table("Users")]
    public class ApplicationUser : IdentityUser<int>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationUser"/> and sets the default values
        /// </summary>
        public ApplicationUser()
        {
            ReceiveNotification = true;
            ReceiveSms = true;
            ReceiveEmail = true;
            RowStatus = ResourceStatus.Active;
        }



        #region common
        /// <summary>
        /// Gets or sets the type of the user
        /// </summary>
        public ApplicationUserType UserType { get; set; }

        /// <summary>
        /// Gets or sets the activation status for the user
        /// </summary>
        public ResourceStatus RowStatus { get; set; }
        #endregion

        #region communication info
        /// <summary>
        /// Gets or sets a flag indicating if a user recieves notification
        /// </summary>
        public bool ReceiveNotification { get; set; }
        /// <summary>
        /// Gets or sets a flag indicating if a user recieves sms
        /// </summary>
        public bool ReceiveSms { get; set; }
        /// <summary>
        /// Gets or sets a flag indicating if a user recieves email
        /// </summary>
        public bool ReceiveEmail { get; set; }
        /// <summary>
        /// Gets or sets the id for the default language to communicate with the user
        /// </summary>
        public int PreferredLanguageId { get; set; }
        #endregion

        #region localization
        /// <summary>
        /// Gets or sets the country code
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Gets or sets the country id
        /// </summary>
        public int? CountryId { get; set; }
        /// <summary>
        /// Gets or sets the city id
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// Gets or sets the area id
        /// </summary>
        public int? AreaId { get; set; }

        #endregion

        #region auth provider
        /// <summary>
        /// Gets or sets the provider used for authintication
        /// </summary>
        public AuthProviderType? AuthProviderType { get; set; }
        /// <summary>
        /// Gets or sets the access token provided by the authentication provider
        /// </summary>
        public string AuthProviderAccessToken { get; set; }
        #endregion

       
       

    }

}
