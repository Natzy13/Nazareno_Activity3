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
            string queryTotalRent = $@"
SELECT COUNT(DISTINCT RH.RentalID)
FROM RentalHeader RH
INNER JOIN RentalDetails RD ON RH.RentalID = RD.RentalID
WHERE RH.UserID = '{loginID}' AND RD.IsPaid = 1";
            return queryTotalRent ;
        }

        public static string queryTotalQuantity(int loginID)
        {
            string queryTotalQuantity = $@"
SELECT SUM(RD.Quantity)
FROM RentalDetails RD
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
WHERE RH.UserID = '{loginID}' AND RD.IsPaid = 1";
            return queryTotalQuantity ;
        }

        public static string queryTotalFee(int loginID) 
        {
            string queryTotalFee = $@"
SELECT SUM(RD.Fee)
FROM RentalDetails RD
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
WHERE RH.UserID = '{loginID}' AND RD.IsPaid = 1";
            return queryTotalFee ;
        }

        public static string queryTotalCharge(int loginID)
        {
            string queryTotalCharge = $@"
SELECT SUM(RD.ChargeFee)
FROM RentalDetails RD
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
WHERE RH.UserID = '{loginID}' AND RD.IsPaid = 1";
            return queryTotalCharge ;
        }

        public static string queryTotalAmount(int loginID)
        {
            string queryTotalAmount = $@"
SELECT SUM(RD.TotalFee)
FROM RentalDetails RD
INNER JOIN RentalHeader RH ON RD.RentalID = RH.RentalID
WHERE RH.UserID = '{loginID}' AND RD.IsPaid = 1";
            return queryTotalAmount ;
        }

        public static string queryUserHistory(int loginID)
        {
           string queryUserHistory = $@"
SELECT 
    RH.RentalID,
    STUFF((
        SELECT ', ' + MI.Title + ' [' + MI.Format + '] (x' + CAST(RD.Quantity AS VARCHAR) + ')'
        FROM RentalDetails RD
        INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
        WHERE RD.RentalID = RH.RentalID
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TitlesWithQuantities,
    MIN(RD.RentalDate) AS RentalDate,
    MAX(RD.ReturnDate) AS ReturnDate,
    STUFF((
        SELECT ', ' + CAST(RD.Fee AS VARCHAR)
        FROM RentalDetails RD
        WHERE RD.RentalID = RH.RentalID
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Fees,
    STUFF((
        SELECT ', ' + CAST(RD.ChargeFee AS VARCHAR)
        FROM RentalDetails RD
        WHERE RD.RentalID = RH.RentalID
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS ChargeFees,
    SUM(RD.TotalFee) AS TotalFee,
    MAX(RD.PaidDate) AS PaidDate
FROM RentalHeader RH
INNER JOIN RentalDetails RD ON RH.RentalID = RD.RentalID
WHERE RH.UserID = {loginID} AND RD.IsPaid = 1
GROUP BY RH.RentalID
ORDER BY MIN(RD.RentalDate) DESC;";
            return queryUserHistory;
        }
    }
}
