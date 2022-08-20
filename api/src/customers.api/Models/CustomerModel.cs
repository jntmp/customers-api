using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json.Serialization;

namespace Customers.Api.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        public StatusEnum Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
