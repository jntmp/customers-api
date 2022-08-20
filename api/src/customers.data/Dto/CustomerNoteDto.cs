using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Customers.Data.Dto
{
    //[Table("CustomerNote")]
    public class CustomerNoteDto
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public string Note { get; set; }
    }
}
