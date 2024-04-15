using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Website
{
    public partial class Edit_pruduct : System.Web.UI.Page
    {
        string scrpt;
        My my = new My();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dt.ToString("dd/MM/yyyy");
                Session["today_date"] = date;

                fetch_all_added_product();
            }

        }



        private void fetch_all_added_product()
        {
            try
            {
                string query = "select * from Add_product order by Id desc  ";
                DataTable dt = my.bind_grid_view(query);
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {

                    grd_available.DataSource = null;
                    grd_available.DataBind();
                    panel_avilabel_product.Visible = false;
                    panel_product_edit.Visible = false;
                }
                else
                {
                    panel_avilabel_product.Visible = true;
                    panel_product_edit.Visible = false;
                    grd_available.DataSource = dt;
                    grd_available.DataBind();


                }
            }
            catch
            {
            }
        }

        protected void lnk_select_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnk.Parent.Parent;
                Label lbl_id = (Label)row.FindControl("lbl_id");

                string id;
                id = lbl_id.Text;
                Session["id"] = id;
                fill_data(id);
            }
            catch
            {
            }
        }

        private void fill_data(string id)
        {
            string query = "Select * from Add_product where Id='" + id + "'";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Add_product");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                panel_product_edit.Visible = false;
                lblmessage.Text = "No any product available.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

            }
            else
            {
                panel_product_edit.Visible = true;
                hd_id.Value = dt.Rows[0][0].ToString();
                hd_product_id.Value = dt.Rows[0]["Product_id"].ToString();
                txt_productname.Text = dt.Rows[0]["Product_name"].ToString();
                txt_packing.Text = dt.Rows[0]["Packing"].ToString();
                txt_mrp.Text = dt.Rows[0]["Mrp"].ToString();
                txt_dp.Text = dt.Rows[0]["DP"].ToString();
                txt_bv.Text = dt.Rows[0]["BV"].ToString();
                lbl_image_path.Text = dt.Rows[0]["Image_path"].ToString();
            }
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

        #region btnsubmiT
        protected void btn_ad_Click(object sender, EventArgs e)
        {

            try
            {
                if (txt_productname.Text == "")
                {
                    lblmessage.Text = "Please Enter Product Name";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                //else if (txt_mrp.Text == "")
                //{
                //    lblmessage.Text = "Please Enter Product MRP.";
                //    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                //}
                //else if (txt_packing.Text == "")
                //{
                //    lblmessage.Text = "Please Enter  Packing";
                //    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                //}

                //else if (txt_dp.Text == "")
                //{
                //    lblmessage.Text = "Please Enter  DP";
                //    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                //}
                //else if (txt_bv.Text == "")
                //{
                //    lblmessage.Text = "Please Enter  BV";
                //    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                //}
                else
                {
                    update_product();
                    fetch_all_added_product();
                }
            }
            catch
            {

            }
        }

        private void update_product()
        {
            string filepath = "";
            if (FileUpload1.HasFile)
            {
                filepath = upload_file_path();

            }
            else
            {
                filepath = lbl_image_path.Text;
            }

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Add_product where id='" + hd_id.Value + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Add_product");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {
                    dr["Product_name"] = txt_productname.Text;
                    dr["Packing"] = txt_packing.Text;
                    dr["Mrp"] = txt_mrp.Text;
                    dr["DP"] = txt_dp.Text;
                    dr["BV"] = txt_bv.Text;
                    if (filepath != "")
                    {
                        dr["Image_path"] = filepath;
                    }
                    SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    fetch_all_added_product();
                    lblmessage.Text = "Product is edited successfully.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                    txt_productname.Text = "";
                    txt_mrp.Text = "";
                    txt_dp.Text = "";
                    txt_bv.Text = "";
                    panel_product_edit.Visible = false;
                    panel_avilabel_product.Visible = true;
                }

            }
        }

        private string upload_file_path()
        {
            string dbfilePath = "";
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss");
            String filerename = date + time;
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 500000)
                {
                    Session["WorkingImage"] = FileUpload1.FileName;
                    string FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();
                    Session["renamedfile"] = filerename + "PIMG1" + FileExtension;
                    string[] allowedExtension = { ".png", ".jpg", ".JPEG", ".jpeg" };
                    for (int i = 0; i < allowedExtension.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtension[i])
                        {
                            FileOK = true;
                            lblmessage.Text = "";
                            break;
                        }
                    }
                }
                else
                {
                    lblmessage.Text = "Please Reduce or compress size of image max(500kb)";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {
                lblmessage.Text = "Please upload file first.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            if (FileOK)
            {
                try
                {
                    string path = (Server.MapPath("../../Products")).ToString();
                    FileUpload1.SaveAs(path + "/" + Session["renamedfile"]);
                    FileSaved = true;
                }
                catch (Exception ex)
                {
                    FileSaved = false;
                    lblmessage.Text = "File has not save.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {

            }
            if (FileSaved)
            {
                string originalPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");
                string fileName = Path.GetFileName(Session["renamedfile"].ToString());
                dbfilePath = originalPath + "/Products/" + fileName;
            }
            return dbfilePath;
        }



        #endregion

        #region DeletE
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.Parent.Parent;
                int idx = row.RowIndex;
                Label lbl_id = (Label)grd_available.Rows[idx].FindControl("lbl_id");
                delete_product(lbl_id.Text);
                fetch_all_added_product();
                panel_product_edit.Visible = false;
                lblmessage.Text = "Product has been delete successfully.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

            }
            catch
            {

            }
        }

        private void delete_product(string product_id)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("delete from Add_product where Id='" + product_id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Add_product");
        }

        #endregion
    }
}