<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AutoPlanReport.aspx.cs" Inherits="Master_MLM.Admin.Report.AutoPlanReport" %>
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
                <a href="#" class="current">Auto Plan Report</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Auto Plan Report</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:DropDownList ID="ddlAutoPlanList" runat="server" OnSelectedIndexChanged="ddlAutoPlanList_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 1" Value="AutoChild_1"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 2" Value="AutoChild_2"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 3" Value="AutoChild_3"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 4" Value="AutoChild_4"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 5" Value="AutoChild_5"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 6" Value="AutoChild_6"></asp:ListItem>
                                    <asp:ListItem Text="Auto Plan - 7" Value="AutoChild_7"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
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
                                                <asp:Label ID="lbl_member_name" runat="server" Text='<%# Bind("MemberName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Left Child">
                                            <ItemTemplate>
                                                <asp:Label ID="lblleft_child" runat="server" Text='<%# Bind("left_child") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Middle Child">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmiddle_child" runat="server" Text='<%# Bind("middle_child") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Right Child">
                                            <ItemTemplate>
                                                <asp:Label ID="lblright_child" runat="server" Text='<%# Bind("right_child") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Achieved Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAchievedDate" runat="server" Text='<%# Bind("AchievedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
<%--                                        <asp:TemplateField HeaderText="ID" Visible="false">
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
