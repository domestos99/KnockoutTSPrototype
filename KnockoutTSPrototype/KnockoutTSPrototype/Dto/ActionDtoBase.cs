using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace KnockoutTSPrototype.Dto
{
    [Serializable]
    public abstract class ActionDtoBase
    {
        [JsonIgnore]
        public abstract string Action { get; }
    }
}