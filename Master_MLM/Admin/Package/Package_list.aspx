<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Package_list.aspx.cs" Inherits="Master_MLM.Admin.Package_list" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   
   <%--  <style type="text/css">
        .ddsmoothmenu ul li a.third {
            color: rgb(255, 255, 255);
            background: #5723A2;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
    </style>
<link href="../css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />--%>

    <link href="../css/custom.css" rel="stylesheet" />
    <script>
        function AlertMe() { document.getElementById("sksButton").click(); }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('a#popup').live('click', function (e) {

                var page = $(this).attr("href")  //get url of link

                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    width: 600,
                    height: 300,
                    title: "Package Info",


                });
                $dialog.dialog('open');
                e.preventDefault();
            });
        });
    </script>
    <%--<style type="text/css">
        .ui-dialog .ui-dialog-content {
            position: relative;
            border: 0;
            padding: .5em 1em;
            background: none;
            overflow: hidden;
            zoom: 1;
        }

        .ui-widget-header {
            padding: 4px 5px!important;
            margin: 2px 0px!important;
            color: #fff!important;
            color: #e9e9e9!important;
            border-bottom: 1px solid #a14da8;
            border-top: 1px solid #a14da8;
            background-color: #aaa;
            background: -webkit-gradient(linear, left top, left bottom, from(#1aaef3), to(#0993d3))!important;
            background: -webkit-linear-gradient(top, #a14da8, #a14da8)!important;
            background: -moz-linear-gradient(top, #1aaef3, #0993d3)!important;
            background: -ms-linear-gradient(top, #1aaef3, #0993d3)!important;
            background: -o-linear-gradient(top, #1aaef3, #0993d3)!important;
            background: linear-gradient(top, #1aaef3, #0993d3)!important;
            box-shadow: none!important;
            color: #fff!important;
            font-weight: bold!important;
        }
    </style>--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="notification" style="display: none;">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                class="closenotificationpan" alt="" />
        </div>
    </div>

    <!--main-container-part-->
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Package</a>
                <a href="#" class="current">Package List</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <!--Action boxes-->
        <div class="container-fluid">

            <!--Chart-box-->
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Package List</h5>
                    </div>
                    <div class="widget-content" style="min-height: 400px;">
                        <div class="row-fluid">

                            <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" Style="width: 100%;"
                                OnRowCancelingEdit="gridview_RowCancelingEdit" OnRowEditing="gridview_RowEditing" ShowHeaderWhenEmpty="true"
                                OnRowUpdating="gridview_RowUpdating" CssClass="table table-bordered data-table dataTable" OnRowCommand="gridview_RowCommand">
                                <EmptyDataTemplate>
                                    <div style="text-align: center;">
                                    No Record Found.
                                </div>
                                </EmptyDataTemplate>
                                <Columns>


                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Package Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Productname" runat="server" Text='<%#Bind("Package_name") %>'></asp:Label>
                                            <asp:Label ID="lbl_product_id" runat="server" Text='<%#Bind("Package_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-Width="120">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_amount" runat="server" Text='<%#Bind("Package_amount") %>'></asp:Label>

                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_amount" runat="server" Height="30px" TextMode="SingleLine" Width="80px"
                                                Text='<%#Bind("Package_amount") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="BV">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PV" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_PV" runat="server" Height="30px" TextMode="SingleLine" Width="80px"
                                                Text='<%#Bind("BV") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Capping" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Capping" runat="server" Text='<%#Bind("Capping") %>'></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_Capping" runat="server" Height="30px" TextMode="SingleLine" Width="80px"
                                                Text='<%#Bind("Capping") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Matching Income" ItemStyle-Width="120" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMatchingIncome" runat="server" Text='<%#Bind("MatchingIncome") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Repurchase BV" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRepurchaseBV" runat="server" Text='<%#Bind("RepurchaseBV") %>'></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRepurchaseBV" runat="server" Height="30px" TextMode="SingleLine" Width="80px"
                                                Text='<%#Bind("RepurchaseBV") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="BV" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PV" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_PV" runat="server" Height="30px" TextMode="SingleLine" Width="80px"
                                                Text='<%#Bind("BV") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Reward Point" ItemStyle-Width="120" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRewardPoint" runat="server" Text='<%#Bind("RewardPoint") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="" ItemStyle-Width="120">
                                        <ItemTemplate>
                                            <i class="grid-icon icon-trash" onclick="$('#ContentPlaceHolder1_gridview_btnDelete_<%# Container.DataItemIndex %>').click();"></i>
                                            <asp:Button ID="btnDelete" CommandArgument='<%#Bind("Package_id") %>' CommandName="IsDelete" runat="server" Text="Delete" style="display: none;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    

                                    <%--<asp:TemplateField HeaderText="Duration">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDuration" runat="server" Text='<%#Bind("Duration") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Monthly Yield (%)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonthlyYield" runat="server" Text='<%#Bind("MonthlyYield") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package Name For User">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPackageNameForShown" runat="server" Text='<%#Bind("PackageNameForShown") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("ID") %>' Visible="false"></asp:Label>
                                                            <asp:ImageButton ID="img_delete" runat="server" Height="16px" ImageUrl="~/images/delete-icon.png"
                                                                OnClientClick="return confirm('Are you sure want delete this data ?')" OnClick="img_delete_Click" />

                                                            <a id="popup" href='Package_full_info.aspx?package_id=<%#Eval("Package_id")%>'>
                                                                <img src="../images/info.png" alt=""
                                                                    style="border-style: none; border-color: inherit; border-width: 0px; height: 25px; width: 25px;" />


                                                            </a>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <!--End-Chart-box-->

        </div>
    </div>
    <!--end-main-container-part-->

    <div class="btn btn-success" style="display: none;" id="sksButton" onclick="$('#gritter-notice-wrapper1').show().fadeOut(8000);">
        SKS
    </div>
    <div id="gritter-notice-wrapper1" style="display: none;">
        <div id="gritter-item-1" class="gritter-item-wrapper  hover" style="">
            <div class="gritter-top"></div>
            <div class="gritter-item">
                <div class="gritter-close" style="display: block;" onclick="$('#gritter-notice-wrapper1').fadeOut(500);"></div>
                <img src="../img/demo/envelope.png" class="gritter-image" />
                <div class="gritter-with-image">
                    <span class="gritter-title">Message</span>
                    <p>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="gritter-bottom"></div>
        </div>
    </div>
</asp:Content>
