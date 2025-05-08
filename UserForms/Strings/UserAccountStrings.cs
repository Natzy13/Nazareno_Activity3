using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Strings
{
    public class UserAccountStrings
    {
        public static string editUserQuery(string editfname, string editusername, string editpass, string editemail,
            string editgender, string ID)
        {
            string editQuery = "Update Users SET Name= '" + @editfname + "',Username= '" + @editusername + "',Password= '" + @editpass + "',Email= '" + @editemail + "',Gender= '" + @editgender + "' where ID = '" + ID + "'";
            return editQuery;
        }

        public static string deactUserQuery(string loginID)
        {
            string deactQuery= $"Update Users SET IsActive= 0 where ID = '{loginID}'";
            return deactQuery;
        }
    }
}
