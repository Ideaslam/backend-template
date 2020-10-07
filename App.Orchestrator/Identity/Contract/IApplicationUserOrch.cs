using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Edura.Model.Support;
using Edura.Domain.Entity.Identity;

namespace Edura.Orchestrator.Identity.Contracts
{
    public interface IApplicationUserOrch
    {
        void AssignRequestParams(RequestParams _requestParams);
        IEnumerable<ApplicationUser> Get();
        //Task<ExecutionResponse<TokenDTO>> Auth(AuthModel authModel);
        //Task<ExecutionResponse<RegisterResponseModel>> VerifyPhone(VerifyPhoneNumberViewModel model);
        //Task<ExecutionResponse<RegisterResponseModel>> ResendVerifyPhoneCode(VerifyPhoneNumberViewModel model);
        //IEnumerable<MyUser> GetAll();
        //Task<ExecutionResponse<bool>> ForgetPassword(ForgetPasswordBindingModel forgetPasswordBindingModel);



    }
}