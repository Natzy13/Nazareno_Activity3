using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Strings
{
    public class UserReturnStrings
    {
    
        public static string displayReturnQuery(int loginID)
        {
            string displayReturnQuery = $@"
     SELECT 
    RH.RentalID,
    STUFF((
        SELECT ', ' + MI.Title + ' (x' + CAST(RD.Quantity AS VARCHAR) + ')'
        FROM RentalDetails RD
        INNER JOIN MediaItems MI ON RD.MediaID = MI.MediaID
        WHERE RD.RentalID = RH.RentalID
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TitlesWithQuantities,
    MIN(RD.RentalDate) AS RentalDate,
    SUM(RD.Quantity) AS TotalQuantity
FROM RentalHeader RH
INNER JOIN RentalDetails RD ON RH.RentalID = RD.RentalID
WHERE RH.UserID = {loginID} AND RD.IsReturned = 0
GROUP BY RH.RentalID
ORDER BY MIN(RD.RentalDate) DESC;";
            return displayReturnQuery;
        }

        public static string userReturnQuery = @"
DECLARE @maxRentalDays INT;
DECLARE @pricePerMedia DECIMAL(10, 2);
DECLARE @mediaID INT;
DECLARE @rentalDate DATETIME;
DECLARE @baseRentalFee DECIMAL(10, 2);
DECLARE @overdueFee DECIMAL(10, 2);
DECLARE @totalFee DECIMAL(10, 2);

-- Cursor to iterate over each media in the rental
DECLARE rental_cursor CURSOR FOR
SELECT MediaID, RentalDate, Quantity
FROM RentalDetails
WHERE RentalID = @rentalID AND IsReturned = 0;

OPEN rental_cursor;

FETCH NEXT FROM rental_cursor INTO @mediaID, @rentalDate, @quantityRent;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Get price and max rental days
    SELECT 
        @pricePerMedia = Price, 
        @maxRentalDays = MaxRentalDays
    FROM MediaItems
    WHERE MediaID = @mediaID;

    -- Base fee
    SET @baseRentalFee = @pricePerMedia * @quantityRent;

    -- Overdue fee calculation
    SET @overdueFee = 0;
    IF DATEDIFF(DAY, @rentalDate, GETDATE()) > @maxRentalDays
    BEGIN
        SET @overdueFee = (DATEDIFF(DAY, @rentalDate, GETDATE()) - @maxRentalDays) * @overdueChargePerDay * @quantityRent;
    END

    -- Total fee
    SET @totalFee = @baseRentalFee + @overdueFee;

    -- Update RentalDetails
    UPDATE RentalDetails
    SET 
        ReturnDate = GETDATE(),
        IsReturned = 1,
        QuantityReturned = @quantityRent,
        Fee = @baseRentalFee,
        ChargeFee = @overdueFee,
        TotalFee = @totalFee
    WHERE RentalID = @rentalID AND MediaID = @mediaID AND IsReturned = 0;

    -- Update stock
    UPDATE MediaItems
    SET AvailableCopies = AvailableCopies + @quantityRent
    WHERE MediaID = @mediaID;

    FETCH NEXT FROM rental_cursor INTO @mediaID, @rentalDate, @quantityRent;
END

CLOSE rental_cursor;
DEALLOCATE rental_cursor;";
    }
}
