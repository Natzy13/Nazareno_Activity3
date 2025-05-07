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
            string tablequery = $@"
SELECT 
    MediaItems.Title,
    Rentals.Quantity,
    Rentals.RentalDate    
FROM Rentals
INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID
LEFT JOIN RentalHistory ON Rentals.RentalID = RentalHistory.RentalID
WHERE Rentals.UserID = '{selectedUser}' AND RentalHistory.IsReturned = 0;";

            return tablequery;
        }

        public static string filterSearch(string column, string value)
        {
            string condition = column == "ID"
                ? $"{column} = '{value}'"
                : $"{column} LIKE '%{value}%'";

            String tablequery = $"SELECT ID, Name, Username FROM Users WHERE IsAdmin = 0 AND {condition}";
            return tablequery;
        }
    }
}
