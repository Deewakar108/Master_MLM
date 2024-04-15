using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Master_MLM.App_Code;
using System.Transactions;

namespace Master_MLM.Admin
{
    public partial class Create_Joining_Products_Kit : System.Web.UI.Page
    {
        string scrpt;
        string query = "";
        My mycode = new My();
        string SelectedProductList = "";
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                try
                {
                    fetch_add_added_tamp_product();
                }
                catch
                {
                }
            }
        }

        private void fetch_add_added_tamp_product()
        {
            query = "Select * from Product_Info";
            mycode.bind_gridview(gridview_product_info, query);
            if (gridview_product_info.Rows.Count == 0)
            {
                panel_btn1.Visible = false;
            }
            else
            {
                panel_btn1.Visible = true;
            }
        }

        #region add_product
        protected void btn_add_product_Click(object sender, EventArgs e)
        {
            if (txt_productname.Text == "")
            {
                AlertMe("Please Enter Product Name ");
                //lbl_message.Text = "Please Enter Product Name ";
                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }

            else
            {
                try
                {
                    add_data_product_table();
                    fetch_add_added_tamp_product();
                }
                catch
                {

                }
            }
        }

        private void add_data_product_table()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Product_Info where Product_name='" + txt_productname.Text + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Info");
            DataTable dt = ds.Tables[0];

            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Product_name"] = txt_productname.Text;
                dr["Product_id"] = mycode.auto_serial("Product_id");
                dr["Date"] = mycode.date();
                dr["Idate"] = mycode.idate();
                dr["Istatus"] = "0";
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                txt_productname.Text = "";
                AlertMe("Product added Successfully");
                ////lbl_message.Text = "Product added Successfully";
                ////scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else
            {
                AlertMe("This Product already Added");
                //lbl_message.Text = "This Product already Added";
                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }
        #endregion
        
        #region delete
        protected void img_delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.Parent.Parent;
                int idx = row.RowIndex;
                Label lbl_id = (Label)gridview_product_info.Rows[idx].FindControl("lbl_id");

                deletedata(lbl_id.Text);
                fetch_add_added_tamp_product();

                AlertMe("Product has been delete successfully.");
                //lbl_message.Text = "Product has been delete successfully.";

                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            catch
            {

            }
        }

        private void deletedata(string id)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("delete from Product_Info where id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Info");
        }
        #endregion

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!IsProductSelected()) { AlertMe("Please select at least one product."); return; }
            if (txt_packagename.Text == "")
            {
                AlertMe("Please Enter Package Id."); return; 
                //lbl_message.Text = "Please Enter Package Id";
                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else if (txt_amount.Text == "")
            {
                AlertMe("Please Enter Purchase Package"); return; 
                //lbl_message.Text = "Please Enter Purchase Package";
                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else if (txtBV.Text == "")
            {
                AlertMe("Please Enter PV"); return; 
                //lbl_message.Text = "Please Enter PV";
                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else if (txt_capping.Text == "")
            {
                AlertMe("Please Enter Capping"); return; 
                //lbl_message.Text = "Please Enter Capping";
                //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else
            {
              
                bool chkaamt = mycode.valid_amount(txt_amount.Text);
                bool chkpv = mycode.valid_amount(txtBV.Text);
                bool capping = mycode.valid_amount(txt_capping.Text);
                if (chkaamt == false)
                {
                    AlertMe("Please Enter Valid Purchase Package"); return; 
                    //lbl_message.Text = "Please Enter Valid Purchase Package";
                    //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else if (chkpv == false)
                {
                    AlertMe("Please Enter Valid PV"); return; 
                    //lbl_message.Text = "Please Enter Valid PV";
                    //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else if (capping == false)
                {
                    AlertMe("Please Enter Valid Capping"); return; 
                    //lbl_message.Text = "Please Enter Valid Capping";
                    //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else
                {
                    if (gridview_product_info.Rows.Count == 0)
                    {
                        AlertMe("Please Enter Product"); return;
                        //lbl_message.Text = "Please Enter Product";
                        //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    }
                    else
                    {
                        send_data_package_table();
                    }
                }

            }
        }

        private void send_data_package_table()
        {
            bool send = false;
            string packageid = mycode.auto_serial("Package_id");
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)))
                {
                    for (int i = 0; i < gridview_product_info.Rows.Count; i++)
                    {

                        Label lbl_product_id = (Label)gridview_product_info.Rows[i].FindControl("lbl_product_id");
                        CheckBox chkProduct = (CheckBox)gridview_product_info.Rows[i].FindControl("chkProduct");

                        if (chkProduct.Checked)
                        {
                            send_data_package_product_map(lbl_product_id.Text, packageid);
                        } 
                        //send_data_package_product_map(lbl_product_id.Text, packageid);
                        //update_product_info("Update Product_Info set Istatus=" + 1 + " where Product_id=" + lbl_product_id.Text + " and Istatus=" + 0 + "");
                    }
                    send_data_package_info(packageid);
                    send = true;
                    scope.Complete();
                    if (send == true)
                    {
                        
                        AlertMe("Package has been Added Successfully");
                        //lbl_message.Text = "Package has been Added Successfully";
                        //scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                        txt_amount.Text = "";
                        txt_packagename.Text = "";
                        txt_productname.Text = "";
                        txtMatchingIncome.Text = "";
                        txtRewardPoint.Text = "";
                        txtDescription.Text = "";
                        gridview_product_info.DataSource = null;
                        gridview_product_info.DataBind();
                        
                        //panel_btn1.Visible = false;
                        
                    }
                }
                if (send == true) { fetch_add_added_tamp_product(); txt_packagename.Focus(); }

            }
            catch
            {
            }
        }

        private void update_product_info(string query)
        {
            try
            {
                mycode.executeQuery(query);
            }
            catch
            {
            }
        }

        private void send_data_package_info(string packageid)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Joining_package where Package_name='" + txt_packagename.Text + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Joining_package");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Package_name"] = txt_packagename.Text;
                dr["Package_id"] = packageid;
                dr["Package_amount"] = txt_amount.Text;
                dr["Description"] = txtDescription.Text;
                dr["Date"] = mycode.date();
                dr["Idate"] = mycode.idate();
                dr["Capping"] = txt_capping.Text;
                dr["MatchingIncome"] = txtMatchingIncome.Text == "" ? "0" : txtMatchingIncome.Text;
                dr["RewardPoint"] = txtRewardPoint.Text == "" ? "0" : txtRewardPoint.Text;

                string RepurchaseBV = txtRepurchaseBV.Text == "" ? "0" : txtRepurchaseBV.Text;
                dr["RepurchaseBV"] = RepurchaseBV;

                dr["BV"] = (int.Parse(RepurchaseBV) * 0.01 * 50).ToString("0.00");
                
                dr["IsActivationPackage"] = ddlIsActivation.SelectedValue;
                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {

            }
        }

        private void send_data_package_product_map(string product_id, string packageid)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Package_details where Packageid='" + packageid + "'  and Product_id='" + product_id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Package_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = packageid;
                dr[2] = product_id;
                dr[3] = mycode.date();
                dr[4] = mycode.idate();

                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);

            }
            else
            {

            }
        }

        public bool IsProductSelected()
        {
            bool Status = false;
            if (gridview_product_info.Rows.Count != 0)
            {
                for (int i = 0; i < gridview_product_info.Rows.Count; i++)
                {
                    CheckBox chkProduct = (CheckBox)gridview_product_info.Rows[i].FindControl("chkProduct");
                    if (chkProduct.Checked) { Status = true; break; }
                }
            }

            return Status;
        }

        public string  GetSelectedProduct()
        {
            SelectedProductList = "";
            if (gridview_product_info.Rows.Count != 0) 
            {
                for (int i = 0; i < gridview_product_info.Rows.Count; i++) 
                {
                    Label lblProductID = (Label)gridview_product_info.Rows[i].FindControl("lbl_product_id");
                    CheckBox chkProduct = (CheckBox)gridview_product_info.Rows[i].FindControl("chkProduct");

                    if (chkProduct.Checked)
                    {
                        if (SelectedProductList == "") { SelectedProductList = lblProductID.Text; }
                        else { SelectedProductList = SelectedProductList + "," + lblProductID.Text; }
                    }                    
                }
            }

            return SelectedProductList;
        }

        public void AlertMe(string Message)
        {
            lblMessage.Text = Message;
            scrpt = "<script>$(document).ready( function () { $('#gritter-notice-wrapper1').show().fadeOut(5000); });</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "AlertMe();", true);
        }
    }
}