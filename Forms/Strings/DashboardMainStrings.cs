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

        public static string queryTotalRentals = "SELECT COUNT(*) FROM Rentals";

        public static string queryTotalRegistered = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 0";

        public static string queryActiveRentals = "SELECT COUNT(*) FROM RentalHistory WHERE IsReturned = 0";

        public static string queryTotalRevenue = "SELECT SUM(TotalFee) FROM RentalHistory WHERE IsPaid = 1";

        public static string queryOverdueRent = "SELECT COUNT(*) FROM Rentals INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID WHERE DATEDIFF(DAY, Rentals.RentalDate, GETDATE()) > MediaItems.MaxRentalDays;";

        public static string historyQuery = @"
        SELECT 
            RH.RentalID,
            U.Name,
            M.Title,
            M.Format,
            RH.RentalDate,
            RH.ReturnDate 
        FROM RentalHistory RH
        JOIN MediaItems M ON RH.MediaID = M.MediaID
        JOIN Users U ON RH.UserID = U.ID
        WHERE RH.IsPaid = 1
        ORDER BY RH.ReturnDate DESC";
    }
}
