using Customers.Data.Dto;
using Dapper.FastCrud;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Api
{
    public class DatabaseEntities
    {
        public void RegisterDapperEntities()
        {
            OrmConfiguration.RegisterEntity<CustomerDto>()
                .SetTableName("Customer")
                .SetDialect(SqlDialect.MsSql)
                .SetProperty(c => c.Id,
                             propMapping => propMapping
                                .SetPrimaryKey()
                                .SetDatabaseGenerated(DatabaseGeneratedOption.Identity)
                                .SetDatabaseColumnName("Id"))
                .SetProperty(c => c.Name,
                             propMapping => propMapping
                                .SetDatabaseColumnName("Name"))
                .SetProperty(c => c.StatusId,
                             propMapping => propMapping
                                .SetDatabaseColumnName("StatusId"))
                .SetProperty(c => c.CreatedDate,
                             propMapping => propMapping
                                .SetDatabaseColumnName("CreatedDate"));

            OrmConfiguration
                .RegisterEntity<CustomerNoteDto>()
                    .SetTableName("CustomerNote")
                    .SetDialect(SqlDialect.MsSql)
                    .SetProperty(note => note.ID,
                                 propMapping => propMapping
                                    .SetPrimaryKey()
                                    .SetDatabaseGenerated(DatabaseGeneratedOption.Identity)
                                    .SetDatabaseColumnName("ID"))
                    .SetProperty(note => note.CustomerId,
                                 propMapping => propMapping
                                    .SetDatabaseColumnName("CustomerId"))
                    .SetProperty(note => note.Note,
                                 propMapping => propMapping
                                    .SetDatabaseColumnName("Note"));
                    

                //.SetParentChildrenRelationship(note => note.Workstations,
                //                                workstation => workstation.BuildingId);

        }
    }
}
