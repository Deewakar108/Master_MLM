using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Collections;
using System.Data;
namespace Master_MLM.Admin
{
    public partial class Member_Notification_Send : System.Web.UI.Page
    {
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    fetch_year();
                }
                catch
                {
                }

            }
        }

        private void fetch_year()
        {
            Dictionary<string, object> dc1 = mycode.startyear_endyear();
            string Startyear = (String)dc1["Startyear"];
            string End_year = (String)dc1["End_year"];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            for (int i = Convert.ToInt32(Startyear); i <= Convert.ToInt32(End_year); i++)
            {

                ar.Add(i);
            }
            ddl_year.DataSource = ar;
            ddl_year.DataBind();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd/MM/yyyy");
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            ddl_day.Text = day;
            ddl_month.Text = month;
            ddl_year.Text = year;
        }

        #region pagesubmit
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                upload_news_data();
            }
            catch
            {
            }
        }

        private void upload_news_data()
        {
            if (ddl_day.Text == "Select" || ddl_month.Text == "Select" || ddl_year.Text == "Select")
            {
                lblmessage.Text = "Please Select Date";
            }
            else
            {

                lblmessage.Text = "";
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(connectionstring);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_news", conn);
                ad.Fill(ds, "Member_news");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["Membercode"] = "All";
                dr["Headline"] = (txt_description.Text).Replace("'", "&#8217;");
                dr["News"] = (txt_description.Text).Replace("'", "&#8217;"); 
                dr["Date"] = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
                dr["Idate"] = ddl_year.Text + ddl_month.Text + ddl_day.Text;
                dr["Time"] = mycode.time();
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                lblmessage.Text = "Notification is successfully uploaded.";
                txt_description.Text = "";

            }
        }
        #endregion
    }
}