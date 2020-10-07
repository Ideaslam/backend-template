using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;
using Edura.Model.DTos.Shared;
using System.Linq;
using Edura.Model.Support;
using Edura.Enums;
using Edura.Model;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Edura.Utils.Helpers
{
    public class MessagesHelper
    {
         public static MemoryCache memCache = MemoryCache.Default;
        public static T GetCachedData<T>(string key)
        {
            try
            {
                if (memCache.Contains(key))
                    return (T)memCache.Get(key);
                return default(T);
            }
            catch (InvalidCastException ex)
            {
                return default(T);
            }
        }
        public static string GetTranslation(string key, string lang)
        {
            string cachedKey = "ar_trans";
            if (lang == "en") {
                cachedKey = "en_trans";
            }
           var cached =  GetCachedData<IEnumerable<TransModel>> (cachedKey);
            if (cached != null)
            {
                List<TransModel> data = (cached).ToList();
                if (data != null)
                {
                    var tr = data.Find(x => x.KeyWord == key);
                    if (tr != null)
                    {
                        return tr.TransWords;
                    }
                    else
                    {
                        return key;
                    }

                }
                else
                {
                    return key;
                }
            }

            return key;

        }
        public static void setlangTrans(object translations , string cachKey)
        {
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddDays(365)
            };
            if (memCache.Contains(cachKey))
            {
                memCache.Remove(cachKey);
            }
            memCache.Add(cachKey, translations, cacheItemPolicy);
        }
        public static void setArTrans( object translations)
        {
            setlangTrans(translations, "ar_trans");
        }
        public static void setEnTrans(object translations)
        {
            setlangTrans(translations, "en_trans");
        }


        public static List<MetaPair> GetDetailedMessages(string messageCode, string message, string MetaPlus = "")
        {
            return new List<MetaPair>() { new MetaPair() { Property = messageCode, Meta = message, MetaPlus = MetaPlus } };

        }
        
        public static void SetDetailedMessages<T>(ExecutionResponse<T> res, string messageCode, string message, string MetaPlus = "", string lang  = "ar")
        {
            LocalizeMessage(ref messageCode, ref message, lang);
            var _MetaPair = GetDetailedMessages(messageCode, message, MetaPlus);
            res.MessageCode = messageCode;
            
            res.Message = _MetaPair[0].Meta +"  '"+MetaPlus+"'";

        }
        public static void SetValidationMessages<T>(ExecutionResponse<T> res, string messageCode, string message, string MetaPlus = "", string lang  = "ar")
        {
            SetDetailedMessages(res, messageCode, message, MetaPlus, lang);
            res.State = ResponseState.ValidationError;
            res.Result = default(T); 
            
        }

        public static void SetSuccessMessage<T>(ExecutionResponse<T> res, string messageCode, string message, string MetaPlus = "", string lang = "ar")
        {
            SetDetailedMessages(res, messageCode, message, MetaPlus, lang);
            res.State = ResponseState.Success;

        }

        public static void SetException<T>(ExecutionResponse<T> res, Exception ex,string lang="ar")
        {
            SetDetailedMessages(res, "generalError", "an error occured", lang);
            res.State = ResponseState.Error;
            res.Exception = ex;
            res.Result = default(T);

        }

        public static void MapExecutionResponse<T>(ExecutionResponse<T> res, Exception ex, string message, ResponseState state)
        {

            res.State = state;
            res.Exception = ex;
            res.Message = message;

        }

        public static void MapExecutionResponse<T>(ExecutionResponse<T> res, Exception ex, string message , ResponseState state, T result)
        {
            res.Result = result;
            res.State = state;
            res.Exception = ex;
            res.Message = message;

        }

        
        public static void MapIdentityResultToExecutionResponse<T>(ExecutionResponse<T> response, IdentityResult result, string lang)
        {

            var error = result.Errors.FirstOrDefault();
            SetValidationMessages(response, error.Code, error.Description, lang: lang);
            
        }


        public static void LocalizeMessage( ref string messageCode, ref string message ,  string lang) {
            string _keyWord = messageCode;
            if (messageCode.StartsWith("MissingData_"))
            {
                _keyWord = "MissingData";
            }
            var transaltedMessage = GetTranslation(_keyWord, lang);
            message = (transaltedMessage == _keyWord ? message : transaltedMessage);
        }

        public static List<MetaPair> DetailMessageOfFluentValidation(ValidationResult validationResult, string lang = "ar")
        {
            var metaPairList = new List<MetaPair>();
            foreach (ValidationFailure validationFailure in validationResult.Errors)
            {
                string messageCode = validationFailure.ErrorCode;
                string message = GetTranslation(messageCode, lang);

                metaPairList.Add(new MetaPair() { Property = messageCode, Meta = message, MetaPlus = "" });

            }
            return metaPairList;

        }

        public static void SetDetailMessageOfFluentValidation<T>(ExecutionResponse<T> res, ValidationResult validationResult , string lang = "ar")
        {
            var metaPairList = new List<MetaPair>();
            foreach (ValidationFailure validationFailure in validationResult.Errors)
            {
                
                string messageCode = validationFailure.ErrorCode;

                string message = GetTranslation(messageCode, lang);


                metaPairList.Add(new MetaPair() { Property = messageCode, Meta = message, MetaPlus = "" });

                res.MessageCode = messageCode;

            }

            res.DetailedMessages = metaPairList;
            

        }


        

       
    }
}
