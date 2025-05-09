using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Strings
{
    public class UserRentStrings
    {
       public static string displayMediaQuery = "SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays FROM MediaItems WHERE AvailableCopies > 0 AND IsAvailable = 1";

        public static string userRentQuery = @"
DECLARE @newRentalID INT;
DECLARE @pricePerMedia DECIMAL(10, 2);

-- Get the media price per piece
SELECT @pricePerMedia = Price FROM MediaItems WHERE MediaID = @mediaID;

-- Insert into Rentals with calculated fee and capture RentalID
INSERT INTO Rentals (UserID, MediaID, RentalDate, Quantity, Fee)
VALUES (@userID, @mediaID, @rentalDate, @quantity, @pricePerMedia * @quantity);

SET @newRentalID = SCOPE_IDENTITY();

-- Input the format in Rental History
DECLARE @format NVARCHAR(50);
SELECT @format = Format FROM MediaItems WHERE MediaID = @mediaID;

-- Insert into RentalHistory
INSERT INTO RentalHistory (RentalID, UserID, MediaID, Format, RentalDate, ReturnDate,IsReturned, Quantity, QuantityReturned , Fee , ChargeFee , TotalFee,IsPaid, PaidDate, Cash, Change)
VALUES (@newRentalID, @userID, @mediaID, @format,  @rentalDate, NULL, 0, @quantity, 0 , 0 , 0 , 0, 0, NULL, 0 , 0);

-- Update AvailableCopies
UPDATE MediaItems 
SET AvailableCopies = AvailableCopies - @quantity 
WHERE MediaID = @mediaID;";

        public static string comboFilterQuery(string column, string value)
        {
            string filter = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND {column} = '{value}'";
            return filter;
        }

        public static string comboFilterMessage(string column, string value)
        {
            string message = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND {column} = '{value}'";
            return message;
        }

        public static string filterSearch(string value)
        {
            string searchFilter = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND TITLE LIKE '%{value}%'";
            return searchFilter;
        }
    }
}
