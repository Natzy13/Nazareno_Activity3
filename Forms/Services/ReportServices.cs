using BogsySystem.Forms.Strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class ReportServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public void reportLoadFunction(DataGridView gridReport)
        {
            try
            {
                DataTable mediaReport = GetMediaReportQuery();

                if (mediaReport.Rows.Count > 0)
                {
                    gridReport.DataSource = mediaReport;
                    dataGridProperties(gridReport);
                }
                else MessageBox.Show("No media found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetMediaReportQuery()
        {           
            DataTable mediaReport = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.queryReport, mediaReport);
            return mediaReport;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["AvailableCopies"].HeaderText = "IN";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["RentedCopies"].HeaderText = "OUT";
            grid.Columns["RentedCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
