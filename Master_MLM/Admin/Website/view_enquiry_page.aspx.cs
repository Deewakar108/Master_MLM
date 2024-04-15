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
    public partial class view_enquiry_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_news(); // fetch enquiry details
            }
        }

        private void load_news()
        {


            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select * from contact_us order by id DESC ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "contact_us");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_manage_request.Visible = false;
                grd_view_enquiry.DataSource = null;
                grd_view_enquiry.DataBind();
                lbl_message.Text = "Sorry, Enquiry Information does not exist.";
            }
            else
            {

                pnl_manage_request.Visible = true; ;
                lbl_message.Text = "";
                ad.Fill(ds);
                grd_view_enquiry.DataSource = ds;
                grd_view_enquiry.DataBind();
            }

        }
        #region pageevent
        protected void grd_view_enquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            load_news();
            grd_view_enquiry.PageIndex = e.NewPageIndex;
            grd_view_enquiry.DataBind();
        }

        protected void grd_view_enquiry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblid = (Label)grd_view_enquiry.Rows[e.RowIndex].FindControl("lbl_id");
            string rowid = lblid.Text;
            delete_data(rowid);
            load_news(); // fetch enquiry details
        }

        private void delete_data(string rowid)
        {
            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select * from contact_us where id='" + rowid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "contact_us");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                //do nothing
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr.Delete();
                    break;
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
        }
        #endregion

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Enquiryreport.xls";
            export_to_excel(grd_view_enquiry, excelname);
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
            load_news(); // fetch enquiry details
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
