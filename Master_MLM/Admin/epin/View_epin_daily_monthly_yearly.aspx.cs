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
using Master_MLM.App_Code;
using System.Collections.Generic;

namespace Master_MLM.Admin
{
    public partial class View_epin_daily_monthly_yearly : System.Web.UI.Page
    {
        #region global

        string status_g = "GENERATED";
        string status_d = "GIVEN";
        string status_u = "USED";
        string status_del = "DELETED";

        #endregion
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetch_year();
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

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            find_data();

        }

        private void find_data()
        {
            string daily = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
            string monthly = ddl_month.Text + "/" + ddl_year.Text;
            string yearly = ddl_year.Text;
            if (rb_daily.Checked == true)
            {
                lbl_message.Text = "";
                pnl_view.Visible = true;
                find_daily_epin_history(daily);
            }
            else if (rb_monthly.Checked == true)
            {
                lbl_message.Text = "";
                pnl_view.Visible = true;
                find_monthly_epin_history(monthly);

            }
            else if (rb_yearly.Checked == true)
            {
                lbl_message.Text = "";
                pnl_view.Visible = true;
                find_yearly_epin_history(yearly);

            }
            else
            {
                lbl_message.Text = "";
                pnl_view.Visible = true;
                lbl_message.Text = "Please select report type";
            }
        }




        #region Daily wise
        private void find_daily_epin_history(string daily)
        {

            fetch_generated_pin_daily(daily);
            fetch_distributed_pin_daily(daily);
            fetch_used_pin_daily(daily);
            fetch_deleted_pin_daily(daily);
        }

