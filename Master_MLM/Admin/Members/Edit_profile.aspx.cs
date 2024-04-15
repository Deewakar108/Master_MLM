using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Edit_profile : System.Web.UI.Page
    {
        Important imp = new Important();
        string scrpt;
        #region page load
        My mycode = new My();
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
            else
            {
                if (!IsPostBack)
                {
                    bind_state();
                }
            }
        }

        private void bind_state()
        {
            mycode.bind_ddl(ddl_state, "Select distinct State from  state_and_district  order by State ");
        }


        protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_state.Text == "Select")
            {
                lbl_message.Text = "Please Select Sate Name";
            }
            else
            {
                lbl_message.Text = "";
                mycode.bind_ddl(ddl_district, "Select distinct District from  state_and_district where State='" + ddl_state.Text + "'  order by District ");

            }
        }




        private void find_data(string membercode)
        {
            lbl_message.Text = "";
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
                txt_pincode.Text = ds.Tables[0].Rows[0]["Pin_code"].ToString();
                txt_sponsorcode.Text = ds.Tables[0].Rows[0][1].ToString();
                txt_sponsorname.Text = ds.Tables[0].Rows[0][2].ToString();
                txt_member_code.Text = ds.Tables[0].Rows[0][3].ToString();
                txt_name.Text = ds.Tables[0].Rows[0][4].ToString();
                string date = ds.Tables[0].Rows[0][5].ToString();
                lbl_joining_date.Text = date;


                if (ds.Tables[0].Rows[0]["Verification_date"].ToString() == "")
                {
                    lbl_verificationdate.Text = "xx/xx/xxxxx";
                    lbl_joining_package.Text = "xxxxx";
                }
                else
                {
                    lbl_verificationdate.Text = ds.Tables[0].Rows[0]["Verification_date"].ToString();
                    lbl_joining_package.Text = ds.Tables[0].Rows[0]["joining_package"].ToString();
                }


                txtemailid.Text = ds.Tables[0].Rows[0][6].ToString();
                txtmobileno.Text = ds.Tables[0].Rows[0][7].ToString();
                hdfMobileNo.Value = ds.Tables[0].Rows[0][7].ToString();
                txtpannumber.Text = ds.Tables[0].Rows[0][8].ToString();

                txt_name.Text = ds.Tables[0].Rows[0][4].ToString();

                txt_fathername.Text = ds.Tables[0].Rows[0][11].ToString();
                txt_dob.Text = ds.Tables[0].Rows[0][12].ToString();

                if (ds.Tables[0].Rows[0][13].ToString() == "")
                {
                }
                else
                {
                    ddl_gender.Text = ds.Tables[0].Rows[0][13].ToString();
                }
                txt_address.Text = ds.Tables[0].Rows[0][14].ToString();
                txt_city.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txt_nomineename.Text = ds.Tables[0].Rows[0][17].ToString();
                txt_nomineerelation.Text = ds.Tables[0].Rows[0][18].ToString();
                txt_nomineeage.Text = ds.Tables[0].Rows[0][19].ToString();
                if (ds.Tables[0].Rows[0][20].ToString() == "")
                {
                }
                else
                {
                    ddl_nomineegender.Text = ds.Tables[0].Rows[0][20].ToString();
                }

                ddl_state.SelectedItem.Text = ds.Tables[0].Rows[0]["State"].ToString();
                bind_district();
                ddl_district.SelectedItem.Text = ds.Tables[0].Rows[0]["District"].ToString();



                Panel1.Visible = true;
            }
        }

        private void bind_district()
        {
            mycode.bind_ddl(ddl_district, "Select distinct District from  state_and_district where State='" + ddl_state.Text + "'  order by District ");
        }
        #endregion page load

        #region Update data
        protected void btn_update_Click(object sender, EventArgs e)
        {
            bool chkob = mycode.valid_number(txtmobileno.Text);

            bool chkavl_mob_no = true;
            if (txtmobileno.Text != hdfMobileNo.Value)
            { chkavl_mob_no = find_mobile_status(); }
            
            
            if (chkob == false)
            {

                lbl_msg.Text = "Please enter valid mobile no.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else if (chkavl_mob_no == false)
            {
                lbl_msg.Text = "This mobile no. is already used ";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else
            {
                string membercode = txt_member_id.Text;

                //if (check_banckaccount(membercode))
                //{
                

                send_data_to_member_registration(membercode);
                update_member_registration_table_for_sponcer(membercode);
                update_member_child_point_details(membercode);
                update_for_binary_status(membercode);
                find_data(membercode);
                Panel1.Visible = false;
                //}
            }
        }

        //private bool check_banckaccount(string membercode)
        //{
        //    bool toreturn = false;
        //    Connection myconn = new Connection();
        //    string coon = myconn.connect_method();
        //    SqlDataAdapter ad = new SqlDataAdapter("Select *  from Member_registration where Account_number='" + accountno + "'  and Member_code!='" + membercode + "'   ", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Member_registration");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        toreturn = true;
        //    }
        //    else
        //    {
        //        toreturn = false;
        //    }
        //    return toreturn;
        //}

        private bool find_mobile_status()
        {
            bool toreturn = false;
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Mobile_number='" + txtmobileno.Text + "' and Member_code!='" + txt_member_code.Text + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                toreturn = true;
            }
            else
            {

                toreturn = false;
            }
            return toreturn;
        }





        private void update_member_child_point_details(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from member_child_points_details where member_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "member_child_points_details");
            DataTable dt = ds.Tables[0];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr[0] = txt_name.Text;
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
                //i++;
            }
        }
        private void update_for_binary_status(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from binary_status where member_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr[0] = txt_name.Text;
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
                //i++;
            }
        }

        private void update_member_registration_table_for_sponcer(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Sponcer_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr[2] = txt_name.Text;
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
                //i++;
            }
        }
        private void send_data_to_member_registration(string membercode)
        {


            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                dr["Pin_code"] = txt_pincode.Text;

                dr[4] = txt_name.Text;
                dr[6] = txtemailid.Text;
                dr[7] = txtmobileno.Text;
                dr[8] = txtpannumber.Text;
                dr[10] = txt_name.Text;
                dr[11] = txt_fathername.Text;
                dr[12] = txt_dob.Text;
                dr[13] = ddl_gender.Text;
                dr[14] = txt_address.Text;
                dr[15] = ddl_district.Text;
                dr[16] = ddl_state.Text;
                dr[17] = txt_nomineename.Text;
                dr[18] = txt_nomineerelation.Text;
                dr[19] = txt_nomineeage.Text;
                dr[20] = ddl_nomineegender.Text;
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
                lbl_message.Text = "Data has been successfully update.";
                Panel1.Visible = false;
            }
        }


        #endregion Update data

        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_member_id.Text == imp.AdminCode)
            {
                lbl_message.Text = "Enter wrong entry";
            }
            else if (txt_member_id.Text == "")
            {
                lbl_message.Text = "Enter member id";
            }
            else
            {
                if (txt_member_id.Text != "")
                {
                    string membercode = txt_member_id.Text;

                    find_data(membercode);
                }
                else 
                { lbl_message.Text = "Enter valid Member code "; }
                //bool chkmobile = mycode.valid_number(txt_member_id.Text);
                //if (chkmobile == false)
                //{
                //    lbl_message.Text = "Enter valid Member code ";
                //}
                //else
                //{
                //    string membercode = txt_member_id.Text;

                //    find_data(membercode);
                //}

            }
        }


    }
}
