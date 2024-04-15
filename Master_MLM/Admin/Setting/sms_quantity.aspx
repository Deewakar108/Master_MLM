<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="sms_quantity.aspx.cs" Inherits="Master_MLM.Admin.sms_quantity"
    Title="SMS Quantity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    SMS Quantity
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .table th, .table td {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Setting</a>
                <a href="#" class="current">SMS Quantity</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>SMS Quantity</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span6 text-center">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-primary btn-lg" OnClick="btnRefresh_Click" />
                                <br />
                                <br />
                                <asp:Label ID="lbl_avl" runat="server" CssClass="label label-info"></asp:Label>
                            </div>
                            <div class="span6 text-center">
                                <br />
                                <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning" Font-Size="45" Style="padding: 25px;"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row-fluid">
                            <asp:GridView ID="grdSMS" runat="server" CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" OnRowCommand="grd_epin_distribute_RowCommand"
                                OnRowDataBound="grd_epin_distribute_RowDataBound"
                                AllowSorting="True">
                                <PagerStyle CssClass="pagination-sks" />
                                <EmptyDataTemplate>
                                    <div style="text-align: center;">
                                        No Record Found.
                                    </div>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Authentication Key">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluid" runat="server" Font-Names="Arial" Text='<%#Bind("uid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sender ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsender" runat="server" Font-Names="Arial" Text='<%#Bind("sender") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Route">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRoute" runat="server" Font-Names="Arial" Text='<%#Bind("route") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" Text="SEND" CssClass="btn btn-primary" CommandName="SMS" CommandArgument='<%# Bind("Status") %>' />
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


</asp:Content>
