using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class UsersServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public DataTable GetUsers()
        {
            string tablequery = "SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0";
            DataTable usersDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, usersDt);
            ObjDBAccess.closeConn();
            return usersDt;
        }

        public int deactUser(int selectedUser)
        {
            SqlCommand activateCommand = new SqlCommand($"Update Users SET IsActive= 1 where ID = '{selectedUser}'");
            int row = ObjDBAccess.executeQuery(activateCommand);
            ObjDBAccess.closeConn();
            return row;
        }

        public int editUser(string name, string email, string gender, int selectedUser) 
        {
            SqlCommand editCommand = new SqlCommand($"Update Users SET Name= '{name}',Email= '{email}',Gender= '{gender}' where ID = '{selectedUser}'");
            editCommand.Parameters.AddWithValue("Name", name);
            editCommand.Parameters.AddWithValue("Email", email);
            editCommand.Parameters.AddWithValue("Gender", gender);
            int row = ObjDBAccess.executeQuery(editCommand);
            return row;
        }

        public DataTable Filter(string column, string value) 
        {
            string tablequery = $"SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0 AND {column} = '{value}'";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void refreshDataGrid(DataGridView grid)
        {
            string tablequery = "SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0";
            DataTable usersDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, usersDt);
            ObjDBAccess.closeConn();
            grid.DataSource = usersDt;           
        }

        public void componentHide(
    Button activateBtn,
    Button editBtn,
    TextBox nameTxt,
    TextBox emailTxt,
    ComboBox genderTxt,
    Label nameLbl,
    Label emailLbl,
    Label genderLbl)
        {
            activateBtn.Visible = false;
            editBtn.Visible = false;
            nameTxt.Visible = false;
            emailTxt.Visible = false;
            genderTxt.Visible = false;
            nameLbl.Visible = false;
            emailLbl.Visible = false;
            genderLbl.Visible = false;
        }

        public void componentShow(
   Button activateBtn,
   Button editBtn,
   TextBox nameTxt,
   TextBox emailTxt,
   ComboBox genderTxt,
   Label nameLbl,
   Label emailLbl,
   Label genderLbl)
        {
            activateBtn.Visible = true;
            editBtn.Visible = true;
            nameTxt.Visible = true;
            emailTxt.Visible = true;
            genderTxt.Visible = true;
            nameLbl.Visible = true;
            emailLbl.Visible = true;
            genderLbl.Visible = true;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Email"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Gender"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
