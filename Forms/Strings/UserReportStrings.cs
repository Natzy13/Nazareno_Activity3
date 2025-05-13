using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class UserReportStrings
    {

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

        public static string getUsersHistoryQuery(int selectedUser)
        {
            string getUsersHistoryQuery = $@"
    SELECT 
        RH.RentalID, 
        STUFF((
            SELECT ', ' + MI.Title + ' [' + MI.Format + '] (x' + CAST(RD.Quantity AS VARCHAR) + ')'
            FROM RentalDetails RD
            INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
            WHERE RD.RentalID = RH.RentalID
            FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TitlesWithQuantities,
        MIN(RD.RentalDate) AS RentalDate,
        MAX(RD.ReturnDate) AS ReturnDate
    FROM RentalHeader RH
    INNER JOIN RentalDetails RD ON RH.RentalID = RD.RentalID
    INNER JOIN Users U ON RH.UserID = U.ID
    WHERE RD.IsReturned = 1 AND RH.UserID = '{selectedUser}'
    GROUP BY RH.RentalID
    ORDER BY MAX(RD.ReturnDate) DESC;";
            return getUsersHistoryQuery;
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
