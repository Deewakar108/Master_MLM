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
using System.IO;
using System.Drawing;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class E_pin_history : System.Web.UI.Page
    {
        #region global

        string status_g = "GENERATED";
        string status_d = "GIVEN";
        string status_u = "USED";
        string status_del = "DELETED";
        #endregion
        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;

                fetch_generated_pin();
                fetch_distributed_pin();
                fetch_used_pin();
                fetch_deleted_pin();
            }
        }

        private void fetch_deleted_pin()
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID, " + 
                        "(select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as " + 
                        "'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as " + 
                        "'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as " + 
                        "'Used_to_name'   from E_PIN_details where status='" + status_del + "'", coon);
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

        private void fetch_generated_pin()
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where status='" + status_g + "'", coon);
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

        private void fetch_distributed_pin()
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name1' from E_PIN_details where status='" + status_d + "'", coon);
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

        private void fetch_used_pin()
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select Epin,Date,Package,distributed_to,used_by,Used_to,Status,ID, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.distributed_to) as 'distributed_to_name',used_by, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.used_by) as 'used_by_name', Used_to, (select top 1 Member_name from Member_registration where Member_code=E_PIN_details.Used_to) as 'Used_to_name'   from E_PIN_details where status='" + status_u + "'", coon);
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
        #endregion
        #region pageevent
        protected void grd_epin_generated_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_generated.PageIndex = e.NewPageIndex;
            grd_epin_generated.DataBind();
            fetch_generated_pin();

        }

        protected void grd_epin_distributed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_distributed.PageIndex = e.NewPageIndex;
            grd_epin_distributed.DataBind();
            fetch_distributed_pin();

        }

        protected void grd_epin_used_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_used.PageIndex = e.NewPageIndex;
            grd_epin_used.DataBind();
            fetch_used_pin();
        }
        #endregion

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
            fetch_generated_pin();
            fetch_distributed_pin();
            fetch_used_pin();
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
