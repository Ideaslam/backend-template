using FcmSharp;
using FcmSharp.Requests;
using FcmSharp.Settings;
using Edura.Enums;
using Edura.Model.DTos.Shared;
using Edura.Model.Support;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Edura.Model.Services.Firebase;

namespace Edura.Services.Notification
{
    public class FcmService
    {
        private readonly AppConfig appConfig;
        private readonly FirebaseConfig firebaseConfig;
        public static FcmClient fcmClient { get; set; }

        public FcmService(IOptions<AppConfig> _appConfig)
        {
            appConfig = _appConfig.Value;
            firebaseConfig = appConfig.Firebase;
            InitFcmClient();
        }

        public FcmService(FirebaseConfig _firebaseConfig)
        {
            firebaseConfig = _firebaseConfig;
            InitFcmClient();
        }

        private void InitFcmClient()
        {
            var settings = FileBasedFcmClientSettings.CreateFromFile(firebaseConfig.AdminSdkFile);
            fcmClient = new FcmClient(settings);
        }
        public async Task<ExecutionResponse<bool>> SendNotification(SendNotificationDTO sendNotificationDTO)
        {
            ExecutionResponse<bool> response = new ExecutionResponse<bool>();

            var androidConfig = new AndroidConfig();
            androidConfig.Notification = new AndroidNotification();
           

            Message message = new Message
            {
                Notification = new FcmSharp.Requests.Notification
                {
                    Title = sendNotificationDTO.Title,
                    Body = sendNotificationDTO.Body,
                },
                AndroidConfig = androidConfig,
                Data = sendNotificationDTO.Data
            };

            CancellationTokenSource cts = new CancellationTokenSource();
            var tokens = sendNotificationDTO.UserTokens.Select(ut => ut.Token).ToArray();
            var result = await fcmClient.SendMulticastMessage(tokens, message, false, cts.Token);//.GetAwaiter().GetResult();

            // handle error
            response.State = ResponseState.Success;
            response.Result = true;
            return response;
            
        }
        

    }
}
