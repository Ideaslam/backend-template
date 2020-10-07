using Edura.Enums;
using Edura.Model.DTos.Shared;
using Edura.Model.Services.Infobip;
using Edura.Model.Support;
using Edura.Utils.Helpers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Edura.Services.Sms
{
    public class InfobipServie
    {
        private readonly AppConfig appConfig;
        private readonly InfobipConfig infobipConfig;

        public InfobipServie(IOptions<AppConfig> _appConfig)
        {
            appConfig = _appConfig.Value;
            infobipConfig = appConfig.Infobip;

        }

        public InfobipServie(InfobipConfig _infobipConfig)
        {
            infobipConfig = _infobipConfig;

        }


        public  async Task<ExecutionResponse<InfobipSendSmsResponse>> SendMessage(InfobipSmsModel model)
        {
            var response = new ExecutionResponse<InfobipSendSmsResponse>();
            try
            {
                string url = infobipConfig.ApiUrl + "/sms/1/text";
                string serializedContent = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
                BaseService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("App", infobipConfig.ApiToken);
                using (HttpResponseMessage sendResponse = await BaseService.Client.PostAsync(url, content))
                {
                    if(sendResponse.StatusCode != HttpStatusCode.OK)
                    {
                        var responseContent = JsonConvert.DeserializeObject(await sendResponse.Content.ReadAsStringAsync());

                        MessagesHelper.SetValidationMessages(response, "Error", responseContent.ToString(), lang: "en");
                        return response;
                    }
                    var res =  JsonConvert.DeserializeObject<InfobipSendSmsResponse>(await sendResponse.Content.ReadAsStringAsync());
                    response.Result = res;
                    response.State = ResponseState.Success;
                }
            }
            catch (Exception ex)
            {
                MessagesHelper.SetException(response, ex);
            }
            return response;
        }

    }
}
