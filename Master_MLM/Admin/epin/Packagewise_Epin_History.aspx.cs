using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin
{
    public partial class Packagewise_Epin_History : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;
                Bind_Package();
            }
        }

        private void Bind_Package()
        {
            ArrayList ar = new ArrayList();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("select distinct Package from E_PIN_details where Package!='" + "" + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_package.DataSource = null;
                ddl_package.DataBind();
            }
            else
            {
                ar.Add("Please Select");
                foreach (DataRow dr in dt.Rows)
                {
                    ar.Add(dr[0].ToString());
                }
            }
            ddl_package.DataSource = ar;
            ddl_package.DataBind();
        }
        My mycode = new My();
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = "";
            if (txt_membercode.Text == "")
            {
                lbl_msg.Text = "Please enter MemberCode";
            }
            else if (ddl_package.Text == "Please Select")
            {
                lbl_msg.Text = "Please enter Package";
            }
            else
            {
                bool chkmembercode = mycode.valid_number(txt_membercode.Text);
                if (chkmembercode == false)
                {
                    lbl_msg.Text = "Please enter valid member code";
                }
                else
                {
                    lbl_msg.Text = "";
                    find_distributed_pin();
                    find_used_pin();
                    find_deleted_pin();
                }

                
            }

        }

        private void find_used_pin()
        {
            string status_u = "USED";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Status='" + status_u + "'and distributed_to='" + txt_membercode.Text + "' and Package='" + ddl_package.Text + "'", coon);
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
                lbl_message_u.Text = "Total- " + rowcount;
                pnl_view.Visible = true;
                grd_epin_used.DataSource = ds;
                grd_epin_used.DataBind();
            }
        }

        private void find_deleted_pin()
        {
            string status_del = "DELETED";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Status='" + status_del + "'and distributed_to='" + txt_membercode.Text + "' and Package='" + ddl_package.Text + "'", coon);
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
                lbl_message_del.Text = "Total- " + rowcount;
                pnl_view.Visible = true;
                grdDeleted.DataSource = ds;
                grdDeleted.DataBind();
            }
        }
        private void find_distributed_pin()
        {
            string status_d = "GIVEN";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Status='" + status_d + "' and distributed_to='" + txt_membercode.Text + "' and Package='" + ddl_package.Text + "'", coon);
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
                lbl_message_d.Text = "Total- " + rowcount;
                pnl_view.Visible = true;
                grd_epin_distributed.DataSource = ds;
                grd_epin_distributed.DataBind();
            }
        }


        #region pageevent

        protected void grd_epin_distributed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_distributed.PageIndex = e.NewPageIndex;
            grd_epin_distributed.DataBind();
            find_distributed_pin();

        }

        protected void grd_epin_used_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_used.PageIndex = e.NewPageIndex;
            grd_epin_used.DataBind();
            find_used_pin();
        }
        #endregion

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

            find_distributed_pin();
            find_used_pin();
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