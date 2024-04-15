using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Member_4235profile
{
    public partial class repurchase_business_bv_point_left_right_self : System.Web.UI.Page
    {

        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string memberid = Session["membercode"].ToString();
                featch_member_business(memberid);
            }
        }

        private void featch_member_business(string memberid)
        {
            string qry = @"Select Month,isnull(Sum(cast(Self as float)),0) as Self_BV, 
(Select (isnull(Sum(cast(Self as float)),0)+isnull(Sum(cast(Team as float)),0)) as total from Re_purchase_member_bv_point_details_monthly where Member_code in(Select left_child from binary_status where member_code ='" + memberid + @"'
 ) and Month=t1.Month) as Left_PV,  (Select (isnull(Sum(cast(Self as float)),0)+isnull(Sum(cast(Team as float)),0)) as total from Re_purchase_member_bv_point_details_monthly where Member_code in(Select right_child from binary_status where member_code ='" + memberid + @"'
 ) and Month=t1.Month) as Right_PV from Re_purchase_member_bv_point_details_monthly t1 where Member_code ='" + memberid + "' group by Month";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {

                //string left_child = dt.Rows[0][3].ToString();
                //string right_child = dt.Rows[0][4].ToString();

                //string left_vb = "0";

                //string right_vb = "0";
                //if (left_child != "")
                //{
                //    left_vb = find_total_business(left_child);
                //}
                //if (right_child != "")
                //{
                //    right_vb = find_total_business(right_child);
                //}

                //string self = find_self(memberid);
                //DataRow drNewRow2 = dtDatas.NewRow();
                //dtDatas.Columns.Add("Month");
                //drNewRow2["self_bv"] = self;
                //drNewRow2["leftbv"] = left_vb;
                //drNewRow2["rightbv"] = right_vb;
                //dtDatas.Rows.Add(drNewRow2);
                //dtDatas.AcceptChanges();
                //ViewState["dtDatas"] = dtDatas;
                gridview.DataSource = dt;
                gridview.DataBind();
            }
        }

        //private string find_self(string memberid)
        //{
        //    string self = "0";
        //    Connection con = new Connection();
        //    string connect = con.connect_method();
        //    SqlConnection conn = new SqlConnection(connect);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select Sum(cast(Self as float)) as Self from Re_purchase_member_bv_point_details_monthly_backup where Member_code ='" + memberid + "'", conn);


        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = ds.Tables[0].Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        self = "0";
        //    }
        //    else
        //    {
        //        self = dt.Rows[0][0].ToString();

        //    }
        //    return self;
        //}
        //private string find_total_business(string membercode)
        //{

        //    int leftbv = 0;
        //    int teambv = 0;
        //    int total_leftbv = 0;
        //    Connection con = new Connection();
        //    string connect = con.connect_method();
        //    SqlConnection conn = new SqlConnection(connect);

        //    SqlDataAdapter ad = new SqlDataAdapter("Select Sum(cast(Self as float)) as Self,Sum(cast(Team as float)) as Team from Re_purchase_member_bv_point_details_monthly_backup where Member_code ='" + membercode + "'", conn);

        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly_backup");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = ds.Tables[0].Rows.Count;
        //    if (rowcount == 0)
        //    {
        //    }
        //    else
        //    {
        //        if (dt.Rows[0][0].ToString() != "")
        //        {
        //            leftbv = Convert.ToInt32(dt.Rows[0][0].ToString());
        //        }
        //        if (dt.Rows[0][1].ToString() != "")
        //        {
        //            teambv = Convert.ToInt32(dt.Rows[0][1].ToString());
        //        }

        //        total_leftbv = leftbv + teambv;
        //    }

        //    return total_leftbv.ToString();

        //}

    }
}