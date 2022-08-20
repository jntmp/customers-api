using System.ComponentModel.DataAnnotations;

namespace Customers.Api.Models.Request
{
    public class CustomerRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
