using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace BogsySystem.UserForms.Services
{
    
    public class ReceiptFormServices
    {
        DBAccess ObjDBAccess = new DBAccess();
        private Bitmap memoryImage;

        public void receiptFormLoad(DataGridView grid, Label namelbl, Label cashlbl, 
            Label changelbl, Label datereceipt)
        {
            int RentalDetailID = UserPayServices.RentalDetailID;
                  
            try
            {
                DataTable userMediaHistory = userReceipt(RentalDetailID);

                if (userMediaHistory.Rows.Count > 0)
                {
                    grid.DataSource = userMediaHistory;
                    DataRow row = userMediaHistory.Rows[0];
                    string name = row["Name"].ToString();
                    decimal cash = row.Field<decimal>("Cash");
                    decimal change = row.Field<decimal>("Change");
                    DateTime date = row.Field<DateTime>("ReturnDate");

                    namelbl.Text = name;
                    cashlbl.Text = cash.ToString("F2");
                    changelbl.Text = change.ToString("F2");
                    datereceipt.Text = date.ToString();
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No History Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable userReceipt(int rentalDetailID)
        {
            DataTable userReceipt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReceiptFormString.queryReceipt(rentalDetailID),userReceipt);
            ObjDBAccess.closeConn();
            return userReceipt;
        }

        public Bitmap CaptureControl(Control control)
        {
            Bitmap memoryImage = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(memoryImage, new Rectangle(0, 0, control.Width, control.Height));
            return memoryImage;
        }
  
        public void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public void PrintForm(Control controlToPrint, Size? customSize = null)
        {
            // Save original size
            Size originalSize = controlToPrint.Size;

            // If custom size is provided, temporarily set it
            if (customSize.HasValue)
            {
                controlToPrint.Size = customSize.Value;
                controlToPrint.PerformLayout();
                controlToPrint.Refresh();
            }

            // Capture the resized or original control
            memoryImage = CaptureControl(controlToPrint);

            // Restore original size if it was changed
            if (customSize.HasValue)
            {
                controlToPrint.Size = originalSize;
                controlToPrint.PerformLayout();
                controlToPrint.Refresh();
            }

            // Set up the print document
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["RentalDetailID"].Visible = false;
            grid.Columns["Cash"].Visible = false;
            grid.Columns["Change"].Visible = false;
            grid.Columns["Name"].Visible = false;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ReturnDate"].HeaderText = "Return Date";
            grid.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalFee"].HeaderText = "Total";
            grid.Columns["TotalFee"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
