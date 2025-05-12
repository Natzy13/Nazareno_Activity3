using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class ReportStrings
    {
        public static string queryReport = @"
        SELECT 
            Title, 
            AvailableCopies, 
            (TotalCopies - AvailableCopies) AS RentedCopies 
        FROM MediaItems
        WHERE IsAvailable = 1
        ORDER BY Title ASC;";

        public static string queryUsers = "SELECT ID, Name, Username FROM Users WHERE IsAdmin = 0";

        public static string getUsersActiveRentals(int selectedUser)
        {
            string getUsersActiveRentals = $@"
SELECT 
    MI.Title,
    RD.Quantity,
    RD.RentalDate
FROM RentalDetails RD
INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
WHERE RH.UserID = '{selectedUser}' AND RD.IsReturned = 0;";

            return getUsersActiveRentals;
        }

        public static string filterSearch(string column, string value)
        {
            string condition = column == "ID"
                ? $"{column} = '{value}'"
                : $"{column} LIKE '%{value}%'";

            string filterSearch = $"SELECT ID, Name, Username FROM Users WHERE IsAdmin = 0 AND {condition}";
            return filterSearch;
        }
    }
}
