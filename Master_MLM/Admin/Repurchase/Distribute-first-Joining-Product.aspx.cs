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
    public partial class Distribute_first_Joining_Product : System.Web.UI.Page
    {
        bool check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dt.ToString("dd/MM/yyyy");
                txt_date.Text = date;


            }
        }

        #region find data

        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_stock_point_code.Text == "")
                {
                    lbl_message.Text = "Please enter stock point code";
                }
                else
                {
                    lbl_message.Text = "";
                    find_member_details();
                    find_products();

                }
            }
            catch (Exception ex)
            {

            }

        }

        private void find_products()
        {

            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Product_name,Product_code from First_joining_product ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "First_joining_product");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_product.Items.Insert(0, new ListItem("Select", "0"));
            }
            else
            {
                ddl_product.DataTextField = ds.Tables[0].Columns["Product_name"].ToString();
                ddl_product.DataValueField = ds.Tables[0].Columns["Product_code"].ToString();
            }

            ddl_product.DataSource = ds.Tables[0];
            ddl_product.DataBind();
            ddl_product.Items.Insert(0, new ListItem("Select", "0"));
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

                hd_franchise_code.Value = txt_stock_point_code.Text;
                panel_member_details.Visible = true;
                fatch_Distribute_code();

            }
        }

        private void fatch_Distribute_code()
        {
            Distribute_no dn = new Distribute_no();
            txt_distributionno.Text = dn.Distributeno();
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";
            bool isValidNumeric1 = ValidateNumber(txt_sell_quantity.Text);
            try
            {
                if (isValidNumeric1 == false)
                {
                    lbl_message.Text = "Only digit allowed for sell quantity";
                }
                else
                {
                    lbl_message.Text = "";
                    send_data_into_distribute_first_joining_stock();
                }
            }
            catch (Exception exc)
            {
            }

        }

        private void send_data_into_distribute_first_joining_stock()
        { 
            int sellquantity = int.Parse(txt_sell_quantity.Text);

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string idate = dtm.ToString("yyyyMMdd");
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Distribute_first_joining_stock ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Distribute_first_joining_stock");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[1] = hd_franchise_code.Value;
            dr[2] = txt_distributionno.Text;
            dr[3] = ddl_product.Text;
            dr[4] = txt_sell_quantity.Text;
            dr[5] = txt_mrp.Text;
            dr[6] = "SUBMITED";
            dr[7] = date;
            dr[8] = Convert.ToInt32(idate);
            dr[9] = Convert.ToDouble(txt_mrp.Text) * Convert.ToDouble(sellquantity);

            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
            txt_mrp.Text = "";
            txt_sell_quantity.Text = "";

            fill_girid_view();
            

        }

        private void fill_girid_view()
        {

            string Status = "SUBMITED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Distribute_first_joining_stock DF join First_joining_product FD on DF.Product_id=FD.Product_code  where DF.Status='" + Status + "' order by DF.Id asc", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Distribute_first_joining_stock");
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
                double totalamount = 0;
                int gridview_rowcount = gridview.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {

                    Label lbl_totalmrp = (Label)gridview.Rows[i].FindControl("lbl_totalmrp");

                    if (lbl_totalmrp.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_totalmrp.Text);
                    }

                }
                lbl_totalamount.Text = totalamount.ToString();


            }

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
            SqlDataAdapter ad = new SqlDataAdapter("delete from Distribute_first_joining_stock where id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Distribute_first_joining_stock");
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

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                find_products_details();
            }
            catch (Exception ex)
            {

            }

        }

        private void find_products_details()
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select price from First_joining_product where Product_code='" + ddl_product.SelectedValue + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "First_joining_product");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                txt_mrp.Text = dt.Rows[0][0].ToString();
            }
        }

        protected void txt_sell_quantity_TextChanged(object sender, EventArgs e)
        { 
        }


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

                        Label lbl_Productid = (Label)gridview.Rows[i].FindControl("lbl_Productid");
                        Label lbl_Mrp = (Label)gridview.Rows[i].FindControl("lbl_Mrp");

                        Label lbl_Quantity = (Label)gridview.Rows[i].FindControl("lbl_Quantity");
                        Label lbl_totmrp = (Label)gridview.Rows[i].FindControl("lbl_totmrp");



                        update_Re_Franchise_stock_wise_entry(lbl_Productid.Text, lbl_Quantity.Text);
                    }
                    update_distribute_first_joining_stock();
                    check = true;
                    if (check == true)
                    {
                        scope.Complete();
                        string path = "First_joinng_Print_bill_GN.aspx?fran_code=" + txt_stock_point_code.Text + "&billno=" + txt_distributionno.Text;
                        Response.Redirect(path);
                    }

                }
                fill_girid_view();

            }
            catch (Exception exc)
            {
            }

        }

        private void update_Re_Franchise_stock_wise_entry(string Productid, string quantity)
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from First_joining_Franchise_stock_wise_entry where Franchise_code='" + hd_franchise_code.Value + "' and Product_id='" + Productid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = hd_franchise_code.Value;
                dr[2] = Productid;
                dr[3] = quantity;
                dr[4] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {
                int qty = Convert.ToInt32(dt.Rows[0][3].ToString());

                foreach (DataRow dr in dt.Rows)
                {
                    dr[3] = qty + Convert.ToInt32(quantity);
                    dr[4] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }
        private void update_distribute_first_joining_stock()
        {
            string Status = "SUBMITED";
            string added = "ADDED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("update Distribute_first_joining_stock set Status='" + added + "' where Stockpoint_code='" + hd_franchise_code.Value + "' and Status='" + Status + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Distribute_first_joining_stock");
        }

        #endregion
    }
}