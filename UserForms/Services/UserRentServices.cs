using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace BogsySystem.UserForms.Services
{
    public class UserRentServices
    {
        DBAccess ObjDBAccess = new DBAccess();
        private string Title { get; set; }
        private int MediaID { get; set; }
        private int AvailableCopies { get; set; }

        public DataTable cartTable = new DataTable();

        public void userRentLoad(Label quantitylbl, NumericUpDown quantitytxt, Button rentbtn, DataGridView grid, 
            DataGridView cartGrid, DataTable cartTable)
        {
            componentHide(quantitylbl, quantitytxt, rentbtn, cartGrid);
            cartTableFunction(cartTable, cartGrid);
            try
            {
                DataTable displayRent = displayMediaQuery();

                if (displayRent.Rows.Count > 0)
                {
                    grid.DataSource = displayRent;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cartTableFunction(DataTable cartTable, DataGridView cartGrid)
        {
            cartTable.Columns.Add("MediaID", typeof(int));
            cartTable.Columns.Add("Title", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Subtotal", typeof(decimal));
            cartGrid.DataSource = cartTable;
            dataGridCartProperties(cartGrid);
        }

        public DataTable displayMediaQuery()
        {
            DataTable displayMediaQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.displayMediaQuery, displayMediaQuery);
            ObjDBAccess.closeConn();
            return displayMediaQuery;
        }

        public void addCartButtonFunction(DataGridView rentGrid, Label quantitylbl, NumericUpDown quantitytxt,
     DataTable cartTable, Label subtotaltxt, DataGridView cartGrid, Button rentbtn)
        {
            int mediaID = -1;
            int quantity = (int)quantitytxt.Value;
            decimal price = 0;
            int availableCopies = 0;      
            if (cartGrid.SelectedRows.Count > 0)
            {
                mediaID = Convert.ToInt32(cartGrid.SelectedRows[0].Cells["MediaID"].Value);
                foreach (DataGridViewRow row in rentGrid.Rows)
                {
                    if (!row.IsNewRow && Convert.ToInt32(row.Cells["MediaID"].Value) == mediaID)
                    {
                        availableCopies = Convert.ToInt32(row.Cells["AvailableCopies"].Value);
                        break;
                    }
                }

                DataRow existingRow = cartTable.Rows
                    .Cast<DataRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r["MediaID"]) == mediaID);

                if (existingRow != null)
                {
                    price = Convert.ToDecimal(existingRow["Price"]);

                    if (quantity > availableCopies)
                    {
                        MessageBox.Show("Not enough copies available!");
                        return;
                    }

                    existingRow["Quantity"] = quantity;
                    existingRow["Subtotal"] = price * quantity;
                }
            }

            else if (rentGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = rentGrid.SelectedRows[0];
                mediaID = Convert.ToInt32(selectedRow.Cells["MediaID"].Value);
                string title = selectedRow.Cells["Title"].Value.ToString();
                price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                quantity = 1;
                
                DataRow existingRow = cartTable.Rows
                    .Cast<DataRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r["MediaID"]) == mediaID);

                if (existingRow == null)
                {
                    cartTable.Rows.Add(mediaID, title, price, quantity, price * quantity);
                }
            }

            decimal totalSubtotal = cartTable.AsEnumerable().Sum(r => r.Field<decimal>("Subtotal"));
            subtotaltxt.Text = totalSubtotal.ToString("F2");
            addCartComponent(rentGrid, cartGrid, rentbtn, quantitytxt, quantitylbl);
        }

        public void clearCartButtonFunction(DataGridView cartGrid,Label subtotaltxt, Label quantitylbl,
            NumericUpDown quantitytxt, Button rentbtn)
        {
            if (cartGrid.SelectedRows.Count > 0)
            {
                int rowIndex = cartGrid.SelectedRows[0].Index;
                if (rowIndex >= 0 && rowIndex < cartTable.Rows.Count)
                {
                    cartTable.Rows.RemoveAt(rowIndex);
                }
                
                decimal totalSubtotal = cartTable.AsEnumerable().Sum(row => row.Field<decimal>("Subtotal"));
                subtotaltxt.Text = totalSubtotal.ToString("F2");
            }

           componentHide(quantitylbl, quantitytxt, rentbtn, cartGrid);
        }

        public int createRentalHeaderQuery(int userID, decimal totalFee)
        {
            SqlCommand cmd = new SqlCommand(UserRentStrings.createRentalHeaderQuery);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@rentalDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@totalFee", totalFee);
            object result = ObjDBAccess.executeScalar(cmd);
            ObjDBAccess.closeConn();
            return Convert.ToInt32(result);
        }

        public void rentButtonFunction(NumericUpDown quantitytxt, DataGridView grid, DataGridView cart,
            Label subtotaltxt)
        {
            List<string> rentedItems = new List<string>();
            int userID = int.Parse(LoginServices.ID);

            decimal totalFee = 0;
            foreach (DataGridViewRow row in cart.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    totalFee += price * quantity;
                }
            }

            int rentalID = createRentalHeaderQuery(userID, totalFee);

            foreach (DataGridViewRow row in cart.Rows)
            {
                if (!row.IsNewRow)
                {
                    int mediaID = Convert.ToInt32(row.Cells["MediaID"].Value);
                    string title = row.Cells["Title"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    int userRent = userRentQuery(rentalID, mediaID, quantity);

                    if (userRent > 0)
                    {
                        rentedItems.Add($"- {title} ({quantity} pcs)");
                        quantitytxt.Value = 1;
                    }
                    else
                    {
                        MessageBox.Show($"Error renting {title}. Operation aborted.");
                        return;
                    }
                }
            }

            MessageBox.Show("Successfully rented:\n\n" + string.Join("\n", rentedItems), "Rental Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cart.ClearSelection();
            ClearCart(cart, subtotaltxt);
            refreshDataGridQuery(grid);
        }

        public int userRentQuery(int rentalID, int mediaID, int quantity)
        {
            SqlCommand cmd = new SqlCommand(UserRentStrings.userRentQuery);
            cmd.Parameters.AddWithValue("@rentalID", rentalID);
            cmd.Parameters.AddWithValue("@mediaID", mediaID);
            cmd.Parameters.AddWithValue("@rentalDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            int result = ObjDBAccess.executeQuery(cmd);
            ObjDBAccess.closeConn();
            return result;
        }

        private void ClearCart(DataGridView grid, Label subtotaltxt)
        {

            if (grid.DataSource is DataTable dataTable)
            {
                dataTable.Clear();
            }
            else
            {
                grid.Rows.Clear();
            }
            subtotaltxt.Text = "0.00";
            grid.ClearSelection();
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, DataGridView cartGrid, Label quantitylbl, NumericUpDown quantitytxt)
        {
            try
            {               
                if (e.RowIndex >= 0)
                {                
                    grid.CurrentRow.Selected = true;
                    cartGrid.ClearSelection();
                    quantitylbl.Visible = false;
                    quantitytxt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void cartCellClickFunction(DataGridViewCellEventArgs e, DataGridView cartGrid, DataGridView grid, 
            NumericUpDown quantitytxt, Label quantitylbl)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = cartGrid.Rows[e.RowIndex];            
                cartGrid.CurrentRow.Selected = true;
                grid.ClearSelection();
                int selectedQuantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                quantitytxt.Value = selectedQuantity;
                componentShow(quantitylbl,quantitytxt);
            }
        }

        public void filterComboboxFunction(ComboBox filterbtn, DataGridView grid)
        {
            string selectedFilter = filterbtn.SelectedItem.ToString();

            if (selectedFilter == "All")
            {
                refreshDataGridQuery(grid);
            }
            else if (selectedFilter == "VCD" || selectedFilter == "DVD")
            {
                comboboxApplyFilter("Format", selectedFilter, grid);
            }
            else if (selectedFilter.StartsWith("Max Rent"))
            {
                // Extract the number of days from the filter text
                var match = Regex.Match(selectedFilter, @"\d+");
                if (match.Success)
                {
                    string days = match.Value;
                    comboboxApplyFilter("MaxRentalDays", days, grid);
                }
            }
        }

        public void comboboxApplyFilter(string column, string value, DataGridView grid)
        {
            try
            {
                DataTable comboboxFilter = comboboxFilterQuery(column, value);

                if (comboboxFilter.Rows.Count > 0)
                {
                    grid.DataSource = comboboxFilter;
                    dataGridProperties(grid);
                }
                else
                {
                    
                    MessageBox.Show(UserRentStrings.comboFilterMessage(column,value), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable comboboxFilterQuery(string column, string value)
        {
            DataTable comboboxFilterQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.comboFilterQuery(column, value), comboboxFilterQuery);
            ObjDBAccess.closeConn();
            return comboboxFilterQuery;
        }

        public void searchButtonFunction(DataGridView grid, TextBox searchtxt)
        {
            string filterValue = searchtxt.Text.Trim();

            if (filterValue.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    DataTable allMedia = displayMediaQuery();
                    grid.DataSource = allMedia;
                    dataGridProperties(grid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                return;
            }

            if (string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Please enter a title to search.");
                return;
            }

            try
            {
                DataTable filteredMedia = searchButtonQuery(filterValue);
                if (filteredMedia.Rows.Count > 0)
                {
                    grid.DataSource = filteredMedia;
                    dataGridProperties(grid);
                }
                else
                {
                    MessageBox.Show("No matching media found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public DataTable searchButtonQuery(string value)
        {           
            DataTable searchButtonQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.filterSearch(value), searchButtonQuery);
            ObjDBAccess.closeConn();
            return searchButtonQuery;
        }

        public void refreshDataGridQuery(DataGridView grid)
        {           
            DataTable refreshDataGrid = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.displayMediaQuery, refreshDataGrid);
            ObjDBAccess.closeConn();
            grid.DataSource = refreshDataGrid;
            dataGridProperties(grid);
        }

        public void componentHide(Label quantitylbl, Control quantitytxt, Button rentbtn, DataGridView cartGrid)
        {
            quantitylbl.Visible = false;
            quantitytxt.Visible = false;
            rentbtn.Visible = cartGrid.Rows.Count > 0;
        }
            public void componentShow(Label quantitylbl, Control quantitytxt)
        {
            quantitylbl.Visible = true;
            quantitytxt.Visible = true;
        }

        public void addCartComponent(DataGridView grid, DataGridView cartGrid, Button rentbtn,
            NumericUpDown quantitytxt, Label quantitylbl)
        {
            grid.ClearSelection();
            cartGrid.ClearSelection();
            rentbtn.Visible = cartTable.Rows.Count > 0;
            quantitytxt.Visible = false;
            quantitylbl.Visible = false;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["MediaID"].Visible = false;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["AvailableCopies"].HeaderText = "Available";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void dataGridCartProperties(DataGridView cartGrid)
        {
            cartGrid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            cartGrid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;
            cartGrid.Columns["MediaID"].Visible = false;
            cartGrid.Columns["Subtotal"].Visible = false;
            cartGrid.Columns["Price"].Visible = false;
        }
    }
}
