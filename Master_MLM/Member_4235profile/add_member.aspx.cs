using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Transactions;
using System.Globalization;

namespace Master_MLM.Member_4235profile
{
    public partial class add_member : System.Web.UI.Page
    {

        string sql = "";
        Important imp = new Important();
        DateTime CurrentDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        My Mycode = new My();
        //BinaryPlan binaryPlan = new BinaryPlan();
        string AdminCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string Interval = GetIntervalValue();

            AdminCode = imp.AdminCode;
            if (!IsPostBack)
            {
                if (Session["epin"] != null)
                {
                    txtEPin.Text = Session["epin"].ToString();
                    txtEPin.Enabled = false;
                }
                else { Response.Redirect("Allocated_pin_list.aspx"); }
                try
                {
                    BindYearInDropDown();
                    //BindPackageInDropDown();
                    Mycode.bind_ddl(ddlState, "Select distinct State from  state_and_district  order by State ");
                }
                catch (Exception ex) { }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validation
            if (rdbFemale.Checked == false && rdbMale.Checked == false) { Alert("Invalid Gender."); return; }
            if (ddlYear.SelectedValue == "Select") { Alert("Invalid Year."); return; }
            if (ddlState.SelectedValue == "Select") { Alert("Invalid State."); return; }
            if (ddlDistrict.SelectedValue == "Select") { Alert("Invalid District."); return; }
            if (txtReferralID.Value.Trim() == "") { Alert("Invalid Referral Code."); return; }
            if (txtReferralName.Value.Trim() == "") { Alert("Invalid Referral Name."); return; }
            if (txtSponsorID.Value.Trim() == "") { Alert("Invalid Sponsor Code."); return; }
            if (txtSponsorName.Value.Trim() == "") { Alert("Invalid Sponsor Name."); return; }
            if (txtPassword.Value.Trim().Length == 0) { Alert("Invalid Password"); return; }
            //if (txtReferralBankName.Text == "" || txtDDNumber.Text == "") { Alert("Invalid Amount Deposit Detail."); return; }
            //if (!Mycode.valid_number(txtEPin.Text)) { Alert("Invalid Mobile No."); return; }
            if (!Mycode.valid_number(txtMobile.Value)) { Alert("Invalid Mobile No."); return; }
            if (txtMobile.Value.Trim().Length < 10) { Alert("Invalid Mobile No."); return; }
            //if (txtUserName.Value.Trim().Length < 6) { Alert("Invalid User Name. Minimum 6 character required."); return; }
            //if (IsMobileNoUnique(txtMobile.Value.Trim())) { Alert("Mobile No. already exist."); return; }
            NewRegistration();
        }

        public bool IsMobileNoUnique(string MobileNo)
        {
            bool status = false;
            string sql = "select  * from Member_registration where Mobile_number='" + MobileNo + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0) { status = true; }

            return status;
        }

        private void BindYearInDropDown()
        {
            int currentYear = DateTime.Now.Year;
            int lastYear = DateTime.Now.AddYears(-60).Year;
            ddlYear.Items.Add(new ListItem { Text = "Select", Value = "Select" });
            for (int i = currentYear; i > lastYear; i--)
            {
                ddlYear.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
            }
        }

        private void BindPackageInDropDown()
        {
            sql = " select Package_name, Package_id from Joining_package";
            DataTable dt = imp.FillTable(sql);
            ddlPackage.Items.Add(new ListItem { Text = "Select Package", Value = "Select" });
            foreach (DataRow dr in dt.Rows)
            {
                ddlPackage.Items.Add(new ListItem { Text = dr["Package_name"].ToString(), Value = dr["Package_id"].ToString() });
            }
        }

        private void BindDateInDropDown()
        {
            int currentYear = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int days = DateTime.DaysInMonth(currentYear, month);
            ddlYear.Items.Add(new ListItem { Text = "Select", Value = "Select" });
            for (int i = 1; i < days; i++)
            {
                ddlDate.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
            }
        }

