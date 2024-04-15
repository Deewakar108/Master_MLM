using Master_MLM.App_Code;
using Master_MLM.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Repurchase
{
    public partial class Add_Franchise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    fatch_all_added_stock_point_details();
                }
                catch (Exception ex)
                {
                }
            }

        }

        private void fatch_all_added_stock_point_details()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter("select * from Re_Franchise_details ", conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {
                panel_view.Visible = false;
                gridview.DataSource = null;
                gridview.DataBind();
            }
            else
            {
                panel_view.Visible = true;
                gridview.DataSource = ds;
                gridview.DataBind();

            }
        }
        private void fatch_Stockpoint_code()
        {
            txt_stockpointcode.Text = Mycode.Re_franchise_code();
        }

        #region find
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_member_code.Text == "" || txt_member_code.Text == "12345678")
            {
                lblmessage.Text = "Please enter valid member code";
            }
            else
            {
                lblmessage.Text = "";
                find_data();
            }
        }

        private void find_data()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + txt_member_code.Text + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lblmessage.Text = "Member code doesn't exist";
                panel_add_data.Visible = false;
            }
            else
            {
                lblmessage.Text = "";
                lbl_membername.Text = dt.Rows[0][4].ToString();
                fatch_Stockpoint_code();
                panel_add_data.Visible = true;

            }
        }
        #endregion


        #region btN add
        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_member_code.Text == "")
            {
                lblmessage.Text = "Please Enter Member code";
            }
            else
            {
                lblmessage.Text = "";
                bool isValidNumeric1 = ValidateNumber(txt_mobileno.Text);
                if (isValidNumeric1 == false)
                {
                    lblmessage.Text = "Please enter valid mobile no";

                }
                else
                {
                    lblmessage.Text = "";
                    add_stock_point_details();
                }
            }
        }

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

        private void add_stock_point_details()
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string idate = dtm.ToString("yyyyMMdd");

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select* from Re_Franchise_details where Member_code='" + txt_member_code.Text + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = txt_member_code.Text;
                dr[2] = lbl_membername.Text;
                dr[3] = txt_city.Text;
                dr[4] = txt_address.Text;
                dr[5] = txt_mobileno.Text;
                dr[6] = txt_stockpointcode.Text;
                dr[7] = txt_pwd.Text;
                dr[8] = date;
                dr[9] = Convert.ToInt32(idate);
                dr[10] = txt_franchisename.Text;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                //SendMsg(txt_mobileno.Text, txt_member_code.Text, lbl_membername.Text);
                lblmessage.Text = "Franchise details successfully added";
                txt_member_code.Text = "";
                lbl_membername.Text = "";
                txt_city.Text = "";
                txt_address.Text = "";
                txt_mobileno.Text = "";
                txt_pwd.Text = "";
                txt_stockpointcode.Text = "";
                txt_franchisename.Text = "";
                fatch_all_added_stock_point_details();
            }
            else
            {
                lblmessage.Text = "This Franchise is already added";
            }

        }

        #region message_sending

        private void SendMsg(string mobileno, string membercode, string membername)
        {
            string message = "DEAR " + membername + " Welcome To Ocean Health Pariwar Your REPURCHASE User ID =" + txt_stockpointcode.Text + " and Password is = '" + txt_pwd.Text + "' For more details Login to oceanhealthpariwar.com Achieve The Best";
            Message_sending.SendMsg(membercode, mobileno, message); 
        }

        private void send_message_details_in_Message_send_details(string mobileno, string message, string results, string membercode, string url)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string time = dtm.ToString("hh:mm:ss tt");

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details", conn6);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
            DataTable dt6 = ds6.Tables[0];
            DataRow dr6 = dt6.NewRow();
            dr6[1] = membercode;
            dr6[2] = mobileno;
            dr6[3] = date;
            dr6[4] = message;
            dr6[5] = results;
            dr6[6] = time;
            dr6[7] = url;
            dr6[8] = "";
            dt6.Rows.Add(dr6);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
            ad6.Update(dt6);
        }

        #endregion message_sending
        #endregion
        #region gride view edit
        protected void gridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview.EditIndex = -1;
            fatch_all_added_stock_point_details();
            gridview.DataBind();
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview.EditIndex = e.NewEditIndex;
            fatch_all_added_stock_point_details();
            gridview.DataBind();
        }

        protected void gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gridview.Rows[e.RowIndex];
            Label lbl_id = (Label)row.FindControl("lbl_id");
            TextBox txt_Address = (TextBox)row.FindControl("txt_Address");
            TextBox txt_City = (TextBox)row.FindControl("txt_City");
            TextBox txt_Mobileno = (TextBox)row.FindControl("txt_Mobileno");
            TextBox txt_Pwd = (TextBox)row.FindControl("txt_Pwd");
            TextBox txt_Franchise_name = (TextBox)row.FindControl("txt_Franchise_name");

            string id = lbl_id.Text;
            bool isValidNumeric1 = ValidateNumber(txt_Mobileno.Text);
            if (isValidNumeric1 == false)
            {
                lblmessage.Text = "Please enter valid mobile no";

            }
            else
            {
                edit_stock_point_details(id, txt_Address.Text, txt_City.Text, txt_Mobileno.Text, txt_Pwd.Text, txt_Franchise_name.Text);
                gridview.EditIndex = -1;
                lblmessage.Text = "Stock point edit successfully";
            }



        }

        private void edit_stock_point_details(string id, string Address, string City, string Mobileno, string Pwd, string Franchise_name)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where  Id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[3] = City;
                    dr[4] = Address;
                    dr[5] = Mobileno;
                    dr[7] = Pwd;
                    dr[10] = Franchise_name;
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
                gridview.EditIndex = -1;
                fatch_all_added_stock_point_details();
            }
        }




        #endregion



        #region Delete
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;
            delete_Re_Franchise_details(id);
            fatch_all_added_stock_point_details();
            lblmessage.Text = "";
        }
        private void delete_Re_Franchise_details(string id)
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select* from Re_Franchise_details where Id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr.Delete();
                    break;
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);

            }

        }

        #endregion
    }
}