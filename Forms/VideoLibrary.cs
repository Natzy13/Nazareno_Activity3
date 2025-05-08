using BogsySystem.Forms.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BogsySystem.Forms
{
    public partial class VideoLibrary : Form
    {
        VideoLibraryServices services = new VideoLibraryServices();
 
        public VideoLibrary()
        {
            InitializeComponent();
        }

        private void VideoLibrary_Load(object sender, EventArgs e)
        {
            services.vidLoadFunction(filterbtn, editbtn, removebtn, dataGridVid);
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            services.AddButtonFunction(vidtitletxt, formatxt, maxrenttxt, quantitytxt, dataGridVid);
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            services.EditButtonFunction(vidtitletxt, formatxt, maxrenttxt, quantitytxt, dataGridVid);

        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            services.RemoveButtonFunction(dataGridVid, vidtitletxt, formatxt, maxrenttxt, quantitytxt);
        }

        private void filterbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.filterComboboxFunction(filterbtn,dataGridVid);
        }

        private void dataGridVid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.cellClickFunction(e, dataGridVid, addbtn, editbtn, removebtn, vidtitletxt, 
                formatxt, maxrenttxt, quantitytxt);
        }

        private void dataGridVid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridVid.ClearSelection();           
            services.clearDataFields(vidtitletxt,formatxt,maxrenttxt,quantitytxt);
            services.componentProperties(addbtn, editbtn,removebtn);
        }

        private void dataGridVid_Click(object sender, EventArgs e)
        {
            dataGridVid.ClearSelection();
            services.clearDataFields(vidtitletxt, formatxt, maxrenttxt, quantitytxt);
            services.componentProperties(addbtn, editbtn, removebtn);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchButtonFunction(dataGridVid, searchfilter, searchtxt);
        }
    }
}