        public bool IsEmptyPosition(string MemberCode, string Position)
        {
            bool status = false;

            string sql = " select * from binary_status where member_code = '" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                if (Position.ToUpper() == "LEFT")
                {
                    if (dt.Rows[0]["left_child"].ToString() == "")
                    {
                        status = true;
                    }
                }

                if (Position.ToUpper() == "RIGHT")
                {
                    if (dt.Rows[0]["right_child"].ToString() == "")
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        private void NewRegistration()
        {
            #region For Registration

            string Your_plan = "";

            string Sponcer_code = txtSponsorID.Value.ToUpper();
            string Sponcer_name = txtSponsorName.Value;

            string Position = "";
            if (rdbLeft.Checked == true) { Position = "Left"; }
            else if (rdbRight.Checked == true) { Position = "Right"; }
            else if (rdbMiddle.Checked == true) { Position = "Middle"; }
            else { Alert("Please select Position."); return; }

            //Check here For Vacant Position.
            //if (!IsEmptyPosition(Sponcer_code, Position)) { Alert(Position + " Position is not vacant."); txtSponsorName.Value = ""; txtSponsorID.Disabled = false; return; }


            string ReferralCode = txtReferralID.Value;
            string ReferralName = txtReferralName.Value;

            //string ReferralCode = Sponcer_code.ToUpper();
            //string ReferralName = Sponcer_name;

            string Member_code = imp.suffixTag + imp.UniqueUserID();//??
            string Member_name = txtFullName.Value;

            txtUserName.Value = Member_code;                                                   //UserName
            //txtUserName.Value = txtMobile.Value.Trim();                                        //UserName

            string Date = CurrentDate.ToString("dd/MM/yyyy");
            string Email = txtEmail.Value;
            string Mobile_number = txtMobile.Value;
            string Pan_number = txtPAN.Value;
            string DL_number = "";
            string Your_Name = txtFullName.Value;
            string Father_name = "";
            string Date_of_birth = ddlDate.SelectedValue + "/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue;
            string member_imagepath = "";

            string Gender = "";

            if (rdbMale.Checked == true) { Gender = "Male"; member_imagepath = "/Content/images/male-icon.png"; }
            else if (rdbFemale.Checked == true) { Gender = "Female"; member_imagepath = "/Content/images/girl.jpg"; }
            else { Alert("Please select Gender."); return; }

            string Address = txtAddress.Value;
            string District = ddlDistrict.SelectedValue;//??
            string State = ddlState.SelectedValue;//??
            string Nominee_name = "";
            string Nominee_relation = "";
            string Nominee_age = "";
            string Nominee_gender = "";
            string Account_number = txtAccounNo.Value;
            string Bank_name = txtBankName.Value;
            string Branch_name = txtBranchName.Value;
            string Ifsc_code = txtIFSCCode.Value;
            string AadharNumber = txtAadhar.Value;
            string Status = "Pending";
            string formno = find_formno().ToString();

            string Referal_code = ReferralCode;
            string Referal_name = ReferralName;

            string joining_package = "0";            //??

            string Joining_amount = "0";
            string Package_id = "0";
            string BV = "0";


            string Blockstatus = "UNBLOCKED";
            string Pinno = txtEPin.Text;
            string Joiningtime = CurrentDate.ToString("hh:mm:ss tt");
            string BP = "";//??
            string DP = "";//??
            string MFP = "";//??
            string Paidstatus = "FREE";
            string Verification_date = "";
            string Verification_time = "";
            string Verification_idate = "";
            string Product = "";
            string Product_delivered_status = "";
            string check_data = "";
            string Pin_code = txtPIN.Value;

            string City = txtCity.Value;
            string Payee_Name_bank = txtPayeeName.Value;
            string Proof_identy = "";
            string proof_address = "";
            string PV = "0";//??
            string Capping = "0";//??
            string Level = "0";//??
            string MatchingIncome = "0";
            string RewardPoint = "0";
            string RewardBV = "0";
            string RepurchaseBV = "0";

            if (txtEPin.Text.Trim() != "")
            {
                if (!IsValidEPin()) { Alert("Invalid EPin."); return; }
                Joining_amount = hdfPackageAmount.Value;
                joining_package = hdfPackageName.Value;
                Package_id = hdfPackageID.Value;
                MatchingIncome = hdfMatchingIncome.Value;
                RewardPoint = hdfRewardPoint.Value;
                Pinno = txtEPin.Text;

                RewardBV = hdfRewardBV.Value;
                RepurchaseBV = hdfRepurchaseBV.Value;


                if (int.Parse(hdfIsActivationPackage.Value) == 0)
                {
                    Paidstatus = "PAID";
                    Status = "Verified";
                    Verification_date = CurrentDate.ToString("dd/MM/yyyy");
                    Verification_time = CurrentDate.ToString("hh:mm:ss tt");
                    Verification_idate = CurrentDate.ToString("yyyyMMdd");
                }
            }

            //SponsorDetails sp =  GetSponsorCodeForReliable();
            //Sponcer_code = sp.SponsorCode;
            //Position = sp.Position;
            //Sponcer_name = FindSponsorName(Sponcer_code);

            //It is used when find Position Sponsor code wise.
            //Position = GetEmptyPosition(Sponcer_code);
            //if (Position == "") { Alert("Position not available."); return; }

            //For Left-Middle-Right Member Plan.
            Sponcer_code = GetSponsorCode(Sponcer_code, Position);
            Sponcer_name = FindSponsorName(Sponcer_code);

            string DDBankName = txtReferralBankName.Text;
            string DDNumber = txtDDNumber.Text;

            string RoyaltyTarget = "2";

            //Nominee Details
            Nominee_name = txtNomineeName.Value;
            Nominee_gender = "";
            if (rdbNomineeMale.Checked == true) { Nominee_gender = "Male"; }
            if (rdbNomineeFemale.Checked == true) { Nominee_gender = "Female"; }
            Nominee_age = txtNomineeAge.Value;
            Nominee_relation = txtNomineeRelation.Value;

            string UserName = txtUserName.Value;
            if (IsUserNameExist(UserName)) { Alert("UserName already exist. Choose another user name."); return; }

            string Interval = GetIntervalValue();
            #endregion

            #region For Binary Table

            string name = txtFullName.Value;
            string member_code = Member_code;
            string introducer_code = Sponcer_code;
            string left_child = "";
            string right_child = "";
            string people_no = "0";
            string filled = "NO";
            #endregion

            #region For Member Login Table

            string User_id = Member_code;
            string Pwd = txtPassword.Value;
            string Transaction_Password = "0";

            #endregion

            #region FOR SMS

            string message = "Dear " + Member_name + " Welcome to " + imp.CompanyName + ". Your Member Code =" + Member_code + ", User Name = " + UserName + " and Password is = " +
                Pwd + ". Thanks for being with us(" + imp.CompanyName + ") visit :- " + imp.Url;

            #endregion

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)))
            {
                try
                {
                    sql = "insert into Member_registration(Your_plan,Sponcer_code,Sponcer_name,Member_code,Member_name,Date,Email," +
                        " Mobile_number,Pan_number,DL_number,Your_Name,Father_name,Date_of_birth,Gender,Address,District,State,Nominee_name," +
                        " Nominee_relation,Nominee_age,Nominee_gender,Account_number,Bank_name,Branch_name,Ifsc_code,Status,formno," +
                        " Referal_code,Referal_name,member_imagepath,Joining_amount,joining_package,Position,Blockstatus,Pinno,Joiningtime," +
                        " BP,DP,BV,MFP,Paidstatus,Verification_date,Verification_time,Verification_idate,Product,Product_delivered_status," +
                        " check_data,Pin_code,Package_id,City,Payee_Name_bank,Proof_identy,proof_address,PV,Capping,Level, DDBankName, DDNumber, " +
                        " AadharNumber, RewardPoint, MatchingIncome, LeftChild, RightChild, RoyaltyTarget, RepurchaseBV, RewardBV, Interval) values ('" +
                        Your_plan + "','" + Sponcer_code + "','" + Sponcer_name + "','" + Member_code + "','" + Member_name + "','" + Date + "','" + Email + "','" +
                        Mobile_number + "','" + Pan_number + "','" + DL_number + "','" + Your_Name + "','" + Father_name + "','" + Date_of_birth + "','" + Gender
                        + "','" + Address + "','" + District + "','" + State + "','" + Nominee_name + "','" + Nominee_relation + "','" + Nominee_age + "','" +
                        Nominee_gender + "','" + Account_number + "','" + Bank_name + "','" + Branch_name + "','" + Ifsc_code + "','" + Status + "','" + formno +
                        "','" + Referal_code + "','" + Referal_name + "','" + member_imagepath + "','" + Joining_amount + "','" + joining_package + "','" + Position +
                        "','" + Blockstatus + "','" + Pinno + "','" + Joiningtime + "','" + BP + "','" + DP + "','" + BV + "','" + MFP + "','" + Paidstatus + "','" +
                        Verification_date + "','" + Verification_time + "','" + Verification_idate + "','" + Product + "','" + Product_delivered_status +
                        "','" + check_data + "','" + Pin_code + "','" + Package_id + "','" + City + "','" + Payee_Name_bank + "','" + Proof_identy + "','" +
                        proof_address + "','" + PV + "','" + Capping + "','" + Level + "','" + DDBankName + "','" + DDNumber + "','" + AadharNumber + "','" +
                        RewardPoint + "','" + MatchingIncome + "', '0', '0', '" + RoyaltyTarget + "', '" + RepurchaseBV + "', '" + RewardBV + "', '" + Interval + "')"; // in registration table.
                    int i1 = imp.InsertUpdateDelete(sql);


                    sql = "insert into Member_Login(Membercode,User_id,Pwd,Transaction_Password, userName) values ('" + Member_code + "','" +
                        User_id + "','" + Pwd + "','" + Transaction_Password + "','" + UserName + "');";            // in Member Login table.
                    int i2 = imp.InsertUpdateDelete(sql);

                    //Insert into Binary Tree Table.
                    sql = "insert into binary_status(name,member_code,introducer_code,countChild,left_child,right_child)  values ('" + name + "','" + member_code +
                  "','" + introducer_code + "','','','')";
                    int i3 = imp.InsertUpdateDelete(sql);

                    if (Position.ToUpper() == "LEFT") { sql = "update   binary_status  set  left_child = '" + member_code + "', countChild = countChild + 1 where  member_code ='" + introducer_code + "'"; }
                    if (Position.ToUpper() == "RIGHT") { sql = "update   binary_status  set  right_child = '" + member_code + "', countChild = countChild + 1 where  member_code ='" + introducer_code + "'"; }
                    if (Position.ToUpper() == "MIDDLE") { sql = "update   binary_status  set  middle_child = '" + member_code + "', countChild = countChild + 1 where  member_code ='" + introducer_code + "'"; }

                    int i4 = imp.InsertUpdateDelete(sql);

                    //Update EPIN
                    int i5 = 0;
                    if (txtEPin.Text != "")
                    {
                        sql = "Update E_PIN_details set Status='USED', Used_to='" + member_code + "', used_by='" + introducer_code + "', used_date='" + Date +
                              "' where Epin='" + txtEPin.Text + "'";
                        i5 = imp.InsertUpdateDelete(sql);
                    }
                    else { i5 = 1; }

                    if (i1 != 0 && i2 != 0 && i3 != 0 && i4 != 0 && i5 != 0)
                    {
                        Session["registrationMemberCode"] = member_code;
                        ClearAll();
                        sms_sender.send_message(Mobile_number, message, member_code);
                        //Alert("Member ID <b> " + Member_code + "</b> is successfully registered.");
                        scope.Complete();
                        UpdateMemberCount(member_code);
                        Response.Redirect("print_joining_voucher.aspx", false);
                    }
                    else { Alert("Invalid operation."); return; }

                }
                catch (Exception ex)
                {
                    Alert("Invalid operation."); return;
                }
            }
        }

        public bool IsValidEPin()
        {
            if (txtEPin.Text == "") { Alert("Invalid E Pin."); return false; }
            string sql = "select *, isnull((select top 1 IsActivationPackage from Joining_package where Package_name=Package), 0) as IsActivationPackage, " +
                         "isnull((select top 1 Package_amount from Joining_package where Package_name=Package), 0) as package_amount, " +
                         "isnull((select top 1 RewardPoint from Joining_package where Package_name=Package), 0) as RewardPoint, isnull((select top 1 " +
                         "MatchingIncome from Joining_package where Package_name=Package), 0) as MatchingIncome from E_PIN_details where Status='GIVEN' " +
                         "and  Epin='" + txtEPin.Text + "'";

            sql = "select * from (select *, isnull((select top 1 IsActivationPackage from Joining_package where Package_name=Package), 0) as IsActivationPackage,  " +
                  "isnull((select top 1 BV from Joining_package where Package_name=Package), 0) as BV," +
                  "isnull((select top 1 RepurchaseBV from Joining_package where Package_name=Package), 0) as RepurchaseBV," +
                  "isnull((select top 1 Package_amount from Joining_package where Package_name=Package), 0) as package_amount,  isnull((select top 1 RewardPoint  " +
                  "from Joining_package where Package_name=Package), 0) as RewardPoint, isnull((select top 1  MatchingIncome from Joining_package where  " +
                  "Package_name=Package), 0) as MatchingIncome from E_PIN_details where Status='GIVEN' and  Epin='" + txtEPin.Text +
                  "') T where  IsActivationPackage in (0, 1)";

            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                hdfPackageName.Value = dt.Rows[0]["Package"].ToString();
                hdfPackageAmount.Value = dt.Rows[0]["package_amount"].ToString();
                hdfRewardPoint.Value = dt.Rows[0]["RewardPoint"].ToString();
                hdfMatchingIncome.Value = dt.Rows[0]["MatchingIncome"].ToString();
                hdfPackageID.Value = dt.Rows[0]["Package_id"].ToString();
                hdfIsActivationPackage.Value = dt.Rows[0]["IsActivationPackage"].ToString();

                hdfRewardBV.Value = dt.Rows[0]["BV"].ToString();
                hdfRepurchaseBV.Value = dt.Rows[0]["RepurchaseBV"].ToString();

                txtEPin.Enabled = false;
                return true;
            }
            else { Alert("Invalid E Pin."); return false; }

        }

        public bool IsUserNameExist(string UserName)
        {
            string sql = "select userName from Member_Login where userName='" + UserName + "'";
            DataTable dtUserName = imp.FillTable(sql);
            if (dtUserName.Rows.Count != 0) { return true; }
            return false;
        }

        private SponsorDetails GetSponsorCodeForReliable()
        {
            SponsorDetails s = new SponsorDetails();
            string sql = " select * from binary_status where countChild != 3  order by id asc";
            DataTable dt = imp.FillTable(sql);

            if (dt.Rows.Count != 0)
            {
                string SponsorCode = dt.Rows[0]["member_code"].ToString();

                if (dt.Rows[0]["left_child"].ToString() == "")
                {
                    s.SponsorCode = SponsorCode;
                    s.Position = "Left";
                    return s;
                }

                if (dt.Rows[0]["middle_child"].ToString() == "")
                {
                    s.SponsorCode = SponsorCode;

                    s.Position = "Middle";
                    return s;
                }

                if (dt.Rows[0]["right_child"].ToString() == "")
                {
                    s.SponsorCode = SponsorCode;
                    s.Position = "Right";
                    return s;
                }

            }
            return s;
        }

        private string GetSponsorCode(string SponsorCode, string Position)
        {
            string sql = " select * from binary_status where member_code = '" + SponsorCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                if (Position == "Left")
                {
                    if (dt.Rows[0]["left_child"].ToString() == "") { return SponsorCode; }
                    else
                    {
                        SponsorCode = dt.Rows[0]["left_child"].ToString();
                        SponsorCode = GetSponsorCode(SponsorCode, Position);
                        return SponsorCode;
                    }
                }
                if (Position == "Right")
                {
                    if (dt.Rows[0]["right_child"].ToString() == "") { return SponsorCode; }
                    else
                    {
                        SponsorCode = dt.Rows[0]["right_child"].ToString();
                        SponsorCode = GetSponsorCode(SponsorCode, Position);
                        return SponsorCode;
                    }
                }
                if (Position == "Middle")
                {
                    if (dt.Rows[0]["middle_child"].ToString() == "") { return SponsorCode; }
                    else
                    {
                        SponsorCode = dt.Rows[0]["middle_child"].ToString();
                        SponsorCode = GetSponsorCode(SponsorCode, Position);
                        return SponsorCode;
                    }
                }
            }
            return SponsorCode;
        }

        private string FindSponsorName(string MemberCode)
        {
            sql = "select Member_code, Member_name from Member_registration where Member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return dt.Rows[0]["Member_name"].ToString(); }
            return "";
        }

        //public static void send_message(string mobile, string message, string membercode)
        //{
        //    Important imp1 = new Important();
        //    if (!imp1.IsSend) { return; }

        //    string str1 = imp1.Key;                              //Key
        //    string str2 = imp1.SenderID;                         //Sender ID
        //    string str3 = "1";
        //    string text = mobile;
        //    string str4 = message;
        //    string url = "http://" + "mysms.msgclub.net" + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + str1 + "&message=" + str4 + "&senderId=" + str2 +
        //        "&routeId=" + str3 + "&mobileNos=" + text + "&smsContentType=unicode";
        //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //    try
        //    {
        //        HttpWebResponse httpres = (HttpWebResponse)httpWebRequest.GetResponse();
        //        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        //        string result = sr.ReadToEnd();
        //        sr.Close();
        //        send_message_details_in_Message_send_details(mobile, message, membercode, result, url);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private static void send_message_details_in_Message_send_details(string mobile, string message, string membercode, string result, string  url)
        //{
        //    DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        //    string time = dtm.ToString("hh:mm:ss tt");

        //    Connection con = new Connection();
        //    string connectionstring = con.connect_method();
        //    SqlConnection conn6 = new SqlConnection(connectionstring);
        //    SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details", conn6);
        //    DataSet ds6 = new DataSet();
        //    ad6.Fill(ds6, "Message_send_details");
        //    DataTable dt6 = ds6.Tables[0];
        //    DataRow dr6 = dt6.NewRow();
        //    //dr6[0] = membercode;
        //    //dr6[1] = mobile;
        //    //dr6[2] = dtm.ToString("dd/MM/yyyy");
        //    //dr6[3] = message;
        //    //dr6[4] = result;
        //    //dr6[5] = time;
        //    dr6[1] = membercode;
        //    dr6[2] = mobile;
        //    dr6[3] = dtm.ToString("dd/MM/yyyy");
        //    dr6[4] = message;
        //    dr6[7] = url;
        //    dr6[8] = result;
        //    dr6[6] = time;
        //    dt6.Rows.Add(dr6);
        //    SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
        //    ad6.Update(dt6);
        //}

        public void ClearAll()
        {
            txtAadhar.Value = "";
            txtPAN.Value = "";
            txtPayeeName.Value = "";
            txtBankName.Value = "";
            txtBranchName.Value = "";
            txtAccounNo.Value = "";
            txtIFSCCode.Value = "";

            txtPassword.Value = "";

            txtPIN.Value = "";
            ddlState.SelectedValue = "Select";
            ddlDistrict.SelectedValue = "Select";
            txtCity.Value = "";
            txtAddress.Value = "";
            txtFullName.Value = "";
            txtMobile.Value = "";

            txtEmail.Value = "";
            txtSponsorID.Value = "";
            txtSponsorName.Value = "";
            rdbLeft.Checked = false;
            rdbRight.Checked = false;
            rdbMale.Checked = false;
            rdbLeft.Checked = false;
            txtFullName.Value = "";
            ddlPackage.SelectedValue = "Select";

            txtSponsorID.Disabled = false;
            txtUserName.Value = "";
            txtPassword.Value = "";
            //txtSponsorName.Disabled = false;
        }

        private int find_formno()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select formno,Id from Member_registration order by id DESC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlState.Text == "Select")
            {
                Alert("Please select district.");
            }
            else
            {
                Mycode.bind_ddl(ddlDistrict, "Select distinct District from  state_and_district where State='" +
                    ddlState.Text + "'  order by District ");

            }
        }

        public void Alert(string Message)
        {
            lbl_msg.Text = Message;
            divAlert.Visible = true;
            imp.Alert();
        }

        protected void btnFindSponsor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSponsorID.Value == "") { Alert("Invalid Sponsor ID."); return; }
                else
                {
                    sql = "select Member_code, Member_name from Member_registration where Member_code='" + txtSponsorID.Value + "'";
                    DataTable dt = imp.FillTable(sql);
                    if (dt.Rows.Count != 0) { txtSponsorID.Disabled = true; txtSponsorName.Value = dt.Rows[0]["Member_name"].ToString(); }
                    else { Alert("Invalid Sponsor ID."); return; }

                    SubmitButtonShowHide();
                }
            }
            catch (Exception ex) { Alert("Invalid Sponsor ID."); txtSponsorID.Focus(); return; }
        }

        public bool IsPositionAvailable(string SponsorCode, string Position)
        {
            string sql = "select left_child,right_child,member_code, introducer_code from binary_status where member_code='" +
                SponsorCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["left_child"].ToString() != "") { return false; }
                if (dt.Rows[0]["right_child"].ToString() != "") { return false; }
            }
            return true;
        }

        public void UpdateMemberCount(string MemberCode)
        {
            RegistrationPageUpdate r = new RegistrationPageUpdate();
            r.MemberCode = MemberCode;
            Global.RegistrationMemberCountList.Add(r);
        }

        private string GetEmptyPosition(string SponsorCode)
        {
            string sql = " select * from binary_status where member_code = '" + SponsorCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["left_child"].ToString() == "") { return "Left"; }
                if (dt.Rows[0]["middle_child"].ToString() == "") { return "Middle"; }
                if (dt.Rows[0]["right_child"].ToString() == "") { return "Right"; }
            }
            return "";
        }

        protected void btnFindReferral_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReferralID.Value == "") { Alert("Invalid Referral ID."); return; }
                else
                {
                    sql = "select Member_code, Member_name from Member_registration where Member_code='" + txtReferralID.Value + "'";
                    DataTable dt = imp.FillTable(sql);
                    if (dt.Rows.Count != 0)
                    {
                        //txtReferralID.Disabled = true; 
                        txtReferralName.Value = dt.Rows[0]["Member_name"].ToString();

                        string Position = "";
                        if (rdbLeft.Checked == true) { Position = "Left"; }
                        else if (rdbRight.Checked == true) { Position = "Right"; }
                        else if (rdbMiddle.Checked == true) { Position = "Middle"; }
                        else { Alert("Please Select Position."); return; }

                        string Sponcer_code = txtReferralID.Value;
                        Sponcer_code = GetSponsorCode(Sponcer_code, Position);
                        string Sponcer_name = FindSponsorName(Sponcer_code);

                        txtSponsorID.Value = Sponcer_code;
                        txtSponsorName.Value = Sponcer_name;
                    }
                    else { Alert("Invalid Referral ID."); return; }

                    SubmitButtonShowHide();
                }
            }
            catch (Exception ex) { Alert("Invalid Sponsor ID."); txtSponsorID.Focus(); return; }
        }

        public void SubmitButtonShowHide()
        {
            //if (txtReferralName.Value != "" && txtSponsorName.Value != "") { btnSubmit.Visible = true; }
            if (txtSponsorName.Value != "") { btnSubmit.Visible = true; }
            else { btnSubmit.Visible = false; }
        }

        private string GetIntervalValue()
        {
            DateTime dtCurrent = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            DateTime dtFixed = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 12:00:00 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //First Slot
            DateTime dtStart1 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 06:00:00 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd1 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 11:59:59 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //Second Slot
            DateTime dtStart2 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 12:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd2 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 05:59:59 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //Third Slot
            DateTime dtStart3 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 06:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd3 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 11:59:59 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            if (dtCurrent >= dtStart1 && dtCurrent <= dtEnd1) { return "1"; }
            if (dtCurrent >= dtStart2 && dtCurrent <= dtEnd2) { return "2"; }
            if (dtCurrent >= dtStart3 && dtCurrent <= dtEnd3) { return "3"; }
            return "1";
        }
    }
}