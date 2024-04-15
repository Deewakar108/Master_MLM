using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Master_MLM.App_Code;
using System.Globalization;


namespace Master_MLM.App_Code
{
    public class ocean_closing
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

        string DeductablePair = "5, 10, 15, 20, 25";

        public string PackagePV(string PackageName)
        {
            string sql = "select  * from Joining_package where Package_name='" + PackageName + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0]["BV"].ToString();
            }
            return "1";
        }

        public bool StartClosing(string StartDate, string EndDate, string ClosingNumber, string ClosingDate, string Closing_iDate, string DeleteID, string IntervalStatus)
        {
            Closing_StartDate = StartDate;
            Closing_EndDate = EndDate;
            Closing_ClosingNumber = ClosingNumber;
            Closing_ClosingDate = ClosingDate;
            Closing_Closing_iDate = Closing_iDate;
            Closing_DeleteID = DeleteID;

            AdminCode = imp.AdminCode;

            bool status = false;
            try
            {
                GetAllDataFromTableFor_Closing(); //Required For Closing.

                string Start_iDate = imp.ConvertStringTo_iDate(StartDate);
                string End_iDate = imp.ConvertStringTo_iDate(EndDate);

                //Filter Data For Closing...
                //DataRow[] drMembers = dtAllMember.Select("Joining_iDate>=" + Start_iDate + " and  Joining_iDate<=" + End_iDate);

                DataRow[] drMembers = dtAllMember.Select("Interval='" + IntervalStatus + "' and  Verification_iDate>=" + Start_iDate + " and  Verification_iDate<=" + End_iDate + " and  Paidstatus='PAID'");
                if (drMembers.Length != 0)
                {
                    DataTable dtTempMember = drMembers.CopyToDataTable();
                    DateTime dtStartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtEndDate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    ////This Loop is responsible for DateWise Closing.

                    while (dtStartDate <= dtEndDate)
                    {
                        //DataRow[] drTempMember = dtTempMember.Select("Date='" + dtStartDate.ToString("dd/MM/yyyy") + "'");
                        DataRow[] drTempMember = dtTempMember.Select("Verification_date='" + dtStartDate.ToString("dd/MM/yyyy") + "'");
                        foreach (DataRow dr in drTempMember)
                        {
                            count = count + 1;
                            string MemberCode = dr["Member_code"].ToString();
                            string tempStartDate = dtStartDate.ToString("dd/MM/yyyy");
                            //string JoiningTime = dr["Verification_time"].ToString();

                            string PackageName = dr["joining_package"].ToString();
                            Point = int.Parse(PackagePV(PackageName));

                            int Interval = int.Parse(dr["Interval"].ToString());
                            JoiningAmount = int.Parse(dr["Joining_amount"].ToString());

                            UpdatePairIn_DailyChildTable(MemberCode, tempStartDate, ClosingNumber, DeleteID, Interval.ToString());
                        }

                        dtStartDate = dtStartDate.AddDays(1);
                    }

                    UpdateClosingStatus(ClosingNumber, "Complete");                                             //Update in Global Table

                    //return true;
                    if (IsClosingInProcess())         //Not Exist Then Entry
                    {
                        UpdateClosingStatus(ClosingNumber, "Insert-Data");                                     //Update in Global Table

                        if (!IsClosingExist(Start_iDate.ToString(), End_iDate.ToString(), IntervalStatus))
                        {
                            //Plan
                            UpdateDailyChildTable_Using_Business_Plan("Sponsor", ClosingNumber, StartDate, EndDate, ClosingDate, DeleteID);

                            //CarryForward
                            UpdateAllCarryForwardAmountForClosing(Start_iDate, End_iDate, StartDate, EndDate, ClosingNumber, ClosingDate, Closing_iDate, DeleteID);

                            //Update Reward
                            //UpdateReward(ClosingNumber);

                            //Paid To Payout From Achieved Referral Income
                            AchievedReferralIncome(StartDate, EndDate, ClosingNumber, DeleteID, ClosingDate);

                            //Paid To Payout From Achieved Incentive Income
                            AchievedIncentiveIncome(StartDate, EndDate, ClosingNumber, DeleteID, ClosingDate);

                            //Updateing Incentive Income Details.
                            StartUpdatingForIncentiveIncome(ClosingNumber);

                            //Updateing Incentive Referral Details.
                            UpdateReferralIncome(ClosingNumber);

                            #region NO NEED

                            //Add in PayoutTable of RoyaltyCommission
                            //UpdateRoyaltyCommission(Start_iDate, End_iDate, ClosingNumber, DeleteID, ClosingDate, StartDate, EndDate);

                            //Add in PayoutTable of CTOCommission
                            //UpdateCTOCommission(Start_iDate, End_iDate, ClosingNumber, DeleteID, ClosingDate, StartDate, EndDate);

                            //Update Spill Income                            
                            //UpdateSpillIncome(dtForSpillIncome, StartDate, EndDate, ClosingNumber, DeleteID, ClosingDate, dtToday.ToString("dd/MM/yyyy"));

                            #endregion

                        }
                    }
                }

                AddIn_Closin_Table(StartDate, EndDate, ClosingDate, ClosingNumber, DeleteID, IntervalStatus);

                UpdateClosingStatusInClosingTable(ClosingNumber, "Complete");                       //Update in Closing Table

                UpdateClosingStatus(ClosingNumber, "Complete");                                     //Update in Global Table

                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                InsertException(ex.ToString(), "Closing");

            }

            return status;
        }

        public void AchievedReferralIncome(string StartDate, string EndDate, string ClosingNumber, string DeleteID, string ClosingDate)
        {
            string ClosingType = "Referral";

            string sql = "select  * from  ReferralAchievedIncome where PaidDate='" + StartDate + "'";
            DataTable dt = imp.FillTable(sql);

            foreach (DataRow Record in dt.Rows)
            {
                string ID = Record["ID"].ToString();
                string MemberCode = Record["MemberCode"].ToString();
                string Commission = Record["Amount"].ToString();
                string AchievedDate = Record["AchievedDate"].ToString();

                //Insert into Payout Table
                AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission, ClosingDate, AchievedDate, "0", ClosingType, "NOTPAID", "N");

                //Update Paid Status in IncentiveAchievedIncome Table
                sql = "update ReferralAchievedIncome set PaidStatus='PAID' where ID='" + ID + "'";
                int i2 = imp.InsertUpdateDelete(sql);

            }
        }

        public void AchievedIncentiveIncome(string StartDate, string EndDate, string ClosingNumber, string DeleteID, string ClosingDate)
        {
            string ClosingType = "Incentive";

            string sql = "select  * from  IncentiveAchievedIncome where PaidDate='" + StartDate + "'";
            DataTable dt = imp.FillTable(sql);

            foreach (DataRow Record in dt.Rows)
            {
                string ID = Record["ID"].ToString();
                string MemberCode = Record["MemberCode"].ToString();
                string Commission = Record["Amount"].ToString();
                string AchievedDate = Record["AchievedDate"].ToString();

                //Insert into Payout Table
                AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission, ClosingDate, AchievedDate, "0", ClosingType, "NOTPAID", "N");

                //Update Paid Status in IncentiveAchievedIncome Table
                sql = "update IncentiveAchievedIncome set PaidStatus='PAID' where ID='" + ID + "'";
                int i2 = imp.InsertUpdateDelete(sql);

            }
        }

        public void UpdateReferralIncome(string ClosingNumber)
        {
            string sql = "select  * from IncentiveAchievedIncome";
            DataTable dtTemp = imp.FillTable(sql);
            foreach (DataRow Record in dtTemp.Rows)
            {
                string MemberCode = Record["MemberCode"].ToString();

                sql = "select  * from Member_registration where Referal_code='" + MemberCode + "' and Member_code in (select  " +
                      "MemberCode from IncentiveAchievedIncome) and  Member_code not in (select MemberCode from ReferralAchievedIncome)";

                DataTable dtReferral = imp.FillTable(sql);
                foreach (DataRow Record1 in dtReferral.Rows)
                {
                    int IncentiveDurationInMonth = 6;
                    int IncentiveAmount = 500;

                    DateTime AchivedDate = dtToday;
                    string stringAchievedDate = dtToday.ToString("dd/MM/yyyy");
                    for (int i = 0; i < IncentiveDurationInMonth; i++)
                    {
                        AchivedDate = AchivedDate.AddMonths(1);
                        string Month = AchivedDate.ToString("MM");
                        string Year = AchivedDate.ToString("yyyy");

                        sql = "insert into ReferralAchievedIncome(MemberCode,Amount,Month,Year,AchievedDate, ClosingNumber) values ('" + MemberCode +
                              "','" + IncentiveAmount + "','" + Month + "','" + Year + "','" + stringAchievedDate + "','" + ClosingNumber + "')";
                        int i1 = imp.InsertUpdateDelete(sql);
                    }
                }
            }
        }

        public void StartUpdatingForIncentiveIncome(string ClosingNumber)
        {
            AdminCode = imp.AdminCode;

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
                                int IncentiveAmount = 1000;

                                DateTime AchivedDate = dtToday;
                                string stringAchievedDate = dtToday.ToString("dd/MM/yyyy");
                                for (int i = 0; i < IncentiveDurationInMonth; i++)
                                {
                                    AchivedDate = AchivedDate.AddMonths(1);
                                    string Month = AchivedDate.ToString("MM");
                                    string Year = AchivedDate.ToString("yyyy");

                                    sql = "insert into IncentiveAchievedIncome(MemberCode,Amount,Month,Year,AchievedDate, ClosingNumber) values ('" + MemberCode +
                                          "','" + IncentiveAmount + "','" + Month + "','" + Year + "','" + stringAchievedDate + "','" + ClosingNumber + "')";
                                    int i1 = imp.InsertUpdateDelete(sql);
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                InsertException(ex.Message, "ClosingReport.aspx");
            }

            //return status;
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

        #region During Exception

        public void UpdateReward(string ClosingNumber)
        {
            string sql = "select * from MemberPairLevel  where  ClosingNumber='" + ClosingNumber + "'";
            DataTable dtMemberPair = imp.FillTable(sql);

            sql = "select distinct MemberCode from MemberPairLevel  where  ClosingNumber='" + ClosingNumber + "'";
            DataTable dtDistinctMember = imp.FillTable(sql);

            sql = "select * from RewardList order by ID ASC";
            DataTable dtReward = imp.FillTable(sql);

            if (dtDistinctMember.Rows.Count != 0)
            {
                foreach (DataRow drMember in dtDistinctMember.Rows)
                {
                    string MemberCode = drMember["MemberCode"].ToString();

                    foreach (DataRow dr in dtReward.Rows)
                    {
                        string PairAchieved = dr["TopUp"].ToString();
                        string Level = dr["ID"].ToString();
                        string RewardName = dr["RewardName"].ToString();
                        string Rank = dr["Rank"].ToString();


                        DataRow[] drPair = dtMemberPair.Select("MemberCode='" + MemberCode + "' and  PairAchieved='" + PairAchieved + "'");
                        if (drPair.Length != 0)
                        {
                            if (!IsAchievedBefore(MemberCode, Level))
                            {
                                string DateOfAchievement = drPair[0]["AchievedDate"].ToString();
                                string Status = "NOTPAID";
                                DateTime dtDateOfAchievement = DateTime.ParseExact(DateOfAchievement, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                string idate = dtDateOfAchievement.ToString("yyyyMMdd");

                                //Add To Reward Achieved List...
                                sql = "insert into AchievedTable(MemberCode,DateOfAchievement,Status,RewardName,Level,idate,ClosingNumber, Rank) values ('" +
                                      MemberCode + "','" + DateOfAchievement + "','" + Status + "','" + RewardName + "','" + Level + "','" + idate + "','" +
                                      ClosingNumber + "','" + Rank + "')";
                                int i1 = imp.InsertUpdateDelete(sql);
                            }
                        }
                        else { break; }
                    }
                }
            }
        }

        public bool IsAchievedBefore(string MemberCode, string Level)
        {
            string sql = "select * from AchievedTable where MemberCode='" + MemberCode + "' and Level='" + Level + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }
            return false;
        }

        public string GetMatchingIncome(string MemberCode)
        {
            string sql = "select * from Member_registration  where  Member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return dt.Rows[0]["MatchingIncome"].ToString(); }
            return "0";
        }

        public void UpdateDailyChildTable_Using_Business_Plan(string ClosingType, string ClosingNumber, string StartDate, string EndDate, string ClosingDate, string DeleteID)
        {
            //  This Plan is working as PV.
            //  1PV = 400.
            //  2PV = 800.
            string MatchingIncome = "800";      // It is minimum.

            string sql = " select Closingno, Membercode, SUM(convert(int, Pair)) as Pair from Daily_child_table where  Closingno='" + ClosingNumber + "'  group by Closingno, Membercode";
            DataTable dtClosingPair = imp.FillTable(sql);
            if (dtClosingPair.Rows.Count != 0)
            {
                foreach (DataRow drMember in dtClosingPair.Rows)
                {
                    string MemberCode = drMember["MemberCode"].ToString();
                    int MaxPairCount = 5;
                    int PairCount = int.Parse(drMember["Pair"].ToString());

                    int TotalPair = PairCount;
                    int TotalPayablePair = MaxPairCount;
                    int TotalAutoPaidPair = 0;
                    if (TotalPair > TotalPayablePair) { TotalAutoPaidPair = TotalPair - TotalPayablePair; }
                    else { TotalPayablePair = TotalPair; }

                    double Commission = TotalPayablePair * int.Parse(MatchingIncome);
                    if (Commission > 0)
                    {
                        string AchievedDate = ClosingDate;
                        AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate,
                                         TotalPair.ToString(), ClosingType, "NOTPAID", "N");
                    }

                    Commission = TotalAutoPaidPair * int.Parse(MatchingIncome);
                    if (Commission > 0)
                    {
                        string AchievedDate = ClosingDate;
                        AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate,
                                         TotalPair.ToString(), ClosingType, "AUTOPAID", "N");
                    }
                }
            }

            #region NO NEED IN THIS PROJECT

            //sql = "select * from MemberPairLevel  where  ClosingNumber='" + ClosingNumber + "'";
            //DataTable dtMemberPair = imp.FillTable(sql);

            //DataTable dtTempMemberPair = dtMemberPair.Copy();
            //if (dtMemberPair.Rows.Count != 0)
            //{
            //    //Get Distinct Member
            //    DataTable dtDistinctMember = dtTempMemberPair.DefaultView.ToTable(true, "MemberCode");

            //    foreach (DataRow drMember in dtDistinctMember.Rows)
            //    {
            //        string MemberCode = drMember["MemberCode"].ToString();

            //        string MatchingIncome = "600";  //Fixed BY Admin. //GetMatchingIncome(MemberCode);  
            //        DataRow[] drFilteredMember = dtMemberPair.Select("MemberCode='" + MemberCode + "'");
            //        if (drFilteredMember.Length != 0)
            //        {
            //            //DataTable dtFilteredMember = drFilteredMember.CopyToDataTable();
            //            //DataTable dtCappingPair = dtFilteredMember.Rows.Cast<System.Data.DataRow>().Take(CappingPair_Max).CopyToDataTable();

            //            //int TotalPair = dtFilteredMember.Rows.Count;
            //            //int TotalPayablePair = dtCappingPair.Rows.Count;
            //            //int TotalAutoPaidPair = 0;
            //            //if (TotalPair > TotalPayablePair) { TotalAutoPaidPair = TotalPair - TotalPayablePair; }

            //            //double Commission = TotalPayablePair * int.Parse(MatchingIncome);
            //            //if (Commission > 0)
            //            //{
            //            //    string AchievedDate = ClosingDate;
            //            //    AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate,
            //            //                     TotalPair.ToString(), ClosingType, "NOTPAID", "N");
            //            //}

            //            //Commission = TotalAutoPaidPair * int.Parse(MatchingIncome);
            //            //if (Commission > 0)
            //            //{
            //            //    string AchievedDate = ClosingDate;
            //            //    AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate,
            //            //                     TotalPair.ToString(), ClosingType, "AUTOPAID", "N");
            //            //}

            //            #region NO NEED IN THIS PROJECT

            //            //////Get Distinct Member
            //            ////DataTable dtDistinctDate = dtFilteredMember.DefaultView.ToTable(true, "AchievedDate");
            //            ////foreach (DataRow drDate in dtDistinctDate.Rows)
            //            ////{
            //            ////    string AchievedDate = drDate["AchievedDate"].ToString();
            //            ////    DataRow[] drTotalPairs = dtMemberPair.Select("ClosingNumber='" + ClosingNumber + "' and MemberCode='" + MemberCode + "' and AchievedDate='" + AchievedDate + "'");
            //            ////    if (drTotalPairs.Length != 0)
            //            ////    {
            //            ////        DataTable dtTotalPairs = drTotalPairs.CopyToDataTable();

            //            ////        //Check Capping First.
            //            ////        DataTable dtCappingPair = dtTotalPairs.Rows.Cast<System.Data.DataRow>().Take(CappingPair_Max).CopyToDataTable();

            //            ////        //Send PairAchieved Commission.
            //            ////        DataRow[] drAchievedPair = dtCappingPair.Select("PairAchieved not in (" + DeductablePair + ")");
            //            ////        if (drAchievedPair.Length != 0)
            //            ////        {
            //            ////            int TotalPair = drAchievedPair.Length;
            //            ////            double Commission = TotalPair * int.Parse(MatchingIncome);
            //            ////            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate, TotalPair.ToString(), ClosingType, "NOTPAID", "N");
            //            ////        }

            //            ////        //Send AutoPaid Commission.
            //            ////        DataRow[] drAutoPaidPair = dtCappingPair.Select("PairAchieved in (" + DeductablePair + ")");
            //            ////        if (drAutoPaidPair.Length != 0)
            //            ////        {
            //            ////            int TotalPair = drAutoPaidPair.Length;
            //            ////            double Commission = TotalPair * int.Parse(MatchingIncome);
            //            ////            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate, TotalPair.ToString(), ClosingType, "AUTOPAID", "N");
            //            ////        }
            //            ////    }
            //            ////}

            //            #endregion

            //        }
            //    }
            //}

            #endregion
        }

        public void UpdateDailyChildTable_Using_Business_Plan_OLD(string ClosingType, string ClosingNumber, string StartDate, string EndDate, string ClosingDate, string DeleteID)
        {
            string sql = "select * from MemberPairLevel  where  ClosingNumber='" + ClosingNumber + "'";
            DataTable dtMemberPair = imp.FillTable(sql);

            DataTable dtTempMemberPair = dtMemberPair.Copy();
            if (dtMemberPair.Rows.Count != 0)
            {
                //Get Distinct Member
                DataTable dtDistinctMember = dtTempMemberPair.DefaultView.ToTable(true, "MemberCode");

                foreach (DataRow drMember in dtDistinctMember.Rows)
                {
                    string MemberCode = drMember["MemberCode"].ToString();

                    string MatchingIncome = "600";  //Fixed BY Admin. //GetMatchingIncome(MemberCode);  
                    DataRow[] drFilteredMember = dtMemberPair.Select("MemberCode='" + MemberCode + "'");
                    if (drFilteredMember.Length != 0)
                    {
                        DataTable dtFilteredMember = drFilteredMember.CopyToDataTable();
                        DataTable dtCappingPair = dtFilteredMember.Rows.Cast<System.Data.DataRow>().Take(CappingPair_Max).CopyToDataTable();

                        int TotalPair = dtFilteredMember.Rows.Count;
                        int TotalPayablePair = dtCappingPair.Rows.Count;
                        int TotalAutoPaidPair = 0;
                        if (TotalPair > TotalPayablePair) { TotalAutoPaidPair = TotalPair - TotalPayablePair; }

                        double Commission = TotalPayablePair * int.Parse(MatchingIncome);
                        if (Commission > 0)
                        {
                            string AchievedDate = ClosingDate;
                            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate,
                                             TotalPair.ToString(), ClosingType, "NOTPAID", "N");
                        }

                        Commission = TotalAutoPaidPair * int.Parse(MatchingIncome);
                        if (Commission > 0)
                        {
                            string AchievedDate = ClosingDate;
                            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate,
                                             TotalPair.ToString(), ClosingType, "AUTOPAID", "N");
                        }

                        #region NO NEED IN THIS PROJECT

                        //////Get Distinct Member
                        ////DataTable dtDistinctDate = dtFilteredMember.DefaultView.ToTable(true, "AchievedDate");
                        ////foreach (DataRow drDate in dtDistinctDate.Rows)
                        ////{
                        ////    string AchievedDate = drDate["AchievedDate"].ToString();
                        ////    DataRow[] drTotalPairs = dtMemberPair.Select("ClosingNumber='" + ClosingNumber + "' and MemberCode='" + MemberCode + "' and AchievedDate='" + AchievedDate + "'");
                        ////    if (drTotalPairs.Length != 0)
                        ////    {
                        ////        DataTable dtTotalPairs = drTotalPairs.CopyToDataTable();

                        ////        //Check Capping First.
                        ////        DataTable dtCappingPair = dtTotalPairs.Rows.Cast<System.Data.DataRow>().Take(CappingPair_Max).CopyToDataTable();

                        ////        //Send PairAchieved Commission.
                        ////        DataRow[] drAchievedPair = dtCappingPair.Select("PairAchieved not in (" + DeductablePair + ")");
                        ////        if (drAchievedPair.Length != 0)
                        ////        {
                        ////            int TotalPair = drAchievedPair.Length;
                        ////            double Commission = TotalPair * int.Parse(MatchingIncome);
                        ////            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate, TotalPair.ToString(), ClosingType, "NOTPAID", "N");
                        ////        }

                        ////        //Send AutoPaid Commission.
                        ////        DataRow[] drAutoPaidPair = dtCappingPair.Select("PairAchieved in (" + DeductablePair + ")");
                        ////        if (drAutoPaidPair.Length != 0)
                        ////        {
                        ////            int TotalPair = drAutoPaidPair.Length;
                        ////            double Commission = TotalPair * int.Parse(MatchingIncome);
                        ////            AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Commission.ToString(), ClosingDate, AchievedDate, TotalPair.ToString(), ClosingType, "AUTOPAID", "N");
                        ////        }
                        ////    }
                        ////}

                        #endregion

                    }
                }
            }
        }

        public void UpdateAllCarryForwardAmountForClosing(string Start_iDate, string End_iDate, string StartDate, string EndDate, string ClosingNumber, string ClosingDate, string Closing_iDate, string DeleteID)
        {
            string sql = "Update payout set Start_date = '" + StartDate + "',End_date = '" + EndDate + "',Closing_date = '" + ClosingDate + "',Joining_date = '" + ClosingDate +
                         "',Deleteid = '" + DeleteID + "',Closingno = '" + ClosingNumber + "',Idate = N'" + Closing_iDate + "',Statre_Idate = '" + Start_iDate +
                         "',End_Idate = '" + End_iDate + "' where (Start_date is null or End_date is null) and Closingno='CarryForward' and ClosingType='CarryForward'";
            int i1 = imp.InsertUpdateDelete(sql);
        }

        public void UpdateRoyaltyCommission(string Start_iDate, string End_iDate, string ClosingNumber, string DeleteID, string ClosingDate, string StartDate, string EndDate)
        {
            string Ids = "0";
            string sql = "select  *, isnull((select Amount from RoyaltyDetails where ID=Level), 0) as Amount from RoyaltyAchievedTable where PaidStatus='NOTPAID' and Paid_iDate between " + Start_iDate + " and " + End_iDate;
            DataTable dtTemp = imp.FillTable(sql);
            foreach (DataRow dr in dtTemp.Rows)
            {
                Ids = Ids + "," + dr["ID"].ToString();
                string MemberCode = dr["MemberCode"].ToString();
                string Total = dr["Amount"].ToString();

                AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Total, ClosingDate, ClosingDate, "0", "Royalty", "NOTPAID", "N");
            }

            if (Ids != "")
            {
                sql = "update RoyaltyAchievedTable set Status='PAID', PaidStatus='PAID', ClosingNumber='" + ClosingNumber + "'  where Status='NOTPAID' and ID in (" + Ids + ")";
                int i1 = imp.InsertUpdateDelete(sql);
            }
        }

        public void UpdateCTOCommission(string Start_iDate, string End_iDate, string ClosingNumber, string DeleteID, string ClosingDate, string StartDate, string EndDate)
        {
            string Ids = "0";
            string sql = "select  * from CTOAchievedTable where PaidStatus='NOTPAID' and Paid_iDate between " + Start_iDate + " and " + End_iDate;
            DataTable dtTemp = imp.FillTable(sql);
            foreach (DataRow dr in dtTemp.Rows)
            {
                Ids = Ids + "," + dr["ID"].ToString();
                string MemberCode = dr["MemberCode"].ToString();
                string Total = dr["TotalAmount"].ToString();

                AddToPayOutTable(MemberCode, StartDate, EndDate, ClosingNumber, DeleteID, Total, ClosingDate, ClosingDate, "0", "CTO", "NOTPAID", "N");
            }

            if (Ids != "")
            {
                sql = "update CTOAchievedTable set Status='PAID', PaidStatus='PAID', ClosingNumber='" + ClosingNumber + "'  where Status='NOTPAID' and ID in (" + Ids + ")";
                int i1 = imp.InsertUpdateDelete(sql);
            }
        }

        public bool IsValidForMoreCappingPair(string MemberCode)
        {
            string sql = "select  * from TopUpMemberList where MemberCode='" + MemberCode + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0) { return true; }
            return false;
        }

        public void InsertException(string Message, string Page)
        {
            DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            string date = dtToday.ToString("dd/MM/yyyy");
            string time = dtToday.ToString("hh:mm:ss tt");

            string sql = "insert into ExceptionDetails(exception_message,date,time,page) values ('" + Message + "','" + date + "','" + time + "','" + Page + "')";
            int i = imp.InsertUpdateDelete(sql);
        }

        #endregion

        #region During Closing Process

        public void UpdateSpillIncome(DataTable dtTemp, string StartDate, string EndDate, string CLosingNumber, string deleteid, string ClosingDate, string date)
        {
            DataTable dtNewTable = dtTemp.Copy();
            //Get Distinct MemberCode From Daily Child Table.
            DataTable dtTempMember = dtTemp.DefaultView.ToTable(true, "Referal_code");
            foreach (DataRow dr in dtTempMember.Rows)
            {
                double SpillCommission = 0;
                string MemberCode = dr["Referal_code"].ToString();
                DataRow[] drCount = dtNewTable.Select("Referal_code='" + MemberCode + "' and Referal_code<>Sponcer_code");
                if (drCount.Length != 0)
                {
                    DataTable dtTempSpill = drCount.CopyToDataTable();
                    SpillCommission = Convert.ToDouble(dtTempSpill.Compute("SUM(JoiningAmount)", "JoiningAmount>=0"));
                    SpillCommission = SpillCommission * 10 * 0.01;
                }

                string UpdateTo = "Referral";
                int TotalReferral = drCount.Length;

                double Total = SpillCommission;
                if (Total > 0)
                {
                    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, Total.ToString(), ClosingDate, date, TotalReferral.ToString(), UpdateTo, "NOTPAID", "N");
                }
            }
        }

        public string FindMemberPosition(string MemberCode)
        {
            string Position = "";
            DataRow[] drAllMember = dtAllMember.Select("Member_code='" + MemberCode + "'");
            if (drAllMember.Length != 0)
            {
                Position = drAllMember[0]["Position"].ToString().ToUpper();
            }
            return Position;
        }

        public string FindSponsorCode(string MemberCode)
        {
            string Position = "";
            DataRow[] drAllMember = dtAllMember.Select("Member_code='" + MemberCode + "'");
            if (drAllMember.Length != 0)
            {
                Position = drAllMember[0]["Sponcer_code"].ToString().ToUpper();
            }
            else { Position = AdminCode; }
            return Position;
        }

        public string FindJoiningTime(string MemberCode)
        {
            string Joiningtime = "";
            DataRow[] drAllMember = dtAllMember.Select("Member_code='" + MemberCode + "'");
            if (drAllMember.Length != 0)
            {
                Joiningtime = drAllMember[0]["Verification_time"].ToString().ToUpper();
                if (Joiningtime == "")
                {
                    Joiningtime = drAllMember[0]["Joiningtime"].ToString().ToUpper();
                }
            }
            else { Joiningtime = "00:00:00 AM"; }
            return Joiningtime;
        }

        public int FindRatioType(int PairLevel)
        {
            int RatioType = 0;
            DataRow[] drRatio = dtCycle1.Select("Level<='" + PairLevel + "'", "ID DESC");
            if (drRatio.Length != 0)
            {
                RatioType = int.Parse(drRatio[0]["RatioType"].ToString());
            }
            return RatioType;
        }

        public PairInfo FindRatio(int RatioType, int CurrentPairLevel)
        {
            PairInfo r = new PairInfo();
            r.Left = "";
            r.Right = "";
            r.WhenEqual = "";
            DataRow[] drRatio = dtCycle1.Select("RatioType='" + RatioType + "' and Level<='" + (CurrentPairLevel) + "'", "ID DESC");
            if (drRatio.Length != 0)
            {
                r.Left = drRatio[0]["LeftRatio"].ToString();
                r.Right = drRatio[0]["RightRatio"].ToString();
                r.WhenEqual = drRatio[0]["WhenEqual"].ToString();
            }
            return r;
        }
        public void UpdatePairIn_DailyChildTable(string MemberCode, string StartDate, string ClosingNumber, string DeleteID, string Interval,
                                                 bool IsIntervalWise = false, int NoOfInterval = 1)
        {
            string Position = FindMemberPosition(MemberCode);         // Position = LEFT or RIGHT;
            string SponsorCode = FindSponsorCode(MemberCode);
            string JoiningTime = FindJoiningTime(MemberCode);
            DateTime dtStartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (SponsorCode == AdminCode) { return; }
            else
            {
                //Get All Daily Child Taable Each Time...
                GetAllDailyChildTable();


                DataRow[] drDailyChild = dtDailyChild.Select("Membercode='" + SponsorCode + "' and Date='" + StartDate + "' and  Closingno='" + ClosingNumber +
                                                             "' and  Interval = '" + Interval + "'");
                if (drDailyChild.Length != 0)
                {
                    int Left = int.Parse(drDailyChild[0]["Total_leftchild"].ToString());
                    int Right = int.Parse(drDailyChild[0]["Total_rightchild"].ToString());
                    int Pair = int.Parse(drDailyChild[0]["Pair"].ToString());

                    //Update Pair Here.
                    PairInfo pairUpdate = GetUpdatePairValue(Left, Right, Pair, Position, SponsorCode, ClosingNumber, StartDate, Interval);

                    string LeftChild = pairUpdate.Left;
                    string RightChild = pairUpdate.Right;
                    string PairChild = pairUpdate.Pair;

                    UpdateInToDailyChildTableInDataBase(SponsorCode, StartDate, ClosingNumber, LeftChild, RightChild, PairChild, Interval);
                }
                else
                {
                    string Membercode = SponsorCode;
                    PairInfo p = FindPreviousPairInfo(Membercode, StartDate);

                    int Left = int.Parse(p.Left);
                    int Right = int.Parse(p.Right);
                    int Pair = int.Parse(p.Pair);

                    string Date = StartDate;
                    string Time = JoiningTime;
                    DateTime dtNewDate = DateTime.ParseExact(Date + " " + Time, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    string Closingno = ClosingNumber;

                    //Update Pair Here.
                    PairInfo pairUpdate = GetUpdatePairValue(Left, Right, Pair, Position, SponsorCode, ClosingNumber, StartDate, Interval);
                    string Total_leftchild = pairUpdate.Left;
                    string Total_rightchild = pairUpdate.Right;
                    string NewPair = pairUpdate.Pair;
                    int Idate = int.Parse(dtStartDate.ToString("yyyyMMdd"));

                    InsertInToDailyChildTableInDataBase(ClosingNumber, DeleteID, Idate.ToString(), Date, Time, Membercode, Total_leftchild, Total_rightchild, NewPair, Interval);

                }

                UpdatePairIn_DailyChildTable(SponsorCode, StartDate, ClosingNumber, DeleteID, Interval);
            }
        }

        public void AddPairInMemberPairLevel(int PairAchieved, string MemberCode, string AchievedDate, string ClosingNumber, string Interval)
        {
            //MemberCode, PairAchieved, IsUsed, AchievedDate, ClosingNumber
            //dtMemberPairLevel.Rows.Add(MemberCode, Pair, "0", AchievedDate, ClosingNumber);
            //select MemberCode, PairAchieved, IsUsed, AchievedDate, ClosingNumber, ID from MemberPairLevel order by ID asc
            InsertInToMemberPairLevelInDataBase(MemberCode, ClosingNumber, PairAchieved.ToString(), AchievedDate, Interval);
        }

        public int GetPreviousMemberPair(string MemberCode)
        {
            string sql = "select Membercode, SUM(convert(int, Pair)) as Pair from Daily_child_table where  Membercode='" + MemberCode + "'  group by Membercode";
            DataTable dtClosingPair = imp.FillTable(sql);

            if (dtClosingPair.Rows.Count != 0) { return int.Parse(dtClosingPair.Rows[0]["Pair"].ToString()); }

            //Get All Member Pair Level From DB.
            //GetAllMemberPairLevel();

            //int Pair = 0;
            //DataRow[] drAllPairLevel = dtMemberPairLevel.Select("MemberCode='" + MemberCode + "'", "PairAchieved DESC");
            //if (drAllPairLevel.Length != 0)
            //{
            //    Pair = int.Parse(drAllPairLevel[0]["PairAchieved"].ToString());
            //}
            return 0;
        }

        public IsPairValidTest IsPairVaild(int Left, int Right, int Pair, string Position, string MemberCode)
        {
            IsPairValidTest iPair = new IsPairValidTest();

            int TempIndex = 1;
            int Level = Pair + TempIndex;
            int RatioType = FindRatioType(Level);
            if (RatioType == 0)
            {
                //work on only LEFT OR RIGHT, ANY ONE.
                PairInfo pairRatio = FindRatio(RatioType, Level);

                // 1. Check Left or Right Ratio
                string[] strLeft = pairRatio.Left.Split(':');
                if (int.Parse(strLeft[0]) <= Left && int.Parse(strLeft[1]) <= Right)
                {
                    iPair.Left = int.Parse(strLeft[0]);
                    iPair.Right = int.Parse(strLeft[1]);
                    iPair.IsPairValid = true;
                    return iPair;
                }
            }
            else
            {
                //work on Both LEFT & RIGHT.
                PairInfo pairRatio = FindRatio(RatioType, Level);

                if (Left == Right)
                {
                    // 1. Check Left Ratio
                    string[] strLeft = pairRatio.WhenEqual.Split(':');
                    if (int.Parse(strLeft[0]) <= Left && int.Parse(strLeft[1]) <= Right)
                    {
                        iPair.Left = int.Parse(strLeft[0]);
                        iPair.Right = int.Parse(strLeft[1]);
                        iPair.IsPairValid = true;
                        return iPair;
                    }

                    // 1. Check Right Ratio
                    string[] strRight = pairRatio.WhenEqual.Split(':');
                    if (int.Parse(strRight[0]) <= Left && int.Parse(strRight[1]) <= Right)
                    {
                        iPair.Left = int.Parse(strRight[0]);
                        iPair.Right = int.Parse(strRight[1]);
                        iPair.IsPairValid = true;
                        return iPair;
                    }
                }
                else if (Left > Right)
                {
                    // 1. Check Left Ratio
                    string[] strLeft = pairRatio.Left.Split(':');
                    if (int.Parse(strLeft[0]) <= Left && int.Parse(strLeft[1]) <= Right)
                    {
                        iPair.Left = int.Parse(strLeft[0]);
                        iPair.Right = int.Parse(strLeft[1]);
                        iPair.IsPairValid = true;
                        return iPair;
                    }

                    // 1. Check Right Ratio
                    string[] strRight = pairRatio.Right.Split(':');
                    if (int.Parse(strRight[0]) <= Left && int.Parse(strRight[1]) <= Right)
                    {
                        iPair.Left = int.Parse(strRight[0]);
                        iPair.Right = int.Parse(strRight[1]);
                        iPair.IsPairValid = true;
                        return iPair;
                    }
                }
                else
                {
                    // 1. Check Right Ratio
                    string[] strRight = pairRatio.Right.Split(':');
                    if (int.Parse(strRight[0]) <= Left && int.Parse(strRight[1]) <= Right)
                    {
                        iPair.Left = int.Parse(strRight[0]);
                        iPair.Right = int.Parse(strRight[1]);
                        iPair.IsPairValid = true;
                        return iPair;
                    }

                    // 1. Check Left Ratio
                    string[] strLeft = pairRatio.Left.Split(':');
                    if (int.Parse(strLeft[0]) <= Left && int.Parse(strLeft[1]) <= Right)
                    {
                        iPair.Left = int.Parse(strLeft[0]);
                        iPair.Right = int.Parse(strLeft[1]);
                        iPair.IsPairValid = true;
                        return iPair;
                    }
                }
            }

            iPair.IsPairValid = false;
            return iPair;
        }

        public bool IsValidPairCondition(string MemberCode, string JoiningDate)
        {
            int Joining_iDate_1 = int.Parse(imp.ConvertStringTo_iDate(JoiningDate));

            //string sql = "select *, (select (Convert(int, (Convert(varchar, Convert(datetime, isnull(Verification_date, " + dtToday.ToString("dd/MM/yyyy") +
            //             "), 103), 112)))) as Joining_iDate from Member_registration m  where m.Member_code=b.member_code) as Joining_iDate from binary_status " +
            //             "b where b.introducer_code='" + MemberCode + "'";

            string sql = "select Sponcer_code,Member_code,Verification_idate from Member_registration  where Sponcer_code='" + MemberCode + "'";

            dtAllBinary = imp.FillTable(sql);

            if (dtAllBinary.Rows.Count >= 2)
            {
                int count = 0;
                MemberCode = "";
                foreach (DataRow drX in dtAllBinary.Rows)
                {
                    if (MemberCode == "") { MemberCode = "'" + drX["Member_code"].ToString() + "'"; }
                    else { MemberCode = MemberCode + ",'" + drX["Member_code"].ToString() + "'"; }
                    if (drX["Verification_idate"].ToString() != "")
                    {
                        int Joining_iDate = int.Parse(drX["Verification_idate"].ToString());
                        if (Joining_iDate <= Joining_iDate_1)
                        {
                            count = count + 1;
                        }
                    }
                }
                if (count == 2)
                {
                    //sql = "select *, (select (Convert(int, (Convert(varchar, Convert(datetime, isnull(Verification_date, " + dtToday.ToString("dd/MM/yyyy") +
                    //      "), 103), 112)))) as Joining_iDate from Member_registration m  where m.Member_code=b.member_code) as Joining_iDate from binary_status " +
                    //      "b where b.introducer_code in (" + MemberCode + ")";

                    sql = "select Sponcer_code,Member_code,Verification_idate from Member_registration where Sponcer_code in (" + MemberCode + ")";

                    dtAllBinary = imp.FillTable(sql);
                    if (dtAllBinary.Rows.Count != 0)
                    {
                        foreach (DataRow drNN in dtAllBinary.Rows)
                        {
                            if (drNN["Verification_idate"].ToString() != "")
                            {
                                int Joining_iDate = int.Parse(drNN["Verification_idate"].ToString());
                                if (Joining_iDate <= Joining_iDate_1)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void GetAllBinary()
        {
            string sql = "select *, (select (Convert(int, (Convert(varchar, Convert(datetime, Date, 103), 112)))) as Joining_iDate from Member_registration m " +
                         "where m.Member_code=b.member_code) as Joining_iDate from binary_status b";
            dtAllBinary = imp.FillTable(sql);
        }

        public PairInfo GetUpdatePairValue(int Left, int Right, int Pair, string Position, string MemberCode, string ClosingNumber, string AchievedDate, string Interval)
        {
            PairInfo p = new PairInfo();
            if (Position == "LEFT") { Left = Left + Point; }
            if (Position == "RIGHT") { Right = Right + Point; }

            // Check Here Pair Is Valid.
            int PrevPair = GetPreviousMemberPair(MemberCode);
            //if (IsValidPairCondition(MemberCode, AchievedDate))       //For Check 2:1 or 1:2 
            //{
            IsPairValidTest iPair = IsPairVaild(Left, Right, PrevPair, Position, MemberCode);
            if (iPair.IsPairValid)
            {
                if (Left >= iPair.Left && Right >= iPair.Right)
                {
                    int minValue = 0;
                    if (Left >= Right) { minValue = Right; } else { minValue = Left; }

                    //Pair = Pair + minValue;
                    //Left = Left - minValue;
                    //Right = Right - minValue;

                   
                    if (PrevPair == 0)
                    {
                        //if (IsValidPairCondition(MemberCode, AchievedDate))       //For Check 2:1 or 1:2 
                        //{
                        Pair = Pair + minValue;
                        Left = Left - minValue;
                        Right = Right - minValue;
                        //}
                    }
                    else
                    {
                        Pair = Pair + minValue;
                        Left = Left - minValue;
                        Right = Right - minValue;
                    }
                }
            }
            //}
            p.Left = Left.ToString(); p.Right = Right.ToString(); p.Pair = Pair.ToString();
            return p;
        }

        public PairInfo FindPreviousPairInfo(string MemberCode, string StartDate)
        {
            PairInfo p = new PairInfo();
            p.Left = "0"; p.Right = "0"; p.Pair = "0";
            DataRow[] drDailyChild = dtDailyChild.Select("Membercode='" + MemberCode + "'", "ID DESC");//, "col1 ASC"
            if (drDailyChild.Length != 0)
            {


                p.Left = drDailyChild[0]["Total_leftchild"].ToString();
                p.Right = drDailyChild[0]["Total_rightchild"].ToString();
                p.Pair = "0";
            }
            return p;
        }

        #endregion

        #region  After Successfully Update DailyChild Table in Runtime

        public void UpdateDailyChildTable_Using_Business_Plan(string StartDate, string EndDate, string CLosingNumber, string DeleteID, DataTable dtTemp, string UpdateTo)
        {
            DataTable dtNewTable = dtTemp.Copy();
            //Get Distinct MemberCode From Daily Child Table.
            DataTable dtTempMember = dtTemp.DefaultView.ToTable(true, "Membercode");

            string Start_iDate = imp.ConvertStringTo_iDate(StartDate);
            string End_iDate = imp.ConvertStringTo_iDate(EndDate);

            foreach (DataRow dr in dtTempMember.Rows)
            {
                string MemberCode = dr["Membercode"].ToString();
                string ClosingDate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
                GetMemberPairDetail(MemberCode, Start_iDate, End_iDate, CLosingNumber, StartDate, EndDate, ClosingDate, DeleteID, dtNewTable, UpdateTo);
            }
        }

        public void GetMemberPairDetail(string MemberCode, string Start_iDate, string End_iDate, string CLosingNumber, string StartDate, string EndDate,
                                        string ClosingDate, string DeleteID, DataTable dtTemp, string UpdateTo)
        {
            GetAllDailyChildTable();
            DataRow[] drMember = dtTemp.Select("Membercode = '" + MemberCode + "' and Idate>=" + Start_iDate + " and Idate <=" + End_iDate);

            int AutoPaidPair = 0;
            int DailyCappingPair = 0;

            #region     Weekly Closing

            //Sum All Pair
            if (drMember.Length != 0)
            {

                //if (IsValidForMoreCappingPair(MemberCode)) { CappingPair_Max = 100; }

                //DataTable dtTempDailyChildTable = drMember.CopyToDataTable();

                //int TotalPair = 0;

                //if (dtTempDailyChildTable.Rows.Count != 0)
                //{
                //    TotalPair = Convert.ToInt32(dtTempDailyChildTable.Compute("SUM(TotalPair)", "TotalPair>=0"));
                //}

                //int PairLevel = TotalPair;

                ////Check here Weekly Capping.
                //if (PairLevel > CappingPair_Max) { AutoPaidPair = PairLevel - CappingPair_Max; PairLevel = CappingPair_Max; }


                //double Commission = GetCommission(PairLevel);
                //double LapseCommission = Commission;

                //double Total = PairLevel * Commission;
                //double TotalAutoPaid = AutoPaidPair * LapseCommission;


                //string deleteid = DeleteID;
                //string date = ClosingDate;

                //if (Total > 0)
                //{
                //    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, Total.ToString(), ClosingDate, date, PairLevel.ToString(), UpdateTo, "NOTPAID", "N");
                //}
                //if (TotalAutoPaid > 0)
                //{
                //    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, TotalAutoPaid.ToString(), ClosingDate, date, PairLevel.ToString(), UpdateTo, "AUTOPAID", "Y");
                //}
            }


            #endregion

            #region     Daily Closing

            foreach (DataRow dr in drMember)
            {
                int PairLevel = int.Parse(dr["Pair"].ToString());

                //Check here Daily Capping.
                if (PairLevel > DailyCappingPair) { AutoPaidPair = PairLevel - DailyCappingPair; PairLevel = DailyCappingPair; }

                double LapseCommission = 50;
                double Commission = GetCommission(PairLevel);

                double Total = PairLevel * Commission;
                double TotalAutoPaid = AutoPaidPair * LapseCommission;


                string deleteid = DeleteID;
                string date = dr["Date"].ToString();

                if (Total > 0)
                {
                    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, Total.ToString(), ClosingDate, date, PairLevel.ToString(), UpdateTo, "NOTPAID", "N");
                }
                if (TotalAutoPaid > 0)
                {
                    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, TotalAutoPaid.ToString(), ClosingDate, date, PairLevel.ToString(), UpdateTo, "NOTPAID", "Y");
                }
            }

            #endregion

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
            string carryAmount = "0";

            if (check_member_verification(Member_code))
            {
                Status = "PAYMENT NOT CLEARED DUE TO CODE VERIFICATION.";
            }

            string sql = "insert into payout(Member_code,Start_date,End_date,Slip_no,Totalamount,Tds,Servicecharge,Final_amount,Closing_date,Joining_date,Status,Paid_date," +
                         "Pair_no,interval,Deleteid,Closingno,Idate,Statre_Idate,End_Idate,Auto_pair_deduct,ClosingType, IsLapse,carryAmount) values ('" + Member_code + "','" + Start_date + "','" + End_date +
                         "','" + Slip_no + "','" + Totalamount + "','" + Tds + "','" + Servicecharge + "','" + Final_amount + "','" + Closing_date + "','" + Joining_date +
                         "','" + Status + "','" + Paid_date + "','" + Pair_no + "','" + interval + "','" + Deleteid + "','" + Closingno + "',N'" + Idate + "','" + Statre_Idate +
                         "','" + End_Idate + "','" + Auto_pair_deduct + "','" + ClosingType + "','" + IsLapse + "','" + carryAmount + "')";
            int i = imp.InsertUpdateDelete(sql);

        }

        private bool check_member_verification(string Member_code)
        {
            string sql = "select * from Member_registration where  Member_code='" + Member_code + "' and Paidstatus='FREE' ";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public double GetAdminCharge(double Amount, string MemberCode)
        {
            double admiCharge = imp.AdminCharge * 0.01;
            Amount = Amount * admiCharge;
            return Amount;
        }

        public bool IsClosingExist(string Start_iDate, string End_iDate, string Interval = "1")
        {
            string sql = "select * from closing where  I_Start_date='" + Start_iDate + "' and I_End_date='" + End_iDate + "' and Interval='" + Interval + "'";
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

        public void UpdateClosingStatusInClosingTable(string closingNumber, string Status)
        {
            string sql = "update closing set ClosingStatus = '" + Status + "' where Closingno='" + closingNumber + "'";
            int i = imp.InsertUpdateDelete(sql);
        }

        public void UpdateMemberPairLevelInDataBase(DataTable dtTemp, string ClosingNumber, string StartDate, string EndDate, string ClosingDate)
        {
            DataRow[] drPairLevelPlan = dtMemberPairLevel.Select("ClosingNumber='" + ClosingNumber + "'");
            foreach (DataRow dr in dtTemp.Rows)
            {
                string MemberCode = dr["MemberCode"].ToString();
                string PairAchieved = dr["PairAchieved"].ToString();
                string IsUsed = dr["IsUsed"].ToString();
                string AchievedDate = dr["AchievedDate"].ToString();
                ClosingNumber = dr["ClosingNumber"].ToString();

                string sql = "insert into MemberPairLevel(MemberCode,PairAchieved,IsUsed,AchievedDate,ClosingNumber) values ('" + MemberCode + "','" + PairAchieved +
                             "','" + IsUsed + "','" + AchievedDate + "','" + ClosingNumber + "')";
                int i = imp.InsertUpdateDelete(sql);

                //UpdatePayoutUsingPairNumber(int.Parse(PairAchieved), MemberCode, AchievedDate, StartDate, EndDate, ClosingNumber, ClosingDate);
            }
        }

        public void InsertInToMemberPairLevelInDataBase(string MemberCode, string ClosingNumber, string PairAchieved, string AchievedDate, string Interval)
        {
            string IsUsed = "0";

            #region NO NEED

            //string StartDate = Closing_StartDate;
            //string EndDate = Closing_EndDate;
            //string StartDate = Closing_StartDate;

            #endregion

            string sql = "insert into MemberPairLevel(MemberCode,PairAchieved,IsUsed,AchievedDate,ClosingNumber, Interval) values ('" + MemberCode + "','" + PairAchieved +
                         "','" + IsUsed + "','" + AchievedDate + "','" + ClosingNumber + "','" + Interval + "')";
            int i = imp.InsertUpdateDelete(sql);

        }
        public double GetCommission(int PairLevel)
        {
            double commission = 0;
            DataRow[] drCommission = dtCycle1.Select("Level<='" + PairLevel + "'", "ID DESC");
            if (drCommission.Length != 0)
            {
                commission = double.Parse(drCommission[0]["Income"].ToString());
            }
            return commission;
        }

        public void UpdatePayoutUsingPairNumber(int PairLevel, string MemberCode, string AchievedDate, string StartDate, string EndDate, string CLosingNumber, string ClosingDate)
        {
            //PairLevel = GetRealPairLevel(PairLevel, MemberCode);
            double Commission = GetCommission(PairLevel);
            bool IsCapping = true;
            string deleteid = "";
            string date = AchievedDate;
            if (Commission > 0)
            {
                if (IsCapping)
                {
                    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, Commission.ToString(), ClosingDate, date, PairLevel.ToString());
                }
                else
                {
                    //It is for AUTOPAID.
                    AddToPayOutTable(MemberCode, StartDate, EndDate, CLosingNumber, deleteid, Commission.ToString(), ClosingDate, date, PairLevel.ToString());
                }
            }
        }


        public void AddToPayOutTable(string MemberCode, string StartDate, string EndDate, string ClosingNumber, string DeleteID, string Commission,
                                     string ClosingDate, string JoiningDate, string PairNumber)
        {
            string Member_code = MemberCode;
            string Start_date = StartDate;
            string End_date = EndDate;
            string Slip_no = "0";
            string Totalamount = Commission;
            string Tds = GetTDS(double.Parse(Totalamount), MemberCode).ToString("0.00");
            string Servicecharge = GetAdminCharge(double.Parse(Totalamount)).ToString("0.00");
            string Final_amount = GetFinalAmount(Totalamount, Tds, Servicecharge);
            string Closing_date = ClosingDate;
            string Joining_date = JoiningDate;
            string Status = "NOTPAID";
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
                         "Pair_no,interval,Deleteid,Closingno,Idate,Statre_Idate,End_Idate,Auto_pair_deduct) values ('" + Member_code + "','" + Start_date + "','" + End_date +
                         "','" + Slip_no + "','" + Totalamount + "','" + Tds + "','" + Servicecharge + "','" + Final_amount + "','" + Closing_date + "','" + Joining_date +
                         "','" + Status + "','" + Paid_date + "','" + Pair_no + "','" + interval + "','" + Deleteid + "','" + Closingno + "',N'" + Idate + "','" + Statre_Idate +
                         "','" + End_Idate + "','" + Auto_pair_deduct + "')";
            int i = imp.InsertUpdateDelete(sql);
            if (i == 0) { imp.InsertException(sql, "Closing.aspx"); }
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

        //public void UpdateMemberPairLevel_AccordingToPlan(string ClosingNumber, string DeleteID)
        //{
        //    string sql = "select * from Daily_child_table where Closingno='" + ClosingNumber + "' order by Id asc";
        //    dtDailyChild = imp.FillTable(sql);

        //    DataTable dtDistinctMember = dtDailyChild.DefaultView.ToTable(true, "Membercode");

        //    foreach (DataRow dr in dtDistinctMember.Rows)
        //    {
        //        int Pair = 0;
        //        string MemberCode = dr["Membercode"].ToString();
        //        DataRow[] drLeftRight = dtDailyChild.Select("Membercode='" + MemberCode + "'", "id DESC");
        //        if (drLeftRight.Length != 0)
        //        {
        //            int Left = int.Parse(drLeftRight[0]["Total_leftchild"].ToString());
        //            int Right = int.Parse(drLeftRight[0]["Total_rightchild"].ToString());
        //            string RowID = drLeftRight[0]["id"].ToString();
        //            string Position = "";
        //            if (MemberCode == "43457576" || MemberCode == "53379216")
        //            {
        //                string Xstring = "";
        //            }
        //            bool IsLoopStatus = true;
        //            while (IsLoopStatus)
        //            {
        //                // Check Here Pair Is Valid.
        //                int PrevPair = GetPreviousMemberPair(MemberCode);
        //                IsPairValidTest iPair = IsPairVaild(Left, Right, PrevPair, Position, MemberCode);

        //                if (iPair.IsPairValid)
        //                {
        //                    if (Left >= iPair.Left && Right >= iPair.Right)
        //                    {
        //                        Pair = Pair + 1;
        //                        Left = Left - iPair.Left;
        //                        Right = Right - iPair.Right;

        //                        string AchievedDate = dtToday.ToString("dd/MM/yyyy");
        //                        AddPairInMemberPairLevel(PrevPair + 1, MemberCode, AchievedDate, ClosingNumber);
        //                        IsLoopStatus = true;
        //                    }
        //                }
        //                else { IsLoopStatus = false; }
        //            }
        //            if (Pair > 0)
        //            {
        //                //UpdatePairCountInDailyChildTable(RowID, Pair.ToString(), Left.ToString(), Right.ToString(), DeleteID, ClosingNumber, MemberCode);
        //            }
        //        }
        //    }
        //}

        public void AddIn_Closin_Table(string StartDate, string EndDate, string ClosingDate, string closingNumber, string Deleteid, string IntervalStatus = "1")
        {
            string Idate = imp.ConvertStringTo_iDate(ClosingDate);
            string Closing_Time = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");
            string I_Start_date = imp.ConvertStringTo_iDate(StartDate);
            string I_End_date = imp.ConvertStringTo_iDate(EndDate);

            string sql = "insert into closing(Start_date, End_date, Date, Closingno, Idate, Deleteid, Closing_Time, I_Start_date, I_End_date, ClosingStatus, Interval) values ('" +
                         StartDate + "','" + EndDate + "','" + ClosingDate + "','" + closingNumber + "','" + Idate + "','" + Deleteid + "','" + Closing_Time + "','" +
                         I_Start_date + "','" + I_End_date + "','InProcess','" + IntervalStatus + "')";
            int i = imp.InsertUpdateDelete(sql);
        }

        public void UpdateDailyChildTableInDataBase(string ClosingNumber, string DeleteID)
        {
            DataRow[] drDailyMember = dtDailyChild.Select("Closingno='" + ClosingNumber + "'");
            foreach (DataRow dr in drDailyMember)
            {
                string Membercode = dr["Membercode"].ToString();
                string Total_leftchild = dr["Total_leftchild"].ToString();
                string Total_rightchild = dr["Total_rightchild"].ToString();
                string Pair = dr["Pair"].ToString();
                string Date = dr["Date"].ToString();
                string Time = dr["Time"].ToString();
                string Closingno = ClosingNumber;
                string Idate = dr["Idate"].ToString();

                string sql = "insert into Daily_child_table(Membercode,Total_leftchild,Total_rightchild,Pair,Date,Time,Deleteid,Closingno,Idate) values ('" + Membercode +
                             "','" + Total_leftchild + "','" + Total_rightchild + "','" + Pair + "','" + Date + "','" + Time + "','" + DeleteID + "','" + Closingno +
                             "',N'" + Idate + "')";
                int i = imp.InsertUpdateDelete(sql);
            }
        }

        public void InsertInToDailyChildTableInDataBase(string ClosingNumber, string DeleteID, string Idate, string Date, string Time,
                                                        string MemberCode, string Left, string Right, string Pair, string Interval)
        {
            string sql = "insert into Daily_child_table(Membercode, Total_leftchild, Total_rightchild, Pair,Date, Time,Deleteid, Closingno, Idate, Interval) values ('" +
                         MemberCode + "','" + Left + "','" + Right + "','" + Pair + "','" + Date + "','" + Time + "','" + DeleteID + "','" + ClosingNumber +
                         "',N'" + Idate + "','" + Interval + "')";
            int i = imp.InsertUpdateDelete(sql);
        }

        public void UpdateInToDailyChildTableInDataBase(string MemberCode, string Date, string ClosingNumber, string Left, string Right, string Pair, string Interval)
        {
            string sql = "update Daily_child_table set Total_leftchild='" + Left + "', Total_rightchild='" + Right + "', Pair='" + Pair + "' where Membercode='" + MemberCode +
                         "' and Date='" + Date + "' and Closingno='" + ClosingNumber + "' and Interval='" + Interval + "'";
            int i = imp.InsertUpdateDelete(sql);
        }
        #endregion

        #region Before Closing Start

        public void GetAllDataFromTableFor_Closing()
        {
            GetAllMemberFromRegistrationTable();
            GetCycle1();
        }

        public void GetAllMemberPairLevel()
        {
            string sql = "select MemberCode, PairAchieved, IsUsed, AchievedDate, ClosingNumber, ID from MemberPairLevel order by ID asc";
            dtMemberPairLevel = imp.FillTable(sql);
        }

        public void GetAllDailyChildTable()
        {
            string sql = "select (Convert(datetime, Date + ' ' + Time, 103)) as JoiningDateTime, *, (convert(int, isnull(Pair, 0))) as TotalPair from Daily_child_table order by Id asc";
            dtDailyChild = imp.FillTable(sql);
        }

        public void GetAllMemberFromRegistrationTable()
        {
            string sql = "select Id as SKSID, (Convert(datetime, Date + ' ' + Joiningtime, 103)) as JoiningDateTime, (Convert(int, (Convert(varchar, Convert(datetime, Date, 103), 112)))) " +
                         "as Joining_iDate, (Convert(int, (Convert(varchar, Convert(datetime, Verification_date, 103), 112)))) as Verification_iDate, *, (convert(int, isnull(Joining_amount, 0))) as JoiningAmount from Member_registration order by Id";
            dtAllMember = imp.FillTable(sql);
        }

        public void GetCycle1()
        {
            string sql = " select * from Cycle1 order by Id";
            dtCycle1 = imp.FillTable(sql);
        }

        #endregion

    }
}