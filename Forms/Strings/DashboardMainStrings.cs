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
       
        public static string historyQuery = $@"
SELECT 
    RD.RentalDetailID,
    U.Name,
    MI.Title + ' [' + MI.Format + ']' AS Title,
    RD.Quantity,
    RD.TotalFee,
    RD.RentalDate,
    RD.ReturnDate,
    RD.Cash,
    RD.Change
FROM RentalDetails RD
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
INNER JOIN Users U ON RH.UserID = U.ID
INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
WHERE RD.IsPaid = 1
  AND RD.IsReturned = 1
ORDER BY RD.ReturnDate DESC;";
    }
}
