using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Master_MLM
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        #region repurchase_products
        public class Fetch_repurchase_products
        {
            public string Product_name { get; set; }
            public string Mrp { get; set; }
            public string Bv { get; set; }
            public string Unit { get; set; }
        }


        List<Fetch_repurchase_products> products = new List<Fetch_repurchase_products>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_rep_products_details()
        {
            string query = "Select * from Product_Details order by Product_name asc";
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Details");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    products.Add(new Fetch_repurchase_products
                    {
                        Product_name = dr["Product_name"].ToString(),
                        Mrp = dr["Mrp"].ToString(),
                        Bv = dr["Bv"].ToString(),
                        Unit = dr["Unit"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(products));
            }

        }
        #endregion repurchase_products


        #region ProductS
        //------------------------------Product--------------------------------------


        public class Fetch_Details_of_Products
        {

            public string Product_name { get; set; }
            public string Mrp { get; set; }
            public string Packing { get; set; }
            public string DP { get; set; }
            public string BV { get; set; }
            public string Image_path { get; set; }
        }


        List<Fetch_Details_of_Products> Show_of_products_details = new List<Fetch_Details_of_Products>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_product_details()
        {
            string query = "Select * from Add_product order by Id DESC";
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Add_product");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_products_details.Add(new Fetch_Details_of_Products
                    {
                        Product_name = dr["Product_name"].ToString(),
                        Mrp = dr["Mrp"].ToString(),
                        Packing = dr["Packing"].ToString(),
                        DP = dr["DP"].ToString(),
                        BV = dr["BV"].ToString(),
                        Image_path = dr["Image_path"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_products_details));
            }

        }
        #endregion

    }
}
