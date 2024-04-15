using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Data;

namespace Master_MLM.Member_4235profile
{
    public partial class Bank_Info : System.Web.UI.Page
    {
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
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

                    find_data(membercode);
                }
            }
        }

        private void find_data(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {

            }
            else
            {
                if (ds.Tables[0].Rows[0][21].ToString() == "")
                {
                    txt_accno.Enabled = true;
                    txt_bankname.Enabled = true;
                    txt_bankbranch.Enabled = true;
                    txt_ifsccode.Enabled = true;
                    txt_paename.Enabled = true;
                    txtAadharNo.Enabled = true;
                    txtPANNumber.Enabled = true;
                    btn_update.Visible = true;
                }
                else
                {
                    txt_accno.Enabled = false;
                    txt_bankname.Enabled = false;
                    txt_bankbranch.Enabled = false;
                    txt_ifsccode.Enabled = false;
                    txt_paename.Enabled = false;
                    txtAadharNo.Enabled = false;
                    txtPANNumber.Enabled = false;
                    btn_update.Visible = false;
                }
                txt_accno.Text = ds.Tables[0].Rows[0][21].ToString();
                txt_bankname.Text = ds.Tables[0].Rows[0][22].ToString();
                txt_bankbranch.Text = ds.Tables[0].Rows[0][23].ToString();
                txt_ifsccode.Text = ds.Tables[0].Rows[0][24].ToString();
                txt_paename.Text = ds.Tables[0].Rows[0]["Payee_Name_bank"].ToString();

                txtAadharNo.Text = ds.Tables[0].Rows[0]["AadharNumber"].ToString();
                txtPANNumber.Text = ds.Tables[0].Rows[0]["Pan_number"].ToString();
                
                Panel1.Visible = true;
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string membercode = Session["membercode"].ToString();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Account_number"] = txt_accno.Text;
                    dr["Bank_name"] = txt_bankname.Text;
                    dr["Branch_name"] = txt_bankbranch.Text;
                    dr["Ifsc_code"] = txt_ifsccode.Text;
                    dr["Payee_Name_bank"] = txt_paename.Text;

                    dr["AadharNumber"] = txtAadharNo.Text;
                    dr["Pan_number"] = txtPANNumber.Text;

                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    lbl_message.Text = "Bank info has been successfully update.";
                    Panel1.Visible = false;
                }
            }

        }
    }
}