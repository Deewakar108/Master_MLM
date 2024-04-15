<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreatePackage.aspx.cs"
    Inherits="Master_MLM.Admin.CreatePackage"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                class="closenotificationpan" alt="" />
        </div>
    </div>
    <div class="row" style="text-align: center;">
        <br />
        <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
            <div style="margin: 0px auto; padding: 0px; width: 600px;">
                <div style="margin: 0px; float: left; height: auto; width: 100%; padding: 0px;">
                    <table cellspacing="0" cellpadding="0" border="0" style="margin: 0px; float: left; width: 100%; height: 217px; background-color: #FFFFFF;"
                        class="round shadow">
                        <tr>
                            <td colspan="3" style="padding: 10px 0px 3px 30px; text-align: left; color: #FFFFFF; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;"
                                height="20" class="blue_bg">
                                <h2 style="text-align: left; width: 93%; margin: 0px 0px 5px 0px; float: left;">Package Creation</h2>
                            </td>
                        </tr>

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
                        <tr style="display: none;">
                            <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;">&nbsp; Enter Package Value<sup>*</sup>
                                :</td>
                            <td colspan="2" style="padding: 10px 0px 0px 0px; text-align: left;">
                                <asp:TextBox ID="txtAmount" runat="server" onkeypress="if (isNaN(this.value + String.fromCharCode(event.keyCode))) return false;" CssClass="input" Width="221px" Text="0"></asp:TextBox>
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
                            <td colspan="3" style="padding: 20px 0px 10px 0px">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                    Height="30px" Width="100px" ValidationGroup="a" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
