using Customers.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Data.Interface
{
    public interface ICustomerNoteRepository<T> : IGenericRepository<T> where T : CustomerNoteDto
    {
        IEnumerable<T> GetCustomerNotes(int customerId);
    }
}
