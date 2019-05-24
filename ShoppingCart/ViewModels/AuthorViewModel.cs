using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.ViewModels
{
    public class AuthorViewModel
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName ="FullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "Biography")]
        public string Biography { get; set; }


    }
}