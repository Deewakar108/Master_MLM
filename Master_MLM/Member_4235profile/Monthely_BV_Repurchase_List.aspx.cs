using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Member_4235profile
{
    public partial class Monthely_BV_Repurchase_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                        string format1 = "dd/MM/yyyy";
                        string format2 = "yyyyMMdd";
                        DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                        string date = dtm.ToString(format1);
                        string queriy = "";
                        DateTime d2 = DateTime.ParseExact(date, format1, CultureInfo.InvariantCulture);
                        d2 = d2.AddMonths(-1);
                        string end_date = d2.ToString(format1);
                        string da1y = end_date.Substring(0, 2);
                        string month1 = end_date.Substring(3, 2);
                        string year1 = end_date.Substring(6, 4);

                        ddl_month.Text = month1;
                        ddl_year.Text = year1;

                        string day = date.Substring(0, 2);
                        string month = date.Substring(3, 2);
                        string year = date.Substring(6, 4);

                        hd_memberid.Value = Session["membercode"].ToString();

                        fill_data();

                    }
                }
            }
        }

         

        private void fill_data()
        {
            string format1 = "dd/MM/yyyy";
            string format2 = "yyyyMMdd";
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString(format1);

            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            string queriy = "";
            if (Convert.ToInt32(year + month) == Convert.ToInt32(ddl_year.Text + ddl_month.Text))
            {
               
                queriy = "select mr.Member_code,mr.Member_name,mr.Mobile_number,rpm_mb.Self,rpm_mb.Team from Re_purchase_member_bv_point_details rpm_mb join  Member_registration mr on  rpm_mb.Member_code=mr.Member_code  where rpm_mb.Member_code='" + hd_memberid.Value + "' and  rpm_mb.Member_code!='0'   order by rpm_mb.id ASC";
                final_fill_data(queriy);
            }
            else if (Convert.ToInt32(year + month) < Convert.ToInt32(ddl_year.Text + ddl_month.Text))
            {
                lbl_message.Text = "Please select less than current month";
                pnl_view.Visible = false;
            }
            else if (Convert.ToInt32(year + month) > Convert.ToInt32(ddl_year.Text + ddl_month.Text))
            {
                queriy = "select mr.Member_code,mr.Member_name,mr.Mobile_number,rpm_mb.Self,rpm_mb.Team from Re_purchase_member_bv_point_details_monthly_backup rpm_mb join  Member_registration mr on  rpm_mb.Member_code=mr.Member_code  where rpm_mb.Member_code='" + hd_memberid.Value + "' and  rpm_mb.Member_code!='0' and rpm_mb.Month='" + ddl_month.Text + "' and rpm_mb.Year='" + ddl_year.Text + "'  order by rpm_mb.id ASC";
                final_fill_data(queriy);
            } 
        }

        private void final_fill_data(string queriy)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter(queriy, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                grd_view.DataSource = null;
                grd_view.DataBind();
                lbl_message.Text = "There is no  member in repurchase  List";
            }
            else
            {
                grd_view.Visible = true;
                lbl_message.Text = " ";
                pnl_view.Visible = true;
                grd_view.DataSource = ds;
                grd_view.DataBind();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            fill_data();
        }
        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Monthely_BV_List.xls";
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
            fill_data();
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
            fill_data();
        }
    }
}