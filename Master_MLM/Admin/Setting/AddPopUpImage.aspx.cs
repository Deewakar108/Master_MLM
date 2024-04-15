using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class AddPopUpImage : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { ShowAdd(); }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string ImagePath = imp.UploadFile(FileUpload1, "images/reward/popup/");
            if (ImagePath != "")
            {
                //ImagePath = ImagePath;
                string sql = "insert into PopupImage(ImagePath, IsActive) values('~/" + ImagePath + "','0')";
                sql = "update PopupImage set ImagePath = '~/" + ImagePath + "'";
                int i = imp.InsertUpdateDelete(sql);
                if (i != 0) { ShowAdd(); }
                else { lblMessage.Text = "Inavlid Image."; }
            }
            else { lblMessage.Text = "Inavlid Image."; }
        }

        public void ShowAdd()
        {
            string sql = "select * from PopupImage";
            DataTable dt = imp.FillTable(sql);

            grdImage.DataSource = dt;
            grdImage.DataBind();
        }

        protected void grdImage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsActive") 
            {
                string IsActive = e.CommandArgument.ToString();
                if (IsActive == "0") { IsActive = "1"; } else { IsActive = "0"; }
                string sql = "update PopupImage set IsActive = '" + IsActive + "'";
                int i = imp.InsertUpdateDelete(sql); 
                if (i != 0) { ShowAdd(); }
                else { lblMessage.Text = "Error."; }
            }
        }

        protected void grdImage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Button btn = (Button)e.Row.FindControl("btnActive");
                if (btn.CommandArgument.ToString() == "1") { btn.Text = "Inactive"; }
                else { btn.Text = "Active"; }
            }
        }
    }
}