using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Repurchase
{
    public partial class Add_Product : System.Web.UI.Page
    {
        #region PageloaD
        string scrpt;
        Connection con = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    fetch_unit();
                    fetch_gst();
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void fetch_gst()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select distinct Gst from Gst_Master ", con.connect_method());
            DataSet ds = new DataSet();
            ad.Fill(ds, "state_and_district");
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("0");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ddl_gst_perc.DataSource = ar;
            ddl_gst_perc.DataBind();
        }

        private void fetch_unit()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select distinct Unit from Unit_Master order by Unit asc", con.connect_method());
            DataSet ds = new DataSet();
            ad.Fill(ds, "state_and_district");
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ddl_unit.DataSource = ar;
            ddl_unit.DataBind();
        }
        #endregion

        #region BtnsubmiT
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_unit.SelectedItem.Text == "Select")
                {
                    lblmessage.Text = "Please select unit.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else
                {
                    submit_product_data();
                }
            }
            catch (Exception exe)
            {
            }

        }

        private void submit_product_data()
        {
            string productid = My.auto_serial_id("Rep_product_id");
            Connection myconn = new Connection();
            string coon = myconn.connect_method();
            SqlConnection con = new SqlConnection(coon);
            con.Open();
            SqlCommand cmd;
            string strQuery = "INSERT INTO Product_Details (Product_id,Product_name,Mrp,Bv,Unit,Gst_perc,Gst_amt,Net_Mrp) values (@Product_id,@Product_name,@Mrp,@Bv,@Unit,@Gst_perc,@Gst_amt,@Net_Mrp)";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Product_id", productid);
            cmd.Parameters.AddWithValue("@Product_name", txt_Prduct_name.Text);
            cmd.Parameters.AddWithValue("@Mrp", txt_mrp.Text);
            cmd.Parameters.AddWithValue("@Bv", txt_bv.Text);
            cmd.Parameters.AddWithValue("@Unit", ddl_unit.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Gst_perc", ddl_gst_perc.SelectedItem.Text); 
            cmd.Parameters.AddWithValue("@Gst_amt", txt_gst_value.Text);
            cmd.Parameters.AddWithValue("@Net_Mrp", txt_net_mrp.Text);

            if (My.InsertUpdateData(cmd))
            {
                con.Close();
                txt_Prduct_name.Text = "";
                txt_mrp.Text = ""; 
                txt_bv.Text = "";
                txt_gst_value.Text = "";
                txt_net_mrp.Text = "";
                lblmessage.Text = "Product added successfully.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }
        #endregion
    }
}