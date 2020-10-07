using Edura.Enums;
using Edura.Model.Services.OneSignal;
using Edura.Model.Support;
using Edura.Utils.Helpers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Edura.Services.OneSignal
{
    public class OneSignalService

    {
        private readonly AppConfig appConfig;
        private readonly OneSignalConfig oneSignalConfig;

        public OneSignalService(IOptions<AppConfig> _appConfig)
        {
            appConfig = _appConfig.Value;
            oneSignalConfig = appConfig.OneSignal;
           
        }

        public OneSignalService(OneSignalConfig _oneSignalConfig)
        {
            oneSignalConfig = _oneSignalConfig;

        }
        public async Task<ExecutionResponse<OneSignalAddDeviceResponse>> AddDevice(OneSignalDeviceModel device)
        {
            ExecutionResponse<OneSignalAddDeviceResponse> response = new ExecutionResponse<OneSignalAddDeviceResponse>();
            try
            {
                var json_data = JsonConvert.SerializeObject(device);
                string url = oneSignalConfig.ApiUrl;
                string serializedContent = JsonConvert.SerializeObject(json_data);
                HttpContent content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
                using (HttpResponseMessage sendResponse = await BaseService.Client.PostAsync(url, content))
                {
                    if (sendResponse.StatusCode != HttpStatusCode.OK)
                    {
                        var responseContent = JsonConvert.DeserializeObject(await sendResponse.Content.ReadAsStringAsync());
                        MessagesHelper.SetValidationMessages(response, "Error", responseContent.ToString(), lang: "en");
                        return response;
                    }
                    var res = JsonConvert.DeserializeObject<OneSignalAddDeviceResponse>(await sendResponse.Content.ReadAsStringAsync());
                    response.Result = res;
                    response.State = ResponseState.Success;
                }
            }
            catch(Exception ex)
            {
                MessagesHelper.SetException(response, ex);
            }
            return response;
            
        }
    }
}
