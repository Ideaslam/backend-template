using Edura.Domain.Entity.Identity;
using Edura.Enums;
using System;
using System.Collections.Generic;


namespace Edura.Model.DTos.Shared
{
    public class SendMessageDTO
    {
        public MessageType? MessageType { get; set; }
        public ApplicationUser applicationUser { get; set; }

        //public MessagesTemplateDTO MessagesTemplate { get; set; }
        public string Lang { get; set; }
        public string PhoneNumber { get; set; }
        public int? CountryId { get; set; }
        public string CountryCode { get; set; }
        public Dictionary<string, string> DictionaryData { get; set; }
        public string ClickAction { get; set; }
        public string SenderEmail { get; set; }
        public string DeptEmail { get; set; }
        public string NewPassword { get; set; }
        public bool UseNewPassword { get; set; }
        public string ConfirmationCode { get; set; }
        public bool UseConfirmationCode { get; set; }
        public int GlameraMessageId { get; set; }
        public int? AlgorithmDetailId { get; set; }
        public int? AutomationAlgorithmId { get; set; }

        public string Message { get; set; }

        public string Title { get; set; }

        public List<FireBaseTokenDTO> UserTokens { get; set; }

    }
}
