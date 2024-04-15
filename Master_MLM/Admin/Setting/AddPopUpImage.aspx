<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddPopUpImage.aspx.cs"
    Inherits="Master_MLM.Admin.AddPopUpImage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Create Joining Products Kit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.third {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        .input {
        }

        .table th, .table td {
            padding: 8px;
            line-height: 20px;
            text-align: center !important;
            vertical-align: middle !important;
            border-top: 1px solid #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Setting</a>
                <a href="#" class="current">Reward Popup Add Creation</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Popup Add Creation</h5>
                    </div>
                    <div class="widget-content" style="background-color: #fff;">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid text-center">
                            <div class="span3"></div>
                            <div class="span6" style="text-align: center; border: 1px solid lightgray; padding: 20px; margin: 0 auto">
                                Image :
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" Style="padding: 5px 15px;" />
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <br />
                                <br />
                                <br />
                                Note: Image Size must be less than 1MB. [Height : 1800 and Width : 900]
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="row-fluid">
                            <div class="span12">
                                <asp:GridView ID="grdImage" runat="server" AutoGenerateColumns="False" Style="width: 100%;" OnRowCommand="grdImage_RowCommand"
                                    OnRowDataBound="grdImage_RowDataBound" CssClass="table table-bordered data-table dataTable">
                                    <EmptyDataTemplate>
                                        <div style="text-align: center; font-weight: bold;">
                                            No Record Found.
                                        </div>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" Width="150" ImageUrl='<%# Bind("ImagePath") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Button ID="btnActive" CommandName="IsActive" CssClass="btn btn-primary" CommandArgument='<%#Bind("IsActive") %>' runat="server" Text="Active"
                                                    Style="padding: 5px 10px;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div id="notification" style="display: none;">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                class="closenotificationpan" alt="" />
        </div>
    </div>
    <div class="row" style="text-align: center; display: none;">
        <br />
        <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
            <div style="margin: 0px auto; padding: 0px; width: 600px;">
                <div style="margin: 0px; float: left; height: auto; width: 100%; padding: 0px;">
                    <table cellspacing="0" cellpadding="0" border="0" style="margin: 0px; float: left; width: 100%; height: 217px; background-color: #FFFFFF;"
                        class="round shadow">
                        <tr>
                            <td colspan="3" style="padding: 10px 0px 3px 30px; text-align: left; color: #FFFFFF; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;"
                                height="20" class="blue_bg">
                                <h2 style="text-align: left; width: 93%; margin: 0px 0px 5px 0px; float: left;">Popup Add Creation</h2>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding: 10px 20px 0px 0px; font-size: 15px; font-weight: bold; width: 40%;">Image
                            </td>
                            <td style="text-align: left; padding: 10px 20px 0px 0px; font-size: 15px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding: 10px; text-align: center;"></td>
                        </tr>
                        <%--<tr>
                            <td style="text-align: right; padding: 10px 20px 0px 0px; font-size: 15px;">From 
                            </td>
                            <td style="padding: 10px 0px 0px 0px; text-align: justify;">
                                <asp:DropDownList ID="ddlFromDate" runat="server"></asp:DropDownList> 
                                <asp:DropDownList ID="ddlFromMonth" runat="server"></asp:DropDownList>                                                               
                                <asp:DropDownList ID="ddlFromYear" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding: 10px 20px 0px 0px; font-size: 15px;">To 
                            </td>
                            <td style="padding: 10px 0px 0px 0px; text-align: justify;">
                                <asp:DropDownList ID="ddlToDate" runat="server"></asp:DropDownList> 
                                <asp:DropDownList ID="ddlToMonth" runat="server"></asp:DropDownList>                                                               
                                <asp:DropDownList ID="ddlToYear" runat="server"></asp:DropDownList>                            
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="padding: 10px 0px 0px 0px; text-align: center;" colspan="2">
                                <br />

                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: left; padding-left: 15px;">
                                <br />

                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="margin: 0px; padding: 0px; float: left; width: 100%; height: 175px;" class="scrollbar">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
