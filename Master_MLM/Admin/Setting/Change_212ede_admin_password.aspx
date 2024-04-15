<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Change_212ede_admin_password.aspx.cs" Inherits="Master_MLM.Admin.Change_212ede_admin_password"
    Title="Change Admin Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Change Admin Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fifteen {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        .block {
            margin: 0px 0px 10px 0px;
            padding: 0px;
            float: left;
            width: 100%;
            height: auto;
        }

        .block1 {
            margin: 0px auto;
            padding: 0px;
            width: 1100px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Setting</a>
                <a href="#" class="current">Change Own Password</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Change Own Password</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">Old password :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_old_password" runat="server"  TextMode="Password"></asp:TextBox>
                                        <asp:Label ID="lbl_oldpwd" runat="server" ForeColor="Red" Font-Size="9pt" Width="200px"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">New password :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_new_password" runat="server"  TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Confirm password :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_confirm_password" runat="server"   TextMode="Password"></asp:TextBox>
                                <asp:Label ID="lbl_confirmpwd" runat="server" ForeColor="Red" Font-Size="9pt" Width="200px"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btn_change_pwd" Text="Submit" runat="server" CssClass="btn btn-success" OnClick="btn_change_pwd_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div style="text-align: center;" class="span12">
                                <asp:Label ID="lbl_msg" runat="server" ForeColor="#FF6600" Font-Size="12pt"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
