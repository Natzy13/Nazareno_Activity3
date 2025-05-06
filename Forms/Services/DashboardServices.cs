using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class DashboardServices 
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public int queryTotalMedia()
        {
            string queryTotalMedia = "SELECT COUNT(*) FROM MediaItems WHERE IsAvailable = 1";
            SqlCommand totalMedia = new SqlCommand(queryTotalMedia);
            int TotalMedia = Convert.ToInt32(ObjDBAccess.executeScalar(totalMedia));
            return TotalMedia;
        }

        public int queryTotalRentals()
        {
            string queryTotalRentals = "SELECT COUNT(*) FROM Rentals";
            SqlCommand totalRentals = new SqlCommand(queryTotalRentals);
            int TotalRentals = Convert.ToInt32(ObjDBAccess.executeScalar(totalRentals));
            return TotalRentals;
        }

        public int queryTotalRegistered()
        {
            string queryTotalRegistered = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 0";
            SqlCommand totalRegistered = new SqlCommand(queryTotalRegistered);
            int TotalRegistered = Convert.ToInt32(ObjDBAccess.executeScalar(totalRegistered));
            return TotalRegistered;
        }

        public int queryActiveRentals()
        {
            string queryActiveRentals = "SELECT COUNT(*) FROM RentalHistory WHERE IsReturned = 0";
            SqlCommand activeRentals = new SqlCommand(queryActiveRentals);
            int ActiveRentals = Convert.ToInt32(ObjDBAccess.executeScalar(activeRentals));
            return ActiveRentals;
        }

        public decimal queryTotalRevenue()
        {
            string queryTotalRevenue = "SELECT SUM(TotalFee) FROM RentalHistory WHERE IsPaid = 1";
            SqlCommand totalRevenue = new SqlCommand(queryTotalRevenue);
            object result = ObjDBAccess.executeScalar(totalRevenue);
            decimal TotalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalRevenue;
        }

        public int queryOverdueRent()
        {
            string queryOverdueRent = "SELECT COUNT(*) FROM Rentals INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID WHERE DATEDIFF(DAY, Rentals.RentalDate, GETDATE()) > MediaItems.MaxRentalDays;";
            SqlCommand overdueRent = new SqlCommand(queryOverdueRent);
            int OverdueRent = Convert.ToInt32(ObjDBAccess.executeScalar(overdueRent));
            return OverdueRent;
        }

        public DataTable GetRentalHistory()
        {
            string historyQuery = @"
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

            DataTable mediaDt = new DataTable();

            try
            {
                ObjDBAccess.readDatathroughAdapter(historyQuery, mediaDt);
                ObjDBAccess.closeConn();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve rental history.", ex);
            }

            return mediaDt;
        }
    }
}
