using BogsySystem.Forms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class DashboardServices 
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public int queryTotalMedia()
        {
            SqlCommand totalMedia = new SqlCommand(DashboardMainStrings.queryTotalMedia);
            int TotalMedia = Convert.ToInt32(ObjDBAccess.executeScalar(totalMedia));
            return TotalMedia;
        }

        public int queryTotalRentals()
        {
            SqlCommand totalRentals = new SqlCommand(DashboardMainStrings.queryTotalRentals);
            int TotalRentals = Convert.ToInt32(ObjDBAccess.executeScalar(totalRentals));
            return TotalRentals;
        }

        public int queryTotalRegistered()
        {
            SqlCommand totalRegistered = new SqlCommand(DashboardMainStrings.queryTotalRegistered);
            int TotalRegistered = Convert.ToInt32(ObjDBAccess.executeScalar(totalRegistered));
            return TotalRegistered;
        }

        public int queryActiveRentals()
        {          
            SqlCommand activeRentals = new SqlCommand(DashboardMainStrings.queryActiveRentals);
            int ActiveRentals = Convert.ToInt32(ObjDBAccess.executeScalar(activeRentals));
            return ActiveRentals;
        }

        public decimal queryTotalRevenue()
        {            
            SqlCommand totalRevenue = new SqlCommand(DashboardMainStrings.queryTotalRevenue);
            object result = ObjDBAccess.executeScalar(totalRevenue);
            decimal TotalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalRevenue;
        }

        public int queryOverdueRent()
        {
           
            SqlCommand overdueRent = new SqlCommand(DashboardMainStrings.queryOverdueRent);
            int OverdueRent = Convert.ToInt32(ObjDBAccess.executeScalar(overdueRent));
            return OverdueRent;
        }

        public DataTable GetRentalHistory()
        {
            

            DataTable mediaDt = new DataTable();

            try
            {
                ObjDBAccess.readDatathroughAdapter(DashboardMainStrings.historyQuery, mediaDt);
                ObjDBAccess.closeConn();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve rental history.", ex);
            }

            return mediaDt;
        }
    }
}
