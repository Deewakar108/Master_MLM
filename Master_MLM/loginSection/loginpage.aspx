<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginpage.aspx.cs" Inherits="Master_MLM.loginSection.loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body >
    <form id="form1" runat="server">

        <div class="slider_section">

            <div class="member_login">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 " style="margin: 0px auto; float: none;">
                            <div class="member_logininner" style="height: auto; margin-bottom: 5px;">
                                <img src="../images/logo.png" class="img-responsive" style="margin: 4px auto 4px auto; background-color: #fff;" />
                            </div>
                            <div class="member_logininner">
                                <div class="member_loginbox">
                                    <h2 class="member_head">Login
                                    </h2>
                                    <div class="member_line">
                                        <asp:TextBox ID="txt_userid" runat="server" placeholder=" Enter User Id" CssClass="text_boxdesign"></asp:TextBox>

                                    </div>
                                    <div class="member_line">
                                        <asp:TextBox ID="txt_pwd" runat="server" placeholder="Enter Password" CssClass="text_boxdesign" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="member_line" style="margin-top: 0px;">

                                        <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="member_loginbutton" OnClick="btn_login_Click" />
                                        <asp:Label ID="lbl_msg" runat="server" ForeColor="#ff6600" Font-Size="12px"></asp:Label>
                                    </div>
                                    <h2 class="member_head" style="background-color: transparent; border-bottom: 0px; color: #000; margin-bottom: 10px; padding-top: 0px;">
                                        <a href="../Default.aspx" style="font-size: 12px; margin-right: 10px">Home</a>
                                       <%-- <a href="../RegistrationForm.aspx#Registration" style="font-size: 12px; margin-right: 10px">Register Now</a>--%>
                                        <a href="forgotPassword.aspx" style="font-size: 12px;">Forgot Password</a>

                                    </h2>
                                </div>
                            </div>
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
