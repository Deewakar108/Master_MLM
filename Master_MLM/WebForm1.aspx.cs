using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Important imp = new Important();
        My myc = new My();
        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql = "select id,Verification_date,Verification_time,Interval from dbo.[Member_registration]  where Status='Verified' order by id asc";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                string id = "0";
                string Verification_date = "0";
                string Verification_time = "0";
                string date = "0";
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["id"].ToString();
                    Verification_date = dr["Verification_date"].ToString();
                    Verification_time = dr["Verification_time"].ToString();

                    date = Verification_date + " " + Verification_time;

                    string Interval = GetIntervalValue(date, Verification_date);
                    string qry = "Update Member_registration set Interval='" + Interval + "' where id='" + id + "' ";
                    myc.execute_Query(qry);
                }
            }











            //string sql = " select * from dbo.[Member_registration] order by id desc ";
            //DataTable dt = imp.FillTable(sql);
            //if (dt.Rows.Count != 0)
            //{
            //  foreach(DataRow dr in dt.Rows)
            //  {
            //      string Member_code = dr["Member_code"].ToString();
            //      RegistrationPageUpdate r = new RegistrationPageUpdate();
            //      r.MemberCode = Member_code;
            //      Global.RegistrationMemberCountList.Add(r);
            //  }
            //}

        }

        private string GetIntervalValue(string date, string Verification_date)
        {
            
            //DateTime dtCurrent = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            DateTime dtCurrent = DateTime.ParseExact(date, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //DateTime dtCurrent = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            //DateTime dtFixed = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 12:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //First Slot
            DateTime dtStart1 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 06:00:00 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd1 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 11:59:59 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //Second Slot
            DateTime dtStart2 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 12:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd2 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 05:59:59 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //Third Slot
            DateTime dtStart3 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 06:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd3 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 11:59:59 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            if (dtCurrent >= dtStart1 && dtCurrent <= dtEnd1) { return "1"; }
            if (dtCurrent >= dtStart2 && dtCurrent <= dtEnd2) { return "2"; }
            if (dtCurrent >= dtStart3 && dtCurrent <= dtEnd3) { return "3"; }
            return "1";
        }
    }
}