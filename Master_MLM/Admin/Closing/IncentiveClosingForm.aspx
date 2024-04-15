﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="IncentiveClosingForm.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.IncentiveClosingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Royalty Closing
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function OnClick() {
            $("#<%= btnSubmit.ClientID%>").val("Work is in Progress...");
            return true;
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Closing</a>
                <a href="#" class="current">Royalty Closing</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Make Royalty  Closing</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblPreviousClosingDate" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                                <asp:HiddenField ID="hdfClosingNumber" runat="server" />
                                <asp:HiddenField ID="hdfDeleteID" runat="server" />
                            </div>
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
                                    <asp:ListItem Value="2018" Text="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019" Text="2019">2019</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-bottom: 10px;" OnClientClick="return OnClick();" CssClass="btn btn-success"
                                    OnClick="btnSubmit_Click" />
                            </div>
                            <div class="span12" style="text-align: center;">

                                <br />
                                <asp:Label ID="lblMessage" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <asp:Panel ID="pnlAchivedMember" runat="server" Visible="false">
                
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>All Member </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">

                            <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="false" OnPageIndexChanging="grd_view_PageIndexChanging" PageSize="200" AllowPaging="true" ShowHeaderWhenEmpty="true">
                                <PagerStyle CssClass="pagination-sks" />
                                <EmptyDataTemplate>
                                    <div style="text-align: center;">
                                        No Member Found.
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
                                            <asp:Label ID="lbl_Member_name" runat="server" Text='<%# Bind("Member_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Member_name" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sponcer Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Sponcer_name" runat="server" Text='<%# Bind("Sponcer_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sponcer Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Sponcer_name" runat="server" Text='<%# Bind("Sponcer_code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Mobile_number" runat="server" Text='<%# Bind("Mobile_number") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Achieved Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAchievedDate" runat="server" Text='<%# Bind("AchievedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PaidDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaidDate" runat="server" Text='<%# Bind("PaidDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            </asp:Panel>
        </div>
    </div>

</asp:Content>
