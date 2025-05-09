using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Strings
{
    public class UserPayStrings
    {
        public static string payQuery = @"
SELECT
    Rentals.RentalID,
    MediaItems.Title,
    MediaItems.Format,
    MediaItems.Price AS PricePerPiece,
    RentalHistory.Fee,
    RentalHistory.ChargeFee,
    RentalHistory.TotalFee,
    RentalHistory.RentalDate,
    RentalHistory.ReturnDate,
    RentalHistory.QuantityReturned,
    MediaItems.MaxRentalDays
FROM RentalHistory 
JOIN Rentals  ON RentalHistory.RentalID = Rentals.RentalID
JOIN MediaItems ON RentalHistory.MediaID = MediaItems.MediaID
WHERE RentalHistory.UserID = @userID
  AND RentalHistory.IsPaid = 0
  AND RentalHistory.IsReturned = 1
ORDER BY RentalHistory.ReturnDate DESC;";

        public static string payRentalQuery = @"
    UPDATE RentalHistory 
    SET 
        IsPaid = 1,
        PaidDate = @paidDate,
        Cash = @cash,
        Change = @change
    WHERE 
        RentalID = @rentalID AND 
        UserID = @userID;
";

    }

}
