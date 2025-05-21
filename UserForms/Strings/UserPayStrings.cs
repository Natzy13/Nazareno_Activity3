using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms.Strings
{
    public class UserPayStrings
    {

        public static string payQuery = @"
SELECT
    RD.RentalDetailID,
    MI.Title + ' [' + MI.Format + ']' AS Title,
    RD.Quantity AS Quantity,
    MI.MaxRentalDays AS MaxRentalDays,
    RD.RentalDate,
    RD.Fee,
    RD.ChargeFee,
    RD.TotalFee
FROM RentalDetails RD
INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
WHERE RH.UserID = @userID
  AND RD.IsReturned = 0
  AND RD.IsPaid = 0
ORDER BY RD.RentalDate DESC;";

        public static string userReturnAndPayQuery = @"
-- 1. Mark rental detail as returned with pre-computed fees
UPDATE RentalDetails
SET 
    ReturnDate = GETDATE(),
    IsReturned = 1,
    Fee = @fee,
    ChargeFee = @chargeFee,
    TotalFee = @totalFee
WHERE RentalDetailID = @rentalDetailID AND IsReturned = 0;

-- 2. Update media stock
UPDATE MediaItems
SET AvailableCopies = AvailableCopies + @quantityRent
WHERE MediaID = (
    SELECT MediaID 
    FROM RentalDetails 
    WHERE RentalDetailID = @rentalDetailID
);

-- 3. Mark rental as paid
UPDATE RentalDetails
SET 
    IsPaid = 1,
    PaidDate = @paidDate,
    Cash = @cash,
    [Change] = @change
WHERE RentalDetailID = @rentalDetailID;
";
    }

}