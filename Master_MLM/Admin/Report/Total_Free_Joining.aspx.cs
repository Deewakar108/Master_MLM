using System;
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

namespace Master_MLM.Admin_87554b
{
    public partial class Total_Free_Joining : System.Web.UI.Page
    {
        Important imp = new Important();
        thread_class tc = new thread_class();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            fill_datain_gridview();

        }

        public void BindPackage() 
        {

        }

        private void fill_datain_gridview()
        {
            string status = "Verified";
            string AdminCode = imp.AdminCode;
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code!='" + AdminCode + "' and Paidstatus='FREE'  order by Id ASC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                grd_view.DataSource = null;
                grd_view.DataBind();
                lbl_message.Text = "There is no member joining to free";
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

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            string sql = "select *, isnull((select top 1 Package_amount from Joining_package where Package_name=Package), 0) as package_amount, " +
                         "isnull((select top 1 RewardPoint from Joining_package where Package_name=Package), 0) as RewardPoint, isnull((select top 1 " +
                         "MatchingIncome from Joining_package where Package_name=Package), 0) as MatchingIncome from E_PIN_details where Status='GIVEN' " +
                         "and  Epin='" + txtEPin.Text + "'";

            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                lblPackageName.Text = dt.Rows[0]["Package"].ToString();
                hdfPackageAmount.Value = dt.Rows[0]["package_amount"].ToString();
                hdfPackageRewardPoint.Value = dt.Rows[0]["RewardPoint"].ToString();
                hdfMatchingIncome.Value = dt.Rows[0]["MatchingIncome"].ToString();
                hdfPackageID.Value = dt.Rows[0]["Package_id"].ToString();
                divEPinDetail.Visible = true;
                AlertMe("EPin verified successfully.");
            }
            else { AlertMe("Invalid EPin."); }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            string MemberCode = lblMemberCode.Text;

            string Joining_amount = hdfPackageAmount.Value;
            string joining_package = lblPackageName.Text;
            string Package_id = hdfPackageID.Value;
            string Pinno = txtEPin.Text;
            string MatchingIncome = hdfMatchingIncome.Value;
            string RewardPoint = hdfPackageRewardPoint.Value;

            DateTime dtToday = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            string Verification_date = dtToday.ToString("dd/MM/yyyy");
            string Verification_time = dtToday.ToString("hh:mm:ss tt");
            string Verification_idate = dtToday.ToString("yyyyMMdd");

            string sql = "update Member_registration set Status = 'Verified', Paidstatus = 'PAID', Joining_amount = '" + Joining_amount + "', joining_package = '" + joining_package + "', " +
                         "Package_id = '" + Package_id + "', Pinno = '" + Pinno + "', Verification_date = '" + Verification_date + "', Verification_time = '" + Verification_time + 
                         "', Verification_idate = '" + Verification_idate + "', MatchingIncome = '" + MatchingIncome + "', RewardPoint = '" + RewardPoint + 
                         "' where Member_code='" + MemberCode + "'";
            int i = imp.InsertUpdateDelete(sql);
            if (i == 0) { AlertMe("Try Again"); }
            else 
            {
                pnlActivateMember.Visible = false;
                
                fill_datain_gridview();
                AlertMe("Member successfully activated."); 
            }
        }

        public void AlertMe(string Message)
        {
            lblMessage.Text = Message;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "AlertMe();", true);
        }

        protected void grd_view_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsActivate") 
            {
                string MemberCode = e.CommandArgument.ToString();
                string sql = "select * from Member_registration  where Paidstatus='FREE' and  Member_code='" + MemberCode + "'";
                DataTable dt = imp.FillTable(sql);
                if (dt.Rows.Count != 0)
                {
                    lblMemberName.Text = dt.Rows[0]["Member_name"].ToString();
                    lblMemberCode.Text = dt.Rows[0]["Member_code"].ToString();
                    pnlActivateMember.Visible = true;
                }
                else { AlertMe("Invalid member selected."); }
            }
        }
    }
}