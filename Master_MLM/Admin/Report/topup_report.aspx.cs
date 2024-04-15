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

namespace Master_MLM.Admin_87554b
{
    public partial class topup_report : System.Web.UI.Page
    {
        Important imp = new Important();
        int Start_iDate = 0;
        int End_iDate = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Start_iDate = int.Parse(ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + ddlStartDate.SelectedValue);
                End_iDate = int.Parse(ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + ddlEndDate.SelectedValue);
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Start_iDate = int.Parse(ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + ddlStartDate.SelectedValue);
            End_iDate = int.Parse(ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + ddlEndDate.SelectedValue);

            fill_datain_gridview();

        }

        private void fill_datain_gridview()
        {
            

            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);

            string sql = "select  * from TopUpMemberList t join Member_registration m on m.Member_code=t.MemberCode join E_PIN_details e on e.Epin=t.NewEPin order by t.id desc";

            sql = "select  * from (select  t.*, m.Mobile_number, m.Member_code, m.Member_name, m.Sponcer_code, e.Package, (Convert(int, (Convert(varchar, " + 
                  "Convert(datetime, t.ActivationDate, 103), 112)))) as Topup_Activation_iDate from TopUpMemberList t join Member_registration m on m.Member_code= " +
                  "t.MemberCode join E_PIN_details e on e.Epin=t.NewEPin) T where Topup_Activation_iDate between " + Start_iDate + " and " + End_iDate;

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                grd_view.DataSource = null;
                grd_view.DataBind();
                lbl_message.Text = "Member's Topup records does not exist.";
            }
            else
            {
                grd_view.Visible = true;
                lbl_message.Text = "Your Total Member's Topup is =" + rowcount.ToString(); ;
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
