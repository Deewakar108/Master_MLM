﻿using Master_MLM.App_Code;
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
    public partial class Distribute_Stock : System.Web.UI.Page
    {
        bool check = false;
        #region PAGELOAD
        My mycod = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dt.ToString("dd/MM/yyyy");
                txt_date.Text = date;
                fetch_category_name();
                fill_girid_view();
            }

        }

        private void fetch_category_name()
        {
            mycod.bind_all_ddl_with_id_ltst(ddl_product, "Select Product_name,Product_id from  Product_Details order by Product_name");
        }

        private void fill_girid_view()
        { 
            string Status = "SUBMITED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Product_wise_sell_entery RP join Product_Details PD on RP.Product_id=PD.Product_id where RP.Status='" + Status + "'", conn); 
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
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

                int i;
                int totalbv = 0;
                double totalamount = 0;
                int gridview_rowcount = gridview.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_Tot_bv");
                    Label lbl_Mrp = (Label)gridview.Rows[i].FindControl("lbl_totmrp");
                    if (lbl_BV.Text != "")
                    {
                        totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
                    }
                    if (lbl_Mrp.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_Mrp.Text);
                    }
                }
                lbl_totalamount.Text = totalamount.ToString();
                lbl_totalbv.Text = totalbv.ToString();

            }

        }

        private void fatch_Distribute_code()
        {
            Distribute_no dn = new Distribute_no();
            txt_distributionno.Text = dn.Distributeno();
        }
        #endregion pageload

        #region find data

        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_stock_point_code.Text == "")
            {
                lbl_message.Text = "Please enter stock point code";
            }
            else
            {
                lbl_message.Text = "";
                find_member_details();
            }

        }

        private void find_member_details()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where Stock_point_code ='" + txt_stock_point_code.Text + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "Stock point code doesn't exist";
                panel_member_details.Visible = false;
                panel_view.Visible = false;

            }
            else
            {
                lbl_message.Text = "";
                lbl_membername.Text = dt.Rows[0][2].ToString();
                lbl_city.Text = dt.Rows[0][3].ToString();
                lbl_mobileno.Text = dt.Rows[0][5].ToString();
                lbl_level.Text = dt.Rows[0][11].ToString();

               // find_commission_percentage();

                HiddenField1.Value = txt_stock_point_code.Text;
                panel_member_details.Visible = true;
                fatch_Distribute_code();

            }
        }

        private void find_commission_percentage()
        {

            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Franchise_level where Level ='" + lbl_level.Text + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Franchise_level");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                HiddenField2.Value = "0";
            }
            else
            {
                HiddenField2.Value = dt.Rows[0][2].ToString();
            }
        }
        #endregion

        #region page event
        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.Text == "Select")
                {
                    lbl_message.Text = "Please select product name";
                }
                else
                {
                    find_products_details();
                }
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());
            }

        }

        private void find_products_details()
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Mrp,Bv,Quantity from Re_admin_stock_wise_entry where Product_id='" + ddl_product.SelectedValue + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                txt_bv.Text = dt.Rows[0]["Bv"].ToString();
                txt_mrp.Text = dt.Rows[0]["Mrp"].ToString();
                txt_quantity.Text = dt.Rows[0]["Quantity"].ToString(); 
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
                    lbl_message.Text = "";
                    int quantity = int.Parse(txt_quantity.Text);
                    int sellquantity = int.Parse(txt_sell_quantity.Text);
                    if (quantity >= sellquantity)
                    {

                    }
                    else
                    {
                        lbl_message.Text = "Sorry! sell quantity is greater than available quantity";
                    }
                }
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());
            }
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.Text == "Select")
                {
                    lbl_message.Text = "Please select Product";
                }
                else
                {
                    lbl_message.Text = "";
                    bool isValidNumeric1 = ValidateNumber(txt_sell_quantity.Text);

                    if (isValidNumeric1 == false)
                    {
                        lbl_message.Text = "Only digit allowed for sell quantity";
                    }
                    else
                    {
                        lbl_message.Text = "";
                        send_data_into_Re_Product_wise_sell_entery();
                    }

                }
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());
            }
        }

        private void send_data_into_Re_Product_wise_sell_entery()
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
                SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Product_wise_sell_entery ", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Re_Product_wise_sell_entery");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["Stockpoint_code"] = HiddenField1.Value;
                dr["Distribution"] = txt_distributionno.Text;
                dr["Product_id"] = ddl_product.Text;
                dr["Mrp"] = txt_mrp.Text;
                dr["BV"] = txt_bv.Text;
                dr["Quantity"] = txt_sell_quantity.Text;
                dr["Date"] = date;
                dr["Idate"] = Convert.ToInt32(idate);
                dr["Status"] = "SUBMITED";
                Double tot_mrp = Convert.ToDouble(txt_mrp.Text) * Convert.ToDouble(txt_sell_quantity.Text);
                dr["Tot_mrp"] = tot_mrp;
                dr["Tot_bv"] = Convert.ToDouble(txt_bv.Text) * Convert.ToDouble(txt_sell_quantity.Text);
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
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
            SqlDataAdapter ad = new SqlDataAdapter("delete from Re_Product_wise_sell_entery where id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
        }

        ClassException ce = new ClassException();




        #region final submit
        protected void btn_final_submit_Click(object sender, EventArgs e)
        {

            try
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)))
                {
                    lbl_message.Text = "";
                    int rcount = gridview.Rows.Count;
                    for (int i = 0; i < rcount; i++)
                    {
                        Label lbl_product_id = (Label)gridview.Rows[i].FindControl("lbl_Productnameid");
                        Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_BV");
                        Label lbl_Quantity = (Label)gridview.Rows[i].FindControl("lbl_Quantity");
                        Label lbl_Stockpoint_code = (Label)gridview.Rows[i].FindControl("lbl_Stockpoint_code");
                        Label lbl_Mrp = (Label)gridview.Rows[i].FindControl("lbl_Mrp");
                        

                        Label lbl_totmrp = (Label)gridview.Rows[i].FindControl("lbl_totmrp");
                        Label lbl_Tot_bv = (Label)gridview.Rows[i].FindControl("lbl_Tot_bv");


                        string Productid = lbl_product_id.Text;
                        string BV = lbl_BV.Text;
                        string Quantity = lbl_Quantity.Text;
                        string Stockpoint_code = lbl_Stockpoint_code.Text;
                        string mrp = lbl_Mrp.Text;

                        string tot_mrp = lbl_totmrp.Text;
                        string tot_bv = lbl_Tot_bv.Text;


                        update_Re_Franchise_stock_wise_entry(Productid, BV, Quantity, Stockpoint_code, mrp, tot_mrp, tot_bv);
                        update_Repurchase_stock_wise_entry(Productid, BV, Quantity);
                    }
                    update_Re_Product_wise_sell_entery();


                   // franchise_commission_data();

                    check = true;
                    if (check == true)
                    {
                        scope.Complete();
                        string path = "Print_bill_GN.aspx?fran_code=" + txt_stock_point_code.Text + "&billno=" + txt_distributionno.Text;
                        Response.Redirect(path);
                    }

                }

                //fill_girid_view();


            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

            }
        }

      
           
         

        private void franchise_commission_data()
        {
            string franchise_code = HiddenField1.Value;
            string disrtibution_no = txt_distributionno.Text;
            string franchise_level = lbl_level.Text;
            double percentage = Convert.ToDouble(HiddenField2.Value);

            double dpamount = Convert.ToDouble(lbl_totalamount.Text);
            double commisison_amount;
            commisison_amount = dpamount * percentage / 100;
            double Cdf;
            Cdf = commisison_amount * 5 / 100;
            double Tds = commisison_amount * 10 / 100;
            double total_amount;
            total_amount = commisison_amount - (Tds + Cdf);


            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from franchise_commission ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "franchise_commission");
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.NewRow();
            dr[1] = disrtibution_no;
            dr[2] = franchise_code;
            dr[3] = franchise_level;
            dr[4] = percentage.ToString();
            dr[5] = dpamount.ToString();
            dr[6] = commisison_amount.ToString();
            dr[7] = Tds.ToString();
            dr[8] = Cdf.ToString();
            dr[9] = total_amount.ToString();
            dr[10] = Convert.ToInt32(dtm.ToString("yyyyMMdd"));
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);


        }

        private void update_Re_Franchise_stock_wise_entry(string Productid, string BV, string Quantity, string Stockpoint_code, string mrp, string tot_mrp, string tot_bv)
        {
            double qty = 0;
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_stock_wise_entry where  Product_id='" + Productid + "' and  Stockpoint_code='" + Stockpoint_code + "'  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Product_id"] = Productid;
                dr["BV"] = BV;
                dr["Quantity"] = Quantity;
                dr["Stockpoint_code"] = Stockpoint_code;
                dr["Mrp"] = mrp;
                dr["Tot_mrp"] = tot_mrp;
                dr["Tot_bv"] = tot_bv; 
                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {
                int quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());

                foreach (DataRow dr in dt.Rows)
                {
                    qty = quantity + Convert.ToDouble(Quantity);
                    dr["Quantity"] = qty;
                    dr["Tot_mrp"] = qty * Convert.ToDouble(mrp);
                    dr["Tot_bv"] = qty * Convert.ToDouble(BV); 
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }
        private void update_Repurchase_stock_wise_entry(string Productid, string BV, string Quantity)
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_admin_stock_wise_entry where  Product_id='" + Productid + "' and Bv='" + BV + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                int quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Quantity"] = quantity - Convert.ToInt32(Quantity);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }

        private void update_Re_Product_wise_sell_entery()
        {
            string Status = "SUBMITED";
            string added = "ADDED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("update Re_Product_wise_sell_entery set Status='" + added + "' where Stockpoint_code='" + HiddenField1.Value + "' and Status='" + Status + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
        }

        #endregion
    }
}