using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Data.Dto
{
    public class CustomerDto
    {
        //public CustomerDto(int id, string name, DateTime createdDate, int statusId)
        //{
        //    ID = id;
        //    Name = name;
        //    CreatedDate = createdDate;
        //    StatusId = statusId;
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public string CreatedDate { get; set; }
    }
}
