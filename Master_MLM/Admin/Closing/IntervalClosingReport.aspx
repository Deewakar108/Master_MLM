<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="IntervalClosingReport.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.IntervalClosingReport" %>

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
                                <asp:Button ID="btn_find" style="margin-bottom: 10px;" runat="server" OnClick="btn_find_Click" Text="Find" CausesValidation="False" CssClass="btn btn-primary" />
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
                                        <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Mobile_number" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Carry">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCarryAmount" runat="server" Text='<%# Bind("carryAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Final Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Final_amount" runat="server" Text='<%# Bind("Final_amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href="#" class="btn btn-info btn-sm" onclick="openWindow('<%#Eval("Member_code")+"&startdate="+Eval("Start_date")+"&enddate="+Eval("End_date") %>');">View </a>
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
