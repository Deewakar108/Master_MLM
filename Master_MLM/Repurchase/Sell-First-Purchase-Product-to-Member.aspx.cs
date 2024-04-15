using Master_MLM.App_Code;
using Master_MLM.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Repurchase
{
    public partial class Sell_First_Purchase_Product_to_Member : System.Web.UI.Page
    {
        ClassException ce = new ClassException();
        #region page load
        bool check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (Session["repurchase_user"] == null)
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
                    DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    string date = dt.ToString("dd/MM/yyyy");
                    txt_date.Text = date;
                    fill_girid_view();
                    find_products();

                }
            }
        }
        private void find_products()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Distinct PD.Product_name,PD.Product_code from First_joining_Franchise_stock_wise_entry RFE join First_joining_product PD on RFE.Product_id=PD.Product_code where RFE.Franchise_code='" + Session["repurchase_user"].ToString() + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl__discription.Items.Insert(0, new ListItem("Select", "Select"));
            }
            else
            {
                ddl__discription.DataTextField = ds.Tables[0].Columns["Product_name"].ToString();
                ddl__discription.DataValueField = ds.Tables[0].Columns["Product_code"].ToString();
            }
            ddl__discription.DataSource = ds.Tables[0];
            ddl__discription.DataBind();
            ddl__discription.Items.Insert(0, new ListItem("Select", "Select"));
        }





        private void fill_girid_view()
        {

            string query = @"select * from Fisrt_Purchase_Pro_sell_member_product_wise RP join First_joining_product PD on RP.Product_id=PD.Product_code where RP.Status='SUBMITED' and RP.Member_code='" + txt_membercode.Text + "'and RP.Franchise_code='" + Session["repurchase_user"].ToString() + "' order by RP.Id asc";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                fatch_billno_code();
                panel_view.Visible = false;
                gridview.DataSource = null;
                gridview.DataBind();

            }
            else
            {
                txt_billno.Text = dt.Rows[0][3].ToString();
                panel_view.Visible = true;
                gridview.DataSource = ds;
                gridview.DataBind();

                int i;

                double totalamount = 0;
                int gridview_rowcount = gridview.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {

                    Label lbl_Tot_MRP = (Label)gridview.Rows[i].FindControl("lbl_Tot_MRP");

                    if (lbl_Tot_MRP.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_Tot_MRP.Text);
                    }

                }
                lbl_totalamount.Text = totalamount.ToString();

            }
        }

        #endregion

        #region find member
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_membercode.Text == "")
            {
                lbl_message.Text = "Please enter member code";
            }
            else
            {
                find_member_details();
            }
        }

        private void find_member_details()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + txt_membercode.Text + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "Member code doesn't exist";
                panel_member_details.Visible = false;
                panel_view.Visible = false;

            }
            else
            {
                lbl_message.Text = "";
                lbl_name.Text = dt.Rows[0][4].ToString();
                lbl_mobileno.Text = dt.Rows[0][7].ToString();
                lbl_address.Text = dt.Rows[0][14].ToString();
                panel_member_details.Visible = true;

                fill_girid_view();//

            }
        }


        private void fatch_billno_code()
        {
            fatch_bill_no bl = new fatch_bill_no();
            txt_billno.Text = bl.bill_no();

        }

        #endregion

        #region page event

        protected void ddl__discription_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_mrp.Text = "";
                txt_quantity.Text = "";

                bind_product_details();


            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

            }
        }

        private void bind_product_details()
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select PD.price,RFE.Quantity from First_joining_Franchise_stock_wise_entry RFE join First_joining_product PD on RFE.Product_id=PD.Product_code where RFE.Franchise_code='" + Session["repurchase_user"].ToString() + "' and RFE.Product_id='" + ddl__discription.SelectedValue + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {

                txt_quantity.Text = dt.Rows[0][1].ToString();
                txt_mrp.Text = dt.Rows[0][0].ToString();


            }
        }



        protected void txt_sell_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool isValidNumeric1 = ValidateNumber(txt_quantity.Text);
                bool isValidNumeric2 = ValidateNumber(txt_sell_quantity.Text);
                if (isValidNumeric1 == false)
                {

                }
                else if (isValidNumeric2 == false)
                {
                    lbl_message.Text = "Enter Only digit allowed for sell quantity";
                }
                else
                {
                    int quantity = int.Parse(txt_quantity.Text);
                    int sellquantity = int.Parse(txt_sell_quantity.Text);
                    if (quantity >= sellquantity)
                    {
                        lbl_message.Text = "";
                        btn_add.Enabled = true;
                    }
                    else
                    {
                        lbl_message.Text = "Sorry! sell quantity is greater than available quantity";
                        btn_add.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

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
         
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            delete_data(lbl_id.Text);
            fill_girid_view();
        }

        private void delete_data(string id)
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("delete from Fisrt_Purchase_Pro_sell_member_product_wise where id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Fisrt_Purchase_Pro_sell_member_product_wise");
        }
        #endregion

        #region btn add
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddl__discription.Text == "Select")
                {
                    lbl_message.Text = "Please select product";
                }
                else
                {
                    bool isValidNumeric1 = ValidateNumber(txt_sell_quantity.Text);
                    if (isValidNumeric1 == false)
                    {
                        lbl_message.Text = "Only digit allowed for sell quantity";
                    }
                    else
                    {
                        int quantity = int.Parse(txt_quantity.Text);
                        int sellquantity = int.Parse(txt_sell_quantity.Text);
                        if (quantity >= sellquantity)
                        {
                            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                            string date = dtm.ToString("dd/MM/yyyy");
                            string idate = dtm.ToString("yyyyMMdd");
                            Connection con = new Connection();
                            string Connectionstring = con.connect_method();
                            SqlConnection conn = new SqlConnection(Connectionstring);
                            SqlDataAdapter ad = new SqlDataAdapter("select * from Fisrt_Purchase_Pro_sell_member_product_wise ", conn);
                            DataSet ds = new DataSet();
                            ad.Fill(ds, "Fisrt_Purchase_Pro_sell_member_product_wise");
                            DataTable dt = ds.Tables[0];
                            DataRow dr = dt.NewRow();
                            dr[1] = txt_membercode.Text;
                            dr[2] = Session["repurchase_user"].ToString();
                            dr[3] = txt_billno.Text;
                            dr[4] = ddl__discription.SelectedValue;
                            dr[5] = txt_mrp.Text;
                            dr[6] = txt_sell_quantity.Text;
                            dr[7] = Convert.ToDouble(txt_mrp.Text) - Convert.ToDouble(txt_sell_quantity.Text);
                            dr[8] = date;
                            dr[9] = Convert.ToInt32(idate);
                            dr[10] = "SUBMITED";
                            dr[11] = "Self";
                            dt.Rows.Add(dr);
                            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                            ad.Update(dt);

                            txt_mrp.Text = "";
                            txt_quantity.Text = "";
                            txt_sell_quantity.Text = "";

                            fill_girid_view();
                        }
                        else
                        {
                            lbl_message.Text = "Sorry! sell quantity is greater than available quantity";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

            }

        }
        #endregion

        #region final submit
        protected void btn_final_submit_Click(object sender, EventArgs e)
        {
            double Total_mrp = 0;
            double Total_discount = 0;
            double Total_price = 0;
            double TotalBV = 0;
            int totalquantity = 0;
            string member_code = "";
            string Stockpointcode = "";
            string bill_no = "";
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)))
                {
                    int rcount = gridview.Rows.Count;
                    for (int i = 0; i < rcount; i++)
                    {
                        Label lbl_Membercode = (Label)gridview.Rows[i].FindControl("lbl_Membercode");
                        Label lbl_Stockpoint_code = (Label)gridview.Rows[i].FindControl("lbl_Stockpoint_code");
                        Label lbl_billno = (Label)gridview.Rows[i].FindControl("lbl_billno");
                        Label lbl_Productnameid = (Label)gridview.Rows[i].FindControl("lbl_Productnameid");

                        Label lbl_Mrp = (Label)gridview.Rows[i].FindControl("lbl_Mrp");
                        Label lbl_Quantity = (Label)gridview.Rows[i].FindControl("lbl_Quantity");
                        Label lbl_Tot_MRP = (Label)gridview.Rows[i].FindControl("lbl_Tot_MRP");



                        string Description = lbl_Productnameid.Text;

                        string Quantity = lbl_Quantity.Text;
                        string mrp = lbl_Mrp.Text;

                        member_code = lbl_Membercode.Text;
                        Stockpointcode = lbl_Stockpoint_code.Text;
                        bill_no = lbl_billno.Text;


                        Total_price = Total_price + Convert.ToDouble(lbl_Tot_MRP.Text);
                        totalquantity = totalquantity + Convert.ToInt32(Quantity);



                        update_Re_stock_point_stock_wise_entry(Description, Quantity, Stockpointcode);
                    }
                    Add_Re_sell_member_bill_wise(member_code, Stockpointcode, bill_no, Total_mrp, Total_discount, Total_price, TotalBV, totalquantity);


                    update_Re_sell_member_product_wise(member_code, Stockpointcode, bill_no);

                    send_sms(member_code);
                    check = true;
                    if (check == true)
                    {
                        scope.Complete();

                        string path = "First_joinng_Print_bill_GN.aspx?mem_code=" + txt_membercode.Text + "&billno=" + txt_billno.Text + "&stockpointcode=" + Session["repurchase_user"].ToString();
                        Response.Redirect(path);

                    }
                }



            }
            catch (Exception exc)
            {
                My.submitException1(exc.ToString());
            }
        }

        private void send_sms(string member_code)
        {
            // 
            string message = "Dear " + lbl_name.Text + " thank you for first purchasing product from  icon megamart, with Rs. " + lbl_totalamount.Text + ", your invoice no. is - " + txt_billno.Text + ".  For more details visit  www.iconmegamart.com";
            Message_sending.SendMsg1(member_code, lbl_mobileno.Text, message);

        }


        private void update_Re_stock_point_stock_wise_entry(string Description, string Quantity, string Stockpointcode)
        {
            double qty = 0;
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from First_joining_Franchise_stock_wise_entry where Product_id='" + Description + "' and Franchise_code='" + Stockpointcode + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "First_joining_Franchise_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                int quantity = Convert.ToInt32(dt.Rows[0][3].ToString());

                foreach (DataRow dr in dt.Rows)
                {
                    qty = quantity - Convert.ToInt32(Quantity);
                    dr[3] = qty;
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }


        }
        private void Add_Re_sell_member_bill_wise(string member_code, string Stockpointcode, string bill_no, double Total_mrp, double Total_discount, double Total_price, double TotalBV, int totalquantity)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string idate = dtm.ToString("yyyyMMdd");
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from First_purchare_Re_sell_member_bill_wise ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "First_purchare_Re_sell_member_bill_wise");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[1] = member_code;
            dr[2] = Stockpointcode;
            dr[3] = bill_no;
            dr[4] = totalquantity.ToString();
            dr[5] = Total_price.ToString();
            dr[6] = date;
            dr[7] = idate;
            dr[8] = "Self";
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }
        private void update_Re_sell_member_product_wise(string member_code, string Stockpointcode, string bill_no)
        {

            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("update Fisrt_Purchase_Pro_sell_member_product_wise set Status='ADDED' where Status='SUBMITED' and Member_code='" + member_code + "' and Franchise_code='" + Stockpointcode + "' and Bill_no='" + bill_no + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Fisrt_Purchase_Pro_sell_member_product_wise");
        }


        #endregion

    }
}