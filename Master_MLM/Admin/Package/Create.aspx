<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Master_MLM.Admin.Package.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                class="closenotificationpan" alt="" />
        </div>
    </div>

    <!--main-container-part-->
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Package</a>
                <a href="#" class="current">Package Creation</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <!--Action boxes-->
        <div class="container-fluid">

            <!--Chart-box-->
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Package Creation</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">

                            <div class="span12">
                               <table  border="0" style="margin: 0 auto;  height: 217px;" class="round shadow">
                                                
                                                <tr>
                                                    <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Package Name<sup>*</sup>
                                                        :</td>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                                        <asp:DropDownList ID="ddlPackage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPackage_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:TextBox ID="txtPackageID" Enabled="false" runat="server" Width="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Package Name For User :</td>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                                        <asp:TextBox ID="txtPackageNameForShown" runat="server" CssClass="input" Width="221px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Package Name<sup>*</sup>
                                                        :</td>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                                        <asp:TextBox ID="txtPackageName" runat="server" CssClass="input" Width="221px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Enter Package Value<sup>*</sup>
                                                        :</td>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                                        <asp:TextBox ID="txtAmount" runat="server" onkeypress="if (isNaN(this.value + String.fromCharCode(event.keyCode))) return false;" CssClass="input" Width="221px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Monthly Yield (%)<sup>*</sup> :</td>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                                        <asp:TextBox ID="txtYeildPercentage" runat="server" onkeypress="if (isNaN(this.value + String.fromCharCode(event.keyCode))) return false;" CssClass="input" Width="221px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Duration (Month)<sup>*</sup>
                                                        :</td>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                                        <asp:TextBox ID="txtDuration" runat="server" onkeypress="if (isNaN(this.value + String.fromCharCode(event.keyCode))) return false;" CssClass="input" Width="221px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="padding: 20px 0px 10px 0px; text-align: right;">
                                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                                            CssClass="btn btn-success" ValidationGroup="a" />
                                                    </td>
                                                </tr>
                                            </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--End-Chart-box-->

        </div>
    </div>
    <!--end-main-container-part-->

</asp:Content>
