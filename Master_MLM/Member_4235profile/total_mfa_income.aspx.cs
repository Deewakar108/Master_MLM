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

namespace Master_MLM.Member_4235profile
{
    public partial class total_mfa_income : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                    DataTable taskTable = new DataTable("TaskList");

                    string membercode = Session["membercode"].ToString();

                    FillIncome(membercode);
                }
            }
        }

        private void find_image(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);

            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                Session["membername"] = dt.Rows[0][4].ToString();
            }
        }

        private void FillIncome(string membercode)
        {

            string sql = "select (select Member_name from Member_registration m where m.Member_code=T.Member_code) as MemberName, * from (select  Member_code, " + 
                         "Status, ClosingType, Paid_date, sum(convert(float, Totalamount)) as Totalamount, sum(convert(float, Tds)) as TDS, " + 
                         "sum(convert(float, Servicecharge)) as Servicecharge, sum(convert(float, Final_amount)) as Final_amount from payout " +
                         "where Member_code='" + membercode + "' and ClosingType='MFA-Income' group by Member_code, Status, ClosingType, Paid_date) T";
            DataTable dtTemp = imp.FillTable(sql);

            grd_left.DataSource = dtTemp;
            grd_left.DataBind();
        }


        #region export_gridview_in_excel

        //protected void img_export_Click(object sender, ImageClickEventArgs e)
        //{
        //    DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        //    string date = dtm.ToString("dd/MM/yyyy");
        //    Session["today"] = date;
        //    string excelname = Session["today"] + "leftgenealogy.xls";
        //    export_to_excel(grd_left, excelname);
        //}


        //private void export_to_excel(GridView grd_view, string excelname)
        //{
        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", excelname));
        //    Response.ContentType = "application/ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    grd_view.AllowPaging = false;
        //    // fillgridview();
        //    grd_view.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //    for (int a = 0; a < grd_view.HeaderRow.Cells.Count; a++)
        //    {
        //        grd_view.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
        //    }
        //    int j = 1;
        //    foreach (GridViewRow gvrow in grd_view.Rows)
        //    {
        //        grd_view.BackColor = Color.White;
        //        if (j <= grd_view.Rows.Count)
        //        {
        //            if (j % 2 != 0)
        //            {
        //                for (int k = 0; k < gvrow.Cells.Count; k++)
        //                {
        //                    gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
        //                }
        //            }
        //        }
        //        j++;
        //    }
        //    grd_view.RenderControl(htw);
        //    Response.Write(sw.ToString());
        //    Response.End();


        //}
        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    /* Verifies that the control is rendered */
        //}
        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        //    string date = dtm.ToString("dd/MM/yyyy");
        //    Session["today"] = date;
        //    string excelname = Session["today"] + "rightgenealogy.xls";
        //}
        #endregion export_gridview_in_excel

        protected void grd_left_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lblPaid_date");
                Button btn = (Button)e.Row.FindControl("btnPay");
                if (lbl.Text == "0") { lbl.Text = ""; btn.Visible = false; }
                else { btn.Visible = false; }
            }
        }
       
    }
}