using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.App_Code
{
    public class thread_class
    {
        Important imp = new Important();
        DataTable dtAllMember;
        DataTable dtAllMemberForMemberCount;
        DataTable dtReliablePlan;
        DataTable dtBinary;

        string AdminCode = "BMHP1234";

        
        public void GetAllMemberForMemberCount()
        {
            string sql = "select * from Member_registration order by id asc";
            dtAllMemberForMemberCount = imp.FillTable(sql);
        }

        public string GetPosition1(string MemberCode, DataTable dtTemp)
        {
            DataRow[] dr = dtTemp.Select("Member_code='" + MemberCode + "'");
            if (dr.Length != 0)
            {
                string Position = dr[0]["Position"].ToString();
                return Position;
            }
            return AdminCode;
        }

        public string GetSponsorCode1(string MemberCode, DataTable dtTemp)
        {
            DataRow[] dr = dtTemp.Select("Member_code='" + MemberCode + "'");
            if (dr.Length != 0)
            {
                string SponsorCode = dr[0]["Sponcer_code"].ToString();
                return SponsorCode;
            }
            return AdminCode;
        }

        public bool UpdateLeftRightForMemberCount(string MemberCode)
        {
            AdminCode = imp.AdminCode;
            string sql = "";
            try
            {
                GetAllMemberForMemberCount();
                string SponsorCode = GetSponsorCode1(MemberCode, dtAllMemberForMemberCount);
                string Position = GetPosition1(MemberCode, dtAllMemberForMemberCount);

                string RewardPoint = "0"; //GetMemberRewardPoint(MemberCode);

                while (SponsorCode != AdminCode)
                {
                    DataRow[] dr = dtAllMemberForMemberCount.Select("Member_code='" + SponsorCode + "'");
                    if (dr.Length != 0)
                    {
                        if (Position == "Left") { sql = "update Member_registration set LeftChild = LeftChild + 1, LeftRewardPoint = LeftRewardPoint + " + RewardPoint + "  where  Member_code='" + SponsorCode + "'"; }
                        if (Position == "Right") { sql = "update Member_registration set RightChild = RightChild + 1, RightRewardPoint = RightRewardPoint + " + RewardPoint + "  where  Member_code='" + SponsorCode + "'"; }
                        if (Position == "Middle") { sql = "update Member_registration set MiddleChild = MiddleChild + 1, RightRewardPoint = RightRewardPoint + " + RewardPoint + "  where  Member_code='" + SponsorCode + "'"; }

                        int i = imp.InsertUpdateDelete(sql);
                        if (i == 0) { return false; }

                        Position = GetPosition1(SponsorCode, dtAllMemberForMemberCount);
                        SponsorCode = dr[0]["Sponcer_code"].ToString();
                    }
                }
            }
            catch (Exception ex) { return false; }

            return true;
        }

        public string GetMemberRewardPoint(string MemberCode)
        {
            DataRow[] dr = dtAllMemberForMemberCount.Select("Member_code='" + MemberCode + "'");
            if (dr.Length != 0) { return dr[0]["RewardPoint"].ToString(); }

            return "0";
        }

    }
}