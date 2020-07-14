using System;
using System.Web;
using KnockoutTSPrototype.Utils;

namespace KnockoutTSPrototype.Dto
{
    [Serializable]
    public class PartnerSearchDto : ActionDtoBase
    {
        public string Name { get; set; }

        public override string Action
        {
            get
            {
                return "partner";
            }
        }

        public static bool GetFromContext(HttpContext context, out PartnerSearchDto dto)
        {
            var result = new PartnerSearchDto();
            bool ok = true;

            string name;
            ok &= ServiceParamUtil.GetParamString(context, "Name", out name);
            result.Name = name;


            dto = result;

            return ok;
        }
    }
}