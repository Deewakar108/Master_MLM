
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

namespace Master_MLM.Admin.Repurchase
{
    public partial class Sell_Product_to_Member : System.Web.UI.Page
    {
        ClassException ce = new ClassException();
        #region page load
        bool check = false;
        My mycod = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dt.ToString("dd/MM/yyyy");
                txt_date.Text = date;

                fatch_product();
                fatch_stock_code_id();

                backup_and_previous_month_bv();
            }
        }
        My mucode1 = new My();
        private void backup_and_previous_month_bv()
        {
            mucode1.backup();//backup
        }

        private void fatch_stock_code_id()
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Stock_point_code,Member_name from Re_Franchise_details ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_stockcode.Items.Insert(0, new ListItem("Select", "Select"));

            }
            else
            {
                ddl_stockcode.DataTextField = ds.Tables[0].Columns["Stock_point_code"].ToString();
                ddl_stockcode.DataValueField = ds.Tables[0].Columns["Stock_point_code"].ToString();

            }
            ddl_stockcode.DataSource = ds.Tables[0];
            ddl_stockcode.DataBind();
            ddl_stockcode.Items.Insert(0, new ListItem("Select", "Select"));
        }

        private void fatch_product()
        {
            mycod.bind_all_ddl_with_id_ltst(ddl_product_name, "Select Product_name,Product_id from  Product_Details order by Product_name");

        }


        #endregion

        #region find member
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_stockcode.SelectedItem.Text == "")
                {
                    lbl_message.Text = "Please select franchise code";
                }
                else
                {
                    if (txt_membercode.Text == "")
                    {
                        lbl_message.Text = "Please enter member code";
                    }
                    else
                    {
                        fill_girid_view();
                        find_member_details();
                    }
                }
            }
            catch
            {
            }
        }
        private void fill_girid_view()
        {
            string Status = "SUBMITED";
            string query = @"select * from Re_sell_member_product_wise RP join Product_Details PD on RP.Product_id=PD.Product_id where RP.Status='" + Status + "' and RP.Membercode='" + txt_membercode.Text + "'and RP.Stockpointcode='" + ddl_stockcode.SelectedValue + "'  order by RP.Id asc";
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
                txt_billno.Text = dt.Rows[0]["Bill_no"].ToString();
                panel_view.Visible = true;
                gridview.DataSource = ds;
                gridview.DataBind();

                int i;
                int totalbv = 0;
                double totalamount = 0;
                int gridview_rowcount = gridview.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_Tot_BV");
                    Label lbl_Tot_MRP = (Label)gridview.Rows[i].FindControl("lbl_Tot_MRP");
                    if (lbl_BV.Text != "")
                    {
                        totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
                    }
                    if (lbl_Tot_MRP.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_Tot_MRP.Text);
                    }

                }
                lbl_totalamount.Text = totalamount.ToString();
                lbl_totalbv.Text = totalbv.ToString();

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
                // find_product_of_member_billwise(); // find sell product list if not clear
            }
        }

        //private void find_product_of_member_billwise()
        //{
        //    Connection con = new Connection();
        //    string Connectionstring = con.connect_method();
        //    SqlConnection conn = new SqlConnection(Connectionstring);
        //    SqlDataAdapter ad = new SqlDataAdapter("select * from Re_sell_member_product_wise where Membercode='" + txt_membercode.Text + "' and Stockpointcode='" + ddl_stockcode.SelectedValue + "' and Status='SUBMITED'", conn);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Re_sell_member_product_wise");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        fatch_billno_code();
        //        panel_view.Visible = false;
        //        gridview.DataSource = null;
        //        gridview.DataBind();
        //    }
        //    else
        //    {
        //        txt_billno.Text = dt.Rows[0][3].ToString();
        //        panel_view.Visible = true;
        //        gridview.DataSource = ds;
        //        gridview.DataBind();
        //        int i;
        //        int totalbv = 0;
        //        double totalamount = 0;
        //        int gridview_rowcount = gridview.Rows.Count;
        //        for (i = 0; i < gridview_rowcount; i++)
        //        {
        //            Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_Tot_BV");
        //            Label lbl_Sell_price = (Label)gridview.Rows[i].FindControl("lbl_TotSell_price");
        //            if (lbl_BV.Text != "")
        //            {
        //                totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
        //            }
        //            if (lbl_Sell_price.Text != "")
        //            {
        //                totalamount = totalamount + Convert.ToDouble(lbl_Sell_price.Text);
        //            }

        //        }
        //        lbl_totalamount.Text = totalamount.ToString();
        //        lbl_totalbv.Text = totalbv.ToString();
        //    }
        //}
        private void fatch_billno_code()
        {
            fatch_bill_no bl = new fatch_bill_no();
            txt_billno.Text = bl.bill_no();

        }

        #endregion

        #region page event


        protected void ddl_product_name_SelectedIndexChanged(object sender, EventArgs e)
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
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_stock_wise_entry where Product_id='" + ddl_product_name.SelectedValue + "'  and Stockpoint_code='" + ddl_stockcode.SelectedValue + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                txt_bv.Text = dt.Rows[0]["BV"].ToString();
                txt_quantity.Text = dt.Rows[0]["Quantity"].ToString();
                txt_mrp.Text = dt.Rows[0]["Mrp"].ToString();

            }
        }

        //private void fil_sell_price(string mrp)
        //{

        //    double mrp1 = double.Parse(mrp);
        //    double discount1 = double.Parse(discount);
        //    double price = Convert.ToDouble(mrp1 - (mrp1 * (discount1) / 100));
        //    txt_sell_price.Text = price.ToString();

        //}

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
            SqlDataAdapter ad = new SqlDataAdapter("delete from Re_sell_member_product_wise where id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_sell_member_product_wise");
        }
        #endregion

        #region btn add
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product_name.Text == "Select")
                {
                    lbl_message.Text = "Please select product";
                }
                else if (txt_bv.Text == "")
                {
                    lbl_message.Text = "Please enter BV";
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
                            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_sell_member_product_wise ", conn);
                            DataSet ds = new DataSet();
                            ad.Fill(ds, "Re_sell_member_product_wise");
                            DataTable dt = ds.Tables[0];
                            DataRow dr = dt.NewRow();
                            dr["Membercode"] = txt_membercode.Text;
                            dr["Stockpointcode"] = ddl_stockcode.SelectedValue;
                            dr["Bill_no"] = txt_billno.Text;
                            dr["Product_id"] = ddl_product_name.SelectedValue;
                            dr["BV"] = txt_bv.Text;
                            dr["MRP"] = txt_mrp.Text;
                            dr["Quantity"] = txt_sell_quantity.Text;
                            dr["Date"] = date;
                            dr["Idate"] = Convert.ToInt32(idate);
                            dr["Status"] = "SUBMITED";

                            Double tot_mrp = Convert.ToDouble(txt_mrp.Text) * Convert.ToDouble(txt_sell_quantity.Text);
                            dr["Tot_MRP"] = tot_mrp;
                            dr["Tot_BV"] = Convert.ToDouble(txt_bv.Text) * Convert.ToDouble(txt_sell_quantity.Text);
                            dr["entry_by"] = "Admin";
                            dt.Rows.Add(dr);
                            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                            ad.Update(dt);

                            txt_sell_quantity.Text = "";

                            txt_mrp.Text = "";
                            txt_bv.Text = "";
                            txt_quantity.Text = "";

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
                        Label lbl_Description = (Label)gridview.Rows[i].FindControl("lbl_Productnameid");
                        Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_BV");
                        Label lbl_Mrp = (Label)gridview.Rows[i].FindControl("lbl_Mrp");
                        Label lbl_Quantity = (Label)gridview.Rows[i].FindControl("lbl_Quantity");

                        Label lbl_Tot_BV = (Label)gridview.Rows[i].FindControl("lbl_Tot_BV");
                        Label lbl_Tot_MRP = (Label)gridview.Rows[i].FindControl("lbl_Tot_MRP");


                        string Description = lbl_Description.Text;
                        string BV = lbl_BV.Text;
                        string Quantity = lbl_Quantity.Text;
                        string mrp = lbl_Mrp.Text;

                        member_code = lbl_Membercode.Text;
                        Stockpointcode = lbl_Stockpoint_code.Text;
                        bill_no = lbl_billno.Text;

                        TotalBV = TotalBV + Convert.ToDouble(lbl_Tot_BV.Text);
                        Total_mrp = Total_mrp + Convert.ToDouble(lbl_Tot_MRP.Text);
                        totalquantity = totalquantity + Convert.ToInt32(Quantity);

                        update_Re_stock_point_stock_wise_entry(Description, BV, Quantity, Stockpointcode);
                    }
                    Add_Re_sell_member_bill_wise(member_code, Stockpointcode, bill_no, Total_mrp, TotalBV, totalquantity);
                    send_data_into_Repurchase_daily_detail(member_code, bill_no, Total_mrp, TotalBV);
                    update_Re_sell_member_product_wise(member_code, Stockpointcode, bill_no);
                    Fatch_introducer_code fic = new Fatch_introducer_code();
                    string introducer_no = fic.introducer_code(member_code);
                    send_data_into_member_bv_point_deatils(member_code, introducer_no, TotalBV);

                    //send_data_into_member_ranking_details(member_code);
                    check = true;
                    send_sms(member_code);

                    if (check == true)
                    {
                        scope.Complete();
                        string path = "Print_bill_member_sell.aspx?mem_code=" + txt_membercode.Text + "&billno=" + txt_billno.Text + "&stockpointcode=" + ddl_stockcode.SelectedValue;
                        Response.Redirect(path);
                        // lbl_message.Text = "Sell successfully send";
                    }
                }
                //   fill_girid_view();
            }
            catch (Exception exc)
            {

            }
        }


        private void update_Re_stock_point_stock_wise_entry(string Description, string BV, string Quantity, string Stockpointcode)
        {
            double qty = 0;
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_stock_wise_entry where Product_id='" + Description + "' and Stockpoint_code='" + Stockpointcode + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                int quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                double Mrp = Convert.ToDouble(dt.Rows[0]["Mrp"].ToString());
                int B_V = Convert.ToInt32(dt.Rows[0]["BV"].ToString());

                foreach (DataRow dr in dt.Rows)
                {
                    qty = quantity - Convert.ToInt32(Quantity);
                    dr["Quantity"] = qty;
                    dr["Mrp"] = qty * Convert.ToDouble(Mrp);
                    dr["Tot_bv"] = qty * Convert.ToDouble(B_V);

                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }


        }


        private void Add_Re_sell_member_bill_wise(string member_code, string Stockpointcode, string bill_no, double Total_mrp, double TotalBV, int totalquantity)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string idate = dtm.ToString("yyyyMMdd");
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_sell_member_bill_wise ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_sell_member_bill_wise");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["Membercode"] = member_code;
            dr["Stock_code"] = Stockpointcode;
            dr["Billno"] = bill_no;
            dr["Total_mrp"] = Total_mrp.ToString();
            dr["TotalBV"] = TotalBV.ToString();
            dr["Date"] = date;
            dr["Idate"] = idate;
            dr["Totalquantity"] = totalquantity.ToString();
            dr["entry_by"] = "Admin";
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }
        private void update_Re_sell_member_product_wise(string member_code, string Stockpointcode, string bill_no)
        {
            string Status = "SUBMITED";
            string added = "ADDED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("update Re_sell_member_product_wise set Status='" + added + "' where Status='" + Status + "' and Membercode='" + member_code + "' and Stockpointcode='" + Stockpointcode + "' and Bill_no='" + bill_no + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_sell_member_product_wise");
        }
        private void send_data_into_member_bv_point_deatils(string member_code, string introducer_no, double TotalBV)
        {
            add_Re_purchase_member_bv_point_details(member_code, introducer_no, TotalBV);
            update_introducer_code_bv_pint(introducer_no, TotalBV);

            add_Re_purchase_member_bv_point_details_monthly(member_code, introducer_no, TotalBV);
            update_introducer_code_bv_pint_monthly(introducer_no, TotalBV);


        }

        private void add_Re_purchase_member_bv_point_details(string member_code, string introducer_no, double TotalBV)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_purchase_member_bv_point_details where Member_code='" + member_code + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = member_code;
                dr[2] = introducer_no;
                dr[3] = TotalBV.ToString();
                dr[4] = "0";
                dr[5] = date;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {
                int quantity = Convert.ToInt32(dt.Rows[0][3].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    dr[3] = quantity + TotalBV;
                    dr[5] = date;
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }

        }
        private void update_introducer_code_bv_pint(string member_code, double TotalBV)
        {
            Fatch_introducer_code fic = new Fatch_introducer_code();
            string introducer_no = fic.introducer_code(member_code);
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn5 = new SqlConnection(connectionstring);
            SqlDataAdapter ad5 = new SqlDataAdapter("Select * from Re_purchase_member_bv_point_details where member_code='" + member_code + "'", conn5);
            DataSet ds = new DataSet();
            ad5.Fill(ds, "Re_purchase_member_bv_point_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = member_code;
                dr[2] = introducer_no;
                dr[3] = "0";
                dr[4] = TotalBV.ToString();
                dr[5] = date;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad5);
                ad5.Update(dt);
                if (introducer_no == "12345678")
                {
                }
                else
                {

                    update_introducer_code_bv_pint(introducer_no, TotalBV);
                }
            }
            else
            {

                string nextmembercode = ds.Tables[0].Rows[0][2].ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    int bv = Convert.ToInt32(dt.Rows[0][4].ToString());
                    dr[4] = bv + TotalBV;
                    dr[5] = date;
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad5);
                ad5.Update(dt);
                if (nextmembercode == "12345678")
                {
                }
                else
                {

                    update_introducer_code_bv_pint(nextmembercode, TotalBV);
                }

            }
        }

        private void add_Re_purchase_member_bv_point_details_monthly(string member_code, string introducer_no, double TotalBV)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("MM/yyyy");
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_purchase_member_bv_point_details_monthly where Member_code='" + member_code + "'  and Month='" + date + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_purchase_member_bv_point_details_monthly");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = member_code;
                dr[2] = introducer_no;
                dr[3] = TotalBV.ToString();
                dr[4] = "0";
                dr[5] = date;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {
                int BV = Convert.ToInt32(dt.Rows[0][3].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    dr[3] = BV + TotalBV;

                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }
        private void update_introducer_code_bv_pint_monthly(string member_code, double TotalBV)
        {
            Fatch_introducer_code fic = new Fatch_introducer_code();
            string introducer_no = fic.introducer_code(member_code);
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("MM/yyyy");

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn5 = new SqlConnection(connectionstring);
            SqlDataAdapter ad5 = new SqlDataAdapter("Select * from Re_purchase_member_bv_point_details_monthly where member_code='" + member_code + "' and Month='" + date + "'", conn5);
            DataSet ds = new DataSet();
            ad5.Fill(ds, "Re_purchase_member_bv_point_details_monthly");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = member_code;
                dr[2] = introducer_no;
                dr[3] = "0";
                dr[4] = TotalBV.ToString();
                dr[5] = date;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad5);
                ad5.Update(dt);
                if (introducer_no == "12345678")
                {
                }
                else
                {
                    update_introducer_code_bv_pint_monthly(introducer_no, TotalBV);
                }
            }
            else
            {

                string nextmembercode = ds.Tables[0].Rows[0][2].ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    int bv = Convert.ToInt32(dt.Rows[0][4].ToString());
                    dr[4] = bv + TotalBV;

                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad5);
                ad5.Update(dt);
                if (nextmembercode == "12345678")
                {
                }
                else
                {
                    update_introducer_code_bv_pint_monthly(nextmembercode, TotalBV);
                }

            }
        }

        #endregion
        //Repurchase_daily_detail code is not used
        #region Repurchase_daily_detail
        private void send_data_into_Repurchase_daily_detail(string member_code, string bill_no, double Total_price, double TotalBV)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Sponcer_code,Position from Member_registration where Member_code='" + member_code + "' ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt1 = ds.Tables[0];
            int rowcount = dt1.Rows.Count;
            if (rowcount > 0)
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("Select * from Repurchase_daily_detail ", coon);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Repurchase_daily_detail");
                DataTable dt = ds1.Tables[0];
                DataRow dr = dt.NewRow();
                dr[1] = bill_no;
                dr[2] = member_code;
                dr[3] = dt1.Rows[0][0].ToString();
                dr[4] = dt1.Rows[0][1].ToString();
                dr[5] = Total_price;
                dr[6] = TotalBV;
                dr[7] = date;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad1);
                ad1.Update(dt);
                update_senior_pv(member_code, dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), TotalBV.ToString(), date);
            }
        }

        private void update_senior_pv(string membercode, string seniorcode, string position, string PV, string date)
        {
            send_data_into_Repurchase_left_right_pv(membercode, seniorcode, position, PV, date);
            update_senior(seniorcode, position, PV, date);

            send_data_into_Repurchase_tot_left_right_pv(membercode, seniorcode, position, PV, date);
            update_tot_senior(seniorcode, position, PV, date);
        }

        private void send_data_into_Repurchase_left_right_pv(string membercode, string seniorcode, string position, string PV, string date)
        {
            string month = date.Substring(3);
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn4 = new SqlConnection(connectionstring);
            SqlDataAdapter ad4 = new SqlDataAdapter("Select * from Repurchase_left_right_pv where Membercode='" + membercode + "' and Month='" + month + "'", conn4);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4, "Repurchase_left_right_pv");
            DataTable dt4 = ds4.Tables[0];
            int rowcount = dt4.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr4 = dt4.NewRow();
                dr4[1] = membercode;
                dr4[2] = seniorcode;
                dr4[3] = "0";
                dr4[4] = "0";
                dr4[5] = month;
                dr4[6] = date;
                dt4.Rows.Add(dr4);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
                ad4.Update(dt4);
            }
        }

        private void update_senior(string seniorcode, string position, string PV, string date)
        {
            if (seniorcode != "12345678")
            {

                string month = date.Substring(3);
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn4 = new SqlConnection(connectionstring);
                SqlDataAdapter ad4 = new SqlDataAdapter("Select * from Repurchase_left_right_pv where Membercode='" + seniorcode + "' and Month='" + month + "'", conn4);
                DataSet ds4 = new DataSet();
                ad4.Fill(ds4, "Repurchase_left_right_pv");
                DataTable dt4 = ds4.Tables[0];
                int rowcount = dt4.Rows.Count;
                if (rowcount == 0)
                {
                    string senior_of_senior = find_senior(seniorcode);

                    DataRow dr4 = dt4.NewRow();
                    dr4[1] = seniorcode;
                    dr4[2] = senior_of_senior;
                    if (position == "Left")
                    {
                        dr4[3] = PV;
                        dr4[4] = "0";
                    }
                    else if (position == "Right")
                    {
                        dr4[3] = "0";
                        dr4[4] = PV;
                    }
                    dr4[5] = month;
                    dr4[6] = date;
                    dt4.Rows.Add(dr4);
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
                    ad4.Update(dt4);

                    string nextposition = find_introducer_position(seniorcode);
                    send_senior_to_upper(seniorcode, senior_of_senior, nextposition, date);
                    update_senior(senior_of_senior, nextposition, PV, date);
                }
                else
                {
                    string nextmembercode = dt4.Rows[0][2].ToString();
                    double leftov = Convert.ToDouble(dt4.Rows[0][3].ToString());
                    double rightov = Convert.ToDouble(dt4.Rows[0][4].ToString());
                    foreach (DataRow dr in dt4.Rows)
                    {
                        if (position == "Left")
                        {
                            dr[3] = leftov + Convert.ToDouble(PV);
                        }
                        else if (position == "Right")
                        {
                            dr[4] = rightov + Convert.ToDouble(PV);
                        }
                        SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
                        ad4.Update(dt4);
                    }

                    if (nextmembercode != "12345678")
                    {
                        string nextposition = find_introducer_position(seniorcode);
                        send_senior_to_upper(seniorcode, nextmembercode, nextposition, date);
                        update_senior(nextmembercode, nextposition, PV, date);
                    }

                }

            }
        }
        private void send_senior_to_upper(string seniorcode, string senior_codde, string position, string date)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn4 = new SqlConnection(connectionstring);
            SqlDataAdapter ad4 = new SqlDataAdapter("select * from Virtual_payout", conn4);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4, "Virtual_payout");
            DataTable dt4 = ds4.Tables[0];
            DataRow dr4 = dt4.NewRow();
            dr4[0] = seniorcode;
            dr4[1] = senior_codde;
            dr4[2] = position;
            dr4[3] = date;
            dt4.Rows.Add(dr4);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
            ad4.Update(dt4);

        }
        private string find_introducer_position(string code)
        {
            string position = "";
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select Position from Member_registration where Member_code='" + code + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            position = dt.Rows[0][0].ToString();

            return position;
        }

        private string find_senior(string code)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn4 = new SqlConnection(connectionstring);
            SqlDataAdapter ad4 = new SqlDataAdapter("Select Sponcer_code from Member_registration where Member_code='" + code + "' ", conn4);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4, "Member_registration");
            DataTable dt4 = ds4.Tables[0];
            int rowcount = dt4.Rows.Count;
            if (rowcount == 0)
            {
                return "";
            }
            else
            {
                return dt4.Rows[0][0].ToString();
            }
        }

        private void send_data_into_Repurchase_tot_left_right_pv(string membercode, string seniorcode, string position, string PV, string date)
        {
            string month = date.Substring(3);
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn4 = new SqlConnection(connectionstring);
            SqlDataAdapter ad4 = new SqlDataAdapter("Select * from Repurchase_tot_left_right_pv where Membercode='" + membercode + "' and Month='" + month + "'", conn4);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4, "Repurchase_tot_left_right_pv");
            DataTable dt4 = ds4.Tables[0];
            int rowcount = dt4.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr4 = dt4.NewRow();
                dr4[1] = membercode;
                dr4[2] = seniorcode;
                dr4[3] = "0";
                dr4[4] = "0";
                dr4[5] = month;
                dr4[6] = date;
                dt4.Rows.Add(dr4);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
                ad4.Update(dt4);
            }
        }

        private void update_tot_senior(string seniorcode, string position, string PV, string date)
        {
            if (seniorcode != "12345678")
            {

                string month = date.Substring(3);
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn4 = new SqlConnection(connectionstring);
                SqlDataAdapter ad4 = new SqlDataAdapter("Select * from Repurchase_tot_left_right_pv where Membercode='" + seniorcode + "' and Month='" + month + "'", conn4);
                DataSet ds4 = new DataSet();
                ad4.Fill(ds4, "Repurchase_tot_left_right_pv");
                DataTable dt4 = ds4.Tables[0];
                int rowcount = dt4.Rows.Count;
                if (rowcount == 0)
                {
                    string senior_of_senior = find_senior(seniorcode);

                    DataRow dr4 = dt4.NewRow();
                    dr4[1] = seniorcode;
                    dr4[2] = senior_of_senior;
                    if (position == "Left")
                    {
                        dr4[3] = PV;
                        dr4[4] = "0";
                    }
                    else if (position == "Right")
                    {
                        dr4[3] = "0";
                        dr4[4] = PV;
                    }
                    dr4[5] = month;
                    dr4[6] = date;
                    dt4.Rows.Add(dr4);
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
                    ad4.Update(dt4);

                    string nextposition = find_introducer_position(seniorcode);
                    update_tot_senior(senior_of_senior, nextposition, PV, date);
                }
                else
                {
                    string nextmembercode = dt4.Rows[0][2].ToString();
                    double leftov = Convert.ToDouble(dt4.Rows[0][3].ToString());
                    double rightov = Convert.ToDouble(dt4.Rows[0][4].ToString());
                    foreach (DataRow dr in dt4.Rows)
                    {
                        if (position == "Left")
                        {
                            dr[3] = leftov + Convert.ToDouble(PV);
                        }
                        else if (position == "Right")
                        {
                            dr[4] = rightov + Convert.ToDouble(PV);
                        }
                        SqlCommandBuilder cb = new SqlCommandBuilder(ad4);
                        ad4.Update(dt4);
                    }

                    if (nextmembercode != "12345678")
                    {
                        string nextposition = find_introducer_position(seniorcode);
                        update_tot_senior(nextmembercode, nextposition, PV, date);
                    }
                }

            }
        }
        #endregion Repurchase_daily_detail


        #region member_ranking_details
        private void send_data_into_member_ranking_details(string member_code)
        {


            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + member_code + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {

                string left_child = dt.Rows[0][3].ToString();
                string right_child = dt.Rows[0][4].ToString();

                double left_vb = 0;
                double right_vb = 0;

                if (left_child != "")
                {
                    left_vb = Otheruses.find_total_business(left_child);
                }
                if (right_child != "")
                {
                    right_vb = Otheruses.find_total_business(right_child);
                }

                double self = Otheruses.find_self_business(member_code);
                double total_pv = self + left_vb + right_vb;


                find_ranking(member_code, total_pv);

            }

        }
        private void find_ranking(string membercode, double TotalBV)
        {



            if (Convert.ToDouble(TotalBV) >= 500000000)
            {
                if (check_ranking(membercode, "Crown Diamond"))
                {
                    send_data_into_member_rank_detail(membercode, "Crown Diamond", TotalBV);
                }
            }
            else if (Convert.ToDouble(TotalBV) >= 6000000 && Convert.ToDouble(TotalBV) < 500000000)
            {
                if (check_ranking(membercode, "Diamond"))
                {
                    send_data_into_member_rank_detail(membercode, "Diamond", TotalBV);
                }
            }
            else if (Convert.ToDouble(TotalBV) >= 700000 && Convert.ToDouble(TotalBV) < 6000000)
            {
                if (check_ranking(membercode, "Platinum Star"))
                {
                    send_data_into_member_rank_detail(membercode, "Platinum Star", TotalBV);
                }
            }
            else if (Convert.ToDouble(TotalBV) >= 150000 && Convert.ToDouble(TotalBV) < 700000)
            {
                if (check_ranking(membercode, "Gold Star"))
                {
                    send_data_into_member_rank_detail(membercode, "Gold Star", TotalBV);
                }
            }
            else { }



        }

        private void send_data_into_member_rank_detail(string membercode, string rank, double TotalBV)
        {
            DateTime date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_rank_detail where Member_code='" + membercode + "'  and Rank='" + rank + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_rank_detail");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = membercode;
                dr[2] = rank;
                dr[3] = date.ToString("dd/MM/yyyy");
                dr[4] = TotalBV.ToString();
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }

        }

        private bool check_ranking(string membercode, string rank)
        {
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select  * from dbo.[Member_rank_detail] where Member_code='" + membercode + "' and Rank='" + rank + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_rank_detail");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion member_ranking_details
        private void send_sms(string member_code)
        {
            string message = "Dear " + lbl_name.Text + " thank you for purchasing product from  Ocean Health Pariwar, with Rs. " + lbl_totalamount.Text + ", your invoice no. is - " + txt_billno.Text + " and your total BV is - " + lbl_totalbv.Text + ".  For more details visit www.oceanhealthpariwar.com";
            Message_sending.SendMsg1(member_code, lbl_mobileno.Text, message);
        }
    }
}