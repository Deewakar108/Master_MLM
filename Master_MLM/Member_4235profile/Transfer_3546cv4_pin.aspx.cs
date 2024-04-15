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

namespace Master_MLM.Member_4235profile
{
    public partial class Transfer_3546cv4_pin : System.Web.UI.Page
    {


        #region page load
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

                #region pagbindin
                try
                {
                    //string mypage = Request.QueryString["mypage"];
                    //if (!String.IsNullOrEmpty(mypage))
                    //{
                    //    string page = mycode.Unzip(mypage);

                    //    if (page == mycode.Unzip(Session["verify"].ToString()))
                    //    {
                    if (!IsPostBack)
                    {
                        string membercode = Session["membercode"].ToString();
                        DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                        string date = dtm.ToString("dd/MM/yyyy");
                        Session["today"] = date;
                        // find_allocated_pin(membercode);
                        find_package(membercode);
                    }
                    //    }
                    //    else
                    //    {
                    //        Session.Abandon();
                    //        Session.Clear();
                    //        Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    //        Response.Write("<script language=javascript>wnd.close();</script>");
                    //        Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    //    }
                    //}
                    //else
                    //{

                    //    Session.Abandon();
                    //    Session.Clear();
                    //    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    //    Response.Write("<script language=javascript>wnd.close();</script>");
                    //    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    //}

                }
                catch
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    Response.Write("<script language=javascript>wnd.close();</script>");
                    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                }
                #endregion

            }

        }

        private void find_package(string membercode)
        {
            ArrayList ar = new ArrayList();
            string status = "GIVEN";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct Package from E_PIN_details where  distributed_to ='" + membercode + "' and Status='" + status + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                ar.Add("Select package");
                foreach (DataRow dr in dt.Rows)
                {
                    ar.Add(dr[0].ToString());

                }
                ddl_package.DataSource = ar;
                ddl_package.DataBind();

            }
        }

        //private void find_allocated_pin(string membercode)
        //{
        //    string status = "GIVEN";
        //    Connection con = new Connection();
        //    string connstr = con.connect_method();
        //    SqlConnection coon = new SqlConnection(connstr);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where  distributed_to ='" + membercode + "' and Status='" + status + "'", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "E_PIN_details");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        lbl_msg.Text = "Sorry! no data found";
        //        grd_epin.DataSource = null;
        //        grd_epin.DataBind();
        //    }
        //    else
        //    {
        //        lbl_msg.Text = "";
        //        grd_epin.DataSource = ds;
        //        grd_epin.DataBind();
        //    }
        //    lbl_avilable_pin.Text = rowcount.ToString();
        //    if (lbl_avilable_pin.Text == "0")
        //    {
        //        txt_member_id.Enabled = false;
        //        txt_pin_qty.Enabled = false;
        //    }
        //    else
        //    {
        //        txt_member_id.Enabled = true;
        //        txt_pin_qty.Enabled = true;
        //    }
        //}


        #endregion page load
        
        #region find
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (ddl_package.Text == "Select package")
            {
                lbl_findmsg.Text = "Please select package.";
            }
            else
            {
                find_pin();
            }
        }

        private void find_pin()
        {
            string membercode = Session["membercode"].ToString();
            string status = "GIVEN";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where  distributed_to ='" + membercode + "' and Status='" + status + "' and Package='" + ddl_package.Text + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_findmsg.Text = "Sorry! no data found.";
                pnl_view.Visible = false;

            }
            else
            {
                pnl_view.Visible = true;
                lbl_findmsg.Text = "";
                grd_epin.DataSource = ds;
                grd_epin.DataBind();

                lbl_avilable_pin.Text = rowcount.ToString();
                //if (lbl_avilable_pin.Text == "0")
                //{
                //    txt_member_id.Enabled = false;
                //    txt_pin_qty.Enabled = false;
                //}
                //else
                //{
                //    txt_member_id.Enabled = true;
                //    txt_pin_qty.Enabled = true;
                //}
            }
        }
        #endregion find




        #region transfer pin
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string membercode = Session["membercode"].ToString();
            if (txt_pin_qty.Text == "")
            {
                lbl_submit_msg.Text = "Please enter pin quantity.";
            }
            else if (txt_member_id.Text == "")
            {
                lbl_submit_msg.Text = "Please enter member id";
            }
            else
            {
                if (txt_member_id.Text == membercode)
                {
                    lbl_submit_msg.Text = "Please enter valid member id.";
                }
                else
                {
                    bool enter_pin_qty = ValidateNumber(txt_pin_qty.Text);

                    if (enter_pin_qty == false)
                    {
                        lbl_submit_msg.Text = "Only digit allowed";
                    }
                    else
                    {
                        if ((Convert.ToInt32(lbl_avilable_pin.Text)) >= Convert.ToInt32(txt_pin_qty.Text))
                        {
                            int qty = Convert.ToInt32(txt_pin_qty.Text);
                            for (int i = 0; i < qty; i++)
                            {
                                Label lblepin = (Label)grd_epin.Rows[i].FindControl("lbl_epin");
                                string epin;
                                epin = lblepin.Text;
                                string check_member_id = find_memberid(txt_member_id.Text);
                                if (check_member_id == "yes")
                                {
                                    lbl_submit_msg.Text = "";
                                    transfer_pin(epin, membercode);
                                    update_pin_detail_table(epin, membercode);
                                }
                                else
                                {
                                    lbl_submit_msg.Text = "Wrong Enter Member Code";
                                }

                            }
                            //find_allocated_pin(membercode);
                            find_pin();
                            txt_member_id.Text = "";
                            txt_pin_qty.Text = "";
                        }
                        else
                        {
                            lbl_submit_msg.Text = "Enter pin transfer not greater  than avilable pin.";

                        }

                    }
                }
            }
        }

        private string find_memberid(string Member_id)
        {
            string status = "yes";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Member_code from Member_registration where Member_code ='" + Member_id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                status = "no";
                return status;
            }
            else
            {
                status = "yes";
                return status;
            }
        }


        private void transfer_pin(string epin, string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Transfer_epin_member", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Transfer_epin_member");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = membercode;
            dr[1] = find_name(membercode);
            dr[2] = txt_member_id.Text;
            dr[3] = find_name(txt_member_id.Text);
            dr[4] = Session["today"].ToString();
            dr[5] = epin;
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
            lbl_submit_msg.Text = "Pin has been transfer successfully.";
            lbl_name.Text = "";
        }
        private object find_name(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Member_name from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];


            return dt.Rows[0][0].ToString();


        }
        private void update_pin_detail_table(string epin, string membercode)
        {


            string status = "GIVEN";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where  Epin ='" + epin + "' and Status='" + status + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[2] = txt_member_id.Text;
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }

        }
        #endregion transfer pin
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

        protected void txt_member_id_TextChanged(object sender, EventArgs e)
        {
            lbl_submit_msg.Text = "";
            lbl_submit_msg.Text = "";
            string membercode = txt_member_id.Text;
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code='" + membercode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                btn_submit.Enabled = false;
                lbl_name.Text = "";
                txt_member_id.Text = "";
                lbl_submit_msg.Text = "Sorry! no data found.";
            }
            else
            {
                lbl_submit_msg.Text = "";
                btn_submit.Enabled = true;
                lbl_name.Text = dt.Rows[0][4].ToString();

            }
        }


    }
}