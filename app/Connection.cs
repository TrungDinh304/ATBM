using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATBM
{
    internal class ConnectionStr
    {
        public static string connectionStr = @"DATA SOURCE=localhost:1521/xe;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\Users\DELL\Oracle\network\admin;PERSIST SECURITY INFO=True;USER ID=SYS;PASSWORD=12345";
    }
}