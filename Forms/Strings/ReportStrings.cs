using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class ReportStrings
    {
        public static string queryReport = @"
        SELECT 
            Title, 
            AvailableCopies, 
            (TotalCopies - AvailableCopies) AS RentedCopies 
        FROM MediaItems
        WHERE IsAvailable = 1
        ORDER BY Title ASC;";
    }
}
