using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;
using System.Data;

namespace Master_MLM.Admin.Package
{
    public partial class AddProduct : System.Web.UI.Page
    {
        Important imp = new Important();
        DateTime dtToday = DateTime.UtcNow.AddMinutes(30).AddHours(5);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_usermlm"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            if (!IsPostBack) { BindProduct(); }
        }

        private void BindProduct() 
        {
            string sql = "select  * from Product_Info";
            DataTable dt = imp.FillTable(sql);
            grdProduct.DataSource = dt;
            grdProduct.DataBind();
        }

        public bool IsAllFieldValid() 
        {
            if (txt_productname.Text.Trim() == "") { AlertMe("Please Enter Product Name."); return false; }
            if (txtPrice.Text.Trim() == "") { AlertMe("Please Enter Product Price."); return false; }
            if (txtBV.Text.Trim() == "") { AlertMe("Please Enter PV."); return false; }
            if (IsExist(txt_productname.Text.Trim())) { AlertMe("Product Name already exist."); return false; }
            return true;
        }

        public void AlertMe(string Message)
        {
            lblMessage.Text = Message;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "AlertMe();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsAllFieldValid()) { return; }
            string ProductName = txt_productname.Text;
            string Price = txtPrice.Text;
            string BV = txtBV.Text;
            string InsertDate = dtToday.ToString("dd/MM/yyyy");
            string Insert_iDate = dtToday.ToString("yyyyMMdd");
            string Insert_Time = dtToday.ToString("hh:mm:ss tt");
            string ProductID = GetProductID();
            string sql = "insert into Product_Info(Product_name,Product_id,Date,Idate,Time,Istatus,Amount,BV) values ('" + ProductName + "','" + ProductID +
                         "','" + InsertDate + "',N'" + Insert_iDate + "','" + Insert_Time + "','0','" + Price + "','" + BV + "')";
            int i = imp.InsertUpdateDelete(sql);
            if (i == 0) { AlertMe("Try again."); return; }
            AlertMe("Product successfully added.");
            BindProduct();
        }

        private string GetProductID()
        {
            string sql = "select  isnull(Max(Product_id), '101') as ProductID from Product_Info";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return (int.Parse(dt.Rows[0]["ProductID"].ToString()) + 1).ToString(); }
            return "101";
        }

        private bool IsExist(string ProductName)
        {
            string sql = "select  * from Product_Info where Product_name='" + ProductName + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }
            return false;
        }

        private bool IsProductExistIn_PackageDetailsTable(string ProductID)
        {
            string sql = "select  * from Package_details where Product_id='" + ProductID + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }
            return false;
        }

        protected void grdProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsDelete") 
            {
                string ProductID = e.CommandArgument.ToString();
                if (IsProductExistIn_PackageDetailsTable(ProductID)) { AlertMe("Product can not deleted. It is used in other Packages."); return; }
                string sql = "delete from  Product_Info where Product_id='" + ProductID + "'";
                int i = imp.InsertUpdateDelete(sql);
                if (i == 0) { AlertMe("Try again."); return; }
                AlertMe("Product successfully deleted.");
                BindProduct();
            }
        }
    }
}