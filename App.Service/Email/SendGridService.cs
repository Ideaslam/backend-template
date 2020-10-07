using Edura.Enums;
using Edura.Model.DTos;
using Edura.Model.DTos.Shared;
using Edura.Model.Services;
using Edura.Model.Services.SendGrid;
using Edura.Model.Support;
using Edura.Utils.Helpers;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Edura.Services.Email
{
    public class SendGridService
    {
        private readonly AppConfig appSettings;
        private readonly SendGridConfig sendGridConfig;
        public static SendGridClient sendGridClient;
        public SendGridService(IOptions<AppConfig> _appSettings)
        {
            appSettings = _appSettings.Value;
            sendGridConfig = appSettings.SendGrid;
            sendGridClient = new SendGridClient(sendGridConfig.ApiKey);
        }
        public static async Task<ExecutionResponse<bool>> SendEmail( SendEmailModel model)
        {
            ExecutionResponse<bool> response = new ExecutionResponse<bool>();
            try
            {
                var from = new EmailAddress(model.SenderEmail, "");
                var to = new EmailAddress(model.DeptEmail, "");
                var plainTextContent = model.Message;
                var htmlContent = model.htmlContent;
                var subject = model.Subject;

                var email = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var sendEmailAsyncRes = await sendGridClient.SendEmailAsync(email);
                if (sendEmailAsyncRes.StatusCode != HttpStatusCode.Accepted)
                {
                    MessagesHelper.SetValidationMessages(response, "Email_Error", sendEmailAsyncRes.Body.ToString(), lang: "en");
                    return response;
                }
                response.State = ResponseState.Success;
                response.Result = true;
            }
            catch(Exception ex)
            {
                MessagesHelper.SetException(response, ex);
            }
            return response;
        }


       
    }
}
