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
using System.Globalization;
using System.IO;
using System.Drawing;
using Master_MLM.App_Code;
using Master_MLM.AppCode;


namespace Master_MLM.Admin
{
    public partial class Royalty_Bank_payout_chart : System.Web.UI.Page
    {
        string scrpt;
        string format = "dd/MM/yyyy";
        string ClosingType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ClosingType = "'Royalty'"; //imp.ClosingType;

            Page.Server.ScriptTimeout = 36000;
            if (!IsPostBack)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("Membername");
                dtdatas.Columns.Add("Bankname");
                dtdatas.Columns.Add("Branchname");
                dtdatas.Columns.Add("Accountno");
                dtdatas.Columns.Add("Ifsccode");

                dtdatas.Columns.Add("Totalamount");
                dtdatas.Columns.Add("Tds");
                dtdatas.Columns.Add("Cds");

                dtdatas.Columns.Add("Netmount");
                dtdatas.Columns.Add("Carryout");

                dtdatas.Columns.Add("Grand_total");
                dtdatas.Columns.Add("Date");
                dtdatas.Columns.Add("Status");

                ViewState["dtdatas"] = dtdatas;

                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;


                ArrayList ar = new ArrayList();
                ar = Otheruses.featch_year(dtm);
                ddl_s_year.DataSource = ar;
                ddl_s_year.DataBind();


