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
    public partial class Bank_payout_chart : System.Web.UI.Page
    {
        string scrpt;
        string format = "dd/MM/yyyy";
        string ClosingType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ClosingType = "'Referral','Sponsor','CarryForward'"; //imp.ClosingType;

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
                dtdatas.Columns.Add("Processingcharge");
                dtdatas.Columns.Add("Netmount");
                dtdatas.Columns.Add("Carryout");
                dtdatas.Columns.Add("Pinamount");
                dtdatas.Columns.Add("Grand_total");
                dtdatas.Columns.Add("Date");
                dtdatas.Columns.Add("Status");
                dtdatas.Columns.Add("SpecialPayoutAmount");
                ViewState["dtdatas"] = dtdatas;



                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;


                ArrayList ar = new ArrayList();
                ar = Otheruses.featch_year(dtm);
                ddl_s_year.DataSource = ar;
                ddl_s_year.DataBind();

                ddl_e_year.DataSource = ar;
                ddl_e_year.DataBind();


                find_alreadymadedate();
            }
        }

        private void find_alreadymadedate()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Satartdate,Enddate  from Bankpayout_made_details order by id DESC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Bankpayout_made_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_s_date.Enabled = true;
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

                ddl_s_date.Text = startdate.Substring(0, 2);
                ddl_s_month.Text = startdate.Substring(3, 2);
                ddl_s_year.Text = startdate.Substring(6, 4);

                ddl_s_date.Enabled = false;
                ddl_s_month.Enabled = false;
                ddl_s_year.Enabled = false;
            }
        }

        #region find payout

        protected void btn_find_Click(object sender, EventArgs e)
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(enddate, format, CultureInfo.InvariantCulture);
            int result = DateTime.Compare(d2, d1);

            if (result < 0)//d2 is less than d1
            {
                lbl_message.Text = "End Date cannot be Smaller Than Start Date";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                pnl_view.Visible = false;
            }
            else
            {
                find_membercode();
            }
        }

        private void find_membercode()
        {
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("Membername");
                dtdatas.Columns.Add("Bankname");
                dtdatas.Columns.Add("Branchname");
                dtdatas.Columns.Add("Accountno");
                dtdatas.Columns.Add("Ifsccode");
                //   dtdatas.Columns.Add("Binaryincome");
                //   dtdatas.Columns.Add("Teambonus");
                //    dtdatas.Columns.Add("Star_binary");
                dtdatas.Columns.Add("Totalamount");
                dtdatas.Columns.Add("Tds");
                dtdatas.Columns.Add("Cds");
                dtdatas.Columns.Add("Processingcharge");
                dtdatas.Columns.Add("Netmount");
                dtdatas.Columns.Add("Carryout");
                dtdatas.Columns.Add("Pinamount");
                dtdatas.Columns.Add("Grand_total");
                dtdatas.Columns.Add("Date");
                dtdatas.Columns.Add("Status");
                dtdatas.Columns.Add("SpecialPayoutAmount");
                ViewState["dtdatas"] = dtdatas;
            }
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration", coon);
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
                    string membercode = dt.Rows[i][3].ToString();
                    string membername = dt.Rows[i][4].ToString();
                    string bankname = dt.Rows[i][22].ToString();
                    string branchname = dt.Rows[i][23].ToString();
                    string accountno = dt.Rows[i][21].ToString();
                    string ifsccode = dt.Rows[i][24].ToString();
                    string package = dt.Rows[i][32].ToString();

                    find_payout(membercode, membername, bankname, branchname, accountno, ifsccode, package);
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

                save_data_in_bankpayout_details();
            }
        }

        Important imp = new Important();
        private double FindSpecialPayoutAmount(string MemberCode, string ClossingNumber)
        {
            double payout = 0;
            string sql = "select sum(cast(Payout as float)) as Payout from Referal_closing_special where MemberCode='" + MemberCode + "' and  ClosingNumber='" +
                            ClossingNumber + "' group by MemberCode, ClosingNumber";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return double.Parse(dt.Rows[0]["payout"].ToString()); }
            return payout;
        }

        private double FindSpecialPayoutAmount(string MemberCode, string StartDate, string EndDate)
        {
            double payout = 0;
            string sql = "select sum(cast(Payout as float)) as Payout from Referal_closing_special where MemberCode='" +
                MemberCode + "' and (convert(int, SUBSTRING([StartDate], 7, 4) + SUBSTRING([StartDate], 4, 2) +SUBSTRING([StartDate], 1, 2))) >=" + StartDate +
                " and (convert(int, SUBSTRING([EndDate], 7, 4) + SUBSTRING([EndDate], 4, 2) +SUBSTRING([EndDate], 1, 2))) <=" + EndDate + " group by MemberCode";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return double.Parse(dt.Rows[0]["payout"].ToString()); }
            return payout;
        }

        private void find_payout(string membercode, string membername, string bankname, string branchname, string accountno, string ifsccode, string package)
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(enddate, format, CultureInfo.InvariantCulture);
            int result = DateTime.Compare(d2, d1);

            string status = "NOTPAID";

            double carryAmount = 0;
            double payout = 0.0;
            double totalamount = 0.0;
            double tds = 0.0;
            double cds = 0.0;
            double Processingcharge = 0.0;
            double netamount = 0.0;
            double carryout = 0.0;
            double pinpayout = 0.0;
            double grandamount = 0.0;
            double daily_salary_tds = 0.0;
            double daily_salary_cds = 0.0;
            double daily_sdalary_netamount = 0.0;

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);

            SqlDataAdapter ad = new SqlDataAdapter("Select  sum(cast(Totalamount as float)) as Totalamount,sum(cast(Tds as float)) as Tds,sum(cast(Servicecharge as float)) as " +
                "Servicecharge,sum(cast(Final_amount as float)) as Final_amount,Member_code, sum(cast(carryAmount as float)) as carryAmount from payout where Member_code='" + membercode +
                "' and  ClosingType in (" + ClosingType + ") and Status='" + status + "'  and (CONVERT(DATETIME, Start_date, 103) BETWEEN CONVERT(DATETIME, '" + startdate +
                "', 103) AND CONVERT(DATETIME, '" + enddate + "', 103)) group by  Member_code", coon);

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
                string closing_number = "-";// dt.Rows[0]["Closingno"].ToString();

                payout = Convert.ToDouble(dt.Rows[0][0].ToString());
                tds = Convert.ToDouble(dt.Rows[0][1].ToString());
                cds = Convert.ToDouble(dt.Rows[0][2].ToString());
                netamount = Convert.ToDouble(dt.Rows[0][3].ToString());
                carryAmount = Convert.ToDouble(dt.Rows[0]["carryAmount"].ToString());
                //double SpecialPayoutAmount = FindSpecialPayoutAmount(membercode, startdate, enddate); //?? Is required group by...??
                double SpecialPayoutAmount = 0;// FindSpecialPayoutAmount(membercode, closing_number); //?? Update on 13/11/2017 By SKS.

                double daily_salary = find_daily_salary(membercode, status, startdate, enddate);

                daily_salary_tds = Convert.ToDouble(Session["tds"].ToString());
                daily_salary_cds = Convert.ToDouble(Session["cds"].ToString());
                daily_sdalary_netamount = Convert.ToDouble(Session["netamount"].ToString());

                Session.Remove("tds");
                Session.Remove("cds");
                Session.Remove("netamount");

                //totalamount = payout + daily_salary;
                totalamount = payout + daily_salary;
                netamount = netamount + daily_sdalary_netamount;
                //carryout = find_carryout(membercode); //OLD
                carryout = carryAmount; //SKS
                //pinpayout = find_pinpayout(membercode);
                grandamount = (netamount + carryout) - pinpayout + SpecialPayoutAmount;

                if (payout == 0)
                {

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
                    //drNewRow["Binaryincome"] = payout;
                    // drNewRow["Teambonus"] = teambonus;
                    // drNewRow["Star_binary"] = starbinary;
                    drNewRow["Totalamount"] = totalamount;
                    drNewRow["Tds"] = tds + daily_salary_tds;
                    drNewRow["Cds"] = cds + daily_salary_cds;
                    //drNewRow["Processingcharge"] = Processingcharge;
                    drNewRow["Netmount"] = netamount;
                    drNewRow["Carryout"] = carryout;
                    drNewRow["Pinamount"] = pinpayout;
                    drNewRow["Grand_total"] = grandamount;
                    drNewRow["Date"] = Session["today"].ToString();
                    drNewRow["Status"] = "NOTPAID";
                    drNewRow["SpecialPayoutAmount"] = SpecialPayoutAmount.ToString();

                    //add this new row to the Datatable and commit changes
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                }
            }
        }

        private double find_carryout_from_payout(string membercode)
        {
            double carryAmount = 0;

            string sql = "";
            DataTable dtTemp = imp.FillTable(sql);

            if (dtTemp.Rows.Count != 0)
            {

            }

            return carryAmount;
        }


        private double find_daily_salary(string membercode, string status, string startdate, string enddate)
        {
            double payout = 0.0;
            double tds = 0.0;
            double cds = 0.0;
            double netamount = 0.0;

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select sum(cast(Totalamount as float)) as Totalamount,sum(cast(Tds as float)) as Tds,sum(cast(Servicecharge as float)) as Servicecharge,sum(cast(Final_amount as float)) as Final_amount,Membercode from daily_member_salary where Membercode='" + membercode + "' and Status='" + status + "'  and   (CONVERT(DATETIME, pairdate, 103) BETWEEN CONVERT(DATETIME, '" + startdate + "', 103) AND CONVERT(DATETIME, '" + enddate + "', 103)) group by Membercode ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "daily_member_salary");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                Session["tds"] = tds;
                Session["cds"] = cds;
                Session["netamount"] = netamount;
            }

            else
            {
                payout = Convert.ToDouble(dt.Rows[0][0].ToString());
                tds = Convert.ToDouble(dt.Rows[0][1].ToString());
                cds = Convert.ToDouble(dt.Rows[0][2].ToString());
                netamount = Convert.ToDouble(dt.Rows[0][3].ToString());

                Session["tds"] = tds;
                Session["cds"] = cds;
                Session["netamount"] = netamount;
            }
            return payout;
        }

        private void update_data_in_below_fivehundred_table(string membercode)
        {
            string status = "NOTINCLUDED";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Below_fivehundredpayout where Membercode='" + membercode + "' and Status='" + status + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Below_fivehundredpayout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dr[16] = "INCLUDED";
                    dr[20] = Session["today"].ToString();
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    i++;
                }
            }
        }

        private void send_data_in_below_fivehundred_table(string membercode, string membername, string bankname, string branchname, string accountno, string ifsccode, double totalamount, double tds, double cds, double netamount, double carryout, double pinpayout, double grandamount, double Processingcharge)
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Below_fivehundredpayout", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Below_fivehundredpayout");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = membercode;
            dr[1] = membername;
            dr[2] = bankname;
            dr[3] = branchname;
            dr[4] = accountno;
            dr[5] = ifsccode;
            dr[6] = "0";
            dr[7] = "0";
            dr[8] = "0";
            dr[9] = totalamount;
            dr[10] = tds;
            dr[11] = cds;
            dr[12] = netamount;
            dr[13] = carryout;
            dr[14] = pinpayout;
            dr[15] = grandamount;
            dr[16] = "NOTINCLUDED";
            dr[17] = Session["today"].ToString();
            dr[18] = startdate;
            dr[19] = enddate;
            dr[22] = Processingcharge;
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }

        private double find_carryout(string membercode)
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;

            string status = "NOTINCLUDED";
            double amount = 0.0;

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select top 1 Grand_total from Below_fivehundredpayout where Membercode='" + membercode + "' and Status='" + status +
                                                   "' and Startdate !='" + startdate + "' and Enddate !='" + enddate + "' Order by ID DESC", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Below_fivehundredpayout");
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

        private double find_pinpayout(string membercode)
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;

            DateTime d1 = DateTime.ParseExact(startdate, format, CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(enddate, format, CultureInfo.InvariantCulture);
            int result = DateTime.Compare(d2, d1);

            string runningdate = "";
            double amount = 0.0;

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_wallete_purchase_pin where Membercode='" + membercode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_wallete_purchase_pin");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                for (int i = 0; i < rowcount; i++)
                {
                    runningdate = dt.Rows[i][4].ToString();
                    DateTime submitdate = DateTime.ParseExact(runningdate, format, CultureInfo.InvariantCulture);
                    int result2 = DateTime.Compare(submitdate, d1);

                    if (result2 >= 0)//submitdate date is greater and equal than d1
                    {
                        int result3 = DateTime.Compare(d2, submitdate);//laste date greater than and equal
                        if (result3 >= 0)
                        {
                            amount = amount + Convert.ToDouble(dt.Rows[i][3].ToString());
                        }
                    }
                }
            }
            return amount;
        }

        #endregion find payout

        #region save data

        private void save_data_in_bankpayout_details()
        {
            int grcount = grd_payout_list.Rows.Count;
            for (int j = 0; j < grcount; j++)
            {
                Label lbl_Member_code = (Label)grd_payout_list.Rows[j].FindControl("lbl_Member_code");
                Label lbl_Name = (Label)grd_payout_list.Rows[j].FindControl("lbl_Name");
                Label lbl_bank_name = (Label)grd_payout_list.Rows[j].FindControl("lbl_bank_name");
                Label lbl_Branch_name = (Label)grd_payout_list.Rows[j].FindControl("lbl_Branch_name");
                Label lbl_Account_number = (Label)grd_payout_list.Rows[j].FindControl("lbl_Account_number");
                Label lbl_Ifsc_code = (Label)grd_payout_list.Rows[j].FindControl("lbl_Ifsc_code");

                //Label lbl_Binaryincome = (Label)grd_payout_list.Rows[j].FindControl("lbl_Binaryincome");
                //Label lbl_Teambonus = (Label)grd_payout_list.Rows[j].FindControl("lbl_Teambonus");

                Label lbl_totamount = (Label)grd_payout_list.Rows[j].FindControl("lbl_totamount");
                Label lbl_Tds = (Label)grd_payout_list.Rows[j].FindControl("lbl_Tds");
                Label lbl_Cds = (Label)grd_payout_list.Rows[j].FindControl("lbl_Cds");
                //   Label lbl_Processingcharge = (Label)grd_payout_list.Rows[j].FindControl("lbl_Processingcharge");
                Label lbl_Netmount = (Label)grd_payout_list.Rows[j].FindControl("lbl_Netmount");
                Label lbl_Carryout = (Label)grd_payout_list.Rows[j].FindControl("lbl_Carryout");
                Label lbl_Pinamount = (Label)grd_payout_list.Rows[j].FindControl("lbl_Pinamount");
                Label lbl_Grand_total = (Label)grd_payout_list.Rows[j].FindControl("lbl_Grand_total");
                Label lbl_date = (Label)grd_payout_list.Rows[j].FindControl("lbl_date");
                Label lbl_status = (Label)grd_payout_list.Rows[j].FindControl("lbl_status");
                //Label lbl_SpecialPayoutAmount = (Label)grd_payout_list.Rows[j].FindControl("lbl_SpecialPayoutAmount");

                string membercode, membername, bankname, branchname, acountname, ifsccode, status, date;
                string totalamount, tds, cds, Processingcharge, netamount, carryout, pinamount, Grand_total, SpecialPayoutAmount;
                membercode = lbl_Member_code.Text;
                membername = lbl_Name.Text;
                bankname = lbl_bank_name.Text;
                branchname = lbl_Branch_name.Text;
                acountname = lbl_Account_number.Text;
                ifsccode = lbl_Ifsc_code.Text;
                SpecialPayoutAmount = "0";// lbl_SpecialPayoutAmount.Text;

                totalamount = lbl_totamount.Text;
                tds = lbl_Tds.Text;
                cds = lbl_Cds.Text;
                Processingcharge = "00";
                netamount = lbl_Netmount.Text;
                carryout = lbl_Carryout.Text;
                pinamount = lbl_Pinamount.Text;
                Grand_total = lbl_Grand_total.Text;
                status = lbl_status.Text;
                date = lbl_date.Text;

                send_data_into_bank_payut_chart(membercode, membername, bankname, branchname, acountname, ifsccode, totalamount,
                    tds, cds, Processingcharge, netamount, carryout, pinamount, Grand_total, status, date, SpecialPayoutAmount);
            }

            send_data_into_bankpayoutmade_details();
            find_alreadymadedate();
            lbl_message.Text = "Bank payout has been successfully made.";
            scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            //pnl_view.Visible = false;
        }

        private void send_data_into_bankpayoutmade_details()
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select *  from Bankpayout_made_details ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Bankpayout_made_details");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = startdate;
            dr[1] = enddate;
            dr[2] = Session["today"].ToString();
            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }

        private void send_data_into_bank_payut_chart(string membercode, string membername, string bankname, string branchname,
            string acountname, string ifsccode, string totalamount, string tds, string cds, string Processingcharge,
            string netamount, string carryout, string pinamount, string Grand_total, string status, string date, string SpecialPayoutAmount)
        {
            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Bank_payout_details where Membercode='" + membercode + "' and Startdate='" + startdate + "' and Enddate='" + enddate + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Bank_payout_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = membercode;
                dr[1] = membername;
                dr[2] = bankname;
                dr[3] = branchname;
                dr[4] = acountname;
                dr[5] = ifsccode;
                dr[6] = "0";
                dr[7] = "0";
                dr[8] = "0";
                dr[9] = totalamount;
                dr[10] = tds;
                dr[11] = cds;
                dr[12] = netamount;
                dr[13] = carryout;
                dr[14] = pinamount;
                dr[15] = Grand_total;
                dr[16] = status;
                dr[17] = date;
                dr[18] = startdate;
                dr[19] = enddate;
                dr[22] = Processingcharge;
                dr["SpecialPayOut"] = SpecialPayoutAmount;
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
