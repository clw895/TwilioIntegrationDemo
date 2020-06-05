using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ContosoCrafts.WebSite.Models
{
    public class AutopilotResponse
    {
        public List<object> Actions {get;set;}
        public class Show
        {
            public string Body { get; set; }
            public List<Image> Images {get;set;}

            public class Image
            {
                public string Label {get;set;}
                public Uri Url {get;set;}
            }
        }


    }
}