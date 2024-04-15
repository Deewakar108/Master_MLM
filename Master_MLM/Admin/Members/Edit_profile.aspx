<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Edit_profile.aspx.cs" Inherits="Master_MLM.Admin.Edit_profile"
    Title="Edit Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Edit Profile
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
                <a href="#" class="current">Edit Profile</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Edit Profile</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="row" style="padding: 30px 0px 0px 0px;">
                                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                    <div style="margin: 0px auto;">
                                        <table class="table sks-table">
                                            <tr>
                                                <td>Member code :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_member_id" runat="server" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="2">
                                                    <asp:Button ID="btn_find" runat="server" OnClick="btn_find_Click" Text="Find" CssClass="btn btn-primary" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 10px 0px 10px 0px; text-align: center;">
                                                    <asp:Label ID="lbl_message" runat="server"  CssClass="lbl lbl-warning"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>


                                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                    <div style="margin: 0px auto; padding: 0px; width: 1000px;">
                                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                                            <table>
                                                <tr>
                                                    <td colspan="4" style="padding: 10px 0px 10px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; background-color: #313235;"
                                                        class="blue_bg">
                                                        <h2 style="text-align: center; width: 93%; margin: 0px; float: left;">Edit Profile</h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 0px 0px 0px 0px; font-family: ebrima; font-size: 15px; font-weight: bold; text-decoration: underline; background-color: #FFFFFF;"
                                                        colspan="4">
                                                        <h2 class=" blue_bg" style="margin: 0px; padding: 5px 0px 5px 20px; width: 205px; float: left; font-size: 17px; color: #FFFFFF;">Joining Information
                                                        </h2>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panel2" runat="server" Visible="false">
                                                    <tr>
                                                        <td class="lefttd">Sponsor Code :
                                                        </td>
                                                        <td class="righttd">
                                                            <asp:TextBox ID="txt_sponsorcode" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td class="lefttd">Sponsor Name :
                                                        </td>
                                                        <td class="righttd">
                                                            <asp:TextBox ID="txt_sponsorname" runat="server" ReadOnly="true" Style="width: 214px;"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>

                                                <tr>
                                                    <td class="lefttd">Member Code :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_member_code" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">Purchase Product :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:Label ID="lbl_joining_package" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd" style="padding-bottom: 10px">Purchase Date :
                                                    </td>
                                                    <td class="righttd" style="padding-bottom: 10px">


                                                        <asp:Label ID="lbl_joining_date" runat="server"></asp:Label>


                                                    </td>
                                                    <td class="lefttd" style="padding-bottom: 10px">Verification Date</td>
                                                    <td class="righttd">
                                                        <asp:Label ID="lbl_verificationdate" runat="server" s=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="text-align: left; padding: 0px 10px 0px 0px; font-family: ebrima; font-size: 15px; font-weight: bold; text-decoration: underline; background-color: #FFFFFF;"
                                                        colspan="4">
                                                        <h2 class=" blue_bg" style="margin: 0px; padding: 5px 0px 5px 20px; width: 205px; float: left; font-size: 17px; color: #FFFFFF;">Personal Details
                                                        </h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Name :
                                                    </td>
                                                    <td class="righttd" colspan="3">
                                                        <asp:TextBox ID="txt_name" runat="server" class="textcolor" Style="width: 250px;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                            Display="Dynamic" ControlToValidate="txt_name" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Father&#39;s Name :
                                                    </td>
                                                    <td class="righttd" colspan="3">
                                                        <asp:TextBox ID="txt_fathername" runat="server" class="textcolor" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Date of Birth :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_dob" runat="server" class="textcolor"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">Gender :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:DropDownList ID="ddl_gender" runat="server" Style="color: Green; font-weight: bold; width: 90px;">
                                                            <asp:ListItem>Male</asp:ListItem>
                                                            <asp:ListItem>Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Address :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_address" runat="server" class="textcolor" Style="width: 250px; height: 50px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd" style="padding-bottom: 10px">Pin Code :
                                                    </td>
                                                    <td class="righttd" style="padding-bottom: 10px">
                                                        <asp:TextBox ID="txt_pincode" runat="server" class="textcolor" Width="200px" MaxLength="6"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td class="lefttd">State :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:DropDownList ID="ddl_state" runat="server" Style="color: Green; font-weight: bold; width: 150px;" AutoPostBack="True" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="lefttd">District :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:DropDownList ID="ddl_district" runat="server" Style="color: Green; font-weight: bold; width: 150px;">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">City :</td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_city" runat="server" class="textcolor" Width="250px"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">Mobile Number :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txtmobileno" runat="server" class="textcolor" Width="214px" ></asp:TextBox>
                                                        <asp:HiddenField ID="hdfMobileNo" runat="server" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            Display="Dynamic" ControlToValidate="txtmobileno" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd" style="padding-bottom: 10px">Email Id :
                                                    </td>
                                                    <td class="righttd" style="padding-bottom: 10px">
                                                        <asp:TextBox ID="txtemailid" runat="server" class="textcolor" Width="250px"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd" style="padding-bottom: 10px">Pan Number : </td>
                                                    <td class="righttd" style="padding-bottom: 10px">
                                                        <asp:TextBox ID="txtpannumber" runat="server" class="textcolor" Width="214px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="text-align: left; padding: 0px 10px 0px 0px; font-family: ebrima; font-size: 15px; font-weight: bold; text-decoration: underline; background-color: #FFFFFF;"
                                                        colspan="4">
                                                        <h2 class=" blue_bg" style="margin: 0px; padding: 5px 0px 5px 20px; width: 205px; float: left; font-size: 17px; color: #FFFFFF;">Nominee Details
                                                        </h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd">Nominee Name :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_nomineename" runat="server" class="textcolor" Style="width: 250px;"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd">Nominee Relation :
                                                    </td>
                                                    <td class="righttd">
                                                        <asp:TextBox ID="txt_nomineerelation" runat="server" class="textcolor"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lefttd" style="padding-bottom: 10px">Nominee Age :
                                                    </td>
                                                    <td class="righttd" style="padding-bottom: 10px">
                                                        <asp:TextBox ID="txt_nomineeage" runat="server" class="textcolor"></asp:TextBox>
                                                    </td>
                                                    <td class="lefttd" style="padding-bottom: 10px">Nominee Gender :
                                                    </td>
                                                    <td class="righttd" style="padding-bottom: 10px">
                                                        <asp:DropDownList ID="ddl_nomineegender" runat="server" Style="color: Green; font-weight: bold; width: 90px;">
                                                            <asp:ListItem>Male</asp:ListItem>
                                                            <asp:ListItem>Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>

                                                <tr>
                                                    <td style="text-align: center; padding: 20px 10px 10px 0px" colspan="4">
                                                        <asp:Button ID="btn_update" CssClass="btn btn-success"  Text="Update" runat="server" OnClick="btn_update_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; padding: 20px 10px 10px 0px" colspan="4">&nbsp;
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




    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_msg" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                class="closenotificationpan" alt="" />
        </div>
    </div>

</asp:Content>
