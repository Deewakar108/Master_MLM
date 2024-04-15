﻿<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="auto_plan_team_structure.aspx.cs" Inherits="Master_MLM.Admin.Report.auto_plan_team_structure"
    Title="Auto Plan Tree Structure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Tree Structure
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panel {
            margin-bottom: 20px;
            background-color: #fff;
            border: 1px solid transparent;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0,0,0,.05);
            box-shadow: 0 1px 1px rgba(0,0,0,.05);
        }

        .panel-default {
            border-color: #ddd;
        }

            .panel-default > .panel-heading {
                color: #333;
                background-color: #f5f5f5;
                border-color: #ddd;
            }

        .panel-heading {
            padding: 10px 15px;
            border-bottom: 1px solid transparent;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
        }

        .panel-body {
            padding: 15px;
        }
    </style>

    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
            background-color: #F700A9;
            color: #fff;
        }

        .level3 {
            width: 38px;
            line-height: 1;
        }

        .tooltip {
            display: none;
            position: absolute;
            border: 1px solid #333;
            border-radius: 5px;
            padding: 10px;
            color: #000;
            font-size: 12px;
            background-color: #F6FF71;
            font-family: sans-serif,'Open Sans',Arial;
        }

        #top {
            margin-right: 0px;
        }

        .style1 {
            height: 20px;
        }

        .child-level-1 {
            font-size: 11px;
        }

        .child-level-2 {
            font-size: 9px !important;
        }
    </style>

    <script type="text/javascript">
        function hoverdiv(e, divid) {
            //alert(divid);
            var left = e.clientX + "px";
            var top = e.clientY + "px";

            var div = document.getElementById(divid);
            //alert(div);
            div.style.left = left;
            div.style.top = top;

            $("#" + divid).toggle();
            return false;
        }
    </script>


    <style type="text/css">
        .colun_round {
            border: 1px solid #000;
            width: 20px;
            height: 20px;
            line-height: 25px;
            margin: 0px 0px 0px 0px;
            padding: 0px;
            float: left;
            -webkit-border-radius: 70px 70px 70px 70px;
            border-radius: 70px 70px 70px 70px;
            text-align: center;
        }

        .parastyle {
            height: 20px;
            line-height: 25px;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 5px;
            float: left;
            text-align: center;
        }

        .bg_rd {
            background-color: red;
        }

        .bg_blue {
            background-color: blue;
        }

        .bg_grien {
            background-color: green;
        }
    </style>



    <style type="text/css">
        .jqstooltip {
            position: absolute;
            left: 30px;
            top: 0px;
            display: block;
            visibility: hidden;
            background: rgb(0, 0, 0) transparent;
            background-color: rgba(0,0,0,0.6);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000);
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000)";
            color: white;
            font: 10px arial, san serif;
            text-align: left;
            white-space: nowrap;
            border: 0px solid white;
            border-radius: 3px;
            -webkit-border-radius: 3px;
            z-index: 10000;
        }

        .jqsfield {
            color: white;
            padding: 5px 5px 5px 5px;
            font: 10px arial, san serif;
            text-align: left;
        }
    </style>


    <style>
        .align {
            text-align: center;
            vertical-align: middle;
        }

            .align span {
                font-size: 12px;
                font-weight: normal;
                text-align: center;
                vertical-align: middle;
            }

            table tbody tr:hover{
                background-color: #fff;
            }
    </style>

    <script>
        function Back() {
            history.go(-1);
            return false;
        }
        function Next() {
            history.go(+1);
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Report</a>
                <a href="#" class="current">Auto Plan Tree Structure</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-share-alt" onclick="$('#<%= btnPreviusPage.ClientID %>').click();"></i></span>
                        <h5>Auto Plan Tree Structure</h5>
                    </div>
                    <div class="widget-content" style="background-color: #fff;">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning" Text=""></asp:Label>
                                <asp:Button ID="btnPreviusPage" OnClick="btnPreviusPage_Click" runat="server" Text="Back"
                                    Style="margin-top: -10px; padding: 8px 20px; display: none;" CssClass="btn btn-primary btn-sm pull-right" />
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:TextBox ID="txt_memberid" runat="server" CssClass="span2" placeholder="Enter member code" ></asp:TextBox>
                                <asp:Button ID="btn_find" runat="server" Text="Find" OnClick="btn_find_Click" CssClass="btn btn-primary"
                                    Style="margin-bottom: 10px;" />
                            </div>
                        </div>

                        <asp:Panel ID="panel_view_tree" runat="server" Visible="false">
                            <div class="row-fluid">

                                <asp:Panel ID="pnlAdmin" runat="server">
                                    <div class="btn btn-success" style="width: 30%; margin: 0 auto; margin-top: 20px; margin-bottom: 30px; border-radius: 5px; display: none;">
                                        <table style="width: 100%;">
                                            <tbody id="topMemberAdmin" runat="server"></tbody>
                                        </table>
                                    </div>

                                    <br />
                                    <table style="width: 100%; margin: 0 auto; border: none;" id="Table2">
                                        <tbody>
                                            <tr>
                                                <td colspan="18" style="height: 23px;" class="align">
                                                    <span runat="server" id="spTopAdminName"></span>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="18" class="align">
                                                    <img src="images/admin-3.gif" style="border-width: 0px;" />&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td colspan="6" class="align">
                                                    <span runat="server" id="spAdmin1" class="child-level-1">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td colspan="6" class="align">
                                                    <span runat="server" id="spAdmin2" class="child-level-1">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td colspan="6" class="align">
                                                    <span runat="server" id="spAdmin3" class="child-level-1">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="18" style="padding: 3px;">
                                                    <!--Only for Hieght-->
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="align" colspan="6">
                                                    <img src="images/Top-3.gif" style="border-width: 0px;" /></td>
                                                <td class="align" colspan="6">
                                                    <img src="images/Top-3.gif" style="border-width: 0px;" /></td>
                                                <td class="align" colspan="6">
                                                    <img src="images/Top-3.gif" style="border-width: 0px;" /></td>
                                            </tr>
                                            <tr>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin4" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin5" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin6" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin7" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin8" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin9" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin10" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin11" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                                <td class="align level3" colspan="2">
                                                    <span runat="server" id="spAdmin12" class="child-level-2">
                                                        <img src="images/grey.jpg" /></span><br />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
                                </asp:Panel>
                            </div>

                            <div class="row-fluid">
                                <div class="span12">
                                    <br />
                                    <br />
                                    <span class="badge badge-important"><i class="icon-user"></i></span>Free<br />
                                    <span class="badge badge-success"><i class="icon-user"></i></span>Paid<br />
                                    <span class="badge"><i class="icon-user"></i></span>Empty
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
