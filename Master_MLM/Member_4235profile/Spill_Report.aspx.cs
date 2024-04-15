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

namespace Master_MLM.Member_4235profile
{
    public partial class Spill_Report : System.Web.UI.Page
    {
        Important imp = new Important();
        string AdminCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCode = imp.AdminCode;

            if (Session["membercode"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            else
            {

                if (!IsPostBack)
                {
                    fetch_year();
                    fetch_today();


                }
            }
        }


        My mycode = new My();
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


        protected string hide_string(string str)
        {

            string val = "";
            if (str != "")
            {
                if (str.Length >= 10)
                {
                    val = str.Substring(0, 2) + "xxxxxxxx" + str.Substring((str.Length) - 2, 2);
                }
            }
            return val;
        }

        private void fetch_today()
        {
            string searchindate = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
            string queiry = "Select * from Member_registration where Date ='" + searchindate + "' and Referal_code!=Sponcer_code and Member_code!='" + AdminCode + "' and Referal_code='" + Session["membercode"].ToString() + "'  ORDER BY CONVERT(DATETIME, Date, 103)";
            bind_grid_view(queiry);
        }

        private void bind_grid_view(string queiry)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter(queiry, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {

                pnl_view.Visible = false;
                lbl_message.Text = "Sorry Data Not Found";
                grd_view.DataSource = null;
                grd_view.DataBind();

            }
            else
            {
                pnl_view.Visible = true;
                lbl_message.Text = "";
                grd_view.DataSource = ds;
                grd_view.DataBind();


            }
        }


        #region pageevent
        protected void rb_monthly_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = false;
            ddl_month.Visible = true;
            ddl_year.Visible = true;
            pnl_view.Visible = false;
        }

        protected void rb_yearly_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = false;
            ddl_month.Visible = false;
            ddl_year.Visible = true;
            pnl_view.Visible = false;
        }

        protected void rb_daily_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = true;
            ddl_month.Visible = true;
            ddl_year.Visible = true;
            pnl_view.Visible = false;
        }
        #endregion pageevent

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                finddata();
            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }

        private void finddata()
        {
            if (rb_daily.Checked == true)
            {
                string searchindate = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
                string queiry = "Select * from Member_registration where Date ='" + searchindate + "' and Referal_code!=Sponcer_code and Member_code!='" + AdminCode + "' and Referal_code='" + Session["membercode"].ToString() + "'  ORDER BY CONVERT(DATETIME, Date, 103)";
                bind_grid_view(queiry);
            }
            else if (rb_monthly.Checked == true)
            {
                string searchindate = ddl_month.Text + "/" + ddl_year.Text;
                string queiry = "Select * from Member_registration where Date Like '%" + searchindate + "%' and Referal_code!=Sponcer_code and Member_code!='" + AdminCode + "' and Referal_code='" + Session["membercode"].ToString() + "'  ORDER BY CONVERT(DATETIME, Date, 103)";
                bind_grid_view(queiry);
            }
            else if (rb_yearly.Checked == true)
            {
                string searchindate = ddl_year.Text;
                string queiry = "Select * from Member_registration where Date Like '%" + searchindate + "%' and Referal_code!=Sponcer_code and Member_code!='" + AdminCode + "' and Referal_code='" + Session["membercode"].ToString() + "'  ORDER BY CONVERT(DATETIME, Date, 103)";
                bind_grid_view(queiry);
            }
            else
            {

                lbl_message.Text = "Please select report type";
            }
        }




    }
}