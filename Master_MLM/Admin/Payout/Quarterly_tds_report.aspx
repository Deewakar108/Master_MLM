﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Quarterly_tds_report.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.Quarterly_tds_report" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Tds Report Quarterly
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.seventh {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
    <script type="text/javascript">
        function printTable() {
            var printContent = document.getElementById("tblPrintIQ");
            var windowUrl = 'abount:blank';
            var num;
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(num, windowName, 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Payout</a>
                <a href="#" class="current">TDS Report Quarterly</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_export.ClientID %>').click();"></i></span>
                        <h5>TDS Report Quarterly</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:DropDownList ID="ddl_quarter" runat="server" CssClass="span1">
                                    <asp:ListItem>Q1</asp:ListItem>
                                    <asp:ListItem>Q2</asp:ListItem>
                                    <asp:ListItem>Q3</asp:ListItem>
                                    <asp:ListItem>Q4</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddl_s_year" runat="server" CssClass="span1" Style="padding-left: 0;">
                                </asp:DropDownList>
                                <asp:Button ID="btn_find" runat="server"  OnClick="btn_find_Click" Text="Find" Style="margin-left: 10px; margin-bottom: 10px;" CssClass="btn btn-primary" />
                            </div>
                        </div>
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0"  /></asp:LinkButton>
                            <asp:ImageButton ID="img_export" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 20px" OnClick="img_export_Click" />
                        </div>

                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid" id="tblPrintIQ">
                                <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered data-table dataTable"
                                    OnRowDataBound="grd_payout_list_RowDataBound">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_code" runat="server" Font-Names="Arial" Text='<%#bind("Member_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_name" runat="server" Font-Names="Arial" Text='<%#bind("Member_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_bank_name" runat="server" Font-Names="Arial" Text='<%#Bind("Bank_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Branch_name" runat="server" Font-Names="Arial" Text='<%#Bind("Branch_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account no.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Account_number" runat="server" Font-Names="Arial" Text='<%#Bind("Account_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ifsc code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Ifsc_code" runat="server" Font-Names="Arial" Text='<%#Bind("Ifsc_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pancard">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Pancard" runat="server" Font-Names="Arial" Text='<%#Bind("Pan_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS">
                                            <ItemTemplate>

                                                <asp:Label ID="lbl_tot" runat="server" Font-Names="Arial"></asp:Label>


                                                <asp:Label ID="lbl_tds" runat="server" Font-Names="Arial" Visible="false"></asp:Label>
                                                <asp:Label ID="lbl_ref" runat="server" Font-Names="Arial" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_startdate" runat="server" Font-Names="Arial"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <div class="span12">
                                    Total Amount : <asp:Label ID="lbl_total_paout" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
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
