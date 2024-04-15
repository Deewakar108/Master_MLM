using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;

namespace Master_MLM.App_Code
{
    public class My
    {
        public int fetch_idate(string date)
        {
            int idate = Convert.ToInt32(date.Substring(6, 4) + date.Substring(3, 2) + date.Substring(0, 2));
            return idate;
        }
        public int fetch_imonth(string month)
        {
            int imonth = Convert.ToInt32(month.Substring(4, 3) + month.Substring(0, 2));
            return imonth;
        }
        public static void fetch_year(DropDownList ddl)
        {
            ArrayList ar = new ArrayList();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            int year = dt.AddYears(1).Year;
            ar.Add("Select");
            for (int i = 2018; i <= year; i++)
            {
                ar.Add(i);
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }
        #region common
        public string date()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
        }
        public string idate()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
        }
        public string time()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");
        }
        public string itime()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("HHmmss");
        }

        public Dictionary<string, object> startyear_endyear()
        {

            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            SqlDataAdapter ad = new SqlDataAdapter("Select Startyear,End_year from Global", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Global");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {

            }
            else
            {
                dc["Startyear"] = dt.Rows[0][0].ToString();
                dc["End_year"] = dt.Rows[0][1].ToString();
            }

            return dc;

        }

        public Dictionary<string, object> forgetpwd(string userid)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            SqlDataAdapter ad = new SqlDataAdapter("Select ml.Pwd,ml.Transaction_Password,mr.Member_name,mr.Mobile_number from Member_registration mr join Member_Login ml on mr.Member_code=ml.Membercode where mr.Member_code=" + userid + "", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Global");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                dc["Pwd"] = "NO";
                dc["Member_name"] = "NO";
                dc["Mobile_number"] = "NO";
                dc["Transaction_Password"] = "NO";
            }
            else
            {
                dc["Pwd"] = dt.Rows[0]["Pwd"].ToString();
                dc["Member_name"] = dt.Rows[0]["Member_name"].ToString();
                dc["Mobile_number"] = dt.Rows[0]["Mobile_number"].ToString();
                dc["Transaction_Password"] = dt.Rows[0]["Transaction_Password"].ToString();
            }

            return dc;
        }






        public Dictionary<string, object> startyear_dob()
        {

            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc["Startdob"] = "1960";
            dc["End_dob"] = "2000";
            return dc;

        }




        public Dictionary<string, object> Nextcoming7days(string date)
        {
            Dictionary<string, object> dc = new Dictionary<string, object>();
            DateTime d2 = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            d2 = d2.AddDays(7);
            string Next7date = d2.ToString("dd/MM/yyy");
            DateTime d3 = DateTime.ParseExact(Next7date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int Next7idate = Convert.ToInt32(d3.ToString("yyyyMMdd"));
            dc["Next7date"] = Next7date;
            dc["Next7idate"] = Next7idate;
            return dc;
        }



        public static string auto_serial_id(string column)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Global ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[column] = "2";
                result = "1";
                dt.Rows.Add(dr);
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[column].ToString() == "")
                    {
                        result = "1";
                        dr[column] = "2";
                    }
                    else
                    {
                        result = dr[column].ToString();
                        dr[column] = Convert.ToDouble(dr[column]) + 1;
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return result;
        }



        public string auto_serial(string column)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            string result = "";

            SqlDataAdapter ad = new SqlDataAdapter("select * from Global ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[column] = "2";
                result = "1";
                dt.Rows.Add(dr);
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[column].ToString() == "")
                    {
                        result = "1";
                        dr[column] = "2";
                    }
                    else
                    {
                        result = dr[column].ToString();
                        dr[column] = Convert.ToDouble(dr[column]) + 1;
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return result;
        }
        #endregion

        //auto genrate password

        public String characters = "abcdeCDEfghijkzMABFHIJKLNOlmnopqrPQRSTstuvwxyUVWXYZ";
        public string password()
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("mmss");
            Random unique1 = new Random();
            string s = "";
            int unique;
            int n = 0;
            while (n < 6)
            {
                if (n % 2 == 0)
                {
                    s += unique1.Next(10).ToString();
                }
                else
                {
                    unique = unique1.Next(52);
                    if (unique < this.characters.Length)
                        s = String.Concat(s, this.characters[unique]);
                }
                n++;
            }
            string tempo = s + date;

            return tempo;


        }



        public void bind_ddl(DropDownList ddl, string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }

        public string packageid(string package)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter("Select Package_id from Joining_package where Start_Unit='" + package + "' ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return "0";

            }
            else
            {
                return dt.Rows[0][0].ToString();

            }


        }


        public void bind_ddl_with_all(DropDownList ddl, string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ar.Add("All Section");
            ddl.DataSource = ar;
            ddl.DataBind();

        }
        public void execute_Query(string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();

            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);

        }

        public void executeQuery(string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(query, coon);
                DataSet ds = new DataSet();
                ad.Fill(ds);

            }
            catch (Exception esc)
            {

            }
        }

        public static void submitException(Exception exception)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            string date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            string time = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");
            SqlDataAdapter ad = new SqlDataAdapter("Select * from ExceptionDetails", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr["exception_message"] = exception;
            dr["date"] = date;
            dr["time"] = time;
            dr["idate"] = idate;
            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);

        }

        public static void submitException1(string exception)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            string date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            string time = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");
            SqlDataAdapter ad = new SqlDataAdapter("Select * from ExceptionDetails", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr["exception_message"] = exception;
            dr["date"] = date;
            dr["time"] = time;
            dr["idate"] = idate;
            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);

        }
        public bool valid_number(string p)
        {
            try
            {
                Convert.ToInt64(p);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool valid_amount(string p)
        {
            try
            {
                Convert.ToDouble(p);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void bind_all_ddl_with_id(DropDownList ddl, string query, string Itemname, string value)
        {

            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";
                ddl.DataValueField = "Select";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[Itemname].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[value].ToString();


            }

            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "Select"));

        }
        //---------------------------Bind DDL----------------------------------
        public void bind_all_ddl_with_id_ltst(DropDownList ddl, string query)
        {


            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();

            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";
                ddl.DataValueField = "Select";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "Select"));
        }

        public void bind_all_ddl_with_id_ltst_all(DropDownList ddl, string query)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();

            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "All";
                ddl.DataValueField = "All";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("All", "All"));
        }




        internal string featch_tranid()
        {
            int Transaction_id = 0;
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select max(cast(Transaction_id as int)) from Allocated_E_PIN_details", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Allocated_E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                Transaction_id = 1;
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    Transaction_id = 1;
                }
                else
                {
                    Transaction_id = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                }
            }
            return Transaction_id.ToString();
        }




        public bool vchk_dublicatemobno(string mobno)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter("Select *  from UserRegistrationMaster where mobile='" + mobno + "'   ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "UserRegistrationMaster");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region zipunzip
        public String Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return Convert.ToBase64String(mso.ToArray());
            }
        }
        public string Unzip(string str)
        {

            byte[] bytes = Convert.FromBase64String(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {                     //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        #endregion

        #region find ip
        public string find_ip(bool CheckForward = false)
        {
            string ip = null;
            if (CheckForward)
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            { // Using X-Forwarded-For last address
                ip = ip.Split(',')
                       .Last()
                       .Trim();
            }

            return ip;


        }
        #endregion

        public string faechid(string query, string column)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result = dr[column].ToString();

                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return result;
        }

        public void bind_gridview(GridView gridview, string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            gridview.DataSource = ds;
            gridview.DataBind();
        }
        public DataTable bind_grid_view(string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            DataTable dt;
            SqlCommand cmd;

            SqlConnection conn = new SqlConnection(coon);

            if (conn == null)
            {
                conn = new SqlConnection(coon);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dt;


        }

        public int my_rowcount(string query)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            int count = 0;
            SqlConnection sqlCnn;
            SqlCommand sqlCmd;
            string sql = null;
            string sql1 = query;

            sql = sql1;
            sqlCnn = new SqlConnection(coon);
            try
            {
                sqlCnn.Open();
                sqlCmd = new SqlCommand(sql, sqlCnn);
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    count = Convert.ToInt32(sqlReader.GetValue(0).ToString());
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
            }
            catch (Exception ex)
            {


            }
            return count;
        }

        public static string hide_string(string str)
        {
            string val = "";
            if (str != "")
            {
                if (str.Length >= 10)
                {
                    val = str.Substring(0, 2) + "xxxxxxxx" + str.Substring((str.Length) - 2, 2);
                }
            }
            return val;
        }



        public static bool check_panno(string panno)
        {
            bool toreturn = false;
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter("Select *  from Member_registration where Pan_number='" + panno + "'   ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                toreturn = true;
            }
            else
            {
                if (rowcount < 8)
                {
                    toreturn = true;
                }
                else
                {
                    toreturn = false;
                }
            }
            return toreturn;
        }

        public static bool check_bank_account(string accountno)
        {
            bool toreturn = false;
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlDataAdapter ad = new SqlDataAdapter("Select *  from Member_registration where Account_number='" + accountno + "'   ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                toreturn = true;
            }
            else
            {
                toreturn = false;
            }
            return toreturn;
        }
        #region find_member_rp_point
        public static double find_member_point(ArrayList al)
        {
            double rp_point = 0.0;
            string membercode = "";
            for (int i = 0; i < al.Count; i++)
            {
                membercode = al[i].ToString();
                string left_child1 = find_the_child(membercode, "Left");
                string right_child1 = find_the_child(membercode, "Right");

                if (left_child1 != "")
                {
                    al.Add(left_child1);
                }
                if (right_child1 != "")
                {
                    al.Add(right_child1);
                }
                string qry = "";

                qry = @"Select * from Member_registration where Member_code ='" + membercode + "'";

                Connection con = new Connection();
                string connect = con.connect_method();
                SqlConnection conn = new SqlConnection(connect);
                SqlDataAdapter ad1 = new SqlDataAdapter(qry, conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Member_registration");
                DataTable dt1 = ds1.Tables[0];
                int rowcount1 = ds1.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {
                }
                else
                {
                    rp_point = rp_point + Convert.ToDouble(find_rp_point(membercode));
                }
            }
            return rp_point;

        }

        private static string find_rp_point(string childcode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter(" select RP from dbo.[Member_registration] mr join Joining_package jp on mr.Joining_amount=jp.Package_amount where mr.Member_code='" + childcode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return "0";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }


        private static string find_the_child(string membercode, string position)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                if (position == "Left")
                {
                    toreturn = dt.Rows[0][3].ToString();
                }
                if (position == "Right")
                {
                    toreturn = dt.Rows[0][4].ToString();
                }
            }

            return toreturn;
        }
        #endregion find_member_rp_point



        // 14/10/2017 Anand Kumar
        public bool find_status(string query)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Stock_Point_Deatils");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string stock_point_code()
        {
            string membercode = "";
            bool duplicateid = false;
            Random rn = new Random();
            int i = 100000;
            int j = 999990;
            do
            {
                int k = rn.Next(i, j);
                membercode = k.ToString();
                duplicateid = check_dauplicate_id(membercode);

                if (duplicateid == true)
                {

                }
            } while (duplicateid == false);

            return membercode;
        }

        private bool check_dauplicate_id(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_reg = new SqlDataAdapter("select * from Stock_Point_Deatils where Stock_Point_Code =" + membercode + "", conn);
            DataSet ds = new DataSet();
            ad_reg.Fill(ds, "Stock_Point_Deatils");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public void send_sms(string name, string userid, string pwd, string mob)
        {
            string uid = "bc2fbbb916c75bdc1359e0adac545f63";
            string sender = "ITMNET";
            string route = "1";
            string mobile = mob;
            string message = "Dear " + name + " Welcome to  Wowmax Entertainment Your Stock Point Code = " + userid + "  and Password is =" + pwd + ". For more details Login to www.itmbusiness.net Achieve The Best";
            string domain = "mysms.msgclub.net";
            string pushid = "1";

            string message1 = Uri.EscapeDataString(message);
            string url = "http://" + domain + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + uid + "&message=" + message1 + "&senderId=" + sender + "&routeId=" + route + "&mobileNos=" + mobile + "&smsContentType=english";
            string result = "";
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();

            }
            catch (Exception ex)
            {
            }
            send_message_details_in_Message_send_details(mobile, message, "SEND", userid, url, result);
        }

        private void send_message_details_in_Message_send_details(string mobile, string message, string status, string userid, string url, string result)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details", conn);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
            DataTable dt6 = ds6.Tables[0];
            DataRow dr6 = dt6.NewRow();
            dr6[1] = userid;
            dr6[2] = mobile;
            dr6[3] = date();
            dr6[4] = message;
            dr6[5] = status;
            dr6[6] = time();
            dr6[7] = url.ToString();
            dr6[8] = result;
            dt6.Rows.Add(dr6);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
            ad6.Update(dt6);
            update_message_allocation_details();
        }

        private void update_message_allocation_details()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_allocation_details", conn);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_allocation_details");
            DataTable dt6 = ds6.Tables[0];
            int rowcount = dt6.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                int messagereminder = Convert.ToInt32(dt6.Rows[0][1].ToString());
                int used = Convert.ToInt32(dt6.Rows[0][2].ToString());
                foreach (DataRow dr in dt6.Rows)
                {
                    dr[1] = messagereminder - 1;
                    dr[2] = used + 1;
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
                    ad6.Update(dt6);
                }
            }
        }


        //------------------------------------------Insert Update Data
        public static Boolean InsertUpdateData(SqlCommand cmd)
        {
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            String strConnString = coon;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
            return true;


        }
        // backup  backup_and_previous_month_bv
        public void backup()
        {
            string format1 = "dd/MM/yyyy";
            string format2 = "yyyyMMdd";
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString(format1);

            DateTime d2 = DateTime.ParseExact(date, format1, CultureInfo.InvariantCulture);
            d2 = d2.AddMonths(-1);
            string end_date = d2.ToString(format1);
            string day = end_date.Substring(0, 2);
            string month = end_date.Substring(3, 2);
            string year = end_date.Substring(6, 4);

            bool previous_month_backup = find_status_previous_month(month, year);
            if (previous_month_backup == true)
            {
                // if true than backup
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)))
                    {
                        backagip(month, year);
                        //Deletedfrom_Re_purchase_member_bv_point_details();
                        scope.Complete();
                    }

                }
                catch (Exception esc)
                {
                    My.submitException(esc);
                }

            }
            else
            {
               
            }


        }
        private void Deletedfrom_Re_purchase_member_bv_point_details()
        {
            string query = "delete from Re_purchase_member_bv_point_details where Member_code!='DH123456'";
            exeSql(query);
            query = "Update Re_purchase_member_bv_point_details set Self='0',Team='0' where  Member_code='DH123456'";
            exeSql(query);

        }
        public void exeSql(string query)
        {
            try
            {
                Connection con = new Connection();
                string Connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(Connectionstring);
                SqlDataAdapter ad = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);

            }
            catch (Exception esc)
            {
                My.submitException(esc);
            }
        }
        private void backagip(string month, string year)
        {
            string date = month+"/"+year;

            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);

            SqlDataAdapter ad = new SqlDataAdapter("insert into  Re_purchase_member_bv_point_details_monthly_backup  select Member_code,introducer_code,Self,Team,'" + month + "','" + year + "'  FROM Re_purchase_member_bv_point_details where Date like'%" + date + "%' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
        }
        private bool find_status_previous_month(string month1, string year)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select  * from Re_purchase_member_bv_point_details_monthly_backup where Month='" + month1 + "' and Year='" + year + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}