using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.Admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        Important imp = new Important();
        DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select top 1 (select count(Member_code) from Member_registration where Paidstatus='PAID') as PAID, (select count(Member_code) " + 
                         "from Member_registration where Paidstatus='FREE') as FREE from Member_registration";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) 
            {
                //[FREE, PAID]
                hdfPieData.Value = "[" + dt.Rows[0]["FREE"].ToString() + "," + dt.Rows[0]["PAID"].ToString() + "]";
            }


            sql = "select Member_code, Paidstatus, (convert(int,substring(Date, 7, 4)+substring(Date, 4, 2)+substring(Date, 1, 2))) as Joining_iDate from Member_registration";
            dt = new DataTable();
            dt = imp.FillTable(sql);

            string Free = ""; string Paid = "";

            if (dt.Rows.Count != 0)
            {
                string year = dtToday.Year.ToString();
                for (int i = 1; i <= 12; i++)
                {
                    string Start_iDate = year + i.ToString("00") + "01";
                    DateTime tempDate = DateTime.ParseExact(Start_iDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    string End_iDate = tempDate.AddMonths(1).AddDays(-1).ToString("yyyyMMdd");

                    DataRow[] drFree = dt.Select("Paidstatus='FREE' and Joining_iDate>=" + Start_iDate + " and Joining_iDate<=" + End_iDate);
                    if (Free == "") { Free = drFree.Length.ToString(); } else { Free = Free + ", " + drFree.Length.ToString(); }

                    DataRow[] drPaid = dt.Select("Paidstatus='PAID' and Joining_iDate>=" + Start_iDate + " and Joining_iDate<=" + End_iDate);
                    if (Paid == "") { Paid = drPaid.Length.ToString(); } else { Paid = Paid + ", " + drPaid.Length.ToString(); }
                }
                
            }

            hdfBarFree.Value = "[" + Free + "]";
            hdfBarPaid.Value = "[" + Paid + "]";

            //Package Wise FOr Pie Chart
            string PiePackageWiseData = "";
            string PiePackageWiseLabel = "";

            sql = "select Package_name, count(Member_code) as Total from Joining_package j left join Member_registration m on j.Package_name=m.joining_package group by Package_name";
            dt = imp.FillTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (PiePackageWiseData=="") { PiePackageWiseData = dt.Rows[i]["Total"].ToString(); }
                    else { PiePackageWiseData = PiePackageWiseData + ", " + dt.Rows[i]["Total"].ToString(); }

                    if (PiePackageWiseLabel == "") { PiePackageWiseLabel = "'" + dt.Rows[i]["Package_name"].ToString() + "'"; }
                    else { PiePackageWiseLabel = PiePackageWiseLabel + ", '" + dt.Rows[i]["Package_name"].ToString() + "'"; }
                }
            }

            hdfPiePackageWiseData.Value = "[" + PiePackageWiseData + "]";
            hdfPiePackageWiseLabel.Value = "[" + PiePackageWiseLabel + "]";



            //Package Wise FOr Pie Chart
            //sql = "select Package_name, Joining_iDate, count(Member_code) as Total from (select Package_name, Member_code, (convert(int,substring(m.Date, 7, 4)+" + 
            //      "substring(m.Date, 4, 2)+substring(m.Date, 1, 2))) as Joining_iDate from Joining_package j left join Member_registration m on j.Package_name=m.joining_package) T group by Package_name, Joining_iDate";
            //dt = imp.FillTable(sql);
            //if (dt.Rows.Count > 0)
            //{

            //}
        }
    }
}