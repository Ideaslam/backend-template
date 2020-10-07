using Edura.Enums;
using Edura.Model.DTos.Shared;
using Edura.Model.Services.BranchIo;
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

namespace Edura.Services.Branch
{
    public class BranchService
    {
        private readonly AppConfig appConfig;
        private readonly BranchIoConfig branchIoConfig;

        public BranchService(IOptions<AppConfig> _appConfig)
        {
            appConfig = _appConfig.Value;
            branchIoConfig = appConfig.BranchIo;
        }

        public BranchService(BranchIoConfig _branchIoConfig)
        {
            branchIoConfig = _branchIoConfig;
        }
        public  async Task<ExecutionResponse<BranchCreateLinkResponse>> CreateDeepLink(BranchIoDeepLinkParms deepLinkParms)
        {
            ExecutionResponse<BranchCreateLinkResponse> response = new ExecutionResponse<BranchCreateLinkResponse>();
            try
            {
                string url = branchIoConfig.ApiUrl + "/v1/url";
                deepLinkParms.branch_key = branchIoConfig.ApiKey;
                string serializedContent = JsonConvert.SerializeObject(deepLinkParms);
                HttpContent content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

                using (HttpResponseMessage sendResponse = await BaseService.Client.PostAsync(url, content))
                {
                    if (sendResponse.StatusCode != HttpStatusCode.OK)
                    {
                        var responseContent = JsonConvert.DeserializeObject(await sendResponse.Content.ReadAsStringAsync());

                        MessagesHelper.SetValidationMessages(response, "Error", responseContent.ToString(), lang: "en");
                        return response;
                    }
                    var res = JsonConvert.DeserializeObject<BranchCreateLinkResponse>(await sendResponse.Content.ReadAsStringAsync());
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
