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
    public partial class Add_product : System.Web.UI.Page
    {
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    string date = dt.ToString("dd/MM/yyyy");
                    create_product_code();
                }
                catch (Exception exe)
                {

                }
            }
        }

        private void create_product_code()
        {

            productcode p = new productcode();
            txt_product_code.Text = p.product_code();
        }

        protected void btnupload_Click(object sender, EventArgs e)
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
                //    lblmessage.Text = "Please Enter DP.";
                //    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                //}
                //else if (txt_bv.Text == "")
                //{
                //    lblmessage.Text = "Please Enter BV.";
                //    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                //}

                else
                {
                    add_products_details();
                }
            }
            catch (Exception exe)
            {
            }

        }

        private void add_products_details()
        {

            string filepath = "#";
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 500000)
                {
                    filepath = upload_file_path();
                    if (filepath == "")
                    {
                        lblmessage.Text = "Please choose file";
                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    }
                    else
                    {
                        finsl_submit(filepath);
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
                lblmessage.Text = "Please choose file";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }

        private void finsl_submit(string filepath)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Add_product", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Add_product");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["Product_id"] = txt_product_code.Text;
            dr["Product_name"] = txt_productname.Text;
            dr["Mrp"] = txt_mrp.Text;
            dr["Packing"] = txt_packing.Text;
            dr["DP"] = txt_dp.Text;
            dr["BV"] = txt_bv.Text;
            dr["Image_path"] = filepath;
            dr["Date"] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            dr["Idate"] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            dr["Time"] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt"); ;

            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);
            txt_product_code.Text = "";
            txt_packing.Text = "";
            txt_productname.Text = "";
            txt_mrp.Text = "";
            txt_bv.Text = "";
            txt_dp.Text = "";
            lblmessage.Text = "Product details is added successfully.";
            scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
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
    }
}