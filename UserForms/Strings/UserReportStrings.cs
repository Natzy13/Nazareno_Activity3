using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Strings
{
    public class UserReportStrings
    {
        public static string queryTotalRent(int loginID)
        {
            string queryTotalRent = $"SELECT COUNT(*) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            return queryTotalRent ;
        }

        public static string queryTotalQuantity(int loginID)
        {
            string queryTotalQuantity = $"SELECT SUM(Quantity) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            return queryTotalQuantity ;
        }

        public static string queryTotalFee(int loginID) 
        {
            string queryTotalFee = $"SELECT SUM(Fee) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            return queryTotalFee ;
        }

        public static string queryTotalCharge(int loginID)
        {
            string queryTotalCharge = $"SELECT SUM(ChargeFee) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            return queryTotalCharge ;
        }

        public static string queryTotalAmount(int loginID)
        {
            string queryTotalAmount = $"SELECT SUM(TotalFee) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            return queryTotalAmount ;
        }

        public static string queryUserHistory(int loginID)
        {
            String queryUserHistory = $@"SELECT 
    MI.Title,
    RH.RentalDate,
    RH.ReturnDate,
    R.Quantity,
    RH.Fee,
    RH.ChargeFee,
    RH.TotalFee,
    RH.Cash,
    RH.PaidDate    
FROM RentalHistory RH
JOIN MediaItems MI ON RH.MediaID = MI.MediaID
JOIN Rentals R ON RH.RentalID = R.RentalID
WHERE RH.UserID = '{loginID}' AND RH.IsPaid = 1 ORDER BY RH.RentalDate DESC;";
            return queryUserHistory;
        }
    }
}
