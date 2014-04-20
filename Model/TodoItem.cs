using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GetStartedWithMobileServices.Model
{
    [DataContract]
    public class TodoItem : ModelBase
    {
        int number;

        [DataMember]
        [JsonProperty("number")]
        public int Number
        {
            get { return number; }
            set { this.SetProperty(ref number, value); }
        }

        string title;

        [DataMember]
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { this.SetProperty(ref title, value); }
        }

        string description;

        [DataMember]
        [JsonProperty("description")]
        public string Description
        {
            get { return description; }
            set { this.SetProperty(ref description, value); }
        }

        public TodoItem()
        {
            this.number = 0;
            this.title = string.Empty;
            this.description = string.Empty;
        }
    }
}
