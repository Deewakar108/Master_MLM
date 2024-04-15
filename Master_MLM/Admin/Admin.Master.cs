using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

namespace Master_MLM.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region     Company Details

            lblCompanyName.Text = imp.CompanyName;
            lblYear.Text = imp.CopyRightDate;
            lblAdmin.Text = "Administrator";
            #endregion

            if (Session["admin_usermlm"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            else
            {
                if (Session["sksMenu"] != null)
                {
                    string sksID = Session["sksMenu"].ToString();
                }
            }
            //Session["admin_usermlm"] = "1";

            //var sb = new StringBuilder();
            //sidebar.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
            //string s = sb.ToString();

            //XmlDocument xml = new XmlDocument();

            //foreach (Control item in ulMenu.Controls)
            //{
            //    if (item is HtmlGenericControl)
            //        Response.Write(((HtmlGenericControl)item).InnerHtml + "<br>");

            //}
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