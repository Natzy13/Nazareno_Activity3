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

        public static string createRentalHeaderQuery = @"
        INSERT INTO RentalHeader (UserID, RentalDate, TotalFee)
        VALUES (@userID, @rentalDate, @totalFee);
        SELECT SCOPE_IDENTITY();";

        public static string userRentQuery = @"
DECLARE @pricePerMedia DECIMAL(10, 2);
SELECT @pricePerMedia = Price FROM MediaItems WHERE MediaID = @mediaID;

DECLARE @format NVARCHAR(50);
SELECT @format = Format FROM MediaItems WHERE MediaID = @mediaID;

INSERT INTO RentalDetails (RentalID, MediaID, Format, RentalDate, Quantity, Fee)
VALUES (@rentalID, @mediaID, @format, @rentalDate, @quantity, @pricePerMedia);

UPDATE MediaItems 
SET AvailableCopies = AvailableCopies - @quantity 
WHERE MediaID = @mediaID;";

        public static string comboFilterQuery(string column, string value)
        {
            string filter = $@"
SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
FROM MediaItems 
WHERE AvailableCopies > 0 AND IsAvailable = 1 AND {column} = '{value}'";
            return filter;
        }

        public static string comboFilterMessage(string column, string value)
        {
            string message = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND IsAvailable = 1 AND {column} = '{value}'";
            return message;
        }

        public static string filterSearch(string value)
        {
            string searchFilter = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND IsAvailable = 1 AND TITLE LIKE '%{value}%'";
            return searchFilter;
        }
    }
}