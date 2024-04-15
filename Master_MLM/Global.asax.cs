using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Master_MLM.App_Code;
using System.Timers;
using System.Data;
using System.Data.SqlClient;


namespace Master_MLM
{
    public class Global : System.Web.HttpApplication
    {

        public static bool memberCountStatus = true;
        public static bool TrioCountStatus = true;
        public static bool IsSMSSend = true;
        public static thread_class tc = new thread_class();
        public static List<RegistrationPageUpdate> SMSList = new List<RegistrationPageUpdate>();
        public static List<RegistrationPageUpdate> RegistrationMemberList = new List<RegistrationPageUpdate>();
        public static List<RegistrationPageUpdate> RegistrationMemberCountList = new List<RegistrationPageUpdate>();
        public static List<ExceptionMessage> RegistrationExceptionList = new List<ExceptionMessage>();

        protected void Application_Start(object sender, EventArgs e)
        {
            Thread thr = new Thread(starting_background_thread);
            thr.IsBackground = true;
            thr.Start();

        }

        private void starting_background_thread(object obj)
        {
            repurchase_royalty_update();

        }
        #region repurchase_royalty_update
        private static void repurchase_royalty_update()
        {

            string sql = " select distinct Member_code from Re_purchase_member_bv_point_details_monthly";
            Important imp = new Important();
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string membercode = dt.Rows[i][0].ToString().ToUpper();
                    featch_member_business(membercode);
                }
            }
        }

        private static void featch_member_business(string membercode)
        {
            string qry = @"Select isnull(Sum(cast(Self as float)),0) as Self_BV, 
(Select (isnull(Sum(cast(Self as float)),0)+isnull(Sum(cast(Team as float)),0)) as total from Re_purchase_member_bv_point_details_monthly where Member_code in(Select left_child from binary_status where member_code ='" + membercode + @"') ) as Left_PV,  
 (Select (isnull(Sum(cast(Self as float)),0)+isnull(Sum(cast(Team as float)),0)) as total from Re_purchase_member_bv_point_details_monthly where Member_code in(Select right_child from binary_status where member_code ='" + membercode + @"') ) as Right_PV 
 from Re_purchase_member_bv_point_details_monthly t1 where Member_code ='" + membercode + "'";
            Important imp = new Important();
            DataTable dt = imp.FillTable(qry);
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                double left_bv = Convert.ToDouble(dt.Rows[0][1].ToString());
                double right_bv = Convert.ToDouble(dt.Rows[0][2].ToString());
                if (left_bv >= 100000 && right_bv >= 100000)
                {
                    send_data_into_repurchase_royalty_achiever(membercode);
                }
            }
        }

        private static void send_data_into_repurchase_royalty_achiever(string membercode)
        {
            string Closing_date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string Idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");

            string qry = @"IF NOT EXISTS(Select * from Repurchase_Royalty_Member where MemberCode='" + membercode + @"' ) 
                           BEGIN 
                            insert into Repurchase_Royalty_Member(MemberCode,RoyaltyLevel,AchievedDate,Achieved_iDate)
                            values ('" + membercode + "','Diamond','" + Closing_date + "','" + Idate + @"') 
                           END ;";
            Important imp = new Important();
            int i = imp.InsertUpdateDelete(qry);
        }
        #endregion repurchase_royalty_update
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Start();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //do something with the timer
            Thread td = new Thread(new ThreadStart(UpdateMemberInformation));
            td.IsBackground = true;
            td.Start();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static void UpdateMemberInformation()
        {
           
            UpdateMemberCount();


            #region     UNUSED CODE


            //SendSMS();

            //if (TrioCountStatus)
            //{
            //    TrioCountStatus = false;

            //    foreach (var item in RegistrationMemberList)
            //    {
            //        //string SponsorID = item.SponsorCode;
            //        string MemberCode = item.MemberCode;
            //        //string MemberName = item.MemberName;
            //        //string Point = item.Point;
            //        //string JoiningDate = item.JoiningDate;
            //        //string Position = item.Position;

            //        if (tc.UpdateLeftRightForTrio(MemberCode)) { RegistrationMemberList.Remove(item); }

            //        //if (tc.UpdateRegistrationPage(SponsorID, MemberCode, MemberName, Point, JoiningDate, Position))
            //        //{ RegistrationMemberList.Remove(item); }

            //        break;
            //    }

            //    TrioCountStatus = true;
            //}

            #endregion
        }
        
        public static void UpdateMemberCount()
        {
            if (memberCountStatus)
            {
                memberCountStatus = false;

                foreach (var item in RegistrationMemberCountList)
                {
                    string MemberCode = item.MemberCode;
                    if (tc.UpdateLeftRightForMemberCount(MemberCode)) { RegistrationMemberCountList.Remove(item); }

                    break;
                }

                memberCountStatus = true;
            }
        }

   
    }

    public class RegistrationPageUpdate
    {
        public string MemberCode { get; set; }
        public string SponsorCode { get; set; }
        public string MemberName { get; set; }
        public string SponsorName { get; set; }
        public string Point { get; set; }
        public string Position { get; set; }
        public string JoiningDate { get; set; }
    }

    public class ExceptionMessage
    {
        public string MemberCode { get; set; }
        public string Message { get; set; }
    }
}