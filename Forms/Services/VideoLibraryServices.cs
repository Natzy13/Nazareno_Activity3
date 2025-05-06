using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BogsySystem.Forms.Properties
{
    public class VideoLibraryServices
    {
        private DBAccess ObjDBAccess = new DBAccess();
        public DataTable displayMedia()
        {
            String tablequery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            return mediaDt;
        }

        public int addMedia(string title,string format, int available, int total, decimal price, int maxRent)
        {
            price = (format == "VCD") ? 25 : 50;
            SqlCommand insertMedia = new SqlCommand("Insert into MediaItems(Title, Format, AvailableCopies, TotalCopies, Price, MaxRentalDays) Values (@title, @format, @available, @total, @price, @maxRent)");
            insertMedia.Parameters.AddWithValue("@title", title);
            insertMedia.Parameters.AddWithValue("@format", format);
            insertMedia.Parameters.AddWithValue("@available", available);
            insertMedia.Parameters.AddWithValue("@total", total);
            insertMedia.Parameters.AddWithValue("@price", price);
            insertMedia.Parameters.AddWithValue("@maxRent", maxRent);
            int row = ObjDBAccess.executeQuery(insertMedia);
            return row;
        }

        public int editMedia(string displaytitle, string displayformat, int displaynewavailablecopies, int displaynewtotalcopies, decimal price, int displaymaxRent, int mediaID)
        {
            price = (displayformat == "VCD") ? 25 : 50;

            SqlCommand editCommand = new SqlCommand(
                "Update MediaItems SET Title = @title, Format = @format, AvailableCopies = @available, TotalCopies = @total, Price = @price, MaxRentalDays = @maxRent WHERE MediaID = @mediaID"
            );
            editCommand.Parameters.AddWithValue("@title", displaytitle);
            editCommand.Parameters.AddWithValue("@format", displayformat);
            editCommand.Parameters.AddWithValue("@available", displaynewavailablecopies);
            editCommand.Parameters.AddWithValue("@total", displaynewtotalcopies);
            editCommand.Parameters.AddWithValue("@price", price);
            editCommand.Parameters.AddWithValue("@maxRent", displaymaxRent);
            editCommand.Parameters.AddWithValue("@mediaID", mediaID);
            int row = ObjDBAccess.executeQuery(editCommand);
            return row;
        }

        public int removeMedia(int mediaID)
        {
            SqlCommand deleteMedia = new SqlCommand("UPDATE MediaItems SET IsAvailable = 0 WHERE MediaID = '" + mediaID + "' ");
            int row = ObjDBAccess.executeQuery(deleteMedia);
            return row;
        }

        public DataTable Filter(string column, string value)
        {
            String tablequery = $"SELECT * FROM MediaItems WHERE IsAvailable = 1 AND {column} = '{value}'";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void refreshDataGrid(DataGridView grid)
        {
            string tableQuery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tableQuery, mediaDt);
            grid.DataSource = mediaDt;
            dataGridProperties(grid);
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["MediaID"].HeaderText = "ID";
            grid.Columns["MediaID"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["AvailableCopies"].HeaderText = "Available";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalCopies"].HeaderText = "Total Quantity";
            grid.Columns["TotalCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["IsAvailable"].Visible = false;
        }

      
    }
}
