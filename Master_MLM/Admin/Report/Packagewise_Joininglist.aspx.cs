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
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Packagewise_Joininglist : System.Web.UI.Page
    {
        Important imp = new Important();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_package();
            }
        }

        private void bind_package()
        {
            ArrayList ar = new ArrayList();
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct joining_package from Member_registration where joining_package!=''", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
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
                    string pkg = dr[0].ToString();
                    if (pkg == "0") { pkg = "FREE"; }
                    ar.Add(pkg);
                }
            }
            ddl_package.DataSource = ar;
            ddl_package.DataBind();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            fill_datain_gridview();

        }

        private void fill_datain_gridview()
        {
            string pkgName = ddl_package.SelectedValue;
            if (pkgName == "FREE") { pkgName = "0"; }

            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter(" Select * from Member_registration where Member_code!='" + imp.AdminCode + "' and joining_package='" + pkgName + "'  order by Id ASC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                grd_view.DataSource = null;
                grd_view.DataBind();
                lbl_message.Text = "There is no member joining to Paid";
            }
            else
            {
                grd_view.Visible = true;
                lbl_message.Text = "Your Total Joining is =" + rowcount.ToString(); ;
                pnl_view.Visible = true;
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
            fill_datain_gridview();
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

        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            grd_view.DataBind();
            fill_datain_gridview();
        }
    }
}