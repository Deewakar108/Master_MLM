using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Data;
namespace Master_MLM.Admin_87554b
{
    public partial class Quarterly_tds_report : System.Web.UI.Page
    {
        My mycode = new My();
        string format1 = "dd/MM/yyyy";
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
            //ddl_e_year.DataSource = ar;
            //ddl_e_year.DataBind();

            string startdate = mycode.date();




            //ddl_e_date.Text = startdate.Substring(0, 2);
            //ddl_e_month.Text = startdate.Substring(3, 2);
            //ddl_e_year.Text = startdate.Substring(6, 4);



            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string s_date = dt.ToString(format1);
            DateTime d2 = DateTime.ParseExact(s_date, format1, CultureInfo.InvariantCulture);
            d2 = d2.AddMonths(-3);
            string end_date = d2.ToString(format1);
            DateTime d3 = DateTime.ParseExact(end_date, format1, CultureInfo.InvariantCulture);

            string s_datefinal = d3.ToString(format1);

            //ddl_s_date.Text ="01";
            //ddl_s_month.Text = s_datefinal.Substring(3, 2);
            ddl_s_year.Text = s_datefinal.Substring(6, 4);
        }


        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                find_tds_report();
            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }

        private void find_tds_report()
        {
            string query = "";
            //int date1 = Convert.ToInt32(ddl_s_year.Text + ddl_s_month.Text + ddl_s_date.Text);
            //int date2 = Convert.ToInt32(ddl_e_year.Text + ddl_e_month.Text + ddl_e_date.Text); 

            int date1 = 0;
            int date2 = 0;


            if (ddl_quarter.Text == "Q1")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "04" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "06" + "30");
            }
            else if (ddl_quarter.Text == "Q2")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "07" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "09" + "30");
            }
            else if (ddl_quarter.Text == "Q3")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "10" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "12" + "31");
            }
            else if (ddl_quarter.Text == "Q4")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "01" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "03" + "31");
            }

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter("Select py.Member_code,mr.Member_name,mr.Account_number,mr.Bank_name,mr.Branch_name,mr.Ifsc_code,mr.Pan_number from payout py join Member_registration mr on py.Member_code=mr.Member_code where    py.Idate>='" + date1 + "' and py.Idate<='" + date2 + "'  group by py.Member_code,mr.Member_name,mr.Account_number,mr.Bank_name,mr.Branch_name,mr.Ifsc_code,mr.Pan_number order by mr.Member_name  ", conn);

            //SqlDataAdapter ad_contactus = new SqlDataAdapter("mr.Member_name,py.Member_code,mr.Account_number,mr.Bank_name,mr.Branch_name,mr.Ifsc_code,mr.Pan_number from payout py join Member_registration mr on py.Member_code=mr.Member_code where py.Start_date like'%" + date + "' group by mr.Member_name,py.Member_code,mr.Account_number,mr.Bank_name,mr.Branch_name,mr.Ifsc_code,mr.Pan_number ORDER BY CONVERT(DATETIME, py.Start_date, 103)", conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "temp");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {
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
                    Label lblamount = (Label)grd_payout_list.Rows[j].FindControl("lbl_tot");
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

        protected void grd_payout_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //string tds = ((Label)e.Row.FindControl("lbl_tds")).Text;
                    //string ref_tds = ((Label)e.Row.FindControl("lbl_ref")).Text;

                    string Member_code = ((Label)e.Row.FindControl("lbl_Member_code")).Text;

                    double tds = find_tds_amount(Member_code);
                    double ref_tds = find_rtds(Member_code);
                    Label lblamount = (Label)e.Row.FindControl("lbl_tot");

                    if (tds == 0)
                    {
                        tds = 0;
                    }
                    if (ref_tds == 0)
                    {
                        ref_tds = 0;
                    }

                    lblamount.Text = Convert.ToString(tds + ref_tds).ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private double find_rtds(string Member_code)
        {
            int date1 = 0;
            int date2 = 0;


            if (ddl_quarter.Text == "Q1")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "04" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "06" + "30");
            }
            else if (ddl_quarter.Text == "Q2")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "07" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "09" + "30");
            }
            else if (ddl_quarter.Text == "Q3")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "10" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "12" + "31");
            }
            else if (ddl_quarter.Text == "Q4")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "01" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "03" + "31");
            }

            string query = "select sum(cast(Tds as float))   from Referal_income    where Member_code=" + Member_code + " and Idate>=" + date1 + " and Idate<=" + date2 + "  ";// and

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "temp");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {
                return 0;
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(dt.Rows[0][0].ToString());
                }


            }

        }

        private double find_tds_amount(string Member_code)
        {
            int date1 = 0;
            int date2 = 0;


            if (ddl_quarter.Text == "Q1")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "04" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "06" + "30");
            }
            else if (ddl_quarter.Text == "Q2")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "07" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "09" + "30");
            }
            else if (ddl_quarter.Text == "Q3")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "10" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "12" + "31");
            }
            else if (ddl_quarter.Text == "Q4")
            {
                date1 = Convert.ToInt32(ddl_s_year.Text + "01" + "01");
                date2 = Convert.ToInt32(ddl_s_year.Text + "03" + "31");
            }

            string query = "select sum(cast(py.Tds as float)) as totalts from payout py where   py.Member_code=" + Member_code + " and py.Idate>=" + date1 + " and py.Idate<=" + date2 + "  "; 

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "temp");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {
                return 0;
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(dt.Rows[0][0].ToString());
                }


            }




        }
    }
}