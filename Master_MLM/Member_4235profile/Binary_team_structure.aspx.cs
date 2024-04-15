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
using System.Collections.Generic;
using System.Data.SqlClient;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Binary_team_structure : System.Web.UI.Page
    {
        string gender = "";
        int countMemberForMakingID = 0;
        Important imp = new Important();
        string queryString = "";

        string topMemberImage = "images/gr.jpg";
        string PaidMemberImage = "images/gr.jpg";
        string FreeMemberImage = "images/r.jpg";

        string divID = "";
        string LeftRightBV = "Left PV : 0  &nbsp;&nbsp;&nbsp; Right PV : 0";
        string PurchaseDate = "";
        string Package = "";
        string SponsorName = "";
        string AdminCode = "BMHP1234";
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCode = imp.AdminCode;
            if (Request.QueryString["q"] != null) 
            {
                queryString = Request.QueryString["q"].ToString();
            }
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
                if (!IsPostBack)
                {
                    try
                    {
                        if (!IsPostBack)
                        {
                            DataTable dtdatas = new DataTable();
                            dtdatas.Columns.Add("Membercode", typeof(string));
                            dtdatas.Columns.Add("id", typeof(Int32));
                            ViewState["dtdatas"] = dtdatas;
                        }

                        string codenumber = Session["membercode"].ToString();
                        //find_Binary_series(codenumber);
                        //find_legdetails(codenumber);

                        //ShowUnlimitedMemberTree();        //Blocked on 02/11/2017
                        ShowNewBinaryTree(codenumber);      //Blocked on 30/10/2017
                        //RewardPoints r = imp.getRewardPoints(codenumber);
                        //lbl_leftpv.Text = r.LeftRP;
                        //lbl_rightpv.Text = r.RightRP;

                    }
                    catch (Exception ex)
                    {
                        My.submitException(ex);
                    }
                }
            }
        }

        My mycode = new My();
        #region Previous Code

        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                bool chkmobile = mycode.valid_number(txt_memberid.Text);
                if (chkmobile == false)
                {
                    lbl_msg.Text = "Please enter valid member code";
                }
                else
                {
                    string membercode = txt_memberid.Text;

                    bool chkmembercode = mycode.valid_number(txt_memberid.Text);
                    if (chkmembercode == false)
                    {
                        lbl_msg.Text = "Please enter valid member code";
                        panel_view_tree.Visible = false;
                    }
                    else
                    {
                        lbl_msg.Text = "";
                        find_Binary_series(membercode);
                        find_legdetails(membercode);

                        lbl_leftpv.Text = find_left_pv(membercode);
                        lbl_rightpv.Text = find_right_pv(membercode);

                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
        #region leg_details
        private void find_legdetails(string codenumber)
        {
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + codenumber + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {


            }
            else
            {
                panel_view_tree.Visible = true;
                string left_child = dt.Rows[0][3].ToString();
                string right_child = dt.Rows[0][4].ToString();

                if (left_child != "")
                {
                    al.Add(left_child);
                }
                if (right_child != "")
                {
                    a2.Add(right_child);
                }

                bind_left_child(al);
                bind_right_child(a2);
            }
        }
        #region Left Child
        private void bind_left_child(ArrayList al)
        {
            string membercode = "";
            double points = 0.0;
            int redchild = 0;
            int bluechild = 0;
            int greenchild = 0;

            for (int i = 0; i < al.Count; i++)
            {
                membercode = al[i].ToString();
                string left_child1 = find_the_left_child(membercode);
                string right_child1 = find_the_right_child(membercode);

                if (left_child1 != "")
                {
                    al.Add(left_child1);
                }

                if (right_child1 != "")
                {
                    al.Add(right_child1);
                }
                Connection con = new Connection();
                string connect = con.connect_method();
                SqlConnection conn = new SqlConnection(connect);
                SqlDataAdapter ad1 = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + al[i].ToString() + "'", conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Member_registration");
                DataTable dt1 = ds1.Tables[0];
                int rowcount1 = ds1.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {
                }
                else
                {
                    //points = points + Convert.ToDouble(dt1.Rows[0][37].ToString());
                    if (dt1.Rows[0][41].ToString() == "FREE")
                    {
                        redchild = redchild + 1;
                    }
                    else if (dt1.Rows[0][41].ToString() == "PAID")
                    {
                        greenchild = greenchild + 1;
                    }

                }

            }
            //lbl_leftpoint.Text = points.ToString();
            lbl_leftred.Text = redchild.ToString();
            // lbl_leftblue.Text = bluechild.ToString();
            lbl_leftgreen.Text = greenchild.ToString();


        }

        private string find_the_right_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                toreturn = dt.Rows[0][4].ToString();
            }

            return toreturn;
        }
        private string find_the_left_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                toreturn = dt.Rows[0][3].ToString();
            }

            return toreturn;
        }

        #endregion Left Child
        #region Right Child
        private void bind_right_child(ArrayList a2)
        {
            string membercode = "";
            double points = 0.0;
            int redchild = 0;
            int bluechild = 0;
            int greenchild = 0;

            for (int i = 0; i < a2.Count; i++)
            {
                membercode = a2[i].ToString();
                string left_child1 = find_the_left_child(membercode);
                string right_child1 = find_the_right_child(membercode);

                if (left_child1 != "")
                {
                    a2.Add(left_child1);
                }

                if (right_child1 != "")
                {
                    a2.Add(right_child1);
                }
                Connection con = new Connection();
                string connect = con.connect_method();
                SqlConnection conn = new SqlConnection(connect);
                SqlDataAdapter ad1 = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + a2[i].ToString() + "'", conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Member_registration");
                DataTable dt1 = ds1.Tables[0];
                int rowcount1 = ds1.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {
                }
                else
                {

                    if (dt1.Rows[0][41].ToString() == "FREE")
                    {
                        redchild = redchild + 1;
                    }
                    else if (dt1.Rows[0][41].ToString() == "PAID")
                    {
                        greenchild = greenchild + 1;
                    }
                }

            }


            //lbl_rightpoint.Text = points.ToString();
            lbl_rightred.Text = redchild.ToString();
            // lbl_rightblue.Text = bluechild.ToString();
            lbl_rightgreen.Text = greenchild.ToString();


        }

        #endregion Right Child
        #endregion leg_details
        #region find button click


        private void find_introducer(string membercode)
        {
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 1)
            {
                lbl_msg.Text = "";
                string sponsorcode = dt.Rows[0][1].ToString();
                if (sponsorcode == imp.AdminCode)
                {
                    lbl_msg.Text = "Please enter valid member code";
                }
                else
                {
                    if (Session["membercode"].ToString() != sponsorcode)
                    {
                        find_introducer(sponsorcode);
                    }
                    else
                    {

                        string codenumber = txt_memberid.Text;
                        find_Binary_series(codenumber);
                        find_legdetails(codenumber);
                    }
                }
            }
            else
            {
                lbl_msg.Text = "Please enter valid member code";
            }
        }
        #endregion find button click
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DataTable dt_add = (DataTable)ViewState["dtdatas"];
            DataRow drNewRow = dt_add.NewRow();
            drNewRow["Membercode"] = LinkButton1.CommandArgument;// LinkButton1.Text;

            //add this new row to the Datatable and commit changes
            dt_add.Rows.Add(drNewRow);
            dt_add.AcceptChanges();
            ViewState["dtdatas"] = dt_add;

            bind_temp_table();

            //string codenumber = Button2.Text;
            string codenumber = LinkButton2.CommandArgument;//LinkButton2.Text;
            find_Binary_series(codenumber);
            find_legdetails(codenumber);
        }
        private void bind_temp_table()
        {
            grdmemberlist.DataSource = ViewState["dtdatas"];
            grdmemberlist.DataBind();

        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            DataTable dt_add = (DataTable)ViewState["dtdatas"];
            DataRow drNewRow = dt_add.NewRow();
            drNewRow["Membercode"] = LinkButton1.CommandArgument;//LinkButton1.Text;
            //add this new row to the Datatable and commit changes
            dt_add.Rows.Add(drNewRow);
            dt_add.AcceptChanges();
            ViewState["dtdatas"] = dt_add;
            bind_temp_table();
            //string codenumber = Button3.Text;
            string codenumber = LinkButton3.CommandArgument;//LinkButton3.Text;
            find_Binary_series(codenumber);
            find_legdetails(codenumber);
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            DataTable dt_add = (DataTable)ViewState["dtdatas"];
            DataRow drNewRow = dt_add.NewRow();
            drNewRow["Membercode"] = LinkButton1.CommandArgument;//LinkButton1.Text;
            //add this new row to the Datatable and commit changes
            dt_add.Rows.Add(drNewRow);
            dt_add.AcceptChanges();
            ViewState["dtdatas"] = dt_add;

            bind_temp_table();

            //string codenumber = Button4.Text;
            string codenumber = LinkButton4.CommandArgument;//LinkButton4.Text;
            find_Binary_series(codenumber);
            find_legdetails(codenumber);
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            DataTable dt_add = (DataTable)ViewState["dtdatas"];
            DataRow drNewRow = dt_add.NewRow();
            drNewRow["Membercode"] = LinkButton1.CommandArgument;//LinkButton1.Text;
            //add this new row to the Datatable and commit changes
            dt_add.Rows.Add(drNewRow);
            dt_add.AcceptChanges();
            ViewState["dtdatas"] = dt_add;

            bind_temp_table();

            //string codenumber = Button5.Text;
            string codenumber = LinkButton5.CommandArgument;//LinkButton5.Text;
            find_Binary_series(codenumber);
            find_legdetails(codenumber);
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            DataTable dt_add = (DataTable)ViewState["dtdatas"];
            DataRow drNewRow = dt_add.NewRow();
            drNewRow["Membercode"] = LinkButton1.CommandArgument;//LinkButton1.Text;
            //add this new row to the Datatable and commit changes
            dt_add.Rows.Add(drNewRow);
            dt_add.AcceptChanges();
            ViewState["dtdatas"] = dt_add;

            bind_temp_table();

            //string codenumber = Button6.Text;
            string codenumber = LinkButton6.CommandArgument;//LinkButton6.Text;
            find_Binary_series(codenumber);
            find_legdetails(codenumber);
        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            DataTable dt_add = (DataTable)ViewState["dtdatas"];
            DataRow drNewRow = dt_add.NewRow();
            drNewRow["Membercode"] = LinkButton1.CommandArgument;//LinkButton1.Text;
            //add this new row to the Datatable and commit changes
            dt_add.Rows.Add(drNewRow);
            dt_add.AcceptChanges();
            ViewState["dtdatas"] = dt_add;

            bind_temp_table();

            //string codenumber = Button7.Text;
            string codenumber = LinkButton7.CommandArgument;//LinkButton7.Text;
            find_Binary_series(codenumber);
            find_legdetails(codenumber);
        }

        private void find_Binary_series(string codenumber)
        {
            find_left_right_pv(codenumber);
            string childcode;
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from binary_status where member_code ='" + codenumber + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 1)
            {

                lbl_msg.Text = "";


                if (check_paid_or_not(codenumber, "FREE"))
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    LinkButton1.ForeColor = System.Drawing.Color.Red;
                    Image1.ImageUrl = "../../images/red_image.png";
                }
                else
                {
                    if (checkposition(codenumber, "PAID"))
                    {
                        Label1.ForeColor = System.Drawing.Color.Green;
                        LinkButton1.ForeColor = System.Drawing.Color.Green;
                        Image1.ImageUrl = "../../images/green_image.png";
                    }

                }
                Label1.Text = ds.Tables[0].Rows[0][0].ToString();
                //Button1.Text = codenumber;
                //Button1.Enabled = false;
                LinkButton1.Text = My.hide_string(codenumber);//codenumber;
                LinkButton1.CommandArgument = codenumber;
                LinkButton1.Attributes.Add("cmdname", codenumber);

                if (ds.Tables[0].Rows[0][3].ToString() == "")
                {
                    Label2.ForeColor = System.Drawing.Color.Green;
                    LinkButton2.ForeColor = System.Drawing.Color.Green;

                    Image2.ImageUrl = "../../images/binary_empty.png";
                    Label2.Text = "Vacant";
                    LinkButton2.Text = "Add Team Here";

                    img_back1.Visible = false;
                    Image4.Visible = false;
                    Image5.Visible = false;
                    LinkButton4.Visible = false;
                    Label4.Visible = false;
                    LinkButton5.Visible = false;
                    Label5.Visible = false;
                    LinkButton2.Enabled = false;

                    Label2.ForeColor = System.Drawing.Color.Black;
                    LinkButton2.ForeColor = System.Drawing.Color.Black;
                    LinkButton2.Enabled = false;
                }
                else
                {
                    LinkButton2.Enabled = true;
                    childcode = ds.Tables[0].Rows[0][3].ToString();

                    if (check_paid_or_not(childcode, "FREE"))
                    {
                        Label2.ForeColor = System.Drawing.Color.Red;
                        LinkButton2.ForeColor = System.Drawing.Color.Red;
                        Image2.ImageUrl = "../../images/red_image.png";

                    }
                    else
                    {
                        if (checkposition(childcode, "PAID"))
                        {
                            Label2.ForeColor = System.Drawing.Color.Green;
                            LinkButton2.ForeColor = System.Drawing.Color.Green;
                            Image2.ImageUrl = "../../images/green_image.png";
                        }
                    }
                    Label2.Text = find_child_name(childcode);

                    LinkButton2.Text = My.hide_string(childcode);//codenumber;
                    LinkButton2.CommandArgument = childcode;
                    LinkButton2.Attributes.Add("cmdname", childcode);

                    find_second_level_left_node(childcode);
                }


                if (ds.Tables[0].Rows[0][4].ToString() == "")
                {
                    Image3.ImageUrl = "../../images/binary_empty.png";
                    Label3.Text = "Vacant";
                    LinkButton3.Text = "Add Team Here";
                    img_back2.Visible = false;
                    Image6.Visible = false;
                    Image7.Visible = false;
                    LinkButton6.Visible = false;
                    Label6.Visible = false;
                    LinkButton7.Visible = false;
                    Label7.Visible = false;
                    LinkButton3.Enabled = false;

                    Label3.ForeColor = System.Drawing.Color.Black;
                    LinkButton3.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    LinkButton3.Enabled = true;
                    childcode = ds.Tables[0].Rows[0][4].ToString();


                    if (check_paid_or_not(childcode, "FREE"))
                    {
                        Label3.ForeColor = System.Drawing.Color.Red;
                        LinkButton3.ForeColor = System.Drawing.Color.Red;
                        Image3.ImageUrl = "../../images/red_image.png";

                    }
                    else
                    {
                        if (checkposition(childcode, "PAID"))
                        {
                            Label3.ForeColor = System.Drawing.Color.Green;
                            LinkButton3.ForeColor = System.Drawing.Color.Green;
                            Image3.ImageUrl = "../../images/green_image.png";
                        }

                    }
                    Label3.Text = find_child_name(childcode);
                    //LinkButton3.Text = childcode;
                    LinkButton3.Text = My.hide_string(childcode);//codenumber;
                    LinkButton3.CommandArgument = childcode;
                    LinkButton3.Attributes.Add("cmdname", childcode);
                    find_second_level_right_node(childcode);
                }
            }
            else
            {
                lbl_msg.Text = "You entered wrong member code";

            }
        }

        private void find_left_right_pv(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select LeftPV, Right_PV from Member_PV_Details where Membercode ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_PV_Details");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                lbl_leftpv.Text = dt.Rows[0][0].ToString();
                lbl_rightpv.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                lbl_leftpv.Text = "0";
                lbl_rightpv.Text = "0";
            }
        }
        private bool check_paid_or_not(string codenumber, string pay_status)
        {

            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + codenumber + "' and Paidstatus='" + pay_status + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkposition(string codenumber, string Paidstatus)
        {

            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + codenumber + "' and Paidstatus='" + Paidstatus + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string find_gender(string codenumber)
        {
            string type = "";
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + codenumber + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 1)
            {
                type = ds.Tables[0].Rows[0][13].ToString();
            }
            return type;
        }
        private void find_second_level_right_node(string childcode)
        {
            string second_childcode;
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from binary_status where member_code ='" + childcode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 1)
            {
                if (ds.Tables[0].Rows[0][3].ToString() == "")
                {
                    Image6.ImageUrl = "../../images/binary_empty.png";
                    Label6.Text = "Vacant";
                    LinkButton6.Text = "Add Team Here";

                    LinkButton6.Visible = true;
                    Label6.Visible = true;
                    Image6.Visible = true;
                    img_back2.Visible = true;
                    LinkButton6.Enabled = false;

                    Label6.ForeColor = System.Drawing.Color.Black;
                    LinkButton6.ForeColor = System.Drawing.Color.Black;
                    LinkButton6.Enabled = false;
                }
                else
                {
                    LinkButton6.Enabled = true;
                    second_childcode = ds.Tables[0].Rows[0][3].ToString();

                    if (check_paid_or_not(second_childcode, "FREE"))
                    {
                        Label6.ForeColor = System.Drawing.Color.Red;
                        LinkButton6.ForeColor = System.Drawing.Color.Red;
                        Image6.ImageUrl = "../../images/red_image.png";

                    }
                    else
                    {
                        if (checkposition(second_childcode, "PAID"))
                        {
                            Label6.ForeColor = System.Drawing.Color.Green;
                            LinkButton6.ForeColor = System.Drawing.Color.Green;
                            Image6.ImageUrl = "../../images/green_image.png";
                        }

                    }
                    Label6.Text = find_child_name(second_childcode);
                    //LinkButton6.Text = second_childcode;
                    LinkButton6.Text = My.hide_string(second_childcode);//codenumber;
                    LinkButton6.CommandArgument = second_childcode;
                    LinkButton6.Attributes.Add("cmdname", second_childcode);

                    LinkButton6.Visible = true;
                    Label6.Visible = true;
                    Image6.Visible = true;
                    img_back2.Visible = true;
                }


                if (ds.Tables[0].Rows[0][4].ToString() == "")
                {
                    Image7.ImageUrl = "../../images/binary_empty.png";
                    Label7.Text = "Vacant";
                    LinkButton7.Text = "Add Team Here";

                    LinkButton7.Visible = true;
                    Label7.Visible = true;
                    Image7.Visible = true;
                    img_back2.Visible = true;
                    LinkButton7.Enabled = false;

                    Label7.ForeColor = System.Drawing.Color.Black;
                    LinkButton7.ForeColor = System.Drawing.Color.Black;
                    LinkButton7.Enabled = false;
                }
                else
                {
                    LinkButton7.Enabled = true;
                    second_childcode = ds.Tables[0].Rows[0][4].ToString();

                    if (check_paid_or_not(second_childcode, "FREE"))
                    {
                        Label7.ForeColor = System.Drawing.Color.Red;
                        LinkButton7.ForeColor = System.Drawing.Color.Red;
                        Image7.ImageUrl = "../../images/red_image.png";

                    }
                    else
                    {
                        if (checkposition(second_childcode, "PAID"))
                        {
                            Label7.ForeColor = System.Drawing.Color.Green;
                            LinkButton7.ForeColor = System.Drawing.Color.Green;

                            Image7.ImageUrl = "../../images/green_image.png";
                        }

                    }
                    Label7.Text = find_child_name(second_childcode);
                    //LinkButton7.Text = second_childcode;
                    LinkButton7.Text = My.hide_string(second_childcode);//codenumber;
                    LinkButton7.CommandArgument = second_childcode;
                    LinkButton7.Attributes.Add("cmdname", second_childcode);

                    LinkButton7.Visible = true;
                    Label7.Visible = true;
                    Image7.Visible = true;
                    img_back2.Visible = true;
                }
            }

        }
        private void find_second_level_left_node(string childcode)
        {
            string second_childcode;
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from binary_status where member_code ='" + childcode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 1)
            {
                if (ds.Tables[0].Rows[0][3].ToString() == "")
                {
                    Image4.ImageUrl = "../../images/binary_empty.png";
                    Label4.Text = "Vacant";
                    LinkButton4.Text = "Add Team Here";
                    LinkButton4.Visible = true;
                    Label4.Visible = true;
                    Image4.Visible = true;
                    img_back1.Visible = true;
                    LinkButton4.Enabled = false;

                    Label4.ForeColor = System.Drawing.Color.Black;
                    LinkButton4.ForeColor = System.Drawing.Color.Black;
                    LinkButton4.Enabled = false;
                }
                else
                {
                    LinkButton4.Enabled = true;
                    second_childcode = ds.Tables[0].Rows[0][3].ToString();


                    if (check_paid_or_not(second_childcode, "FREE"))
                    {
                        Label4.ForeColor = System.Drawing.Color.Red;
                        LinkButton4.ForeColor = System.Drawing.Color.Red;
                        Image4.ImageUrl = "../../images/red_image.png";

                    }
                    else
                    {
                        if (checkposition(second_childcode, "PAID"))
                        {
                            Label4.ForeColor = System.Drawing.Color.Green;
                            LinkButton4.ForeColor = System.Drawing.Color.Green;

                            Image4.ImageUrl = "../../images/green_image.png";
                        }

                    }
                    Label4.Text = find_child_name(second_childcode);
                    //LinkButton4.Text = second_childcode;
                    LinkButton4.Text = My.hide_string(second_childcode);//codenumber;
                    LinkButton4.CommandArgument = second_childcode;
                    LinkButton4.Attributes.Add("cmdname", second_childcode);

                    LinkButton4.Visible = true;
                    Label4.Visible = true;
                    Image4.Visible = true;
                    img_back1.Visible = true;
                }


                if (ds.Tables[0].Rows[0][4].ToString() == "")
                {
                    Image5.ImageUrl = "../../images/binary_empty.png";
                    Label5.Text = "Vacant";
                    LinkButton5.Text = "Add Team Here";
                    Image5.Visible = true;
                    LinkButton5.Visible = true;
                    Label5.Visible = true;
                    img_back1.Visible = true;
                    LinkButton5.Enabled = false;

                    Label5.ForeColor = System.Drawing.Color.Black;
                    LinkButton5.ForeColor = System.Drawing.Color.Black;
                    LinkButton5.Enabled = false;
                }
                else
                {
                    LinkButton5.Enabled = true;
                    second_childcode = ds.Tables[0].Rows[0][4].ToString();

                    if (check_paid_or_not(second_childcode, "FREE"))
                    {
                        Label5.ForeColor = System.Drawing.Color.Red;
                        LinkButton5.ForeColor = System.Drawing.Color.Red;
                        Image5.ImageUrl = "../../images/red_image.png";

                    }
                    else
                    {
                        if (checkposition(second_childcode, "PAID"))
                        {
                            Label5.ForeColor = System.Drawing.Color.Green;
                            LinkButton5.ForeColor = System.Drawing.Color.Green;
                            Image5.ImageUrl = "../../images/green_image.png";
                        }

                    }
                    Label5.Text = find_child_name(second_childcode);
                    LinkButton5.Text = second_childcode;

                    LinkButton5.Text = My.hide_string(second_childcode);//codenumber;
                    LinkButton5.CommandArgument = second_childcode;
                    LinkButton5.Attributes.Add("cmdname", second_childcode);

                    Image5.Visible = true;
                    LinkButton5.Visible = true;
                    Label5.Visible = true;
                    img_back1.Visible = true;
                }
            }

        }
        private string find_child_name(string childcode)
        {
            Connection con = new Connection();
            string constring = con.connect_method();
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + childcode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;

            return ds.Tables[0].Rows[0][4].ToString();
        }
        #region onmouseover data find

        public class Memberdata
        {
            public string doj { get; set; }
            public string left { get; set; }
            public string right { get; set; }
            public string joiningpackage { get; set; }
            public string sponsorcode { get; set; }
            public string sponsorname { get; set; }
            public string accounttype { get; set; }
            public string leftpv { get; set; }
            public string right_pv { get; set; }
            public string odj { get; set; }
        }
        [System.Web.Services.WebMethod]
        public static List<Memberdata> GetData(string membercode)
        {


            List<Memberdata> membera = new List<Memberdata>();
            Memberdata m = new Memberdata();
            Binary_team_structure t = new Binary_team_structure();
            m.doj = t.find_member_details(membercode);
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select bs.introducer_code,bs.left_child,bs.right_child,mr.Referal_code from binary_status bs join Member_registration mr on bs.Member_code=mr.Member_code where bs.Member_code ='" + membercode + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            string introducer = dt.Rows[0][0].ToString();
            string leftchildcode = dt.Rows[0][1].ToString();
            string rightchildcode = dt.Rows[0][2].ToString();
            string Referal_code = dt.Rows[0][3].ToString();

            string leftcount = "0";
            string rightcount = "0";


            if (leftchildcode != "")
            {
                leftcount = t.find_child_count(leftchildcode);


            }
            if (rightchildcode != "")
            {
                rightcount = t.find_child_count(rightchildcode);


            }

            m.left = leftcount.ToString();
            m.right = rightcount.ToString(); ;
            m.joiningpackage = t.find_member_package(membercode);
            m.sponsorcode = introducer;
            m.sponsorname = t.find_sponsorname(Referal_code);
            m.accounttype = find_joining_type(membercode);
            m.odj = t.find_upgrade_time(membercode);
            m.leftpv = t.find_left_pv(membercode);
            m.right_pv = t.find_right_pv(membercode);
            membera.Add(m);


            return membera.ToList();
        }

        private string find_right_pv(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select Right_PV from Member_PV_Details where Membercode ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_PV_Details");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][0].ToString();
        }

        private string find_left_pv(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select LeftPV from Member_PV_Details where Membercode ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_PV_Details");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][0].ToString();
        }



        private static string find_joining_type(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select Paidstatus from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][0].ToString();
        }

        private string find_sponsorname(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][4].ToString();
        }

        private string find_member_package(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][32].ToString();
        }
        #region data_fetch_for_hover
        private string find_upgrade_time(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select Verification_date,Verification_time from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][0].ToString() + "&nbsp;" + dt.Rows[0][1].ToString();
        }
        private string find_member_details(string membercode)
        {

            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            return dt.Rows[0][5].ToString() + "&nbsp;" + dt.Rows[0][36].ToString();



        }

        private string find_child_count(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from member_child_points_details where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "member_child_points_details");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                return "1";
            }
            else
            {
                return (Convert.ToInt32(dt.Rows[0][3].ToString()) + 1).ToString();
            }

        }

        #endregion data_fetch_for_hover

        #region back
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {


            int grrouwcount = grdmemberlist.Rows.Count - 1;
            for (int i = grrouwcount; i >= 0; i++)
            {
                string code = grdmemberlist.Rows[i].Cells[0].Text;
                find_Binary_series(code);
                find_legdetails(code);


                int idx = grdmemberlist.Rows[i].RowIndex;
                DataTable dtCurrentTable = (DataTable)ViewState["dtdatas"];
                dtCurrentTable.Rows.RemoveAt(idx);
                grdmemberlist.DataSource = dtCurrentTable;
                grdmemberlist.DataBind();
                ViewState["dtdatas"] = dtCurrentTable;
                break;
            }
        }
        #endregion back


        #endregion onmouseover data find

        #endregion
        
        private void ShowNewBinaryTree(string MemberCode)
        {
            string trEmptyMember = "";

            string mouseHover = "<div id='" + divID + "' style='position: fixed;display:none; z-index: 1; background-color: green;" +
                " border-radius: 5px; padding: 10px; color: white; font-size: 12px;'>Purchase Date: " + PurchaseDate + 
                " <br />Package: " + Package + "<br />Sponsor name: " + SponsorName + "<br />" + 
                LeftRightBV + "</div>";

            
            if (queryString != "") { MemberCode = queryString; }

            string MemberImage = "";
            MemberDetail m = getMemberDetail(MemberCode);
            if (m.Paidstatus == "FREE") { MemberImage = FreeMemberImage; }
            else { MemberImage = PaidMemberImage; }
			
            //MemberCount memberCount = imp.GetTotalMemberWithPosition(MemberCode);
            string LeftMemberCode = "";
            string RightMemberCode = "";

            string left = m.LeftChild;// memberCount.Left.ToString();
            string right = m.RightChild;// memberCount.Right.ToString();


            divID = "div" + countMemberForMakingID;
            LeftRightBV = "Left BV : 0  &nbsp;&nbsp;&nbsp; Right BV : 0";
            PurchaseDate = m.VerificationDate;
            Package = m.PackageName;
            SponsorName = m.Name + " [" + m.SponsorCode + "]";
            string LeftRightMember = "Left : " + m.LeftChild + " Right : " + m.RightChild;
            string Referral = m.ReferralName + "  [" + m.ReferralCode + "]";

            mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                 " border-radius: 5px; padding: 10px; color: white; font-size: 11px;'>Purchase Date: " + PurchaseDate +
                 " <br />Package: " + Package + "<br />Sponsor : " + SponsorName + "<br />" + LeftRightMember + "</div>";

            string tr = "<tr><td style='font-size: 11px;'>Left: " + left + "</td><td style='font-size: 12px;'>" + m.Name + "<br />ID: " + m.Code +
                "<br /><img onmouseover=\"hoverdiv(event,'" + divID + "')\" onmouseout=\"hoverdiv(event,'" + divID + "')\" src='" + MemberImage + 
                "'  /></td><td style='font-size: 11px;'>Right: " + right + "  " + mouseHover + "</td></tr>";
            topMember.InnerHtml = tr;

			countMemberForMakingID = countMemberForMakingID + 1;
			divID = "div" + countMemberForMakingID;
            mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                 " border-radius: 5px; padding: 10px; color: white; font-size: 11px;'>Purchase Date: " + PurchaseDate +
                 " <br />Package: " + Package + "<br />Sponsor : " + SponsorName + "<br />" +
                 LeftRightMember + "</div>";
				 
            spTopMemberName.InnerHtml = m.Name + "<br />ID: " + m.Code +
                "<br /><img onmouseover=\"hoverdiv(event,'" + divID + "')\" onmouseout=\"hoverdiv(event,'" + divID + "')\" src='" + MemberImage + 
                "'  /><br/> Left: " + left + " Right: " + right + "  " + mouseHover;

            

            m = getBinaryMember(MemberCode);
            LeftMemberCode = m.LeftMember;
            RightMemberCode = m.RightMember;


            #region Dynamic Child

            #region Left

            ChildLevel(LeftMemberCode, spLeft);
            if (LeftMemberCode == "0")
            {
                ChildLevel(LeftMemberCode, Span1);
                ChildLevel(LeftMemberCode, Span2);
                ChildLevel(LeftMemberCode, Span5);
                ChildLevel(LeftMemberCode, Span6);
                ChildLevel(LeftMemberCode, Span7);
                ChildLevel(LeftMemberCode, Span8);
            }
            else
            {
                MemberDetail m1 = getBinaryMember(LeftMemberCode);
                LeftMemberCode = m1.LeftMember;
                ChildLevel(LeftMemberCode, Span1);
                if (LeftMemberCode == "0")
                {
                    ChildLevel(LeftMemberCode, Span5);
                    ChildLevel(LeftMemberCode, Span6);
                }
                else
                {
                    MemberDetail m2 = getBinaryMember(LeftMemberCode);
                    LeftMemberCode = m2.LeftMember;
                    ChildLevel(LeftMemberCode, Span5);

                    RightMemberCode = m2.RightMember;
                    ChildLevel(RightMemberCode, Span6);
                }

                RightMemberCode = m1.RightMember;
                ChildLevel(RightMemberCode, Span2);
                if (RightMemberCode == "0")
                {
                    ChildLevel(RightMemberCode, Span7);
                    ChildLevel(RightMemberCode, Span8);
                }
                else
                {
                    MemberDetail m2 = getBinaryMember(RightMemberCode);
                    LeftMemberCode = m2.LeftMember;
                    ChildLevel(LeftMemberCode, Span7);

                    RightMemberCode = m2.RightMember;
                    ChildLevel(RightMemberCode, Span8);
                }
            }

            #endregion

            #region Right

            RightMemberCode = m.RightMember;
            ChildLevel(RightMemberCode, spRight);
            if (RightMemberCode == "0")
            {
                ChildLevel(RightMemberCode, Span3);
                ChildLevel(RightMemberCode, Span4);
                ChildLevel(RightMemberCode, Span9);
                ChildLevel(RightMemberCode, Span10);
                ChildLevel(RightMemberCode, Span11);
                ChildLevel(RightMemberCode, Span12);
            }
            else
            {
                MemberDetail m1 = getBinaryMember(RightMemberCode);
                LeftMemberCode = m1.LeftMember;
                ChildLevel(LeftMemberCode, Span3);
                if (LeftMemberCode == "0")
                {
                    ChildLevel(LeftMemberCode, Span9);
                    ChildLevel(LeftMemberCode, Span10);
                }
                else
                {
                    MemberDetail m2 = getBinaryMember(LeftMemberCode);
                    LeftMemberCode = m2.LeftMember;
                    ChildLevel(LeftMemberCode, Span9);

                    RightMemberCode = m2.RightMember;
                    ChildLevel(RightMemberCode, Span10);
                }

                RightMemberCode = m1.RightMember;
                ChildLevel(RightMemberCode, Span4);
                if (RightMemberCode == "0")
                {
                    ChildLevel(RightMemberCode, Span11);
                    ChildLevel(RightMemberCode, Span12);
                }
                else
                {
                    MemberDetail m2 = getBinaryMember(RightMemberCode);
                    LeftMemberCode = m2.LeftMember;
                    ChildLevel(LeftMemberCode, Span11);

                    RightMemberCode = m2.RightMember;
                    ChildLevel(RightMemberCode, Span12);
                }

            #endregion

            #endregion
            }
        }

        private void ChildLevel(string MemberCode, HtmlGenericControl span, string LeftCount = "0", string RightCount = "0")
        {
            countMemberForMakingID = countMemberForMakingID + 1;
            string tr = "";
            string url = "Binary_team_structure.aspx?q=" + MemberCode;
            if (MemberCode != "0")
            {
                string MemberImage = "";
                MemberDetail m = getMemberDetail(MemberCode);
                if (m.Paidstatus == "FREE") { MemberImage = FreeMemberImage; }
                else { MemberImage = PaidMemberImage; }
                //MemberCount memberCount = imp.GetTotalMemberWithPosition(MemberCode);

                divID = "div" + countMemberForMakingID;
                LeftRightBV = "Left BV : " + m.LeftBV + "  &nbsp;&nbsp;&nbsp; Right BV : " + m.RightBV;
                string LeftRightMember = "Left : " + m.LeftChild + " Right : " + m.RightChild;
                PurchaseDate = m.VerificationDate;
                Package = m.PackageName;
                SponsorName = m.SponsorName + " [" + m.SponsorCode + "]";
                string Referral = m.ReferralName + "  [" + m.ReferralCode + "]";

                string mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                    " border-radius: 5px; padding: 10px; color: white; font-size: 12px;'>Purchase Date: " + PurchaseDate +
                    " <br />Package: " + Package + "<br />Sponsor : " + SponsorName + "<br />" + LeftRightMember + "</div>";

                tr = m.Name + "<br />(ID: " + m.Code + ") <br /><a   href='" + url + "'  > " +
                " <img  onmouseover=\"hoverdiv(event,'" + divID + "')\"  onmouseout=\"hoverdiv(event,'" + divID + "')\" src='" + MemberImage + "'   /> " + mouseHover + "</a>";
                //title='LEFT: " + memberCount.Left.ToString() + " Right :  " + memberCount.Right.ToString() + "'

                span.InnerHtml = tr;
            }
            else
            {
                url = "#";
                tr = "N/A" + "<br />(ID: " + "N/A" + ") <br /><a   href='" + url + "' > " +
                    " <img src='images/grey.jpg'   /> </a>";//title='LEFT: 0 Right : 0'
                span.InnerHtml = tr;
            }

        }
        
        private MemberDetail getBinaryMember(string MemberCode)
        {
            MemberDetail m = new MemberDetail();
            string sql = " select  * from binary_status  where member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                m.LeftMember = dt.Rows[0]["left_child"].ToString() == "" ? "0" : dt.Rows[0]["left_child"].ToString();
                m.RightMember = dt.Rows[0]["right_child"].ToString() == "" ? "0" : dt.Rows[0]["right_child"].ToString();

                //m.LeftCount = imp.GetTotalNumber(m.LeftMember).ToString();
                //m.RightCount = imp.GetTotalNumber(m.RightMember).ToString();
                return m;
            }

            m.LeftMember = "0";
            m.RightMember = "0";

            return m;
        }

        public MemberDetail getMemberDetail(string MemberCode) 
        {
            MemberDetail m = new MemberDetail();
            string sql = " select Member_code, Member_name, Status, member_imagepath, Id, Position, Paidstatus, " +
                " Sponcer_name, Sponcer_code, joining_package, Verification_date, Verification_time, BV, Referal_code, Referal_name, " + 
                "Trio, LeftChild, RightChild  from Member_registration   where Member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) 
            {
                m.Name = dt.Rows[0]["Member_name"].ToString();
                m.Code = dt.Rows[0]["Member_code"].ToString();
                m.ImageUrl = dt.Rows[0]["member_imagepath"].ToString();
                m.VerifiedStatus = dt.Rows[0]["Status"].ToString();
                m.Position = dt.Rows[0]["Position"].ToString();
                m.Paidstatus = dt.Rows[0]["Paidstatus"].ToString();
                m.ID = dt.Rows[0]["Id"].ToString();

                m.SponsorName = dt.Rows[0]["Sponcer_name"].ToString();
                m.SponsorCode = dt.Rows[0]["Sponcer_code"].ToString();

                m.ReferralName = dt.Rows[0]["Referal_name"].ToString();
                m.ReferralCode = dt.Rows[0]["Referal_code"].ToString();

                m.Trio = dt.Rows[0]["Trio"].ToString();
                m.LeftChild = dt.Rows[0]["LeftChild"].ToString();
                m.RightChild = dt.Rows[0]["RightChild"].ToString();
                
                m.PackageName = dt.Rows[0]["joining_package"].ToString();
                m.VerificationDate = dt.Rows[0]["Verification_date"].ToString();
                m.VerificationTime = dt.Rows[0]["Verification_time"].ToString();
                m.BV = dt.Rows[0]["BV"].ToString();

                //MemberBV bv = imp.GetMember_BV(m.Code);
                m.LeftBV = "0";// bv.LeftBV.ToString();
                m.RightBV = "0";// bv.RightBV.ToString();

                m.LeftMember = "0";
                m.RightMember = "0";
                return m;
            }
            m.LeftMember = "0";
            m.RightMember = "0";
            return m;
        }

        protected void btn_find_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Binary_team_structure.aspx");
            return;

            if (txt_memberid.Text.Length < 0) { Alert("Invalid Member Code"); return; }
            queryString = txt_memberid.Text;
            ShowNewBinaryTree(queryString);
        }
        
        public void Alert(string Message)
        {
            lbl_msg.Text = Message;
            imp.Alert();
        }

        public void ShowUnlimitedMemberTree() 
        {
            string sponsorCode = imp.AdminCode;
            SponsorForTree sponsor = SponsorTreeView(sponsorCode);

            if (sponsor.Member == null) { Alert("Membercode does not exist."); return; }
            BindMembersTree(sponsor);
        }

        public SponsorForTree SponsorTreeView(string SponsorCode)
        {
            string sqlQuery = "select [id], [introducer_code], [member_code], [name] from  [binary_status] where [introducer_code] = '" + SponsorCode + "' order by [id]";

            DataTable dtTemp = imp.FillTable(sqlQuery);
            SponsorForTree sponsor = new SponsorForTree();
            if (dtTemp.Rows.Count != 0)
            {
                MembersForTree s = new MembersForTree();
                s.MemberCode = dtTemp.Rows[0]["member_code"].ToString();
                s.MemberName = dtTemp.Rows[0]["name"].ToString();
                s.SponsorLevel = "0";

                List<MembersForTree> Members = new List<MembersForTree>();

                foreach (DataRow dr in dtTemp.Rows)
                {
                    MembersForTree member = new MembersForTree();
                    if (dr["member_code"].ToString() != AdminCode)
                    {
                        member.MemberCode = dr["member_code"].ToString();
                        member.MemberName = dr["name"].ToString();

                        if (s.MemberCode != member.MemberCode)
                        {
                            member.AsSponsor = SponsorTreeView(member.MemberCode);
                            Members.Add(member);
                        }
                        
                    }
                    
                }

                sponsor.Member = s;
                sponsor.MembersList = Members;
            }

            return sponsor;
        }
        
        private void BindMembersTree(SponsorForTree SponsorDetails)
        {
            treeMembers.Nodes.Clear();
            treeMembers.Nodes.Add(TreeNode(SponsorDetails));
        }

        public TreeNode ChildNode(MembersForTree member)
        {
            TreeNode tn = new TreeNode();
            tn.Text = member.MemberName + "(" + member.MemberCode + ")";
            if (member.AsSponsor.Member != null) { tn.ChildNodes.Add(TreeNode(member.AsSponsor)); }
            return tn;
        }

        public TreeNode TreeNode(SponsorForTree SponsorDetails)
        {
            if (SponsorDetails.Member == null) { return null; }
            string memberCode = SponsorDetails.Member.MemberCode;
            TreeNode tn = new TreeNode();
            tn.Text = SponsorDetails.Member.MemberName + " (" + memberCode + ") ";
            if (SponsorDetails.MembersList != null)
            {
                foreach (var member in SponsorDetails.MembersList)
                {
                    //tn.ChildNodes.Add(ChildNode(member));
                    if (member.AsSponsor != null) { tn.ChildNodes.Add(ChildNode(member)); }
                    else
                    {
                        //Added on Date 20-10-2017.
                        TreeNode tnChild = new TreeNode();
                        tnChild.Text =  member.MemberName + " (" + member.MemberCode + ")";
                        tn.ChildNodes.Add(tnChild);
                    }
                }
            }
            return tn;
        }

    }

    public class MemberDetail 
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string LeftMember { get; set; }
        public string RightMember { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string VerifiedStatus { get; set; }
        public string Paidstatus { get; set; }

        public string LeftCount { get; set; }
        public string RightCount { get; set; }

        public string SponsorName { get; set; }
        public string SponsorCode { get; set; }

        public string Trio { get; set; }
        public string LeftChild { get; set; }
        public string RightChild { get; set; }

        public string ReferralName { get; set; }
        public string ReferralCode { get; set; }

        public string VerificationDate { get; set; }
        public string VerificationTime { get; set; }
        public string PackageName { get; set; }
        public string BV { get; set; }

        public string LeftBV { get; set; }
        public string RightBV { get; set; }
    }
    
    public class SponsorForTree
    {
        public MembersForTree Member { get; set; }
        public List<MembersForTree> MembersList { get; set; }
    }
    
    public class MembersForTree
    {
        public string MemberCode { get; set; }
        public string MemberName { get; set; }
        public string ReferalCode { get; set; }
        public string ReferalName { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string SponsorLevel { get; set; }
        public string MemberLevel { get; set; }
        public SponsorForTree AsSponsor { get; set; }
    }

}