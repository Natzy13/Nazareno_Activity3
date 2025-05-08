using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class UsersStrings
    {
        public static string getUsersQuery = "SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0";

        public static string activateUserQuery(int selectedUser)
        {
            string activateQuery = $"Update Users SET IsActive= 1 where ID = '{selectedUser}'";
            return activateQuery;
        }

        public static string editUserQuery(string name, string email, string gender, int selectedUser)
        {
            string editQuery = $"Update Users SET Name= '{name}',Email= '{email}',Gender= '{gender}' where ID = '{selectedUser}'";
            return editQuery;
        }

        public static string bitValueFilter(string selectedFilter)
        {
            string bitValue = selectedFilter == "Activated" ? "1" : "0";
            return bitValue;
        }

        public static string comboFilterMesage(string column, string value)
        {
            string statusText = (column == "IsActive" && value == "1") ? "Activated" :
                   (column == "IsActive" && value == "0") ? "Deactivated" : value;

            string message = column == "IsActive"
                ? $"No {statusText} user found."
                : $"No {value} user found.";

            return message;
        }

        public static string comboFilterQuery (string column, string value)
        {
            string comboQuery = $"SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0 AND {column} = '{value}'";
            return comboQuery;
        }

        public static string searchFilterQuery(string column, string value)
        {
            string condition = column == "ID"
               ? $"{column} = '{value}'"
               : $"{column} LIKE '%{value}%'";

            string tablequery = $"SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0 AND {condition}";
            return tablequery;
        }
    } 
}
