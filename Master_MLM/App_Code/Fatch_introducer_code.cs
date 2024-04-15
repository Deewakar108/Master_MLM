using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Master_MLM.AppCode
{
    public class Fatch_introducer_code
    {
        public string introducer_code(string Membercode)
        {
            string introducer = "";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Sponcer_code from Member_registration where Member_code='" + Membercode + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                introducer = "12345678";
                return introducer;
            }
            else
            {
                introducer = dt.Rows[0][0].ToString();
                return introducer;
            }
        }
         
    }
}