using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace KnockoutTSPrototype.Services
{
    public abstract class GenericHandler : IHttpHandler
    {
        public virtual void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }


        public virtual void WriteSuccessResponse(HttpContext context, string message, object data = null)
        {
            var result = new JsonResponse()
            {
                Success = true,
                Data = data,
                Message = message
            };
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public string GetError(string message)
        {
            var result = new JsonResponse()
            {
                Success = false,
                Data = null,
                Message = message
            };
            return JsonConvert.SerializeObject(result);
        }

        public virtual void WriteErrorResponse(HttpContext context, string message, object data = null)
        {
            var result = new JsonResponse()
            {
                Success = false,
                Data = data,
                Message = message
            };
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}