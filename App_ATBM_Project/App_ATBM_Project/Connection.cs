using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App_ATBM_Project
{
    internal class Connection
    {
        static public string username = "";
        static public string password = "";

        static public string ConnectionString = $@"DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID={username};PASSWORD={password}";

    }
}
