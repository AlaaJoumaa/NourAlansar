using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Entities
{
    public class ResponseResult
    {
        [JsonProperty("Message")]
        public virtual string Message { get; set; }

        [JsonProperty("Status")]
        public virtual bool Success { get; set; }

        [JsonProperty("Code")]
        public virtual string Code { get; set; }
        [JsonProperty("Data")]
        public virtual object Data { get; set; }
    }
}
