using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.DTos.Shared
{
   
    public class FireBaseTokenDTO
    {
        public string Token { get; set; }
        public string DeviceId { get; set; }
        public int? ReceiveNotifications { get; set; }
    }
}
