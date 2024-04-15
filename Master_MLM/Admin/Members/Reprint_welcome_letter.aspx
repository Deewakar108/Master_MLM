<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Reprint_welcome_letter.aspx.cs" Inherits="Master_MLM.Admin.Reprint_welcome_letter"
    Title="Reprint Welcome Letter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Reprint Welcome Letter
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Member</a>
                <a href="#" class="current">Member Profile</a>
            </div>
        </div>
        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Member Profile</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="row" style="padding: 20px 0px 20px 0px;">
                                <div class="block">
                                    <div class="block1">
                                        <table  border="0" style="margin: 0px auto 10px auto; border: 1px solid #666666; width: 481px; height: 120px; background-color: #fff;"
                                            class="table-bordered">
                                            <tr>
                                                <td colspan="2" height="30" style="padding: 10px 0px 10px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;"
                                                    class="blue_bg">Reprint Welcome Letter
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Member Code:
                                                </td>
                                                <td style="padding-top: 10px">
                                                    <asp:TextBox ID="txt_membercode" runat="server" Width="175px" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 10px 0px 10px 0px; text-align: center;" width="200">&nbsp;
                                                </td>
                                                <td style="padding: 10px 0px 10px 0px; text-align: justify;">
                                                    <asp:Button ID="btn_find" runat="server" OnClick="btn_find_Click" Text="Find" Style="height: 30px; padding: 2px 0px 0px 0px; width: 100px;"
                                                        Height="25px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                        </div>
                        <div class="row-fluid">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 17px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
