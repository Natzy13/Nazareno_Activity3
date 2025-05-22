using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Strings
{
    public class ReceiptFormString
    {
        public static string queryReceipt(int rentalDetailID)
        {
            string queryUserHistory = $@"
SELECT 
    RD.RentalDetailID,
    U.Name,
    MI.Title + ' [' + MI.Format + ']' AS Title,
    RD.Quantity,
    RD.RentalDate,
    RD.ReturnDate,
    RD.TotalFee,
    RD.Cash,
    RD.Change
FROM RentalDetails RD
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
INNER JOIN Users U ON RH.UserID = U.ID
INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
WHERE RD.RentalDetailID = {rentalDetailID}
  AND RD.IsPaid = 1
  AND RD.IsReturned = 1
ORDER BY RD.ReturnDate DESC;";
            return queryUserHistory;
        }
    }
}
