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
using System.Net;

namespace Master_MLM.Admin.Members
{
    public partial class kyc_member : System.Web.UI.Page
    {
        Important imp = new Important();

        protected void Page_Load(object sender, EventArgs e)
        {
            //fill_datain_gridview();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            fill_datain_gridview();

        }

        private void fill_datain_gridview()
        {

            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("select *, (select  count(*) as Total from Message_send_details where  Type='KYC' and Membercode=Member_code) as " +
                                                   "TotalSMSSend  from Member_registration where (Account_number='' or  Bank_name='' or Branch_name='' or Pan_number='' or Ifsc_code='') " +
                                                   "and  Member_code!='" + imp.AdminCode + "'  order by Id ASC", conn);
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

        protected void grd_view_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsSend")
            {
                string MemberCode = e.CommandArgument.ToString();
                string sql = "select * from Member_registration where  Member_code ='" + MemberCode + "'";
                DataTable dt = imp.FillTable(sql);
                if (dt.Rows.Count != 0)
                {
                    string MobileNo = dt.Rows[0]["Mobile_number"].ToString();
                    string MemberName = dt.Rows[0]["Member_name"].ToString();
                    string Message = "Dear  " + MemberName + ", Your KYC is not updated. Please update your KYC to receive payments. Thank you. " + imp.CompanyName + " " + imp.Url;
                    sms_sender.send_message(MobileNo, Message, MemberCode);   // send sms
                    //Reload All Gridview.
                    fill_datain_gridview();
                }
            }
        }



    }
}
