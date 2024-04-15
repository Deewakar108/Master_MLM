using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Repurchase
{
    public partial class Purchase_Stock_History : System.Web.UI.Page
    {
        string query;
        DataTable dt_add;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dt_add = new DataTable();
                dt_add.Columns.Add("Stockpoint_code");
                dt_add.Columns.Add("Distribution");
                dt_add.Columns.Add("Mrp");
                dt_add.Columns.Add("DP");
                dt_add.Columns.Add("BV");
                dt_add.Columns.Add("Date");
                fatch_data();
            }
        }

        private void fatch_data()
        {
            query = "Select distinct Distribution from Re_Product_wise_sell_entery where Stockpoint_code='" + Session["repurchase_user"].ToString() + "'  ";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "Stock not found......!";
            }
            else
            {
                if (dt_add == null)
                {
                    dt_add = new DataTable();
                    dt_add.Columns.Add("Stockpoint_code");
                    dt_add.Columns.Add("Distribution");
                    dt_add.Columns.Add("Mrp");
                    dt_add.Columns.Add("BV");
                    dt_add.Columns.Add("Date");
                }
                int i;
                for (i = 0; i < rowcount; i++)
                {
                    string Distribution_no = dt.Rows[i][0].ToString();
                    string Stockpoint_code = Session["repurchase_user"].ToString();
                    find_all_data(Distribution_no, Stockpoint_code);

                }
                gridview.DataSource = dt_add;
                gridview.DataBind();


            }
        }

        private void find_all_data(string Distribution_no, string Stockpoint_code)
        {
            double totalamount = 0;
            int totalbv = 0;
            string Status = "ADDED";
            query = "Select * from Re_Product_wise_sell_entery  where Stockpoint_code='" + Stockpoint_code + "' and Distribution='" + Distribution_no + "'  and   Status='" + Status + "' ";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                int i;
                for (i = 0; i < rowcount; i++)
                {

                    totalamount = totalamount + Convert.ToDouble(dt.Rows[i]["Tot_mrp"].ToString());
                    totalbv = totalbv + Convert.ToInt32(dt.Rows[i]["Tot_bv"].ToString()); 
                }
                string date = dt.Rows[0][8].ToString();
                DataRow drNewRow = dt_add.NewRow();
                drNewRow["Stockpoint_code"] = Stockpoint_code;
                drNewRow["Distribution"] = Distribution_no;
                drNewRow["Mrp"] = totalamount.ToString("F");
                drNewRow["BV"] = totalbv.ToString();
                drNewRow["Date"] = date;
                dt_add.Rows.Add(drNewRow);
                dt_add.AcceptChanges();
            }
        }
    }
}