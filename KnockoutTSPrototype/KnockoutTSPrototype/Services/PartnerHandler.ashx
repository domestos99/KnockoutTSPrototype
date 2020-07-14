<%@ WebHandler Language="C#" Class="PartnerHandler" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnockoutTSPrototype.Services;

//namespace KnockoutTSPrototype.Services
//{
public class PartnerHandler : GenericHandler
{
    public override void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        var action = context.Request["action"];

        if (string.IsNullOrWhiteSpace(action))
        {
            context.Response.Write(GetError("Action missing."));
            return;
        }

        action = action.ToLower().Trim();

        if (action == "partner")
        {
            new PartnerProcessor().PartnerHandle(context);
            return;
        }
    }
}

//}