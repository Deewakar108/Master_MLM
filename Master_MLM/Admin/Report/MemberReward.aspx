<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MemberReward.aspx.cs" Inherits="Master_MLM.Admin.Report.MemberReward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Member</a>
                <a href="#" class="current">Member's Rewards</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Member's Rewards</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <asp:GridView ID="grdReward" runat="server" CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="false" AllowPaging="True" PageSize="500" OnRowCommand="grdReward_RowCommand"
                                OnRowDataBound="grdReward_RowDataBound">
                                <PagerStyle CssClass="pagination-sks" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sl" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Member_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_member_code" runat="server" Text='<%# Bind("MemberCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sponsor">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sponcer_code" runat="server" Text='<%# Bind("Sponcer_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_mobile" runat="server" Text='<%#Bind("Mobile_number") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Reward Name">
                                        <ItemTemplate>
                                             <asp:Label ID="lblRewardName" runat="server" Text='<%#Bind("RewardName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Achieved Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_date" runat="server" Text='<%# Bind("DateOfAchievement") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                             <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Paid Date">
                                        <ItemTemplate>
                                             <asp:Label ID="lblPaidDate" runat="server" Text='<%#Bind("PaidDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" CommandArgument='<%# Bind("ID") %>' CommandName="IsSubmit" />
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
