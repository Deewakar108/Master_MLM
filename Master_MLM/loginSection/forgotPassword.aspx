<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="Master_MLM.forgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="keywords" content="" />

    <meta name="description" content="text" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link href="CSS/style6.css" rel="stylesheet" />
    <%-- ...................bootstrap_link.................. --%>
    <link href="bootstrap_link/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="bootstrap_link/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js"></script>


    <script src="bootstrap_link/bootstrap.min.js"></script>
    <%-- ...................End bootstrap_link.................. --%>
    <%-- ...................page design.................. --%>
    <link href="allpage_design.css" rel="stylesheet" />

    <%-- ...................End page design.................. --%>
    <style>
        .member_loginbutton {
            margin: 0 auto !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="slider_section">

            <div class="member_login">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 " style="margin: 0px auto; float: none;">
                            <div class="member_logininner" style="height: auto;  margin-bottom: 5px;">
                                <img src="../images/logo.png" class="img-responsive" style="margin: 4px auto 4px auto; background-color: #fff;" />
                            </div>

                            <div class="member_logininner">
                                <div class="member_loginbox">
                                    <asp:Panel ID="pnlForgot" runat="server" Visible="true">

                                        <div class="member_loginbox">
                                            <h2 class="member_head">Forgot Password
                                            </h2>
                                            <div style="text-align: left;" class="member_line">
                                                Member Code
                                            </div>
                                            <div class="member_line">
                                                <asp:TextBox ID="txtMemberCode" runat="server" placeholder=" Enter Member Code" CssClass="text_boxdesign"></asp:TextBox>
                                            </div>
                                            <div class="member_line" style="margin-top: 0px; text-align: center;">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="member_loginbutton" Style="width: 100%;" OnClick="btnSubmit_Click" />
                                                <asp:Label ID="lbl_msg" runat="server" ForeColor="#ff6600" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                    </asp:Panel>
                                    <asp:Panel ID="pnlVerify" runat="server" Visible="false">

                                        <div class="member_loginbox">
                                            <h2 class="member_head">Verify OTP
                                            </h2>
                                            <div style="text-align: left;" class="member_line">
                                                OTP Code
                                            </div>
                                            <div class="member_line">
                                                <asp:TextBox ID="txtOTPCode" runat="server" placeholder=" Enter OTP Code" CssClass="text_boxdesign"></asp:TextBox>

                                            </div>
                                            <div class="member_line" style="margin-top: 0px; text-align: center;">
                                                <asp:Button ID="btnOTPCode" runat="server" Text="Verify" CssClass="member_loginbutton" Style="width: 100%;" OnClick="btnOTPCode_Click" />
                                                <asp:Label ID="lblOTPMessage" runat="server" ForeColor="#ff6600" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                    </asp:Panel>
                                    <asp:Panel ID="pnlReset" runat="server" Visible="false">

                                        <div class="member_loginbox">
                                            <h2 class="member_head">Reset Password
                                            </h2>
                                            <div class="member_line">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="text_boxdesign"></asp:TextBox>
                                            </div>
                                            <div class="member_line">
                                                <asp:TextBox ID="txtRetypePassword" runat="server"  TextMode="Password"  placeholder="Retype Password" CssClass="text_boxdesign"></asp:TextBox>
                                            </div>
                                            <div class="member_line" style="margin-top: 0px; text-align: center;">
                                                <asp:Button ID="btnSubmitPassowrd" runat="server" Text="Submit" CssClass="member_loginbutton" Style="width: 100%;" OnClick="btnSubmitPassowrd_Click" />
                                                <asp:Label ID="lblPasswordMessage" runat="server" ForeColor="#ff6600" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                    </asp:Panel>

                                    <h2 class="member_head" style="background-color: transparent; border-bottom: 0px; color: #000; margin-bottom: 10px; padding-top: 0px;">
                                        <a href="../Default.aspx" style="font-size: 12px; margin-right: 10px">Home</a>
                                       <%-- <a href="../RegistrationForm.aspx" style="font-size: 12px; margin-right: 10px">Register Now</a>--%>
                                        <a href="loginpage.aspx" style="font-size: 12px;">Login</a>

                                    </h2>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdfMemberCode" runat="server" />
                        </div>



                    </div>
                </div>


                <br />
                <br />
                <br />
            </div>



        </div>






    </form>
</body>
</html>
