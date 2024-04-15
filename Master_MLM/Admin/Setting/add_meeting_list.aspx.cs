using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Master_MLM.App_Code;
namespace Master_MLM.Admin
{
    public partial class add_meeting_list : System.Web.UI.Page
    {
        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dt.ToString("dd/MM/yyyy");
                Session["today_date"] = date;
                string day = date.Substring(0, 2);
                string month = date.Substring(3, 2);
                string year = date.Substring(6, 4);
                ddl_day.Text = day;
                ddl_month.Text = month;
                ddl_year.Text = year;

            }
        }
        #endregion
        #region pagesubmit
        protected void btnupload_Click(object sender, EventArgs e)
        {
            upload_news_data();
        }
        My mycode = new My();
        private void upload_news_data()
        {
            if (ddl_day.Text == "Select" || ddl_month.Text == "Select" || ddl_year.Text == "Select")
            {
                lblmessage.Text = "Please Select Date";
            }
            else
            {
                // string upload_data = upload_file();
                lblmessage.Text = "";
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(connectionstring);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter("Select * from Training_schedule", conn);
                ad.Fill(ds, "Training_schedule");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["Membercode"] = "All";
                dr["Heading"] = txt_heading.Text;
                dr["Training_Details"] = txt_description.Text;
                dr["Location"] = txt_location.Text;
                dr["Date"] = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
                dr["Idate"] = ddl_year.Text + ddl_month.Text + ddl_day.Text;
                dr["Time"] = mycode.time();
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                lblmessage.Text = "Training Schedule is successfully added.";
                txt_heading.Text = "";
                txt_description.Text = "";

            }
        }
        #endregion
        
    }
}