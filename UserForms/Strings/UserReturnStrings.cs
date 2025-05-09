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
            string displayReturnQuery = $@"SELECT 
                              Rentals.RentalID, 
                              Rentals.MediaID, 
                              MediaItems.Title,
                              MediaItems.Format,
                              MediaItems.Price,
                              Rentals.RentalDate,
                              Rentals.Quantity,
                              MediaItems.MaxRentalDays                                                        
                          FROM Rentals
                          INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID
                          INNER JOIN RentalHistory ON RentalHistory.RentalID = Rentals.RentalID
                          WHERE Rentals.UserID = {loginID} AND RentalHistory.IsReturned = 0 ORDER BY Rentals.RentalDate DESC;";
            return displayReturnQuery;
        }

       
            public static string userReturnQuery = @"
DECLARE @maxRentalDays INT;
DECLARE @pricePerMedia DECIMAL(10, 2);
DECLARE @mediaID INT;

-- Get MediaID from Rentals table
SELECT @mediaID = MediaID FROM Rentals WHERE RentalID = @rentalID;

-- Get the price per media and max rental days from MediaItems table
SELECT 
    @pricePerMedia = Price, 
    @maxRentalDays = MaxRentalDays
FROM MediaItems
WHERE MediaID = @mediaID;

-- Calculate the Fee (price * quantity)
DECLARE @baseRentalFee DECIMAL(10, 2);
SET @baseRentalFee = @pricePerMedia * @quantityRent;

-- Calculate the overdue fee if applicable
DECLARE @overdueFee DECIMAL(10, 2) = 0;
IF DATEDIFF(DAY, (SELECT RentalDate FROM Rentals WHERE RentalID = @rentalID), GETDATE()) > @maxRentalDays
BEGIN
    SET @overdueFee = (DATEDIFF(DAY, (SELECT RentalDate FROM Rentals WHERE RentalID = @rentalID), GETDATE()) - @maxRentalDays) * @overdueChargePerDay * @quantityRent;
END

-- Update RentalHistory table 
UPDATE RentalHistory
SET 
    ReturnDate = GETDATE(),
    IsReturned = 1,
    QuantityReturned = @quantityRent,
    Fee = @baseRentalFee,
    ChargeFee = @overdueFee,
    TotalFee = @baseRentalFee + @overdueFee
WHERE RentalID = @rentalID;

-- Update AvailableCopies in MediaItems
UPDATE MediaItems
SET AvailableCopies = AvailableCopies + @quantityRent
WHERE MediaID = @mediaID;";
                 
    }
}
