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
using System.Collections.Generic;
using Master_MLM.App_Code;

namespace Master_MLM.Admin.Payout
{
    public partial class datewise_tds_report : System.Web.UI.Page
    {
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetch_year();

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
            ddl_s_year.DataSource = ar;
            ddl_s_year.DataBind();

            ddl_e_year.DataSource = ar;
            ddl_e_year.DataBind();


        }
        
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (ddl_s_year.SelectedValue == "Select" || ddl_e_year.SelectedValue == "Select") { return; }
            find_tds_report();

        }

        private void find_tds_report()
        {
            string query = "";
            //string date = ddl_month.Text + "/" + ddl_year.Text;

            string FromDate = ddl_s_year.SelectedItem.Text + ddl_s_month.SelectedItem.Text + ddl_s_date.SelectedItem.Text;
            string ToDate = ddl_e_year.SelectedItem.Text + ddl_e_month.SelectedItem.Text + ddl_e_date.SelectedItem.Text;

            //query = "Select p.Member_code, p.Start_date, p.Totalamount,p.Tds,p.Servicecharge,p.Final_amount,p.Closing_date,p.Joining_date,p.Pair_no ,p.interval,mr.Member_name from payout p join Member_registration mr on p.Member_code=mr.Member_code where Start_date like'%" + date + "' ";

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);

            string sql = "";    // "Select py.Member_code,mr.Member_name,py.Tds,py.Start_date,mr.Account_number,mr.Bank_name,mr.Branch_name,mr.Ifsc_code,mr.Pan_number,mr.Account_number from payout py join Member_registration mr on py.Member_code=mr.Member_code where Start_date like'%" + date + "' ORDER BY CONVERT(DATETIME, Start_date, 103)";
            
            sql = "Select py.Joining_iDate, py.Member_code,mr.Member_name,py.Tds,mr.Account_number,mr.Bank_name,mr.Branch_name,mr.Ifsc_code,mr.Pan_number, " + 
                  "mr.Account_number from  (select Member_code, Joining_iDate, SUM(convert(float, Tds)) as Tds from (select *, (convert(int, " + 
                  "(substring(Joining_date, 7, 4)+(substring(Joining_date, 4, 2)+(substring(Joining_date, 1, 2)))))) as Joining_iDate from payout) T " + 
                  "group by Member_code, Joining_iDate) py join Member_registration mr on py.Member_code=mr.Member_code  where Joining_iDate " +
                  "between " + FromDate + " and  " + ToDate + "  order by Joining_iDate";

            SqlDataAdapter ad_contactus = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "Bank_payout_details");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {

                pnl_view.Visible = false;
                lbl_message.Text = "Sorry Data Not Found";
                grd_payout_list.DataSource = null;
                grd_payout_list.DataBind();

            }
            else
            {
                pnl_view.Visible = true;
                lbl_message.Text = "";
                grd_payout_list.DataSource = ds;
                grd_payout_list.DataBind();
                double total = 0.0;
                int grcount = grd_payout_list.Rows.Count;
                for (int j = 0; j < grcount; j++)
                {
                    Label lblamount = (Label)grd_payout_list.Rows[j].FindControl("lbl_tds");
                    if (lblamount.Text != "")
                    {
                        total = total + Convert.ToDouble(lblamount.Text);
                    }
                }
                lbl_total_paout.Text = total.ToString();

            }
        }

        #region export_gridview_in_excel
        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "tdsreport.xls";
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
            find_tds_report();
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

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}