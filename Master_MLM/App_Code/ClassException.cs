using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Master_MLM.App_Code;

namespace Master_MLM.AppCode
{
    public class ClassException
    {
        public void submit_exception(string exception)
        {
           
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from ExceptionDetails", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "ExceptionDetails");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr[0] = exception;
            dr[1] = (DateTime.UtcNow.AddHours(5).AddMinutes(30)).ToString("dd/MM/yyyy");
            dr[2] = (DateTime.UtcNow.AddHours(5).AddMinutes(30)).ToString("hh:mm tt");
            dr[3] = "";
            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);
           
        }
    }
}
