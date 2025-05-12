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
       
        public static string payQuery = @"SELECT
    RH.RentalID,
    STUFF((
        SELECT ', ' + MI.Title + ' [' + MI.Format + '] (x' + CAST(RD.QuantityReturned AS VARCHAR) + ')'
        FROM RentalDetails RD
        INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
        WHERE RD.RentalID = RH.RentalID
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TitlesWithQuantities,
    SUM(RD.Fee) AS Subtotal,
    SUM(RD.ChargeFee) AS ChargeFee,
    SUM(RD.TotalFee) AS TotalFee,
    MIN(RD.RentalDate) AS RentalDate,
    MAX(RD.ReturnDate) AS ReturnDate,
    SUM(RD.QuantityReturned) AS QuantityReturned,
    STUFF((
        SELECT DISTINCT ', ' + CAST(MI.MaxRentalDays AS VARCHAR)
        FROM RentalDetails RD
        INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
        WHERE RD.RentalID = RH.RentalID
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS MaxRentalDays
FROM RentalHeader RH
INNER JOIN RentalDetails RD ON RH.RentalID = RD.RentalID
INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
WHERE RH.UserID = @userID
  AND RD.IsReturned = 1
  AND RD.IsPaid = 0
GROUP BY RH.RentalID
ORDER BY MAX(RD.ReturnDate) DESC;";

        public static string payRentalQuery = @"
    UPDATE RentalDetails
SET 
    IsPaid = 1,
    PaidDate = @paidDate,
    Cash = @cash,
    Change = @change
WHERE 
    RentalID = @rentalID;
";

    }

}
