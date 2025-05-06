using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms
{
   public partial class DashboardMain : Form
    {

        public void dataGridProperties()
        {
            dataGridHistory.Columns["RentalID"].Visible = false;

            dataGridHistory.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["RentalDate"].HeaderText = "Rent Date";
            dataGridHistory.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["ReturnDate"].HeaderText = "Return Date";
            dataGridHistory.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
