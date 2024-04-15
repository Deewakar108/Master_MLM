using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.App_Code
{
    public class IncentiveIncome
    {
        Important imp = new Important();
        string AdminCode = "12345678";
        DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

        DataTable dtAllBinary;
        DataTable dtAllMember;
        DataTable dtCycle1;
        DataTable dtDailyChild;
        DataTable dtMemberPairLevel;
        int count = 0;
        int CappingPair_Max = 5;
        int JoiningAmount = 0;

        string Closing_StartDate = "";
        string Closing_EndDate = "";
        string Closing_ClosingNumber = "";
        string Closing_ClosingDate = "";
        string Closing_Closing_iDate = "";
        string Closing_DeleteID = "";
        int Point = 0;

        public void StartUpdatingForIncentiveIncome(string ClosingNumber)
        {
            AdminCode = imp.AdminCode;

            bool status = false;
            try
            {
                string sql = "select  * from  binary_status where countChild>=2";
                DataTable dt = imp.FillTable(sql);

                foreach (DataRow Record in dt.Rows) 
                {
                    string MemberCode = Record["member_code"].ToString();

                    if (!IsAlreadyAchieved(MemberCode)) 
                    {
                        //Check Here For Valid Package Rs. 6000.
                        //Self Member
                        if (IsValidPackage(MemberCode)) 
                        {
                            //Left
                            string LeftMember = Record["left_child"].ToString();
                            bool LeftStatus = IsValidPackage(LeftMember);

                            //Right
                            string RightMember = Record["right_child"].ToString();
                            bool RightStatus = IsValidPackage(RightMember);

                            if (LeftStatus == true && RightStatus == true) 
                            {
                                int IncentiveDurationInMonth = 12;
                                int IncentiveAmount = 1500;

                                DateTime AchivedDate = dtToday;
                                string stringAchievedDate = dtToday.ToString("dd/MM/yyyy");
                                for (int i = 0; i < IncentiveDurationInMonth; i++) 
                                {
                                    AchivedDate = AchivedDate.AddMonths(1);
                                    string Month = AchivedDate.ToString("MM");
                                    string Year = AchivedDate.ToString("yyyy");

                                    string PaidStatus = "NOTPAID";
                                    string PaidDate = AchivedDate.ToString("dd/MM/yyyy");

                                    sql = "insert into IncentiveAchievedIncome(MemberCode, Amount, Month, Year, AchievedDate, ClosingNumber, PaidDate, PaidStatus) values ('" + 
                                          MemberCode + "','" + IncentiveAmount + "','" + Month + "','" + Year + "','" + stringAchievedDate + "','" + ClosingNumber + "','" + 
                                          PaidDate + "','" + PaidStatus + "')";
                                    int i1 = imp.InsertUpdateDelete(sql);
                                }
                            }
                        }
                    }

                }



                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                InsertException(ex.Message, "ClosingReport.aspx");
            }

            //return status;
        }

        public void InsertException(string Message, string Page)
        {
            DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            string date = dtToday.ToString("dd/MM/yyyy");
            string time = dtToday.ToString("hh:mm:ss tt");

            string sql = "insert into ExceptionDetails(exception_message,date,time,page) values ('" + Message + "','" + date + "','" + time + "','" + Page + "')";
            int i = imp.InsertUpdateDelete(sql);
        }
        
        public bool IsAlreadyAchieved(string MemberCode) 
        {
            string sql = "select distinct MemberCode from IncentiveAchievedIncome where MemberCode='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }
            return false;
        }

        public bool IsValidPackage(string MemberCode)
        {
            string sql = "select distinct MemberCode from TopUpMemberList where MemberCode='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }
            return false;
        }
    }
}