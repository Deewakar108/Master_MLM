using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Repurchase
{
    public partial class View_Product : System.Web.UI.Page
    {
        #region PageloaD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    load_products();
                    fetch_unit();
                    fetch_gst();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void load_products()
        {
            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Product_Details order by id DESC ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Details");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_manage_request.Visible = false;
                grd_product.DataSource = null;
                grd_product.DataBind();
                lbl_message.Text = "Sorry, Product does not exist.";
            }
            else
            {

                pnl_manage_request.Visible = true; ;
                lbl_message.Text = "";
                ad.Fill(ds);
                grd_product.DataSource = ds;
                grd_product.DataBind();
            }
        }
        private void fetch_gst()
        {
            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select distinct Gst from Gst_Master ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "state_and_district");
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("0");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ddl_gst_perc.DataSource = ar;
            ddl_gst_perc.DataBind();
        }

        private void fetch_unit()
        {
            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select distinct Unit from Unit_Master order by Unit asc", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "state_and_district");
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ddl_unit.DataSource = ar;
            ddl_unit.DataBind();
        }

        protected void grd_product_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_product.PageIndex = e.NewPageIndex;
            load_products();
            grd_product.DataBind();
        }
        #endregion

        #region EdiTupdatE
        protected void grd_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnl_product_list.Visible = false;
            pnl_edit_product.Visible = true;
            lbl_message.Text = "";
            GridViewRow row = grd_product.SelectedRow;
            Label lblid = ((Label)(row.FindControl("lbl_id")));
            hd_id.Value = lblid.Text;
            txt_Prduct_name.Text = ((Label)row.FindControl("lbl_Product_name")).Text;
            txt_mrp.Text = ((Label)row.FindControl("lbl_Mrp")).Text;
            txt_bv.Text = ((Label)row.FindControl("lbl_Bv")).Text;
            ddl_unit.Text = ((Label)row.FindControl("lbl_Unit")).Text;
            ddl_gst_perc.Text = ((Label)row.FindControl("lbl_gst_perc")).Text;
            txt_gst_value.Text = ((Label)row.FindControl("lbl_gst_amount")).Text;
            txt_net_mrp.Text = ((Label)row.FindControl("lbl_Net_Mrp")).Text;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                update_data();
            }
            catch (Exception exc)
            {
            }
        }

        private void update_data()
        {
            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Product_Details where Id='" + hd_id.Value + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Details");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Product_name"] = txt_Prduct_name.Text;
                    dr["Mrp"] = txt_mrp.Text;
                    dr["Bv"] = txt_bv.Text;
                    dr["Unit"] = ddl_unit.SelectedItem.Text;
                    dr["Gst_perc"] = ddl_gst_perc.SelectedItem.Text;
                    dr["Gst_amt"] = txt_gst_value.Text;
                    dr["Net_Mrp"] = txt_net_mrp.Text;
                    SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    load_products();
                    lbl_message.Text = "Product is edited successfully.";
                    txt_Prduct_name.Text = "";
                    txt_mrp.Text = "";
                    txt_bv.Text = "";
                    txt_gst_value.Text = "";
                    txt_net_mrp.Text = "";
                    pnl_product_list.Visible = true;
                    pnl_edit_product.Visible = false;
                }

            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_Prduct_name.Text = "";
            txt_mrp.Text = "";
            txt_bv.Text = "";
            txt_gst_value.Text = "";
            txt_net_mrp.Text = "";
            pnl_product_list.Visible = true;
            pnl_edit_product.Visible = false;
        }
        #endregion 

        #region Delete
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;

            delete_class(id);
            load_products();
        }

        private void delete_class(string id)
        {
            Connection con = new Connection();
            string full_path = con.connect_method();
            SqlConnection conn = new SqlConnection(full_path);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Product_Details where Id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Details");
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
                lbl_message.Text = "Deletion process has been completed.";
            }
        }
        #endregion
    }
}