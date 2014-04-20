using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListMobileService.DataObjects
{
    public class UndoneCountResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}