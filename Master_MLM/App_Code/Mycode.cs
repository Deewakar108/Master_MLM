using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Master_MLM.App_Code
{
    public class Mycode
    {

        public static string date()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
        }


        public static int fetch_idate(string date)
        {
            int idate = Convert.ToInt32(date.Substring(6, 4) + date.Substring(3, 2) + date.Substring(0, 2));
            return idate;
        }
        public static int fetch_imonth(string month)
        {
            int imonth = Convert.ToInt32(month.Substring(4, 3) + month.Substring(0, 2));
            return imonth;
        }
        public static int fetch_member_rowid(string membercode)
        {
            int toreturn = 0;
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Id from  Member_registration where Member_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "t1");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                toreturn = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return toreturn;
        }
        public static string fetch_member_code(int rowid)
        {
            string toreturn = "0";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Member_code from  Member_registration where Id= " + rowid + "", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "t2");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                toreturn = dt.Rows[0][0].ToString();
            }
            return toreturn;
        }


        public static void bind_category(DropDownList ddl_category, string poroducttype)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select  distinct cd.category_name,cd.category_id  from Product_Details pd join  CategoryDetails cd  on pd.category_id=cd.category_id where pd.Product_type='" + poroducttype + "' ORDER BY cd.category_name  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Post_Applied_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_category.DataTextField = "Select";
                ddl_category.DataValueField = "Select";

            }

            else
            {

                ddl_category.DataTextField = ds.Tables[0].Columns["category_name"].ToString();
                ddl_category.DataValueField = ds.Tables[0].Columns["category_id"].ToString();
            }

            ddl_category.DataSource = ds.Tables[0];
            ddl_category.DataBind();
            ddl_category.Items.Insert(0, new ListItem("Select", "Select"));



        }

        public static void bind_subcategory(DropDownList ddl_subcategory, string poroducttype, string category)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select  distinct sc.sub_category_name,sc.sub_category_id from Product_Details pd join  SubCategory_details  sc on pd.sub_category_id=sc.sub_category_id  where pd.Product_type='" + poroducttype + "' and pd.category_id='" + category + "' ORDER BY sc.sub_category_name  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Post_Applied_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_subcategory.DataTextField = "Select";
                ddl_subcategory.DataValueField = "Select";

            }

            else
            {

                ddl_subcategory.DataTextField = ds.Tables[0].Columns["sub_category_name"].ToString();
                ddl_subcategory.DataValueField = ds.Tables[0].Columns["sub_category_id"].ToString();
            }

            ddl_subcategory.DataSource = ds.Tables[0];
            ddl_subcategory.DataBind();
            ddl_subcategory.Items.Insert(0, new ListItem("Select", "Select"));
        }
        public static void bind_category_single(DropDownList ddl_category)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select  distinct category_name,category_id  from CategoryDetails ORDER BY category_name  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Post_Applied_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_category.DataTextField = "Select";
                ddl_category.DataValueField = "Select";

            }

            else
            {

                ddl_category.DataTextField = ds.Tables[0].Columns["category_name"].ToString();
                ddl_category.DataValueField = ds.Tables[0].Columns["category_id"].ToString();
            }

            ddl_category.DataSource = ds.Tables[0];
            ddl_category.DataBind();
            ddl_category.Items.Insert(0, new ListItem("Select", "Select"));
        }
        public static void subcategory_single(string category, DropDownList ddl_sub_category)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select  distinct sub_category_name,sub_category_id from SubCategory_details    where category_id='" + category + "' ORDER BY sub_category_name  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Post_Applied_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_sub_category.DataTextField = "Select";
                ddl_sub_category.DataValueField = "Select";

            }

            else
            {

                ddl_sub_category.DataTextField = ds.Tables[0].Columns["sub_category_name"].ToString();
                ddl_sub_category.DataValueField = ds.Tables[0].Columns["sub_category_id"].ToString();
            }

            ddl_sub_category.DataSource = ds.Tables[0];
            ddl_sub_category.DataBind();
            ddl_sub_category.Items.Insert(0, new ListItem("Select", "Select"));
        }
        public static void bind_productname(DropDownList ddl_productname, string poroducttype, string category, string subcategory)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select  distinct Productname,Product_id from Product_Details pd    where Product_type='" + poroducttype + "' and category_id='" + category + "'and sub_category_id='" + subcategory + "'  ORDER BY Productname  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Post_Applied_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_productname.DataTextField = "Select";
                ddl_productname.DataValueField = "Select";
            }
            else
            {
                ddl_productname.DataTextField = ds.Tables[0].Columns["Productname"].ToString();
                ddl_productname.DataValueField = ds.Tables[0].Columns["Product_id"].ToString();
            }

            ddl_productname.DataSource = ds.Tables[0];
            ddl_productname.DataBind();
            ddl_productname.Items.Insert(0, new ListItem("Select", "Select"));
        }
        public DataSet fill_grid_view(string query)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "test");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            return ds;
        }
        public static void execute(string query)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "test");


        }
        public string package_id()
        {
            string packageid = "";
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("yyyyMMddhhmmss");
            Random random = new Random();
            int tempo = random.Next(1000, 9999);
            packageid = date + tempo;
            return packageid;
        }


        public static void bind_package(DropDownList ddl_package)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select   Package_name,Package_id from Joining_package  ORDER BY Package_name  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Joining_package");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_package.DataTextField = "Select";
                ddl_package.DataValueField = "Select";

            }

            else
            {

                ddl_package.DataTextField = ds.Tables[0].Columns["Package_name"].ToString();
                ddl_package.DataValueField = ds.Tables[0].Columns["Package_id"].ToString();
            }

            ddl_package.DataSource = ds.Tables[0];
            ddl_package.DataBind();
            ddl_package.Items.Insert(0, new ListItem("Select", "Select"));



        }
        public static void bind_creat_package(DropDownList ddl_package)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select   Package_name,Package_id from Joining_package  ORDER BY Package_name  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Joining_package");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_package.DataTextField = "Create New";
                ddl_package.DataValueField = "Create New";

            }

            else
            {

                ddl_package.DataTextField = ds.Tables[0].Columns["Package_name"].ToString();
                ddl_package.DataValueField = ds.Tables[0].Columns["Package_id"].ToString();
            }

            ddl_package.DataSource = ds.Tables[0];
            ddl_package.DataBind();
            ddl_package.Items.Insert(0, new ListItem("Select", "Select"));
            ddl_package.Items.Insert(1, new ListItem("Create New", "Create New"));



        }



        #region validation
        private bool ValidateNumber(string number)
        {
            try
            {
                double _num = Convert.ToDouble(number.Trim());
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion


        public DataTable bind_grid_view(string query)
        {

            DataTable dt;
            SqlCommand cmd;

            Connection con = new Connection();
            string connectionstring = con.connect_method();

            SqlConnection conn = new SqlConnection(connectionstring);

            if (conn == null)
            {
                conn = new SqlConnection(connectionstring);
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


        public static string Re_franchise_code()
        {
            string finalcode = "";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_franchise_code  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_franchise_code");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                finalcode = "RE1000";
                DataRow dr = dt.NewRow();
                dr[1] = finalcode;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);

            }
            else
            {
                string code = dt.Rows[0][1].ToString();

                string product_cod = code.Substring(2);
                string mackcode = (Convert.ToInt32(product_cod.ToString()) + 1).ToString();
                finalcode = "RE" + mackcode;

                updatefinalcode(finalcode);
            }
            return finalcode;

        }

        private static void updatefinalcode(string finalcode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Update Re_franchise_code set Code='" + finalcode + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_franchise_code");

        }


        internal static string featch_tranid()
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


        public static double find_total_business(string membercode)
        {
            double leftbv = 0;
            double teambv = 0;
            double total_leftbv = 0;
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Self,Team from Re_purchase_member_bv_point_details where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                leftbv = Convert.ToDouble(dt.Rows[0][0].ToString());
                teambv = Convert.ToDouble(dt.Rows[0][1].ToString());

                total_leftbv = leftbv + teambv;
            }

            return total_leftbv;

        }

        public static double find_self(string memberid)
        {
            double self = 0;
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Self from Re_purchase_member_bv_point_details where Member_code ='" + memberid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details");
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



        public static double find_current_month_teamBV(string memberid, int isdate, int iedate)
        {
            double leftbv = 0;
            double rightbv = 0;
            double total_leftbv = 0;

            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();


            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select left_child,right_child from binary_status where member_code ='" + memberid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                string left_child = dt.Rows[0][0].ToString();
                string right_child = dt.Rows[0][1].ToString();

                if (left_child != "")
                {
                    al.Add(left_child);
                }
                if (right_child != "")
                {
                    a2.Add(right_child);
                }


                leftbv = bind_child(al, isdate, iedate);
                rightbv = bind_child(a2, isdate, iedate);

                total_leftbv = leftbv + rightbv;
            }

            return total_leftbv;

        }

        private static double bind_child(ArrayList al, int isdate, int iedate)
        {
            string membercode = "";
            double tot_bv = 0;
            for (int i = 0; i < al.Count; i++)
            {
                membercode = al[i].ToString();
                string left_child1 = find_the_left_child(membercode);
                string right_child1 = find_the_right_child(membercode);

                if (left_child1 != "")
                {
                    al.Add(left_child1);
                }
                if (right_child1 != "")
                {
                    al.Add(right_child1);
                }

                tot_bv = tot_bv + find_current_month_selfBV(al[i].ToString(), isdate, iedate);
            }
            return tot_bv;
        }
        private static string find_the_left_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
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
                toreturn = dt.Rows[0][3].ToString();
            }

            return toreturn;
        }
        private static string find_the_right_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
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
                toreturn = dt.Rows[0][4].ToString();
            }

            return toreturn;
        }

        public static double find_current_month_selfBV(string memberid, int isdate, int iedate)
        {
            double self = 0;
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Sum(cast(TotalBV as float)) from Re_sell_member_bill_wise where Membercode='" + memberid + "' and Idate>=" + isdate + " and Idate<=" + iedate + "", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_sell_member_bill_wise");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount != 0)
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    self = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            return self;
        }

        public static bool check_current_month_bv(double leftbv, double rightbv, double selfbv, double left_right_limit, double self_limit)
        {
            bool tureturn = false;
            if (leftbv == 0 && rightbv == 0)
            {
                if (selfbv >= self_limit)
                {
                    tureturn = true;
                }
            }
            else
            {
                int big_side = find_big_side(leftbv, rightbv);
                if (big_side == 0)// left is greater than right
                {
                    rightbv = rightbv + selfbv;
                    if (leftbv >= left_right_limit && rightbv >= left_right_limit)
                    {
                        tureturn = true;
                    }
                }
                else if (big_side == 1)// right_is_greater_than_left
                {
                    leftbv = leftbv + selfbv;

                    if (leftbv >= left_right_limit && rightbv >= left_right_limit)
                    {
                        tureturn = true;
                    }
                }
                else
                {
                    if (leftbv >= left_right_limit && rightbv >= left_right_limit)
                    {
                        tureturn = true;
                    }
                }
            }
            return tureturn;
        }

        private static int find_big_side(double Total_leftBV, double Total_rightBV)
        {
            int toreturn = 0;
            if (Total_leftBV > Total_rightBV)
            {
                toreturn = 0;
            }
            else if (Total_rightBV > Total_leftBV)
            {
                toreturn = 1;
            }
            else
            {
                toreturn = 2;
            }
            return toreturn;
        }




    }

}