using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.App_Code
{
    public class ocean_royalty
    {

        Important imp = new Important();
       
        string AdminCode = "";
        DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

        DataTable dtAllMember;

        public bool StartClosing(string StartDate, string EndDate, string ClosingNumber, string ClosingDate, string Closing_iDate, string DeleteID,
                                 string MonthValue, string Year)
        {
            DataTable dtTemp = new DataTable();
            AdminCode = imp.AdminCode;
            bool status = false;
            try
            {
                string Start_iDate = imp.ConvertStringTo_iDate(StartDate);
                string End_iDate = imp.ConvertStringTo_iDate(EndDate);
                int MinimumReferral = 3;
                AddIn_Closin_Table(StartDate, EndDate, ClosingDate, ClosingNumber, DeleteID, "InProcess");

                double TotalCTO = GetTurnOverWithinMonth(Start_iDate, End_iDate);

                #region Update Royalty Member

                DateTime dtStartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string sql = "select  * from (select  *, (Convert(int, (Convert(varchar, Convert(datetime, Date, 103), 112)))) as " +
                             "Joining_iDate from  Member_registration where Member_code not in (select MemberCode from RoyaltyClubMember)) T where Joining_iDate <= " + End_iDate;


                //Check IsExist in MemberPairTable If Required...
                dtAllMember = imp.FillTable(sql);
                if (dtAllMember.Rows.Count != 0)
                {
                    foreach (DataRow drMember in dtAllMember.Rows)
                    {
                        string MemberCode = drMember["Member_code"].ToString();
                        string PackageAmount = drMember["Joining_amount"].ToString();
                        if (MemberCode == "OC508019") 
                        {
                            string x = "wait...";
                        }
                        dtTemp = new DataTable();
                        sql = "select  * from Member_registration  where Referal_code='" + MemberCode + "' and Verification_idate>0 and  Verification_idate<=" + End_iDate;
                        dtTemp = imp.FillTable(sql);
                        if (dtTemp.Rows.Count >= MinimumReferral)
                        {
                            string AchievedDate = dtToday.ToString("dd/MM/yyyy");
                            string Achieved_iDate = dtToday.ToString("yyyyMMdd");

                            sql = "insert into RoyaltyClubMember(MemberCode,AchievedDate,Achieved_iDate) values ('" + MemberCode + "','" + AchievedDate + "','" + Achieved_iDate + "')";
                            int i1 = imp.InsertUpdateDelete(sql);
                        }
                    }

                }

                #endregion

                #region Distribute Royalty

                if (TotalCTO > 0)
                {
                    sql = "select * from RoyaltyClubMember";
                    DataTable dt = imp.FillTable(sql);

                    int TotalMember = dt.Rows.Count;

                    if (TotalMember > 0)
                    {
                        TotalCTO = TotalCTO * 0.02;
                        double PayableCTO = TotalCTO / TotalMember;

                        string ClosingType = "Royalty";
                        foreach (DataRow dr in dt.Rows)
                        {
                            string MemberCode = dr["MemberCode"].ToString();
                            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, PayableCTO.ToString("0.00"), ClosingDate,
                                             ClosingDate, "0", ClosingType, "NOTPAID", "N");
                        }
                    }
                }

                #endregion

                //AddIn_Closin_Table(StartDate, EndDate, ClosingDate, ClosingNumber, DeleteID, "Complete");
                UpdateClosingStatusInClosingTable(ClosingNumber, "Complete");

                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                imp.InsertException(ex.Message, "RoyaltyClosingForm.aspx");
            }

            return status;
        }

        public double GetTurnOverWithinMonth(string StartiDate, string End_iDate)
        {
            //Month = StartDate.Substring(3, 2);
            //Year = StartDate.Substring(6, 4);

            //string sql = "select  isnull(SUM(convert(int, isnull(Joining_amount, 0))), 0) as TurnOver from Member_registration where Date LIKE '%/" + Month + "/" + Year + "%'";

            string sql = " select isnull(SUM(convert(int, isnull(Joining_amount, 0))), 0) as TurnOver from dbo.[Member_registration] where Verification_idate>=" + StartiDate + " and Verification_idate<=" + End_iDate + "";
            DataTable dtTemp = imp.FillTable(sql);
            return double.Parse(dtTemp.Rows[0]["TurnOver"].ToString());
        }

        public void UpdateClosingStatusInClosingTable(string closingNumber, string Status)
        {
            string sql = "update Ry_closing set ClosingStatus = '" + Status + "' where Closingno='" + closingNumber + "'";
            int i = imp.InsertUpdateDelete(sql);
        }

        public string GetFinalAmount(string Amount, string TDS, string AdminCharge)
        {
            // Final Amount = Amount - TDS - AdminCharge.
            Amount = (double.Parse(Amount) - (double.Parse(TDS) + double.Parse(AdminCharge))).ToString("0.00");
            return Amount;
        }

        public double GetTDS(double Amount, string MemberCode)
        {
            double tds = imp.TDS * 0.01;
            //if (IsPanCardExist(MemberCode)) { tds = 0.05; }
            Amount = Amount * tds;
            return Amount;
        }

        public bool IsPanCardExist(string MemberCode)
        {
            DataRow[] drMember = dtAllMember.Select("Member_code='" + MemberCode + "'");
            if (drMember.Length != 0) { if (drMember[0]["Pan_number"].ToString() != "") { return true; } }
            return false;
        }

        public double GetAdminCharge(double Amount)
        {
            double admiCharge = imp.AdminCharge * 0.01;
            Amount = Amount * admiCharge;
            return Amount;
        }

        public void AddToPayOutTable(string MemberCode, string StartDate, string EndDate, string ClosingNumber, string DeleteID, string Commission,
                                     string ClosingDate, string JoiningDate, string PairNumber, string ClosingType, string PaidStatus, string IsLapse)
        {
            string Member_code = MemberCode;
            string Start_date = StartDate;
            string End_date = EndDate;
            string Slip_no = "0";
            string Totalamount = Commission;
            string Tds = GetTDS(double.Parse(Totalamount), MemberCode).ToString("0.00");
            string Servicecharge = GetAdminCharge(double.Parse(Totalamount), MemberCode).ToString("0.00");// Admin Charge
            string Final_amount = GetFinalAmount(Totalamount, Tds, Servicecharge);
            string Closing_date = ClosingDate;
            string Joining_date = JoiningDate;
            string Status = PaidStatus;
            string Paid_date = "0";
            string Pair_no = PairNumber;
            string interval = "0";
            string Deleteid = DeleteID;
            string Closingno = ClosingNumber;
            string Idate = imp.ConvertStringTo_iDate(ClosingDate);
            string Statre_Idate = imp.ConvertStringTo_iDate(StartDate);
            string End_Idate = imp.ConvertStringTo_iDate(EndDate);
            string Auto_pair_deduct = "0";

            string sql = "insert into payout(Member_code,Start_date,End_date,Slip_no,Totalamount,Tds,Servicecharge,Final_amount,Closing_date,Joining_date,Status,Paid_date," +
                         "Pair_no,interval,Deleteid,Closingno,Idate,Statre_Idate,End_Idate,Auto_pair_deduct,ClosingType, IsLapse) values ('" + Member_code + "','" + Start_date + "','" + End_date +
                         "','" + Slip_no + "','" + Totalamount + "','" + Tds + "','" + Servicecharge + "','" + Final_amount + "','" + Closing_date + "','" + Joining_date +
                         "','" + Status + "','" + Paid_date + "','" + Pair_no + "','" + interval + "','" + Deleteid + "','" + Closingno + "',N'" + Idate + "','" + Statre_Idate +
                         "','" + End_Idate + "','" + Auto_pair_deduct + "','" + ClosingType + "','" + IsLapse + "')";
            int i = imp.InsertUpdateDelete(sql);


        }

        public double GetAdminCharge(double Amount, string MemberCode)
        {
            double admiCharge = imp.AdminCharge * 0.01;
            Amount = Amount * admiCharge;
            return Amount;
        }

        public void AddIn_Closin_Table(string StartDate, string EndDate, string ClosingDate, string closingNumber, string Deleteid, string ClosingStatus)
        {
            string Idate = imp.ConvertStringTo_iDate(ClosingDate);
            string Closing_Time = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");
            string I_Start_date = imp.ConvertStringTo_iDate(StartDate);
            string I_End_date = imp.ConvertStringTo_iDate(EndDate);

            string sql = "insert into Ry_closing(Start_date, End_date, Date, Closingno, Idate, Deleteid, Closing_Time, I_Start_date, I_End_date, ClosingStatus) values ('" +
                         StartDate + "','" + EndDate + "','" + ClosingDate + "','" + closingNumber + "','" + Idate + "','" + Deleteid + "','" + Closing_Time + "','" +
                         I_Start_date + "','" + I_End_date + "','" + ClosingStatus + "')";
            int i = imp.InsertUpdateDelete(sql);
        }

        public void UpdateMemberRoyaltyTarget(string MemberCode, string NewTarget)
        {
            string sql = "update Member_registration set RoyaltyTarget= '" + NewTarget + "' where Member_code='" + MemberCode + "'";
            int i1 = imp.InsertUpdateDelete(sql);

            DataRow[] drAchievedMember = dtAllMember.Select("Member_code = '" + MemberCode + "'");
            if (drAchievedMember.Length != 0)
            {
                drAchievedMember[0]["RoyaltyTarget"] = NewTarget;
            }
        }


        public void UpdateMemberCTOBonousStatus(string MemberCode, string Status)
        {
            string sql = "update Member_registration set IsAchievedCTO= '" + Status + "' where Member_code='" + MemberCode + "'";
            int i1 = imp.InsertUpdateDelete(sql);
        }

        public bool IsClosingExist(string Start_iDate, string End_iDate)
        {
            string sql = "select * from Ry_closing where  I_Start_date='" + Start_iDate + "' and I_End_date='" + End_iDate + "'";
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

        public string GetNextTarget(string ID)
        {
            string sql = "select * from RoyaltyDetails  where ID>" + ID;
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return dt.Rows[0]["RequiredMember"].ToString(); }
            return "0";
        }
    
    
    
    }
}