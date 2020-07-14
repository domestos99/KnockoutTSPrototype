using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnockoutTSPrototype.Services;
using Newtonsoft.Json;

namespace KnockoutTSPrototype.Utils
{
    public class ServiceParamUtil
    {

        public static bool GetParamString(HttpContext context, string name, out string value)
        {
            value = context.Request[name];

            if (string.IsNullOrWhiteSpace(value))
            {
                WriteErrorResponse(context, name + " missing.");
                return false;
            }

            return true;
        }

        public static void WriteErrorResponse(HttpContext context, string message, object data = null)
        {
            var result = new JsonResponse()
            {
                Success = false,
                Data = data,
                Message = message
            };
            context.Response.Write(JsonConvert.SerializeObject(result));
        }
    }
}