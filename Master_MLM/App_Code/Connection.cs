using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_MLM.App_Code
{
    public class Connection
    {
        public string connect_method()
        {
            string connectionstring = "";

            //Local
              //connectionstring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Project_work\2019\february\Ocean Health Pariwar\Master_MLM\Master_MLM\App_Data\OCEAN_HEALTH_PARIWAR.mdf;Integrated Security=True";
          
            //Server
            //connectionstring = @"Data Source=184.168.194.58;Integrated Security=False;User ID=oceanhealthmlm; Password=Ints@#2018; Connect Timeout=15;Encrypt=False;Packet Size=4096;";

            //New Server
            //connectionstring = @"Data Source=sg1-wsq1.a2hosting.com;Integrated Security=False;User ID=oceanhea_healthpariwar; Password=86p3f$hM;";
          
            //BC DB
            connectionstring = @"Data Source=sg1-wsq1.a2hosting.com;Integrated Security=False;User ID=oceanhea_new_ocean; Password=szj0O0~8;";

            return connectionstring;
        }
    }
}