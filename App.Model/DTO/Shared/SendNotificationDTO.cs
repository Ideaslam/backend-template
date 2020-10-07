using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.DTos.Shared
{
    public class SendNotificationDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ClickAction { get; set; }
        public Dictionary<string,string> Data { get; set; }
        public List<FireBaseTokenDTO> UserTokens { get; set; }
    }
}
