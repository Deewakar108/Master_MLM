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
    public partial class Member_Bank_Payment_History_List : System.Web.UI.Page
    {
        string query;
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_usermlm"] == null)
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

                    fetch_year();
                    todat_fill_data();

                }
            }
        }

       

        private void fetch_year()
        {
            Dictionary<string, object> dc1 = mycode.startyear_endyear();
            string Startyear = (String)dc1["Startyear"];
            string End_year = (String)dc1["End_year"];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            for (int i = Convert.ToInt32(Startyear); i <= Convert.ToInt32(End_year); i++)
            {

                ar.Add(i);
            }
            ddl_year.DataSource = ar;
            ddl_year.DataBind();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd/MM/yyyy");
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            ddl_day.Text = day;
            ddl_month.Text = month;
            ddl_year.Text = year;
        }

        private void todat_fill_data()
        {
            string searchindate = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;

            query = " select mr.Member_name,mr.Member_code, abp.Bankname,abp.Transaction_id,abp.Amount,abp.Slippath,abp.Date,abp.IFSCCode,abp.Time from  Member_registration mr join Update_bank_payment abp   on abp.Member_code=mr.Member_code where   abp.Date ='" + searchindate + "'  and mr.Member_code!='SSLIFE2018' ORDER BY CONVERT(DATETIME, abp.Date, 103)";
            final_fill_data(query);
        }

        private void final_fill_data(string query)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {

                pnl_view.Visible = false;
                lbl_message.Text = "Sorry Data Not Found";
                grd_view.DataSource = null;
                grd_view.DataBind();

            }
            else
            {
                pnl_view.Visible = true;
                lbl_message.Text = "";
                grd_view.DataSource = ds;
                grd_view.DataBind();



            }
        }

        #region pageevent
        protected void rb_monthly_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = false;
            ddl_month.Visible = true;
            ddl_year.Visible = true;
            pnl_view.Visible = false;
        }

        protected void rb_yearly_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = false;
            ddl_month.Visible = false;
            ddl_year.Visible = true;
            pnl_view.Visible = false;
        }

        protected void rb_daily_CheckedChanged(object sender, EventArgs e)
        {
            ddl_day.Visible = true;
            ddl_month.Visible = true;
            ddl_year.Visible = true;
            pnl_view.Visible = false;
        }
        #endregion pageevent



        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";
            fill_data1();

        }

        private void fill_data1()
        {
            if (rb_daily.Checked == true)
            {

                string searchindate = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;





                query = " select mr.Member_name,mr.Member_code, abp.Bankname,abp.Transaction_id,abp.Amount,abp.Slippath,abp.Date,abp.IFSCCode,abp.Time from  Member_registration mr join Update_bank_payment abp   on abp.Member_code=mr.Member_code where   abp.Date  like '%" + searchindate + "'  and mr.Member_code!='SSLIFE2018' ORDER BY CONVERT(DATETIME, abp.Date, 103)";

                final_fill_data(query);

            }
            else if (rb_monthly.Checked == true)
            {
                string searchindate = ddl_month.Text + "/" + ddl_year.Text;


                query = " select mr.Member_name,mr.Member_code, abp.Bankname,abp.Transaction_id,abp.Amount,abp.Slippath,abp.Date,abp.IFSCCode,abp.Time from  Member_registration mr join Update_bank_payment abp   on abp.Member_code=mr.Member_code where   abp.Date  like '%" + searchindate + "'  and mr.Member_code!='SSLIFE2018' ORDER BY CONVERT(DATETIME, abp.Date, 103)";

                final_fill_data(query);
            }
            else if (rb_yearly.Checked == true)
            {
                string searchindate = ddl_year.Text;


                query = " select mr.Member_name,mr.Member_code, abp.Bankname,abp.Transaction_id,abp.Amount,abp.Slippath,abp.Date,abp.IFSCCode,abp.Time from  Member_registration mr join Update_bank_payment abp   on abp.Member_code=mr.Member_code where   abp.Date  like '%" + searchindate + "'  and mr.Member_code!='SSLIFE2018' ORDER BY CONVERT(DATETIME, abp.Date, 103)";
                final_fill_data(query);

            }
            else
            {

                lbl_message.Text = "Please select  type";
            }
        }

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Bank_payment_status.xls";
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
            fill_data1();
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