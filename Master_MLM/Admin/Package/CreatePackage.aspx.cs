using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;
using System.Data;

namespace Master_MLM.Admin
{
    public partial class CreatePackage : System.Web.UI.Page
    {
        //Important imp = new Important();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { BindExistPackage(); ClearAll(); }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsValidAllFiled()) { return; }

            DateTime dtToday = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            string sql = "";
            string Message = "";
            string Package_name = txtPackageName.Text;
            string Package_id = txtPackageID.Text;
            string Package_amount = txtAmount.Text;
            string Date = dtToday.ToString("dd/MM/yyyy");
            string Idate = dtToday.ToString("yyyyMMdd");
            string MonthlyYield = txtYeildPercentage.Text;
            string Duration = txtDuration.Text;
            string PackageNameForShown = txtPackageNameForShown.Text;

            if (btnSubmit.Text == "Submit")
            {
                sql = "INSERT INTO Joining_package([BV],[Package_name],[Package_id],[Package_amount],[Date],[Idate],[MonthlyYield],[Duration],[PackageNameForShown]) " +
                      "VALUES('" + Package_amount + "','" + Package_name + "','" + Package_id + "','" + Package_amount + "','" + Date + "','" + Idate + "','" + MonthlyYield +
                      "','" + Duration + "','" + PackageNameForShown + "')";
                Message = "Package Successfully created.";
            }
            else
            {
                sql = "UPDATE  Joining_package  set  [Package_name] = '" + Package_name + "',[BV] = '" + Package_amount + "',[Package_amount] = '" + Package_amount + "',[MonthlyYield] = '" +
                       MonthlyYield + "',[Duration] = '" + Duration + "',[PackageNameForShown] = '" + PackageNameForShown + "' where Package_id = '"+ Package_id + "'";
                Message = "Package Successfully modified.";
            }

            //int i = imp.InsertUpdateDelete(sql);
            //if (i == 0) { Alert("Try Again."); }
            //else { Alert(Message); ClearAll(); BindExistPackage(); }

        }

        public bool IsValidAllFiled()
        {
            if (txtPackageNameForShown.Text == "") { Alert("Invalid Package Name For Shown To Users."); txtPackageNameForShown.Focus(); return false; }
            if (txtPackageName.Text == "") { Alert("Invalid Package Name."); txtPackageName.Focus(); return false; }
            if (txtAmount.Text == "") { Alert("Invalid Package Value."); txtAmount.Focus(); return false; }
            if (txtYeildPercentage.Text == "") { Alert("Invalid Monthly Yield."); txtYeildPercentage.Focus(); return false; }
            if (txtDuration.Text == "") { Alert("Invalid Duration."); txtDuration.Focus(); return false; }

            if (btnSubmit.Text == "Submit") 
            { if (IsPackageNameExist(txtPackageName.Text)) { Alert("Package Name Already Exist."); txtPackageName.Focus(); return false; } }
            
            return true;
        }

        public bool IsPackageNameExist(string PackageName) 
        {
            //string sql = "select Package_name, Package_id FROM  Joining_package where  Package_name = '" + PackageName + "'";
            //DataTable dtTemp = imp.FillTable(sql);
            //if (dtTemp.Rows.Count != 0) { return true; }
            return false;
        }

        public void BindExistPackage()
        {
            //string sql = "select Package_name, Package_id FROM  Joining_package";
            //DataTable dtTemp = imp.FillTable(sql);
            //ddlPackage.DataSource = dtTemp;
            //ddlPackage.DataTextField = "Package_name";
            //ddlPackage.DataValueField = "Package_id";
            //ddlPackage.DataBind();
            //ddlPackage.Items.Insert(0, new ListItem { Text = "New Package", Value = "0", Selected = true });
        }

        public string GetNewPackageID()
        {
            return "";// imp.GetNewID("Package_id", "Joining_package");
        }

        protected void ddlPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlPackage.SelectedValue == "0") { ClearAll(); }
            //else { ShowPackageDetail(ddlPackage.SelectedValue); }
        }

        public void ShowPackageDetail(string PackageID)
        {
            //string sql = "select PackageNameForShown, Package_name, Package_id, isnull(Package_amount, 0) as Package_amount, isnull(Duration, 0) as Duration, " +
            //             "isnull(MonthlyYield, 0) as MonthlyYield FROM  Joining_package where Package_id = '" + PackageID + "'";
            //DataTable dtTemp = imp.FillTable(sql);
            //if (dtTemp.Rows.Count != 0)
            //{
            //    txtPackageNameForShown.Text = dtTemp.Rows[0]["PackageNameForShown"].ToString();
            //    txtPackageName.Text = dtTemp.Rows[0]["Package_name"].ToString();
            //    txtAmount.Text = dtTemp.Rows[0]["Package_amount"].ToString();
            //    txtYeildPercentage.Text = dtTemp.Rows[0]["MonthlyYield"].ToString();
            //    txtDuration.Text = dtTemp.Rows[0]["Duration"].ToString();
            //    txtPackageID.Text = dtTemp.Rows[0]["Package_id"].ToString();
            //    btnSubmit.Text = "Modify";
            //}
            //else
            //{
            //    ClearAll();
            //}
        }

        public void ClearAll()
        {
            txtPackageNameForShown.Text = "";
            txtPackageName.Text = "";
            txtAmount.Text = "";
            txtYeildPercentage.Text = "";
            txtDuration.Text = "";
            txtPackageID.Text = GetNewPackageID();            
            txtPackageNameForShown.Focus();
            btnSubmit.Text = "Submit";
        }

        public void Alert(string Message)
        {
            lbl_message.Text = Message;
            string scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
        }
    }
}