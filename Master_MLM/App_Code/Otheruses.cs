using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Master_MLM.AppCode
{
    public class Otheruses
    {


        public static ArrayList featch_joingyear(DateTime dtm)
        {
            ArrayList ar = new ArrayList();
            string preyear = dtm.AddYears(-1).ToString();
            ar.Add(preyear.Substring(6, 4));

            for (int i = 0; i < 3; i++)
            {
                string year = dtm.AddYears(i).ToString();
                ar.Add(year.Substring(6, 4));
            }
            return ar;
        }
        public static ArrayList featch_year(DateTime today)
        {
            CultureInfo culutreInfo = System.Threading.Thread.CurrentThread.CurrentCulture.Clone() as CultureInfo;
            culutreInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = culutreInfo;

            ArrayList ar = new ArrayList();
            string preyear = "01/01/2018";
            DateTime date = Convert.ToDateTime(preyear);
            int totyear = today.Year - date.Year;

            if (date > today.AddYears(-totyear)) totyear--;
            totyear = totyear + 3;

            ar.Add(preyear.Substring(6, 4));

            for (int i = 1; i < totyear; i++)
            {
                string year = date.AddYears(i).ToString();
                ar.Add(year.Substring(6, 4));
            }
            return ar;
        }


        public static double find_total_business(string membercode)
        {
            double leftbv = 0;
            double teambv = 0;
            double total_leftbv = 0;
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select isnull(Sum(cast(Self as float)),0) as Self,isnull(Sum(cast(Team as float)),0) as Team from Re_purchase_member_bv_point_details_monthly_backup where Member_code ='" + membercode + "'", conn);

            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    leftbv = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                if (dt.Rows[0][1].ToString() != "")
                {
                    teambv = Convert.ToDouble(dt.Rows[0][1].ToString());
                }

                total_leftbv = leftbv + teambv;
            }

            return total_leftbv;

        }

        public static double find_self_business(string member_code)
        {
            double self = 0;
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select isnull(Sum(cast(Self as float)),0) as Self from Re_purchase_member_bv_point_details_monthly_backup where Member_code ='" + member_code + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                self = Convert.ToDouble(dt.Rows[0][0].ToString());

            }
            return self;
        }





        internal static double find_self_business_for_difference(string member_code)
        {
            double self = 0;
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select isnull(Sum(cast(Self as float)),0) as Self from Re_purchase_member_bv_point_details_for_diffrence where Member_code ='" + member_code + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                self = Convert.ToDouble(dt.Rows[0][0].ToString());

            }
            return self;
        }

        internal static double find_total_business_for_difference(string membercode)
        {
            double leftbv = 0;
            double teambv = 0;
            double total_leftbv = 0;
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select isnull(Sum(cast(Self as float)),0) as Self,isnull(Sum(cast(Team as float)),0) as Team from Re_purchase_member_bv_point_details_for_diffrence where Member_code ='" + membercode + "'", conn);

            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_for_diffrence");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    leftbv = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                if (dt.Rows[0][1].ToString() != "")
                {
                    teambv = Convert.ToDouble(dt.Rows[0][1].ToString());
                }

                total_leftbv = leftbv + teambv;
            }

            return total_leftbv;

        }
    }
}