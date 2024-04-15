using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using Master_MLM.App_Code;

namespace Master_MLM.Admin_87554b
{
    public partial class View_da_mo_ye_joining : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetch_year();
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
        #region pageevent
        protected void rb_monthly_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = false;
            ddl_month.Visible = true;
            ddl_year.Visible = true;
        }

        protected void rb_yearly_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = false;
            ddl_month.Visible = false;
            ddl_year.Visible = true;
        }

        protected void rb_daily_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = true;
            ddl_month.Visible = true;
            ddl_year.Visible = true;
        }
        #endregion pageevent
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            finddata();
        }

        private void finddata()
        {
            if (rb_daily.Checked == true)
            {

                find_daily_joining();

            }
            else if (rb_monthly.Checked == true)
            {
                find_monthly_joining();

            }
            else if (rb_yearly.Checked == true)
            {
                find_yearly_joining();

            }
            else
            {

                lbl_message.Text = "Please select report type";
            }
        }

        private void find_daily_joining()
        {
            string searchindate = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
          
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter("select * from Member_registration where Date ='" + searchindate + "' and Member_code!='" + imp.AdminCode + "' ORDER BY CONVERT(DATETIME, Date, 103)", conn);
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

        private void find_monthly_joining()
        {
            string searchindate = ddl_month.Text + "/" + ddl_year.Text;
         
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter("select * from Member_registration where Date Like '%" + searchindate + "'  and Member_code!='" + imp.AdminCode + "' ORDER BY CONVERT(DATETIME, Date, 103)", conn);
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

        private void find_yearly_joining()
        {
            string searchindate = ddl_year.Text;
            string status = "VERIFY";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            // SqlDataAdapter ad_contactus = new SqlDataAdapter("select * from Member_registration where Date Like '%" + searchindate + "' and Status='" + status + "'", conn);
            SqlDataAdapter ad_contactus = new SqlDataAdapter("select * from Member_registration where Date Like '%" + searchindate + "' and Member_code!='" + imp.AdminCode + "' ORDER BY CONVERT(DATETIME, Date, 103)", conn);
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

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Totalmemberjoining.xls";
            export_to_excel(grd_view, excelname);
        }

        #region export_gridview_in_excel
        private void export_to_excel(GridView grd_view, string excelname)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", excelname));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_view.AllowPaging = false;
            finddata();
            grd_view.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int a = 0; a < grd_view.HeaderRow.Cells.Count; a++)
            {
                grd_view.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            foreach (GridViewRow gvrow in grd_view.Rows)
            {
                grd_view.BackColor = Color.White;
                if (j <= grd_view.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            grd_view.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion export_gridview_in_excel
    }
}
