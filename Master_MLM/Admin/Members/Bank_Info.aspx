﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Bank_Info.aspx.cs"
    Inherits="Master_MLM.Admin.Bank_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Bank Info
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


        table {
            width: 100%;
            margin: 0px;
            border-spacing: 0px;
            background-color: #EDF1F2;
        }

        .heading {
            background: url(images/h3-slogan-border.png) no-repeat 44px bottom;
            padding-bottom: 0px;
        }

        .bottomtd {
            padding: 5px 10px 10px 0px;
        }

        .lefttd {
            width: 170px;
            text-align: left;
            padding: 5px 0px 0px 40px;
            font-family: ebrima;
            font-size: 15px;
        }

        .righttd {
            padding: 5px 0px 0px 0px;
            text-align: left;
        }

        .trstyle {
            margin: 0px;
            padding: 7px;
            background-color: #F4F4F4;
            border-top: solid 1px #222;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Member</a>
                <a href="#" class="current">Bank Information</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Bank Information</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="row" style="padding: 30px 0px 0px 0px;">
                                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                    <div style="margin: 0px auto; padding: 0px; width: 1000px; height: 205px;">
                                        <table class="table sks-table">
                                            
                                            <tr>
                                                <td>Member code :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_member_id" runat="server" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;">
                                                    <asp:Button ID="btn_find" runat="server" OnClick="btn_find_Click" Text="Find" CssClass="btn btn-primary" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;">
                                                    <asp:Label ID="lbl_message" runat="server" CssClass="lbl lbl-warning"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                    <div style="margin: 0px auto; padding: 0px; width: 1000px;">
                                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                                            <table class="table table-bordered" border="0">
                                                <tr>
                                                    <td colspan="4" height="30" style="padding: 10px 0px 10px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; background-color: #313235;"
                                                        class="blue_bg">
                                                        <h2 style="text-align: center; width: 93%; margin: 0px; float: left;">Edit Your Bank Info
                                                        </h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 0px 0px 0px 0px; font-family: ebrima; font-size: 15px; font-weight: bold; text-decoration: underline; background-color: #FFFFFF;"
                                                        colspan="4">
                                                        <h2 class=" blue_bg" style="margin: 0px; padding: 5px 0px 5px 20px; width: 205px; float: left; font-size: 17px; color: #FFFFFF;">Bank Information
                                                        </h2>
                                                    </td>
                                                </tr>



                                            </table>

                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lefttd">Payee Name :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_paename" runat="server" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">Bank Name :</td>
                                                    <td class="righttd">

                                                        <asp:TextBox ID="txt_bankname" runat="server" Style="width: 250px;"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">&nbsp;Account No :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_accno" runat="server" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">IFSC Code :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_ifsccode" runat="server" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Bank Branch :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_bankbranch" runat="server" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">Pan Number :</td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txtPanNumber" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Aadhar Number :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txtAadhar" runat="server" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">&nbsp;</td>
                                                    <td class="righttd">&nbsp;</td>
                                                </tr>

                                            </table>
                                            <table>

                                                <tr>
                                                    <td style="text-align: center; padding: 20px 10px 10px 0px" colspan="4">
                                                        <asp:Button ID="btn_update" CssClass="btn btn-success" Text="Update" runat="server" OnClick="btn_update_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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







</asp:Content>
