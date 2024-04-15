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

namespace Master_MLM.Member_4235profile
{
    public partial class Payout_chart : System.Web.UI.Page
    {
        string scrpt;
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
                    fill_giidview();
                }
            }
        }

        #region find data

        

        private void fill_giidview()
        {
            string MemberCode = Session["membercode"].ToString();

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            string sql = "Select Bank_name, Branch_name, Ifsc_code, Account_number, b.* from Bank_payout_details b left join  Member_registration m  " +
                         "on m.Member_code=b.Membercode  where b.Membercode='" + MemberCode + "'";
            //SqlDataAdapter ad = new SqlDataAdapter("Select * from Bank_payout_details where Startdate='" + ddl_s_date.Text + "' and Enddate ='" + ddl_e_date.Text + "' ", coon);
            SqlDataAdapter ad = new SqlDataAdapter(sql, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Bank_payout_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                lbl_message.Text = "Sorry! no data found.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                grd_payout_list.DataSource = null;
                grd_payout_list.DataBind();
                grd_payout_list.Visible = true;
            }
            else
            {
                pnl_view.Visible = true;
                grd_payout_list.DataSource = ds;
                grd_payout_list.DataBind();
                grd_payout_list.Visible = true;

                double total = 0.0;
                int rowcount2 = grd_payout_list.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {

                    Label lblamount = (Label)grd_payout_list.Rows[k].FindControl("lbl_Grand_total");
                    if (lblamount.Text != "")
                    {
                        total = total + Convert.ToDouble(lblamount.Text);
                    }
                }
                lbl_total_paout.Text = total.ToString();
            }

        }

        #endregion find data

        #region export_gridview_in_excel
        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "datas.xls";
            export_to_excel(grd_payout_list, excelname);
        }

        private void export_to_excel(GridView grd_view, string excelname)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", excelname));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_view.AllowPaging = false;

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