                find_alreadymadedate();
            }
        }

        private void find_alreadymadedate()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Satartdate,Enddate  from Royalty_Bankpayout_made_details order by id DESC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Bankpayout_made_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_s_month.Enabled = true;
                ddl_s_year.Enabled = true;
            }
            else
            {
                lbl_previous_date.Text = "Previous bank payout made duration is :-" + dt.Rows[0][0].ToString() + " " + "to" + " " + dt.Rows[0][1].ToString();
                string enddate = dt.Rows[0][1].ToString();
                string format2 = "dd/MM/yyyy";
                DateTime d2 = DateTime.ParseExact(enddate, format2, CultureInfo.InvariantCulture);
                d2 = d2.AddDays(1);
                string startdate = d2.ToString("dd/MM/yyyy");

                ddl_s_month.SelectedValue = startdate.Substring(3, 2);
                ddl_s_year.Text = startdate.Substring(6, 4);

                ddl_s_month.Enabled = false;
                ddl_s_year.Enabled = false;
            }
        }

        #region find payout

        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                find_membercode();
            }
            catch (Exception ex)
            {
                My.submitException1(ex.ToString());
            }
        }

        private void find_membercode()
        {
            string startdate = "01/" + ddl_s_month.Text + "/" + ddl_s_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            d1 = d1.AddMonths(1).AddDays(-1);
            string enddate = d1.ToString("dd/MM/yyyy");

            string payoutno = find_payputno();
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("Membername");
                dtdatas.Columns.Add("Bankname");
                dtdatas.Columns.Add("Branchname");
                dtdatas.Columns.Add("Accountno");
                dtdatas.Columns.Add("Ifsccode");

                dtdatas.Columns.Add("Totalamount");
                dtdatas.Columns.Add("Tds");
                dtdatas.Columns.Add("Cds");

                dtdatas.Columns.Add("Netmount");
                dtdatas.Columns.Add("Carryout");

                dtdatas.Columns.Add("Grand_total");
                dtdatas.Columns.Add("Date");
                dtdatas.Columns.Add("Status");

                ViewState["dtdatas"] = dtdatas;
            }
            string qry = " select Member_code,Member_name,Bank_name,Branch_name,Account_number,Ifsc_code,joining_package from Member_registration where Member_code in( select distinct Member_code from  payout  where Start_date='" + startdate + "' and  End_date='" + enddate + "' and Status='NOTPAID' and ClosingType='Royalty') ";

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter(qry, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                for (int i = 0; i < rowcount; i++)
                {
                    string membercode = dt.Rows[i]["Member_code"].ToString();
                    string membername = dt.Rows[i]["Member_name"].ToString();
                    string bankname = dt.Rows[i]["Bank_name"].ToString();
                    string branchname = dt.Rows[i]["Branch_name"].ToString();
                    string accountno = dt.Rows[i]["Account_number"].ToString();
                    string ifsccode = dt.Rows[i]["Ifsc_code"].ToString();
                    string package = dt.Rows[i]["joining_package"].ToString();

                    find_payout(membercode, membername, bankname, branchname, accountno, ifsccode, package, payoutno);
                }

                grd_payout_list.DataSource = ViewState["dtdatas"];
                grd_payout_list.DataBind();
                ViewState["dtdatas"] = null;
                double total = 0.0;
                int grcount = grd_payout_list.Rows.Count;
                for (int j = 0; j < grcount; j++)
                {
                    Label lblamount = (Label)grd_payout_list.Rows[j].FindControl("lbl_Grand_total");
                    if (lblamount.Text != "")
                    {
                        total = total + Convert.ToDouble(lblamount.Text);
                    }
                }
                lbl_total_paout.Text = total.ToString();

                save_data_in_bankpayout_details(payoutno);
            }
        }

        private string find_payputno()
        {
            string Payoutno = "Payoutno_1";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Payoutno from Royalty_Bankpayout_made_details Order by ID DESC", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Royalty_Bankpayout_made_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                string num = dt.Rows[0][0].ToString();
                int i = Convert.ToInt32(num.Substring(9));
                Payoutno = "Payoutno_" + (i + 1);
            }
            return Payoutno;
        }
        private void find_payout(string membercode, string membername, string bankname, string branchname, string accountno, string ifsccode, string package, string payoutno)
        {
            string startdate = "01/" + ddl_s_month.Text + "/" + ddl_s_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            d1 = d1.AddMonths(1).AddDays(-1);
            string enddate = d1.ToString("dd/MM/yyyy");

            string status = "NOTPAID";

            double carryAmount = 0;
            double payout = 0.0;

            double tds = 0.0;
            double cds = 0.0;

            double netamount = 0.0;
            double grandamount = 0.0;


            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);

            SqlDataAdapter ad = new SqlDataAdapter("Select  sum(cast(Totalamount as float)) as Totalamount,sum(cast(Tds as float)) as Tds,sum(cast(Servicecharge as float)) as " +
                "Servicecharge,sum(cast(Final_amount as float)) as Final_amount,Member_code, sum(cast(carryAmount as float)) as carryAmount from payout where Member_code='" + membercode +
                "' and  ClosingType in (" + ClosingType + ") and Status='" + status + "'  and  Start_date='" + startdate + "' and End_date='" + enddate + "' group by  Member_code", coon);

            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                pnl_view.Visible = true;

                payout = Convert.ToDouble(dt.Rows[0][0].ToString());
                tds = Convert.ToDouble(dt.Rows[0][1].ToString());
                cds = Convert.ToDouble(dt.Rows[0][2].ToString());
                netamount = Convert.ToDouble(dt.Rows[0][3].ToString());
                carryAmount = find_carryout(membercode);

                grandamount = netamount + carryAmount;

                if (grandamount < 500)
                {

                    if (grandamount > 0)
                    {
                        update_data_in_below_fivehundred_table(membercode, carryAmount.ToString());
                        send_data_in_below_fivehundred_table(membercode, membername, bankname, branchname, accountno, ifsccode, payout, tds, cds, netamount, carryAmount, grandamount, startdate, enddate);
                    }
                }
                else
                {

                    panel_show.Visible = false;
                    pnl_view.Visible = true;
                    DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                    DataRow drNewRow = dtDatas.NewRow();
                    drNewRow["Membercode"] = membercode;
                    drNewRow["Membername"] = membername;
                    drNewRow["Bankname"] = bankname;
                    drNewRow["Branchname"] = branchname;
                    drNewRow["Accountno"] = accountno;
                    drNewRow["Ifsccode"] = ifsccode;
                    drNewRow["Totalamount"] = payout;
                    drNewRow["Tds"] = tds;
                    drNewRow["Cds"] = cds;
                    drNewRow["Netmount"] = netamount;
                    drNewRow["Carryout"] = carryAmount;
                    drNewRow["Grand_total"] = grandamount;
                    drNewRow["Date"] = Session["today"].ToString();
                    drNewRow["Status"] = "NOTPAID";

                    //add this new row to the Datatable and commit changes
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                    update_data_in_below_fivehundred_table(membercode, carryAmount.ToString());
                }
            }
        }
        private void update_data_in_below_fivehundred_table(string membercode, string carryAmount)
        {
            string status = "NOTINCLUDED";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Royalty_Bank_payout_details_below_five_hundred where Membercode='" + membercode + "' and Status='" + status + "' and Grand_total='" + carryAmount + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Royalty_Bank_payout_details_below_five_hundred");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {
                    dr["Status"] = "INCLUDED";
                    dr["Paiddate"] = Session["today"].ToString();
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }
        private void send_data_in_below_fivehundred_table(string membercode, string membername, string bankname, string branchname, string accountno, string ifsccode, double totalamount, double tds, double cds, double netamount, double carryout, double grandamount, string startdate, string enddate)
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Royalty_Bank_payout_details_below_five_hundred", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Royalty_Bank_payout_details_below_five_hundred");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["Membercode"] = membercode;
            dr["Membername"] = membername;
            dr["Bankname"] = bankname;
            dr["Branchname"] = branchname;
            dr["Accountno"] = accountno;
            dr["Ifsccode"] = ifsccode;
            dr["Totalamount"] = totalamount;
            dr["Tds"] = tds;
            dr["Cds"] = cds;
            dr["Netmount"] = netamount;
            dr["Carryout"] = carryout;
            dr["Grand_total"] = grandamount;
            dr["Status"] = "NOTINCLUDED";
            dr["Date"] = Session["today"].ToString();
            dr["Startdate"] = startdate;
            dr["Enddate"] = enddate;
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }
        private double find_carryout(string membercode)
        {
            string status = "NOTINCLUDED";
            double amount = 0.0;

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select top 1 Grand_total from Royalty_Bank_payout_details_below_five_hundred where Membercode='" + membercode + "' and Status='" + status + "' Order by ID DESC", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Royalty_Bank_payout_details_below_five_hundred");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                amount = amount + Convert.ToDouble(dt.Rows[0][0].ToString());
            }
            return amount;
        }


        #endregion find payout

        #region save data

        private void save_data_in_bankpayout_details(string payoutno)
        {

            string startdate = "01/" + ddl_s_month.Text + "/" + ddl_s_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            d1 = d1.AddMonths(1).AddDays(-1);
            string enddate = d1.ToString("dd/MM/yyyy");

            int grcount = grd_payout_list.Rows.Count;
            for (int j = 0; j < grcount; j++)
            {
                Label lbl_Member_code = (Label)grd_payout_list.Rows[j].FindControl("lbl_Member_code");
                Label lbl_Name = (Label)grd_payout_list.Rows[j].FindControl("lbl_Name");
                Label lbl_bank_name = (Label)grd_payout_list.Rows[j].FindControl("lbl_bank_name");
                Label lbl_Branch_name = (Label)grd_payout_list.Rows[j].FindControl("lbl_Branch_name");
                Label lbl_Account_number = (Label)grd_payout_list.Rows[j].FindControl("lbl_Account_number");
                Label lbl_Ifsc_code = (Label)grd_payout_list.Rows[j].FindControl("lbl_Ifsc_code");


                Label lbl_totamount = (Label)grd_payout_list.Rows[j].FindControl("lbl_totamount");
                Label lbl_Tds = (Label)grd_payout_list.Rows[j].FindControl("lbl_Tds");
                Label lbl_Cds = (Label)grd_payout_list.Rows[j].FindControl("lbl_Cds");

                Label lbl_Netmount = (Label)grd_payout_list.Rows[j].FindControl("lbl_Netmount");
                Label lbl_Carryout = (Label)grd_payout_list.Rows[j].FindControl("lbl_Carryout");

                Label lbl_Grand_total = (Label)grd_payout_list.Rows[j].FindControl("lbl_Grand_total");
                Label lbl_date = (Label)grd_payout_list.Rows[j].FindControl("lbl_date");
                Label lbl_status = (Label)grd_payout_list.Rows[j].FindControl("lbl_status");

                string membercode, membername, bankname, branchname, acountname, ifsccode, status, date;
                string totalamount, tds, cds, netamount, carryout, Grand_total;
                membercode = lbl_Member_code.Text;
                membername = lbl_Name.Text;
                bankname = lbl_bank_name.Text;
                branchname = lbl_Branch_name.Text;
                acountname = lbl_Account_number.Text;
                ifsccode = lbl_Ifsc_code.Text;

                totalamount = lbl_totamount.Text;
                tds = lbl_Tds.Text;
                cds = lbl_Cds.Text;

                netamount = lbl_Netmount.Text;
                carryout = lbl_Carryout.Text;

                Grand_total = lbl_Grand_total.Text;
                status = lbl_status.Text;
                date = lbl_date.Text;

                send_data_into_bank_payut_chart(membercode, membername, bankname, branchname, acountname, ifsccode, totalamount,
                    tds, cds, netamount, carryout, Grand_total, status, date, startdate, enddate, payoutno);
            }

            send_data_into_bankpayoutmade_details(payoutno);
            find_alreadymadedate();
            lbl_message.Text = "Bank payout has been successfully made.";
            scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            //pnl_view.Visible = false;
        }

        private void send_data_into_bankpayoutmade_details(string payoutno)
        {

            string startdate = "01/" + ddl_s_month.Text + "/" + ddl_s_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            d1 = d1.AddMonths(1).AddDays(-1);
            string enddate = d1.ToString("dd/MM/yyyy");

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select *  from Royalty_Bankpayout_made_details ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Royalty_Bankpayout_made_details");
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.NewRow();
            dr[1] = startdate;
            dr[2] = enddate;
            dr[3] = Session["today"].ToString();
            dr[4] = payoutno;
            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }

        private void send_data_into_bank_payut_chart(string membercode, string membername, string bankname, string branchname, string acountname, string ifsccode, string totalamount,
                   string tds, string cds, string netamount, string carryout, string Grand_total, string status, string date, string startdate, string enddate, string payoutno)
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Royalty_Bank_payout_details where Membercode='" + membercode + "' and Startdate='" + startdate + "' and Enddate='" + enddate + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Royalty_Bank_payout_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Membercode"] = membercode;
                dr["Membername"] = membername;
                dr["Bankname"] = bankname;
                dr["Branchname"] = branchname;
                dr["Accountno"] = acountname;
                dr["Ifsccode"] = ifsccode;
                dr["Totalamount"] = totalamount;
                dr["Tds"] = tds;
                dr["Cds"] = cds;
                dr["Netmount"] = netamount;
                dr["Carryout"] = carryout;
                dr["Grand_total"] = Grand_total;
                dr["Status"] = status;
                dr["Date"] = date;
                dr["Startdate"] = startdate;
                dr["Enddate"] = enddate;
                dr["Paiddate"] = "";
                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
        }

        #endregion save data

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
