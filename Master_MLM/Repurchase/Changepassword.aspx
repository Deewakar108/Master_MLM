<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="Master_MLM.Repurchase.Changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Change Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        td, th {
            padding: 5px 10px;
            text-align: left;
        }

            td span {
                padding: 0px 0px;
            }

        .panel-body {
            overflow: auto;
            padding: 15px 0px;
        }

        .btn {
            vertical-align: top;
        }

        option {
            color: #222 !important;
        }

        .textbx-box {
            margin: 0px;
            padding: 0px;
            width: 50%;
            height: auto;
            float: left;
            border-top: 1px solid #eeeeee;
            border-bottom: 1px solid #eeeeee;
        }

        .textbx-lbl-name {
            padding-top: 15px;
            width: 180px;
            float: left;
            text-align: right;
            font-size: 14px;
            font-weight: normal;
            line-height: 20px;
            display: block;
            margin-bottom: 5px;
        }

        .textbx-wpr {
            margin-left: 200px;
            padding: 10px 0;
        }

        .btn {
            padding: 4px 15px;
        }

        .fnl-submit-tbl-styl {
            border: 1px solid #CCCCCC;
            padding: 0px;
            margin: 10px;
            width: 605px;
            font-family: arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            background-color: #FFFFFF;
            float: right;
        }

        @media only screen and (max-width:800px) {
            .textbx-box {
                width: 100%;
            }

            .textbx-lbl-name {
                width: 100%;
                text-align: left;
            }

            .textbx-wpr {
                margin-left: 0px;
                padding: 10px 0;
            }

            .fnl-submit-tbl-styl {
                margin: 10px 0px;
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Change Password</a></h4>
            <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>

            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <div class="grd-over-flow">
                        <div class="textbx-box"  style="width: 100%;">
                            <p class="textbx-lbl-name">Old password  :</p>
                            <div class="textbx-wpr">
                                <asp:TextBox ID="txt_old_password" runat="server"></asp:TextBox>
                                <asp:Label ID="lbl_oldpwd" runat="server" ForeColor="Red" Font-Size="9pt" Width="200px"></asp:Label>
                            </div>
                        </div>
                        <div class="textbx-box"  style="width: 100%;">
                            <p class="textbx-lbl-name">New password  :</p>
                            <div class="textbx-wpr">
                                <asp:TextBox ID="txt_new_password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="textbx-box" style="width: 100%;">
                            <p class="textbx-lbl-name">Confirm password   :</p>
                            <div class="textbx-wpr">
                                <asp:TextBox ID="txt_confirm_password" runat="server"></asp:TextBox>
                                <asp:Label ID="lbl_confirmpwd" runat="server" ForeColor="Red" Font-Size="9pt" Width="200px"></asp:Label>
                            </div>
                        </div>
                        <div class="textbx-box" style="width: 100%;">
                            <p class="textbx-lbl-name"></p>
                            <div class="textbx-wpr">
                                <asp:Button ID="btn_change_pwd" runat="server" class="btn btn-success" Text="Find" OnClick="btn_change_pwd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
