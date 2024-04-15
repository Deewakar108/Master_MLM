﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ClosingReport.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.ClosingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Closing Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
    <script type="text/javascript">
        function openWindow(code) {
            window.open('../../Admin/Payout/Incomedetasils.aspx?mcode=' + code, 'open_window', ' width=1000, height=480, left=150, top=100');
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Closing</a>
                <a href="#" class="current">Closing Report</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Closing Report</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                Closing Date :
                                <asp:DropDownList ID="ddlClosingDate" runat="server" CssClass="span2"></asp:DropDownList>
                                <asp:Button ID="btn_find" Style="margin-bottom: 10px;" runat="server" OnClick="btn_find_Click" Text="Find" CausesValidation="False" CssClass="btn btn-primary" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_view" runat="server" Visible="false">
                            <div class="row-fluid">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="false" OnPageIndexChanging="grd_view_PageIndexChanging" PageSize="200" AllowPaging="true" ShowHeaderWhenEmpty="true">
                                    <PagerStyle CssClass="pagination-sks" />

                                    <EmptyDataTemplate>
                                        <p>No Data Found.</p>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_code" runat="server" Font-Names="Arial" Text='<%#bind("Member_code") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_name" runat="server" Font-Names="Arial" Text='<%#bind("Member_name") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Previour Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Font-Names="Arial" Text='<%#bind("pre_left") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Previous Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_enddate" runat="server" Font-Names="Arial" Text='<%#bind("pre_right") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Carry Forward Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_closingdate" runat="server" Font-Names="Arial" Text='<%#bind("Current_left") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Carry Forward Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_joiningdate" runat="server" Font-Names="Arial" Text='<%#bind("Current_right") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pair">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Pair" runat="server" Font-Names="Arial" Text='<%#bind("Pair") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         
                                        <asp:TemplateField HeaderText="Lapse Pair">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_lapsepair" runat="server" Font-Names="Arial" Text='<%#bind("Lapsepair") %>'
                                                    CssClass="sp_style"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
