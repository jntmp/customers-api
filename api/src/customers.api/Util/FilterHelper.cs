using Customers.Data.Dto;
using System;

namespace Customers.Api.Util
{
    public static class FilterHelper
    {
        private static string[] AllowedFieldFilters = new string[] { "Name", "StatusId" };

        public static (string, int) BuildFilters(string filters)
        {
            string name = "";
            int statusId = -1;

            foreach (var clause in filters.Split(','))
            {
                var field = clause.Split('=');

                if (IsAllowedField(field[0]) && field[0].ToLower() == "name")
                {
                    name = field[1];
                    continue;
                }
                if (IsAllowedField(field[0]) && field[0].ToLower() == "statusid")
                {
                    statusId = int.Parse(field[1]);
                    continue;
                }

                throw new Exception("Invalid operation deteceted.");
            }

            return (name, statusId);
        }

        private static bool IsAllowedField(string field)
        {
            return Array.Exists(AllowedFieldFilters, e => e.ToLower() == field.ToLower());
        }
    }
}
