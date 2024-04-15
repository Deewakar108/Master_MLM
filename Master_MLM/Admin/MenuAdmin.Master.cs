using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class MenuAdmin : System.Web.UI.MasterPage
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region     Company Details

            lblCompanyName.Text = imp.CompanyName;
            lblYear.Text = imp.CopyRightDate;
            lblAdmin.Text = "Administrator";
            #endregion

            if (Session["sksMenu"] != null) 
            {
                string sksID = Session["sksMenu"].ToString();
            }
            //Session["admin_usermlm"] = "1";
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
            Response.Write("<script language=javascript>wnd.close();</script>");
            Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
        }

    }
}