        private void fetch_generated_pin_daily(string daily)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Date ='" + daily + "' and status='" + status_g + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_g.Text = "Pin does not exist.";
                grd_epin_generated.DataSource = null;
                grd_epin_generated.DataBind();
            }
            else
            {
                lbl_message_g.Text = "";
                grd_epin_generated.DataSource = ds;
                grd_epin_generated.DataBind();
            }
        }

        private void fetch_distributed_pin_daily(string daily)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name1' from E_PIN_details where distribution_date ='" + daily + "' and status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_d.Text = "Pin does not exist.";
                grd_epin_distributed.DataSource = null;
                grd_epin_distributed.DataBind();
            }
            else
            {
                lbl_message_d.Text = "";
                grd_epin_distributed.DataSource = ds;
                grd_epin_distributed.DataBind();
            }
        }
        private void fetch_used_pin_daily(string daily)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID,(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name' from E_PIN_details where used_date='" + daily + "' and status='" + status_u + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_u.Text = "Pin does not exist.";
                grd_epin_used.DataSource = null;
                grd_epin_used.DataBind();
            }
            else
            {
                lbl_message_u.Text = "";
                grd_epin_used.DataSource = ds;
                grd_epin_used.DataBind();
            }
        }
        private void fetch_deleted_pin_daily(string daily)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID,(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name' from E_PIN_details where Date='" + daily + "' and status='" + status_del + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_del.Text = "Pin does not exist.";
                grdDeleted.DataSource = null;
                grdDeleted.DataBind();
            }
            else
            {
                lbl_message_del.Text = "";
                grdDeleted.DataSource = ds;
                grdDeleted.DataBind();
            }
        }
        #endregion Daily wise
        #region Month wise
        private void find_monthly_epin_history(string monthly)
        {
            fetch_generated_pin_monthly(monthly);
            fetch_distributed_pin_monthly(monthly);
            fetch_used_pin_monthly(monthly);
            fetch_deleted_pin_monthly(monthly);
        }

        private void fetch_generated_pin_monthly(string monthly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Date like'%" + monthly + "' and status='" + status_g + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_g.Text = "Pin does not exist.";
                grd_epin_generated.DataSource = null;
                grd_epin_generated.DataBind();
            }
            else
            {
                lbl_message_g.Text = "";
                grd_epin_generated.DataSource = ds;
                grd_epin_generated.DataBind();
            }
        }

        private void fetch_distributed_pin_monthly(string monthly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name1' from E_PIN_details where distribution_date like'%" + monthly + "' and status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_d.Text = "Pin does not exist.";
                grd_epin_distributed.DataSource = null;
                grd_epin_distributed.DataBind();
            }
            else
            {
                lbl_message_d.Text = "";
                grd_epin_distributed.DataSource = ds;
                grd_epin_distributed.DataBind();
            }
        }

        private void fetch_used_pin_monthly(string monthly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID,(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name' from E_PIN_details where used_date like'%" + monthly + "' and status='" + status_u + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_u.Text = "Pin does not exist.";
                grd_epin_used.DataSource = null;
                grd_epin_used.DataBind();
            }
            else
            {
                lbl_message_u.Text = "";
                grd_epin_used.DataSource = ds;
                grd_epin_used.DataBind();
            }
        }

        private void fetch_deleted_pin_monthly(string monthly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID,(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name' from E_PIN_details where Date like'%" + monthly + "' and status='" + status_del + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_del.Text = "Pin does not exist.";
                grdDeleted.DataSource = null;
                grdDeleted.DataBind();
            }
            else
            {
                lbl_message_del.Text = "";
                grdDeleted.DataSource = ds;
                grdDeleted.DataBind();
            }
        }
        #endregion Month wise
        #region Year wise
        private void find_yearly_epin_history(string yearly)
        {
            fetch_generated_pin_yearly(yearly);
            fetch_distributed_pin_yearly(yearly);
            fetch_used_pin_yearly(yearly);
            fetch_deleted_pin_yearly(yearly);
        }

        private void fetch_generated_pin_yearly(string yearly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Date like'%" + yearly + "' and status='" + status_g + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_g.Text = "Pin does not exist.";
                grd_epin_generated.DataSource = null;
                grd_epin_generated.DataBind();
            }
            else
            {
                lbl_message_g.Text = "";
                grd_epin_generated.DataSource = ds;
                grd_epin_generated.DataBind();
            }
        }

        private void fetch_distributed_pin_yearly(string yearly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name1' from E_PIN_details where distribution_date like'%" + yearly + "' and status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_d.Text = "Pin does not exist.";
                grd_epin_distributed.DataSource = null;
                grd_epin_distributed.DataBind();
            }
            else
            {
                lbl_message_d.Text = "";
                grd_epin_distributed.DataSource = ds;
                grd_epin_distributed.DataBind();
            }
        }

        private void fetch_used_pin_yearly(string yearly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID,(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name' from E_PIN_details where used_date like'%" + yearly + "' and status='" + status_u + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_u.Text = "Pin does not exist.";
                grd_epin_used.DataSource = null;
                grd_epin_used.DataBind();
            }
            else
            {
                lbl_message_u.Text = "";
                grd_epin_used.DataSource = ds;
                grd_epin_used.DataBind();
            }
        }
        
        private void fetch_deleted_pin_yearly(string yearly)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID,(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name' from E_PIN_details where Date like'%" + yearly + "' and status='" + status_del + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_del.Text = "Pin does not exist.";
                grdDeleted.DataSource = null;
                grdDeleted.DataBind();
            }
            else
            {
                lbl_message_del.Text = "";
                grdDeleted.DataSource = ds;
                grdDeleted.DataBind();
            }
        }
        #endregion Year wise

        #region pageevent
        protected void grd_epin_generated_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_generated.PageIndex = e.NewPageIndex;
            grd_epin_generated.DataBind();
            find_data();

        }

        protected void grd_epin_distributed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_distributed.PageIndex = e.NewPageIndex;
            grd_epin_distributed.DataBind();
            find_data();

        }

        protected void grd_epin_used_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_used.PageIndex = e.NewPageIndex;
            grd_epin_used.DataBind();
            find_data();
        }
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

        protected void img_generated_Click(object sender, ImageClickEventArgs e)
        {
            string excelname = Session["today"].ToString() + "Generatedpin.xls";
            export_to_excel(grd_epin_generated, excelname);
        }



        protected void img_distributed_Click(object sender, ImageClickEventArgs e)
        {
            string excelname = Session["today"].ToString() + "Distributedpin.xls";
            export_to_excel(grd_epin_distributed, excelname);

        }

        protected void img_used_Click(object sender, ImageClickEventArgs e)
        {
            string excelname = Session["today"].ToString() + "Usedpin.xls";
            export_to_excel(grd_epin_used, excelname);
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
            find_data();
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
