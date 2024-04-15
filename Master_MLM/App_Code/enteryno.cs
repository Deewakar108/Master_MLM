using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Master_MLM.Admin.Repurchase
{
    public class enteryno
    {
        public string entery_no()
        {
            string code = "";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Repurchase_entry_no  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_entry_no");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                code = "EN1000";
                DataRow dr = dt.NewRow();
                dr[1] = code;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {

                code = dt.Rows[0][1].ToString();
                string product_cod = code.Substring(2);
                string mackcode = (Convert.ToInt32(product_cod.ToString()) + 1).ToString();
                string finalcode = "EN" + mackcode;
                code = finalcode;
                updatefinalcode(finalcode);



            }
            return code;
        }

        private void updatefinalcode(string finalcode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Repurchase_entry_no ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_entry_no");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[1] = finalcode;
                    break;
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
        }
    }
}
