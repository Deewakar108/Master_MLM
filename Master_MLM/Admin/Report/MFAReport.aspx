<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MFAReport.aspx.cs" Inherits="Master_MLM.Admin.Report.MFAReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Auto Plan Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fifth {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        .gridview a {
            display: inline-block;
            margin: 0px 3px 0px 0px;
            padding: 5px 5px 5px 5px;
            background: #336699;
            background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #336699), color-stop(1, #ffffff));
            background: -ms-linear-gradient(bottom, #336699, #ffffff);
            background: -moz-linear-gradient(center bottom, #336699 0%, #ffffff 100%);
            background: -o-linear-gradient(#ffffff, #336699);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr= '#ffffff', endColorstr= '#336699', GradientType=0);
            font-weight: bold;
            width: auto;
            text-decoration: none;
            cursor: pointer;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Report</a>
                <a href="#" class="current">MFA Report</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>MFA Report</h5>
                    </div>
                    <div class="widget-content">
                        <asp:Panel ID="pnl_view" runat="server">
                            <div class="row-fluid">
                                <asp:GridView ID="grdAutoPlan" runat="server" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true"
                                    AutoGenerateColumns="False">
                                    <EmptyDataTemplate>
                                        <div style="text-align: center;">
                                            Member does not exist.
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
                                                <asp:Label ID="lbl_member_name" runat="server" Text='<%# Bind("Member_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponsor Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblleft_child" runat="server" Text='<%# Bind("Sponcer_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Achieved Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmiddle_child" runat="server" Text='<%# Bind("MFA_AchievedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Right Child">
                                            <ItemTemplate>
                                                <asp:Label ID="lblright_child" runat="server" Text='<%# Bind("right_child") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Achieved Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAchievedDate" runat="server" Text='<%# Bind("AchievedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activation date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_activationdate" runat="server" Text='<%#Bind("Verification_date") %>'></asp:Label>
                                                &nbsp;&nbsp;
                                            <asp:Label ID="lbltime" runat="server" Text='<%#Bind("Verification_time") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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
