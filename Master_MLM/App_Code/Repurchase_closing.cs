using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Master_MLM.App_Code
{
    public class Repurchase_closing
    {
        Important imp = new Important();
        public bool IsClosingInProcess()
        {
            string sql = "select * from  Global  where  id='1'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                if (dtTemp.Rows[0]["ClosingStatus"].ToString() == "Complete") { return true; }
            }
            return false;

        }
        public bool IsClosingExist(string Start_iDate, string End_iDate)
        {
            string sql = "select * from Repurchase_closin_date where  I_Start_date='" + Start_iDate + "' and I_End_date='" + End_iDate + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
        public void UpdateClosingStatus(string closingNumber, string Status)
        {
            string sql = "update Global set ClosingStatus = '" + Status + "' where id='1'";
            int i = imp.InsertUpdateDelete(sql);
        }
        public bool StartClosing(string StartDate, string EndDate, string ClosingNumber, string ClosingDate, string Closing_iDate, string DeleteID,
                               string MonthValue, string Year)
        {
            bool status = false;
            try
            {
                AddIn_Closin_Table(StartDate, EndDate, ClosingDate, ClosingNumber, DeleteID, "InProcess");

                find_member_between_date(StartDate, EndDate, ClosingNumber, DeleteID);
                find_all_member_code(ClosingNumber, DeleteID, StartDate, EndDate);
                Repurchase_royalty_closing(ClosingNumber, DeleteID, StartDate, EndDate);

                UpdateClosingStatusInClosingTable(DeleteID,ClosingNumber, "Complete");

                status = true;

            }
            catch (Exception ex)
            {
                status = false;
                imp.InsertException(ex.ToString(), "Repurchase_closing_Form.aspx");
            }
            return status;
        }
        private void AddIn_Closin_Table(string StartDate, string EndDate, string ClosingDate, string ClosingNumber, string DeleteID, string ClosingStatus)
        {
            string Idate = imp.ConvertStringTo_iDate(ClosingDate);
            int Closing_idate = use.fetch_idate(ClosingDate);
            string I_Start_date = imp.ConvertStringTo_iDate(StartDate);
            string I_End_date = imp.ConvertStringTo_iDate(EndDate);

            string sql = @"insert into Repurchase_closin_date(Start_date,End_date,Closingno,Deleteid,Closing_date,Closing_idate,I_Start_date,I_End_date,ClosingStatus)
                            values ('" + StartDate + "','" + EndDate + "','" + ClosingNumber + "','" + DeleteID + "','" + ClosingDate + "','" + Closing_idate + "','" + I_Start_date + "','" + I_End_date + "','" + ClosingStatus + "');";
            int i = imp.InsertUpdateDelete(sql);
        }
        private void UpdateClosingStatusInClosingTable(string DeleteID, string ClosingNumber, string Status)
        {
            string sql = "update Repurchase_closin_date set ClosingStatus = '" + Status + "' where Closingno='" + ClosingNumber + "' and Deleteid='" + DeleteID + "'";
            int i = imp.InsertUpdateDelete(sql);
        }

        My use = new My();
        private void find_member_between_date(string StartDate, string EndDate, string ClosingNumber, string DeleteID)
        {
            int startdate1 = Convert.ToInt32(use.fetch_idate(StartDate));
            int enddate1 = Convert.ToInt32(use.fetch_idate(EndDate));

            string sql = "select RSM.Membercode,MR.Sponcer_code,MR.Position,sum(cast(RSM.TotalBV as float)) as TotalBV from Re_sell_member_bill_wise  RSM join Member_registration MR on RSM.Membercode=MR.Member_code where RSM.Idate >=" + startdate1 + " and RSM.Idate <=" + enddate1 + "  group by RSM.Membercode,MR.Sponcer_code,MR.Position";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string membercode = dt.Rows[i][0].ToString().ToUpper();
                    string introducercode = dt.Rows[i][1].ToString().ToUpper();
                    string position = dt.Rows[i][2].ToString();
                    double point = Convert.ToDouble(dt.Rows[i][3].ToString());

                    self_commission(StartDate, EndDate, ClosingNumber, DeleteID, membercode, point);
                    send_data_to_daily_child_table(introducercode, position, ClosingNumber, DeleteID, point);

                }
            }
        }
        private void self_commission(string StartDate, string EndDate, string ClosingNumber, string DeleteID, string membercode, double point)
        {
            string Closing_date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string Idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            double payout = 0;
            payout = point * 10 / 100;

            if (payout != 0.0)
            {
                double tds = 0.0, cdf = 0.0, tds_amount = 0.0, admin_charges = 0.0, after_admin = 0.0;
                tds = 5;
                cdf = 10;
                tds_amount = Math.Round((payout * tds / 100), 2);
                admin_charges = Math.Round((payout * cdf / 100), 2);

                after_admin = Math.Round((payout - (tds_amount + admin_charges)), 2);
                string qry = @"insert into Repurchase_payout(Member_code,Start_date,End_date,Totalamount,Tds,Servicecharge,Final_amount,Closing_date,Status,Pair_no,Deleteid,Closingno,Idate,Income_type)
                        values ('" + membercode + "','" + StartDate + "','" + EndDate + "','" + payout + "','" + tds_amount + "','" + admin_charges + "','" + after_admin + "','" + Closing_date + "','NOTPAID','" + point + "','" + DeleteID + "','" + ClosingNumber + "',N'" + Idate + "','SELF INCOME');";
                int i = imp.InsertUpdateDelete(qry);
            }
        }

        #region BV_1_isto_1_matching_CLosing
        private void send_data_to_daily_child_table(string Membercode, string position, string ClosingNumber, string DeleteID, double point)
        {

            string Closing_date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            int idate = Convert.ToInt32(DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd"));

            double leftcount = 0.0, rightcount = 0.0;
            // if introducer is first or company code then we will do nothing
            if (string.Compare(Membercode, "12345678", true) == 0)
            {
            }
            else
            {
                //search for introducer in table with that date.
                Connection con = new Connection();
                string constring = con.connect_method();
                SqlConnection conn = new SqlConnection(constring);
                SqlDataAdapter ad = new SqlDataAdapter("select * from Repurchase_Daily_child_table where Membercode='" + Membercode + "' and Idate =" + idate + "", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Repurchase_Daily_child_table");
                DataTable dt = ds.Tables[0];
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = Membercode;
                    double previous_left = find_previous_left(Membercode, idate);
                    double previous_right = find_previous_right(Membercode, idate);
                    #region postion_left
                    if (position == "Left")
                    {

                        leftcount = previous_left + point;
                        rightcount = previous_right;
                        if (rightcount > 0.0)
                        {
                            if (leftcount >= rightcount)
                            {
                                int pair = (int)Math.Floor(rightcount);
                                double rest = rightcount - pair;
                                dr[1] = (leftcount - (pair)).ToString();
                                dr[2] = rest;
                                dr[3] = pair.ToString();
                            }
                            else
                            {
                                int pair = (int)Math.Floor(leftcount);
                                double rest = leftcount - pair;
                                dr[1] = rest;
                                dr[2] = (rightcount - (pair)).ToString();
                                dr[3] = pair.ToString();
                            }
                        }
                        else
                        {
                            dr[1] = leftcount;
                            dr[2] = "0";
                            dr[3] = "0";
                        }

                    }
                    #endregion position_left
                    #region position_right
                    else
                    {
                        leftcount = previous_left;
                        rightcount = previous_right + point;
                        if (leftcount > 0.0)
                        {

                            if (leftcount >= rightcount)
                            {

                                int pair = (int)Math.Floor(rightcount);
                                double rest = rightcount - pair;
                                dr[1] = (leftcount - (pair)).ToString();
                                dr[2] = rest;
                                dr[3] = pair.ToString();

                            }
                            else
                            {
                                int pair = (int)Math.Floor(leftcount);
                                double rest = leftcount - pair;
                                dr[1] = rest;
                                dr[2] = (rightcount - (pair)).ToString();
                                dr[3] = pair.ToString();

                            }

                        }
                        else
                        {
                            dr[1] = "0";
                            dr[2] = rightcount;
                            dr[3] = "0";
                        }
                    }
                    #endregion position_right
                    dr[4] = Closing_date;
                    dr[7] = DeleteID;
                    dr[8] = ClosingNumber;
                    dr[9] = idate;
                    dr[10] = "0";
                    dt.Rows.Add(dr);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
                else
                {
                    double noofleftchild = Convert.ToDouble(dt.Rows[0][1].ToString());
                    double noofrightchild = Convert.ToDouble(dt.Rows[0][2].ToString());
                    int noofpair = Convert.ToInt32(dt.Rows[0][3].ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        #region position_left
                        if (position == "Left")
                        {
                            noofleftchild = noofleftchild + point;
                            if (noofrightchild > 0)
                            {

                                if (noofleftchild >= noofrightchild)
                                {
                                    int pair = (int)Math.Floor(noofrightchild);
                                    double rest = noofrightchild - pair;
                                    dr[1] = (noofleftchild - (pair)).ToString();
                                    dr[2] = rest;
                                    dr[3] = (noofpair + pair).ToString();
                                }
                                else
                                {
                                    int pair = (int)Math.Floor(noofleftchild);
                                    double rest = noofleftchild - pair;
                                    dr[1] = rest;
                                    dr[2] = (noofrightchild - (pair)).ToString();
                                    dr[3] = (noofpair + pair).ToString();
                                }

                            }
                            else
                            {
                                dr[1] = noofleftchild;
                                dr[2] = "0";
                            }
                        }
                        #endregion position_left
                        #region position_right
                        else
                        {
                            noofrightchild = noofrightchild + point;
                            if (noofleftchild > 0)
                            {

                                if (noofleftchild >= noofrightchild)
                                {
                                    int pair = (int)Math.Floor(noofrightchild);
                                    double rest = noofrightchild - pair;
                                    dr[1] = (noofleftchild - (pair)).ToString();
                                    dr[2] = rest;
                                    dr[3] = (noofpair + pair).ToString();
                                }
                                else
                                {
                                    int pair = (int)Math.Floor(noofleftchild);
                                    double rest = noofleftchild - pair;
                                    dr[1] = rest;
                                    dr[2] = (noofrightchild - (pair)).ToString();
                                    dr[3] = (noofpair + pair).ToString();
                                }

                            }
                            else
                            {
                                dr[1] = "0";
                                dr[2] = noofrightchild;

                            }
                        }
                        #endregion position_right
                        SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                        ad.Update(dt);
                        break;
                    }
                }
                string nextintroducer = find_introducer_code(Membercode);
                if (nextintroducer != "")
                {
                    string nextintroducerposition = find_introducer_position(Membercode);
                    if (nextintroducer == Membercode)
                    {
                        string desc = "Introducer :- " + nextintroducer + "\nMembercode :- " + Membercode;
                    }
                    else
                    {
                        if (string.Compare(nextintroducer, "12345678", true) != 0)
                        {
                            update_sponcer_daily_child_table(nextintroducer.ToUpper(), nextintroducerposition, point, Closing_date, ClosingNumber, DeleteID, idate);
                        }
                    }
                }
            }
        }

        private void update_sponcer_daily_child_table(string Membercode, string position, double point, string Closing_date, string ClosingNumber, string DeleteID, int idate)
        {
            string m_code;
            m_code = Membercode;
            do
            {
                if (string.Compare(m_code, "12345678", true) != 0)
                {
                    send_data_to_dailychild_table(m_code, position, Closing_date, point, ClosingNumber, DeleteID, idate);
                    string nextintroducer = find_introducer_code(m_code);
                    string nextintroducerposition = find_introducer_position(m_code);
                    m_code = nextintroducer;
                    position = nextintroducerposition;
                }
            } while (m_code != "12345678");
        }

        private void send_data_to_dailychild_table(string Membercode, string position, string Closing_date, double point, string ClosingNumber, string DeleteID, int idate)
        {


            double leftcount = 0.0, rightcount = 0.0;
            // if introducer is first or company code then we will do nothing
            if (string.Compare(Membercode, "12345678", true) == 0)
            {
            }
            else
            {
                //search for introducer in table with that date.
                Connection con = new Connection();
                string constring = con.connect_method();
                SqlConnection conn = new SqlConnection(constring);
                SqlDataAdapter ad = new SqlDataAdapter("select * from Repurchase_Daily_child_table where Membercode='" + Membercode + "' and Idate =" + idate + "", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Repurchase_Daily_child_table");
                DataTable dt = ds.Tables[0];
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = Membercode;
                    double previous_left = find_previous_left(Membercode, idate);
                    double previous_right = find_previous_right(Membercode, idate);
                    #region postion_left
                    if (position == "Left")
                    {

                        leftcount = previous_left + point;
                        rightcount = previous_right;
                        if (rightcount > 0.0)
                        {
                            if (leftcount >= rightcount)
                            {
                                int pair = (int)Math.Floor(rightcount);
                                double rest = rightcount - pair;
                                dr[1] = (leftcount - (pair)).ToString();
                                dr[2] = rest;
                                dr[3] = pair.ToString();
                            }
                            else
                            {
                                int pair = (int)Math.Floor(leftcount);
                                double rest = leftcount - pair;
                                dr[1] = rest;
                                dr[2] = (rightcount - (pair)).ToString();
                                dr[3] = pair.ToString();
                            }
                        }
                        else
                        {
                            dr[1] = leftcount;
                            dr[2] = "0";
                            dr[3] = "0";
                        }

                    }
                    #endregion position_left
                    #region position_right
                    else
                    {
                        leftcount = previous_left;
                        rightcount = previous_right + point;
                        if (leftcount > 0.0)
                        {

                            if (leftcount >= rightcount)
                            {

                                int pair = (int)Math.Floor(rightcount);
                                double rest = rightcount - pair;
                                dr[1] = (leftcount - (pair)).ToString();
                                dr[2] = rest;
                                dr[3] = pair.ToString();

                            }
                            else
                            {
                                int pair = (int)Math.Floor(leftcount);
                                double rest = leftcount - pair;
                                dr[1] = rest;
                                dr[2] = (rightcount - (pair)).ToString();
                                dr[3] = pair.ToString();

                            }

                        }
                        else
                        {
                            dr[1] = "0";
                            dr[2] = rightcount;
                            dr[3] = "0";
                        }
                    }
                    #endregion position_right
                    dr[4] = Closing_date;
                    dr[7] = DeleteID;
                    dr[8] = ClosingNumber;
                    dr[9] = idate;
                    dr[10] = "0";
                    dt.Rows.Add(dr);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
                else
                {
                    double noofleftchild = Convert.ToDouble(dt.Rows[0][1].ToString());
                    double noofrightchild = Convert.ToDouble(dt.Rows[0][2].ToString());
                    int noofpair = Convert.ToInt32(dt.Rows[0][3].ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        #region position_left
                        if (position == "Left")
                        {
                            noofleftchild = noofleftchild + point;
                            if (noofrightchild > 0)
                            {

                                if (noofleftchild >= noofrightchild)
                                {
                                    int pair = (int)Math.Floor(noofrightchild);
                                    double rest = noofrightchild - pair;
                                    dr[1] = (noofleftchild - (pair)).ToString();
                                    dr[2] = rest;
                                    dr[3] = (noofpair + pair).ToString();
                                }
                                else
                                {
                                    int pair = (int)Math.Floor(noofleftchild);
                                    double rest = noofleftchild - pair;
                                    dr[1] = rest;
                                    dr[2] = (noofrightchild - (pair)).ToString();
                                    dr[3] = (noofpair + pair).ToString();
                                }

                            }
                            else
                            {
                                dr[1] = noofleftchild;
                                dr[2] = "0";
                            }
                        }
                        #endregion position_left
                        #region position_right
                        else
                        {
                            noofrightchild = noofrightchild + point;
                            if (noofleftchild > 0)
                            {

                                if (noofleftchild >= noofrightchild)
                                {
                                    int pair = (int)Math.Floor(noofrightchild);
                                    double rest = noofrightchild - pair;
                                    dr[1] = (noofleftchild - (pair)).ToString();
                                    dr[2] = rest;
                                    dr[3] = (noofpair + pair).ToString();
                                }
                                else
                                {
                                    int pair = (int)Math.Floor(noofleftchild);
                                    double rest = noofleftchild - pair;
                                    dr[1] = rest;
                                    dr[2] = (noofrightchild - (pair)).ToString();
                                    dr[3] = (noofpair + pair).ToString();
                                }

                            }
                            else
                            {
                                dr[1] = "0";
                                dr[2] = noofrightchild;
                            }
                        }
                        #endregion position_right
                        SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                        ad.Update(dt);
                        break;
                    }
                }
            }
        }

        private string find_introducer_code(string Membercode)
        {
            string membercode = "";
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select Sponcer_code from Member_registration where Member_code='" + Membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount != 0)
            {
                membercode = dt.Rows[0][0].ToString();
            }
            return membercode;
        }

        private string find_introducer_position(string Membercode)
        {

            string position = "";
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select Position from Member_registration where Member_code='" + Membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            position = dt.Rows[0][0].ToString();

            return position;
        }

        private double find_previous_left(string Membercode, int idate)
        {
            double toreturn = 0.0;
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Repurchase_Daily_child_table where Membercode='" + Membercode + "' and Idate !=" + idate + " order by id DESC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Daily_child_table");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {

                toreturn = Convert.ToDouble(dt.Rows[0][1].ToString());
            }

            return toreturn;
        }

        private double find_previous_right(string Membercode, int idate)
        {
            double toreturn = 0.0;
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Repurchase_Daily_child_table where Membercode='" + Membercode + "' and Idate !=" + idate + " order by id DESC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Daily_child_table");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                toreturn = Convert.ToDouble(dt.Rows[0][2].ToString());
            }

            return toreturn;
        }
        #endregion BV_1_isto_1_matching_CLosing

        #region make_payout
        private void find_all_member_code(string ClosingNumber, string DeleteID, string StartDate, string EndDate)
        {

            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select  Membercode,sum(cast(Pair as float)) as tot_pair from Repurchase_Daily_child_table WHERE Deleteid=" + DeleteID + " group by Membercode", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Daily_child_table");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                string membercode = "";
                double pair_value = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    membercode = dt.Rows[i][0].ToString();
                    pair_value = Convert.ToDouble(dt.Rows[i][1].ToString());
                    send_payout_table(membercode, StartDate, EndDate, pair_value, DeleteID, ClosingNumber, "MATCHING INCOME");
                }
            }
        }

        private void send_payout_table(string membercode, string StartDate, string EndDate, double pair_value, string DeleteID, string ClosingNumber, string Income_type)
        {

            string Closing_date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string Idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            double payout = 0;
            payout = pair_value * 20 / 100;

            if (payout != 0.0)
            {
                double tds = 0.0, cdf = 0.0, tds_amount = 0.0, admin_charges = 0.0, after_admin = 0.0;
                tds = 5;
                cdf = 10;
                tds_amount = Math.Round((payout * tds / 100), 2);
                admin_charges = Math.Round((payout * cdf / 100), 2);

                after_admin = Math.Round((payout - (tds_amount + admin_charges)), 2);
                string qry = @"insert into Repurchase_payout(Member_code,Start_date,End_date,Totalamount,Tds,Servicecharge,Final_amount,Closing_date,Status,Pair_no,Deleteid,Closingno,Idate,Income_type)
                        values ('" + membercode + "','" + StartDate + "','" + EndDate + "','" + payout + "','" + tds_amount + "','" + admin_charges + "','" + after_admin + "','" + Closing_date + "','NOTPAID','" + pair_value + "','" + DeleteID + "','" + ClosingNumber + "',N'" + Idate + "','" + Income_type + "');";
                int i = imp.InsertUpdateDelete(qry);
            }
        }

        #endregion make_payout

        #region Repurchase_royalty
        private void Repurchase_royalty_closing(string ClosingNumber, string DeleteID, string StartDate, string EndDate)
        {
            double total_bv = find_total_bv(StartDate, EndDate);
            double distributed_amt = total_bv * 5 / 100;
            string sql = "select * from Repurchase_Royalty_Member";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                double payable_amt = distributed_amt / dtTemp.Rows.Count;

                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    string membercode = dtTemp.Rows[i][1].ToString();
                    send_royalty_payout_table(membercode, StartDate, EndDate, payable_amt, DeleteID, ClosingNumber, "ROYALTY INCOME");
                }
            }

        }
        private void send_royalty_payout_table(string membercode, string StartDate, string EndDate, double pair_value, string DeleteID, string ClosingNumber, string Income_type)
        {

            string Closing_date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string Idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            double payout = 0;
            payout = pair_value;

            if (payout != 0.0)
            {
                double tds = 0.0, cdf = 0.0, tds_amount = 0.0, admin_charges = 0.0, after_admin = 0.0;
                tds = 5;
                cdf = 10;
                tds_amount = Math.Round((payout * tds / 100), 2);
                admin_charges = Math.Round((payout * cdf / 100), 2);

                after_admin = Math.Round((payout - (tds_amount + admin_charges)), 2);
                string qry = @"insert into Repurchase_payout(Member_code,Start_date,End_date,Totalamount,Tds,Servicecharge,Final_amount,Closing_date,Status,Pair_no,Deleteid,Closingno,Idate,Income_type)
                        values ('" + membercode + "','" + StartDate + "','" + EndDate + "','" + payout + "','" + tds_amount + "','" + admin_charges + "','" + after_admin + "','" + Closing_date + "','NOTPAID','" + pair_value + "','" + DeleteID + "','" + ClosingNumber + "',N'" + Idate + "','" + Income_type + "');";
                int i = imp.InsertUpdateDelete(qry);
            }
        }
        private double find_total_bv(string StartDate, string EndDate)
        {
            string sql = " select isnull(sum(cast(TotalBV as float)),0) as TotalBV from dbo.[Re_sell_member_bill_wise] where Idate>=" + use.fetch_idate(StartDate) + " and Idate<=" + use.fetch_idate(EndDate) + "";
            DataTable dtTemp = imp.FillTable(sql);
            return Convert.ToDouble(dtTemp.Rows[0][0].ToString());

        }
        #endregion Repurchase_royalty
    }
}