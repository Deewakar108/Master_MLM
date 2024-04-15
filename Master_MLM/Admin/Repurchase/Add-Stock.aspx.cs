using Master_MLM.Admin.Repurchase;
using Master_MLM.App_Code;
using Master_MLM.AppCode;
using System;
using System.Collections;
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
    public partial class Add_Stock : System.Web.UI.Page
    {
        #region PageloaD
        Connection con = new Connection();
        My mycod = new My();
        bool check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    string date = dt.ToString("dd/MM/yyyy");
                    txt_date.Text = date;
                    fatch_enteryno();
                    fetch_product();
                    fill_girid_view();
                }
                catch (Exception exc)
                {

                }
            }
        }

        private void fill_girid_view()
        {
            string Status = "SUBMITED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(" select * from Re_admin_product_wise_enter RAP join Product_Details PD on RAP.Product_id=PD.Product_id  where RAP.Status='" + Status + "' order by RAP.Id asc", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_product_wise_enter");
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
                double totalmrp = 0;
                int gridview_rowcount = gridview.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_totBV");
                    Label lbl_totmrp = (Label)gridview.Rows[i].FindControl("lbl_tot_mrp");
                    if (lbl_BV.Text != "")
                    {
                        totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
                    }
                    if (lbl_totmrp.Text != "")
                    {
                        totalmrp = totalmrp + Convert.ToDouble(lbl_totmrp.Text);
                    }

                }
                lbl_totalmrp.Text = totalmrp.ToString();
                lbl_totalbv.Text = totalbv.ToString();

            }
        }

        private void fatch_enteryno()
        {
            enteryno en = new enteryno();
            txt_enteryno.Text = en.entery_no();
        }

        private void fetch_product()
        {
            mycod.bind_all_ddl_with_id_ltst(ddl_product_name, "Select Product_name,Product_id from  Product_Details order by Product_name");

        }
        #endregion

        #region FetchproductdetailS
        protected void ddl_product_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fetch_product_details();
            }
            catch (Exception ex)
            {
            }
        }

        private void fetch_product_details()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select Mrp,Bv,Unit,Gst_perc,Gst_amt,Net_Mrp from Product_Details where Product_id='" + ddl_product_name.SelectedValue + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                txt_mrp.Text = dt.Rows[0]["Mrp"].ToString();
                txt_bv.Text = dt.Rows[0]["Bv"].ToString();
                txt_unit.Text = dt.Rows[0]["Unit"].ToString();
                txt_gst_perc.Text = dt.Rows[0]["Gst_perc"].ToString();
                txt_gst_value.Text = dt.Rows[0]["Gst_amt"].ToString();
                txt_net_mrp.Text = dt.Rows[0]["Net_Mrp"].ToString();
            }
        }
        #endregion

        #region BtnaddstocK
        protected void btn_add_stock_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product_name.SelectedItem.Text == "Select")
                {
                    lblmessage.Text = "Please select product name";
                }
                else if (txt_quantity.Text == "0")
                {
                    lblmessage.Text = "Please enter quantity value";
                }
                else if (txt_quantity.Text == "00")
                {
                    lblmessage.Text = "Please enter quantity value";
                }
                else
                {
                    lblmessage.Text = "";
                    send_data();
                }
            }

            catch (Exception ex)
            {
            }
        }

        private void send_data()
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string idate = dtm.ToString("yyyyMMdd");
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_admin_product_wise_enter ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_product_wise_enter");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["Entry_no"] = txt_enteryno.Text;
            dr["Product_id"] = ddl_product_name.SelectedValue;
            dr["Mrp"] = txt_mrp.Text;
            dr["Bv"] = txt_bv.Text;
            dr["Unit"] = txt_unit.Text;
            dr["Gst_perc"] = txt_gst_perc.Text;
            dr["Gst_amt"] = txt_gst_value.Text;
            dr["Net_Mrp"] = txt_net_mrp.Text;
            dr["Quantity"] = txt_quantity.Text;
            dr["Date"] = date;
            dr["idate"] = Convert.ToInt32(idate);
            dr["Status"] = "SUBMITED";
            Double tot_mrp = Convert.ToDouble(txt_mrp.Text) * Convert.ToDouble(txt_quantity.Text);
            dr["Total_Mrp"] = tot_mrp;
            Double tot_gst_amt = (tot_mrp * Convert.ToDouble(txt_gst_perc.Text) / 100);
            dr["Total_gst_amt"] = tot_gst_amt;
            dr["Total_net_mrp"] = tot_mrp - tot_gst_amt;
            dr["Total_Bv"] = Convert.ToDouble(txt_bv.Text) * Convert.ToDouble(txt_quantity.Text);

            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);

            txt_quantity.Text = "";
            txt_mrp.Text = "";
            txt_unit.Text = "";
            txt_bv.Text = "";
            txt_gst_perc.Text = "";
            txt_gst_value.Text = "";
            txt_net_mrp.Text = "";
            fill_girid_view();
        }

        #endregion

        #region Delete
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;

            delete_news(id);
            fill_girid_view();
        }

        private void delete_news(string id)
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_admin_product_wise_enter where Id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_product_wise_enter");
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
                lblmessage.Text = "Deletion process has been completed.";
            }
        }
        #endregion

        #region final submit
        ClassException ce = new ClassException();
        protected void btn_final_submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)))
                {
                    int rcount = gridview.Rows.Count;
                    for (int i = 0; i < rcount; i++)
                    {
                        Label lbl_Product_id = (Label)gridview.Rows[i].FindControl("lbl_Product_id");
                        Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_BV");
                        Label lbl_Quantity = (Label)gridview.Rows[i].FindControl("lbl_Quantity");
                        Label lbl_Mrp = (Label)gridview.Rows[i].FindControl("lbl_Mrp");

                        string mrp = lbl_Mrp.Text;
                        string Productid = lbl_Product_id.Text;
                        string BV = lbl_BV.Text;
                        string Quantity = lbl_Quantity.Text;
                        update_Repurchase_stock_wise_entry(Productid, BV, Quantity, mrp);
                    }
                    update_Repurchase_product_wise_entry();
                    check = true;
                    if (check == true)
                    {
                        scope.Complete();

                        lblmessage.Text = "Stock successfully added";
                    }
                }
                fill_girid_view();
            }
            catch (Exception ex)
            {

                ce.submit_exception(ex.ToString());
            }
        }

        private void update_Repurchase_stock_wise_entry(string Productid, string BV, string Quantity, string mrp)
        {
            int qty = 0;
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_admin_stock_wise_entry where Product_id='" + Productid + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Product_id"] = Productid;
                dr["Mrp"] = mrp;
                dr["Quantity"] = Quantity;
                dr["Bv"] = BV;
                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
            else
            {
                int quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Quantity"] = quantity + Convert.ToInt32(Quantity);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }
        private void update_Repurchase_product_wise_entry()
        {
            string Status = "SUBMITED";
            string added = "ADDED";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("update Re_admin_product_wise_enter set Status='" + added + "' where Status='" + Status + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_admin_product_wise_enter");
        }
        #endregion
    }
}