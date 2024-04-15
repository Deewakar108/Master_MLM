<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RepurchaseClosingReport.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.RepurchaseClosingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Repurchase Closing Report
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
                <a href="#" class="current">Repurchase Closing Report</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Repurchase Closing Report</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="JAN">JAN</asp:ListItem>
                                    <asp:ListItem Value="02" Text="FEB">FEB</asp:ListItem>
                                    <asp:ListItem Value="03" Text="MAR">MAR</asp:ListItem>
                                    <asp:ListItem Value="04" Text="APR">APR</asp:ListItem>
                                    <asp:ListItem Value="05" Text="MAY">MAY</asp:ListItem>
                                    <asp:ListItem Value="06" Text="JUN">JUN</asp:ListItem>
                                    <asp:ListItem Value="07" Text="JUL">JUL</asp:ListItem>
                                    <asp:ListItem Value="08" Text="AUG">AUG</asp:ListItem>
                                    <asp:ListItem Value="09" Text="SEP">SEP</asp:ListItem>
                                    <asp:ListItem Value="10" Text="OCT">OCT</asp:ListItem>
                                    <asp:ListItem Value="11" Text="NOV">NOV</asp:ListItem>
                                    <asp:ListItem Value="12" Text="DEC">DEC</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="span2">
                                </asp:DropDownList>
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
                                        <div style="text-align: center;">
                                            No Record Found
                                        </div>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_name" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponcer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Sponcer_name" runat="server" Text='<%# Bind("SponsorName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponcer Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Sponcer_name" runat="server" Text='<%# Bind("Sponcer_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Mobile_number" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Income Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_incometype" runat="server" Text='<%# Bind("Income_type") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="BV">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_bv" runat="server" Text='<%# Bind("Pair_no") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_TDS" runat="server" Text='<%# Bind("Totalamount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_TDS" runat="server" Text='<%# Bind("TDS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admin Charge">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_AdminCharge" runat="server" Text='<%# Bind("admincharge") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Final Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Final_amount" runat="server" Text='<%# Bind("Final_amount") %>'></asp:Label>
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
