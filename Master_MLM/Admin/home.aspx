<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Master_MLM.Admin.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-center {
            text-align: center !important;
            float: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--main-container-part-->
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a></div>
        </div>
        <!--End-breadcrumbs-->

        <!--Action boxes-->
        <div class="container-fluid minimum-height">
            <%--<div class="quick-actions_homepage">
      <ul class="quick-actions">
        <li class="bg_lb"> <a href="index.html"> <i class="icon-dashboard"></i> <span class="label label-important">20</span> My Dashboard </a> </li>
        <li class="bg_lg span3"> <a href="charts.html"> <i class="icon-signal"></i> Charts</a> </li>
        <li class="bg_ly"> <a href="widgets.html"> <i class="icon-inbox"></i><span class="label label-success">101</span> Widgets </a> </li>
        <li class="bg_lo"> <a href="tables.html"> <i class="icon-th"></i> Tables</a> </li>
        <li class="bg_ls"> <a href="grid.html"> <i class="icon-fullscreen"></i> Full width</a> </li>
        <li class="bg_lo span3"> <a href="form-common.html"> <i class="icon-th-list"></i> Forms</a> </li>
        <li class="bg_ls"> <a href="buttons.html"> <i class="icon-tint"></i> Buttons</a> </li>
        <li class="bg_lb"> <a href="interface.html"> <i class="icon-pencil"></i>Elements</a> </li>
        <li class="bg_lg"> <a href="calendar.html"> <i class="icon-calendar"></i> Calendar</a> </li>
        <li class="bg_lr"> <a href="error404.html"> <i class="icon-info-sign"></i> Error</a> </li>

      </ul>
    </div>--%>
            <!--End-Action boxes-->

            <!--Chart-box-->
            <div class="row-fluid">
                <%--<div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Joining </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lb"><a href="index.html"><i class="icon-dashboard"></i><span class="label label-important">20</span> My Dashboard </a></li>
                                        <li class="bg_lg span3"> <a href="charts.html"> <i class="icon-signal"></i> Charts</a> </li>
                                        <li class="bg_ly"><a href="widgets.html"><i class="icon-inbox"></i><span class="label label-success">101</span> Widgets </a></li>
                                        <li class="bg_lo"><a href="tables.html"><i class="icon-th"></i>Tables</a> </li>
                                        <li class="bg_ls"><a href="grid.html"><i class="icon-fullscreen"></i>Full width</a> </li>
                                        <li class="bg_lo span3"> <a href="form-common.html"> <i class="icon-th-list"></i> Forms</a> </li>
                                        <li class="bg_ls"><a href="buttons.html"><i class="icon-tint"></i>Buttons</a> </li>
                                        <li class="bg_lb"><a href="interface.html"><i class="icon-pencil"></i>Elements</a> </li>
                                        <li class="bg_lg"> <a href="calendar.html"> <i class="icon-calendar"></i> Calendar</a> </li>
                                        <li class="bg_lr"> <a href="error404.html"> <i class="icon-info-sign"></i> Error</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

                

                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>E-Pin </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">                            
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lb"><a href="~/Admin/epin/Generate-epin.aspx" runat="server"><i class="icon-user"></i> Generate E-Pin </a></li>
                                        <li class="bg_lg"> <a href="~/Admin/epin/Distribute-epin.aspx" runat="server"> <i class="icon-user"></i> Distribute E-Pin</a> </li>
                                        <li class="bg_lr"> <a href="~/Admin/epin/E-pin-history.aspx" runat="server"> <i class="icon-user"></i> E-Pin History</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Members </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">                            
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lb"><a href="~/Admin/Report/Total_joining.aspx" runat="server"><i class="icon-user"></i> All Members </a></li>
                                        <%--<li class="bg_lg"> <a href="~/Admin/Report/Total_Free_Joining.aspx" runat="server"> <i class="icon-user"></i> Free Members</a> </li>--%>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Downline </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">                            
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lb"><a href="~/Admin/Report/ternary_team_structure.aspx" runat="server"><i class="icon-user"></i> View Tree </a></li>
                                        <li class="bg_lr"> <a href="~/Admin/Report/Total_left_right_joining.aspx" runat="server"> <i class="icon-user"></i> Genealogy</a> </li>
                                        <li class="bg_lg"> <a href="~/Admin/Report/Genealogy_bt_two_date_positionwise.aspx" runat="server"> <i class="icon-user"></i> Date Wise Genealogy</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Report </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">                            
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lr"><a href="~/Admin/Report/Total_joining.aspx" runat="server"><i class="icon-user"></i> Total Joining</a></li>
                                        <%--<li class="bg_lg"> <a href="~/Admin/Report/Spill_Report.aspx" runat="server"> <i class="icon-user"></i> Spill Report</a> </li>--%>
                                        <li class="bg_lb"> <a href="~/Admin/Report/referralReport.aspx" runat="server"> <i class="icon-user"></i> Referral Report</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Website </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">                            
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lb"><a href="~/Admin/Website/upload_news.aspx" runat="server"><i class="icon-user"></i> Add News </a></li>
                                        <li class="bg_lr"> <a href="~/Admin/Website/edit-news.aspx" runat="server"> <i class="icon-user"></i> Edit News</a> </li>
                                        <li class="bg_lg"> <a href="~/Admin/Website/view_enquiry_page.aspx" runat="server"> <i class="icon-user"></i> View Enquiry</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Setting </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">                            
                            <div class="span12">
                                <div class="quick-actions_homepage text-center">
                                    <ul class="quick-actions">
                                        <li class="bg_lr span3"><a href="~/Admin/Setting/Change_212ede_admin_password.aspx" runat="server"><i class="icon-user"></i> Change Password </a></li>
                                        <li class="bg_lb span3"><a href="~/Admin/Setting/Change_member_password.aspx" runat="server"><i class="icon-user"></i> Change Member's Password </a></li>
                                        <li class="bg_lg span3"> <a href="~/Admin/Setting/show_member_password.aspx" runat="server"> <i class="icon-user"></i> Show Member's Password</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            
            <hr />
        </div>
    </div>
    <!--end-main-container-part-->

</asp:Content>
