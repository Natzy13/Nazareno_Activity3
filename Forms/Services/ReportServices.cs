using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class ReportServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public DataTable GetMediaReport()
        {
            string queryReport = @"
        SELECT 
            Title, 
            AvailableCopies, 
            (TotalCopies - AvailableCopies) AS RentedCopies 
        FROM MediaItems 
        ORDER BY Title ASC;";

            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(queryReport, mediaDt);
            return mediaDt;
        }

        public DataTable GetUsers() 
        {
            String queryUsers = "SELECT ID, Name, Username FROM Users WHERE IsAdmin = 0";
            DataTable mediaDt2 = new DataTable();
            ObjDBAccess.readDatathroughAdapter(queryUsers, mediaDt2);
            return mediaDt2;
        }

        public DataTable GetUsersActiveRentals(int selectedUser)
        {
            string tablequery = $@"
SELECT 
    MediaItems.Title,
    Rentals.Quantity,
    Rentals.RentalDate    
FROM Rentals
INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID
LEFT JOIN RentalHistory ON Rentals.RentalID = RentalHistory.RentalID
WHERE Rentals.UserID = '{selectedUser}' AND RentalHistory.IsReturned = 0;";
            DataTable mediaDt3 = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt3);
            return mediaDt3;
        }

        public void DataGridProperties1(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["AvailableCopies"].HeaderText = "IN";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["RentedCopies"].HeaderText = "OUT";
            grid.Columns["RentedCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void DataGridProperties2(DataGridView grid)
        {
            grid.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void DataGridProperties3(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
