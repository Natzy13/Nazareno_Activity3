using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class VideoLibraryStrings
    {
        public static string displayMedia = "SELECT * FROM MediaItems WHERE IsAvailable = 1";

        public static string addMedia = "Insert into MediaItems(Title, Format, AvailableCopies, TotalCopies, Price, MaxRentalDays) Values (@title, @format, @available, @total, @price, @maxRent)";

        public static string editMedia = "Update MediaItems SET Title = @title, Format = @format, AvailableCopies = @available, TotalCopies = @total, Price = @price, MaxRentalDays = @maxRent WHERE MediaID = @mediaID";

        public static string removeMedia(int mediaID)
        {
            string queryRemoveMedia = "UPDATE MediaItems SET IsAvailable = 0 WHERE MediaID = '" + mediaID + "' ";
            return queryRemoveMedia;
        }

        public static string comboFilterQuery(string column, string value)
        {
            string filter = $"SELECT * FROM MediaItems WHERE IsAvailable = 1 AND {column} = '{value}'";
            return filter ;
        }

        public static string comboFilterMessage(string column, string value)
        {
            string message = column == "Format"
                    ? $"No {value} media found."
                    : $"No media found with a {value}-day maximum rental period.";
            return message ;
        }

        public static string filterSearch()
        {
            string searchFilter = $"SELECT * FROM MediaItems WHERE IsAvailable = 1 AND {filterSearchCondition}";
            return searchFilter ;
        }

        public static string filterSearchCondition(string column, string value)
        {
            string condition = column == "MediaID"
                ? $"{column} = '{value}'"
                : $"{column} LIKE '%{value}%'";
            return condition ;
        }

        
    }
}
