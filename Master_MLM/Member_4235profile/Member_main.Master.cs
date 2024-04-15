using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Member_main : System.Web.UI.MasterPage
    {
        Important imp = new Important();

         protected void Page_Load(object sender, EventArgs e)
        {
            #region     Company Details
            lblCompanyName.Text = imp.CompanyName;
            lblYear.Text = imp.CopyRightDate;
            #endregion
            
            if (Session["membercode"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            else
            {
                if (!IsPostBack)
                {
                    string membercode = Session["membercode"].ToString();
                    find_name(membercode);
                     
                }
            }
        }
        
        private void find_name(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Member_name,Sponcer_code,Sponcer_name,Date,member_imagepath from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                // do nothing
            }
            else
            {               
                Session["membername"] = dt.Rows[0][0].ToString();
                //lbl_membername.Text = "welcome in your profile " + dt.Rows[0][0].ToString();
                //lbl_membercode.Text ="Your Id : "+ membercode; 

                lbl_membername.Text = dt.Rows[0][0].ToString();
                lbl_membercode.Text = "ID : " + membercode;

                if (dt.Rows[0][0].ToString().Length > 12)
                {
                    lbl_membername.Text = dt.Rows[0][0].ToString().Split(' ')[0].ToString();
                }

                if (dt.Rows[0]["member_imagepath"].ToString() != "")
                { imgMember.ImageUrl = dt.Rows[0]["member_imagepath"].ToString(); }
            }
        }

        protected void lnk_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
            Response.Write("<script language=javascript>wnd.close();</script>");
            Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
            Response.Write("<script language=javascript>wnd.close();</script>");
            Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
        }
    }
}