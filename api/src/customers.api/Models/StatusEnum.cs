using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Customers.Api.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusEnum
    {
        Prospective = 0,
        Current = 1,
        NonActive = 2
    }
}
