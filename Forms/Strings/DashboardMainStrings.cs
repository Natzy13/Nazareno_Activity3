using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class DashboardMainStrings
    {
        public static string queryTotalMedia = "SELECT COUNT(*) FROM MediaItems WHERE IsAvailable = 1";

        public static string queryTotalRentals = "SELECT COUNT(*) FROM RentalHeader";

        public static string queryTotalRegistered = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 0";

        public static string queryActiveRentals = "SELECT COUNT(*) FROM RentalDetails WHERE IsReturned = 0";

        public static string queryTotalRevenue = "SELECT SUM(TotalFee) FROM RentalDetails WHERE IsPaid = 1";

        public static string queryOverdueRent = @"
SELECT COUNT(*) 
FROM RentalDetails RD
INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
WHERE DATEDIFF(DAY, RD.RentalDate, GETDATE()) > MI.MaxRentalDays
AND RD.IsReturned = 0;";

        public static string historyQuery = @"
SELECT 
    RH.RentalID,
    U.Name,
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
WHERE RD.IsReturned = 1
GROUP BY RH.RentalID, U.Name
ORDER BY MAX(RD.ReturnDate) DESC;";
    }
}
