using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class SignUpStrings
    {
        public static string registerUserQuery = @"
        INSERT INTO Users (Name, Username, Password, Email, Gender, IsAdmin, IsActive) 
        VALUES (@name, @username, @password, @email, @gender, 0, 1);";
    }
}
