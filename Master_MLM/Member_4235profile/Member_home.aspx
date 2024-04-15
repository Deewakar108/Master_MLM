<%@ Page Title="Member Home Page" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Member_home.aspx.cs" Inherits="Master_MLM.Member_4235profile.Member_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .border {
            border: 1px solid red;
        }
    </style>

    <script>
        function ClickMe(imagePath) {
            //alert(imagePath);
            document.getElementById("myImg").setAttribute("src", imagePath);
            document.getElementById("myImg").click();
            return false;
        }
    </script>
    <style>
        .fancybox-lock .fancybox-overlay {
            overflow: auto;
            overflow-y: scroll;
            z-index: 1000000!important;
        }

        #myImg {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
        }

            #myImg:hover {
                opacity: 0.7;
            }

        /* The Modal (background) */
        .modalSKS {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 665854; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            overflow-y: hidden;
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modalSKS-content {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 800px;
        }

        /* Caption of Modal Image */
        #captionSKS {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 800px;
            text-align: center;
            color: #ccc;
            padding: 10px 0;
            height: 150px;
        }

        /* Add Animation */
        .modalSKS-content, #captionSKS {
            -webkit-animation-name: zoom;
            -webkit-animation-duration: 0.6s;
            animation-name: zoom;
            animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
            from {
                -webkit-transform: scale(0);
            }

            to {
                -webkit-transform: scale(1);
            }
        }

        @keyframes zoom {
            from {
                transform: scale(0);
            }

            to {
                transform: scale(1);
            }
        }

        /* The Close Button */
        .closeSKS {
            position: absolute;
            top: 15px;
            right: 35px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .closeSKS:hover,
            .closeSKS:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modalSKS-content {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: none;">

        <img id="myImg" src="https://www.w3schools.com/howto/img_fjords.jpg" alt="" width="300" height="200" />


    </div>
    <!-- The Modal -->
    <div id="myModalSKS" class="modalSKS">
        <span class="closeSKS">&times;</span>
        <img class="modalSKS-content" id="img01" src="../" />
        <div id="captionSKS"></div>
    </div>

    <script>
        // Get the modal
        var modal = document.getElementById('myModalSKS');

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById('myImg');
        var modalImg = document.getElementById("img01");
        var captionText = document.getElementById("captionSKS");
        img.onclick = function () {
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("closeSKS")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }
    </script>



    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>
    <!--photoday-section-->
    <div class="col-sm-12 wthree-crd">
        <div class="card">
            <div class="card-body">
                <div class="widget widget-report-table">
                    <div class="row m-0 md-bg-grey-100 p-l-20 p-r-20" style="padding: 0; margin: 0;">
                        <div class="col-md-6 col-sm-6 col-xs-6 w3layouts-aug" style="margin-top: 0;">
                            <h3 style="margin-bottom: 0;">Income</h3>
                        </div>
                    </div>

                    <div class="widget-body p-15">
                        <div class="four-grids" style="margin-top: 0;">
                            <div class="col-md-3 four-grid">
                                <a href="total_sponsor_income.aspx">
                                    <div class="four-agileinfo">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-user" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>Pair</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblSponsorIncome" runat="server" Text="0.00"></asp:Label>
                                            </h4>

                                        </div>
                                    </div>
                                </a>
                            </div>
                            <%--<div class="col-md-3 four-grid">
                                <a href="total_autoplan_income.aspx">
                                    <div class="four-agileinfo">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-list-alt" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>Auto Level</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblAutoLevelIncome" runat="server" Text="0.00"></asp:Label></h4>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-4 four-grid">
                                <a href="total_royalty_income.aspx">
                                    <div class="four-w3ls">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-bookmark" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>Royalty</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblRoyalty" runat="server" Text="0.00"></asp:Label></h4>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-4 four-grid">
                                <a href="total_cto_income.aspx">
                                    <div class="four-w3ls">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-bookmark" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>CTO</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblCTO" runat="server" Text="0.00"></asp:Label></h4>
                                        </div>
                                    </div>
                                </a>
                            </div>--%>
                            <div class="col-md-3 four-grid">
                                <a href="total_royalty_income.aspx">
                                    <div class="four-w3ls">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-bookmark" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>Referral Royalty</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblReferral" runat="server" Text="0.00"></asp:Label></h4>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-3 four-grid">
                                <a href="total_repurchase_income.aspx">
                                    <div class="four-wthree">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-user" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>Repurchase</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblRepurchase" runat="server" Text="0.00"></asp:Label>
                                            </h4>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-3 four-grid">
                                <a href="total_repurchase_royalty_income.aspx">
                                    <div class="four-agileinfo">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-user" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>Repurchase Royalty</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblRoyalty" runat="server" Text="0.00"></asp:Label>
                                            </h4>

                                        </div>
                                    </div>
                                </a>
                            </div>
                            <%--<div class="col-md-3 four-grid">
                                <a href="total_mfa_income.aspx">
                                    <div class="four-wthree">
                                        <div class="icon">
                                            <i class="glyphicon glyphicon-folder-open" aria-hidden="true"></i>
                                        </div>
                                        <div class="four-text">
                                            <h3>MFA</h3>
                                            <h4 style="font-size: 14px;"><i class="fa fa-inr" style="font-size: 13px;"></i>
                                                <asp:Label ID="lblMFAIncome" runat="server" Text="0.00"></asp:Label></h4>
                                        </div>
                                    </div>
                                </a>
                            </div>--%>
                            <%--	<div class="col-md-2 four-grid">
						<div class="four-wthree">
							<div class="icon">
								<i class="glyphicon glyphicon-briefcase" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>Royalty</h3>
								<h4 style="font-size: 13px;"><i class="fa fa-inr" style="font-size: 13px;"></i> 
                                    <asp:Label ID="lbl_total_income" runat="server" Text="0"></asp:Label></h4>
								
							</div>
							
						</div>
					</div>
            <div class="col-md-2 four-grid">
						<div class="four-wthree">
							<div class="icon">
								<i class="glyphicon glyphicon-briefcase" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>Repurchase</h3>
								<h4 style="font-size: 13px;"><i class="fa fa-inr" style="font-size: 13px;"></i> 0</h4>
								
							</div>
							
						</div>
					</div>
                <div class="col-md-2 four-grid">
						<div class="four-wthree">
							<div class="icon">
								<i class="glyphicon glyphicon-briefcase" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>RP Points</h3>
								<h4 style="font-size: 13px;">
                                    <asp:Label ID="lbl_rp_points" runat="server" Text="Left: 0, Right: 0"></asp:Label>Left: 0, Right: 0</h4>
								
							</div>
							
						</div>
					</div>--%>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="col-sm-4 wthree-crd">
        <div class="card">
            <div class="card-body">
                <div class="widget widget-report-table">
                    <header class="widget-header m-b-15">
                    </header>

                    <div class="row m-0 md-bg-grey-100 p-l-20 p-r-20">
                        <div class="col-md-6 col-sm-6 col-xs-6 w3layouts-aug">
                            <h3>My Profile</h3>
                        </div>
                    </div>


                    <div class="widget-body p-15">
                        <table class="table table-bordered" style="font-size: 13px; padding: 2px; border-top: 1px solid #F5F5F5;">
                            <tbody>
                                <tr>
                                    <td>Your Id :</td>
                                    <td>
                                        <asp:Label ID="lbl_yourid" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Joining On :</td>
                                    <td>
                                        <asp:Label ID="lbl_joining_date" runat="server" Text=""></asp:Label>
                                    </td>
                                    <%--<td>6,200.00</td>--%>
                                </tr>
                                <tr>
                                    <td>Verification On :</td>
                                    <td>
                                        <asp:Label ID="lbl_verification" runat="server" Text=""></asp:Label></td>
                                    <%--<td>6,500.00</td>--%>
                                </tr>

                                <tr>
                                    <td>Joining Product :</td>
                                    <td>
                                        <asp:Label ID="lbl_package" runat="server" Text=""></asp:Label></td>
                                    <%--<td>6,800.00</td>--%>
                                </tr>
                                <tr style="display: none;">
                                    <td>Upgrade to :</td>
                                    <td>
                                        <asp:Label ID="lbl_upgradepackage" runat="server" Text=""></asp:Label></td>
                                    <%--<td>7,200.00</td>--%>
                                </tr>
                                <tr>
                                    <td>Active Status :</td>
                                    <td>
                                        <asp:Label ID="lbl_status" runat="server" Text=""></asp:Label></td>
                                    <%--<td>5,900.00</td>--%>
                                </tr>
                                <tr>
                                    <td>Sponsor :</td>
                                    <td>
                                        <asp:Label ID="lbl_sponsor" runat="server" Text=""></asp:Label></td>
                                    <%--<td>5,900.00</td>--%>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="col-sm-4 w3-agile-crd" style="display: none;">
        <div class="card">
            <div class="card-body card-padding">
                <div class="widget">
                    <header class="widget-header">
                        <h4 class="widget-title">Product</h4>
                        <hr class="widget-separator" />
                    </header>
                    <%--<hr class="widget-separator">--%>
                    <div class="gallery-grid">
                        <div class="flexslider">
                            <ul class="slides" style="padding: 0;">
                                <li style="list-style: none; border: 1px solid lightgray;">
                                    <img src="images/phone.jpg" style="width: 90%" />
                                    <br />
                                    <br />
                                    <div class="flex-caption" style="text-align: center;">Adventurer Cheesecake Brownie</div>
                                    <br />

                                </li>
                            </ul>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="col-sm-4 wthree-crd">
        <div class="card">
            <div class="card-body">
                <div class="widget widget-report-table">
                    <header class="widget-header m-b-15">
                    </header>

                    <div class="row m-0 md-bg-grey-100 p-l-20 p-r-20">
                        <div class="col-md-6 col-sm-6 col-xs-6 w3layouts-aug">
                            <h3>Total BV</h3>
                        </div>
                    </div>


                    <div class="widget-body p-15">
                        <asp:GridView ID="gridview" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                            CssClass="mydatagrid" PagerStyle-CssClass="pager"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False">
                            <Columns>

                                <asp:TemplateField HeaderText="Self BV">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_self" runat="server" Text='<%#Bind("Self_BV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Left BV">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_leftbv" runat="server" Text='<%#Bind("Left_PV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Right BV">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_rightbv" runat="server" Text='<%#Bind("Right_PV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#00A4CC" />
                        </asp:GridView>
                        <table class="table table-bordered" style="font-size: 13px; padding: 2px; border-top: 1px solid #F5F5F5; margin-top: 10px;">
                            <tbody>
                                <tr>
                                    <td>Repurchase Royalty Level  :</td>
                                    <td>
                                        <asp:Label ID="lblRewardName" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr style="display: none;">
                                    <td>KYC :</td>
                                    <td>
                                        <asp:Label ID="lblKYC" runat="server" Text="Not Updated"></asp:Label></td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-4 wthree-crd">
        <div class="card">
            <div class="card-body">
                <div class="widget widget-report-table">
                    <div class="row m-0 md-bg-grey-100 p-l-20 p-r-20">
                        <div class="col-md-12 col-sm-12 col-xs-12 w3layouts-aug">
                            <h3 style="font-weight: 600;">Binary Carry Forward </h3>
                        </div>
                    </div>
                    <div class="widget-body p-15">
                        <asp:GridView ID="gridviewcarry" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                            CssClass="mydatagrid" PagerStyle-CssClass="pager"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False">
                            <Columns>

                                <%--<asp:TemplateField HeaderText="Colesing Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_colseingdate" runat="server" Text='<%#Bind("colisingdate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Left ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_leftcarry" runat="server" Text='<%#Bind("Current_left") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Right ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_rightcarry" runat="server" Text='<%#Bind("Current_right") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pair ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_pair" runat="server" Text='<%#Bind("Pair") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#F32C13" ForeColor="White" />

                            <PagerStyle CssClass="pager"></PagerStyle>

                            <RowStyle CssClass="rows"></RowStyle>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-4 wthree-crd">
        <div class="card">
            <div class="card-body">
                <div class="widget widget-report-table">
                    <div class="row m-0 md-bg-grey-100 p-l-20 p-r-20">
                        <div class="col-md-12 col-sm-12 col-xs-12 w3layouts-aug">
                            <h3 style="font-weight: 600;">Repurchase Carry Forward </h3>
                        </div>
                    </div>
                    <div class="widget-body p-15">
                        <asp:GridView ID="gridviewrepurchse" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                            CssClass="mydatagrid" PagerStyle-CssClass="pager"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False">
                            <Columns>

                                <asp:TemplateField HeaderText="Colesing Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_purcolseingdate" runat="server" Text='<%#Bind("colising_date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Left ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_purleftcarry" runat="server" Text='<%#Bind("Current_left") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Right ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_purrightcarry" runat="server" Text='<%#Bind("Current_right") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Pair ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_pair" runat="server" Text='<%#Bind("Pair") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <HeaderStyle BackColor="#f131d0" ForeColor="White" />

                            <PagerStyle CssClass="pager"></PagerStyle>

                            <RowStyle CssClass="rows"></RowStyle>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>

    <!--//photoday-section-->
    <!--w3-agileits-pane-->
    <div class="w3-agileits-pane" style="display: none;">

        <div class="col-md-4 wthree-pan">
            <div class="panel panel-default">
                <div class="panel-heading" style="margin: 0;"><i class="fa fa-bell fa-fw"></i>Customer care no. </div>
                <!-- /.panel-heading -->
                <div class="panel-body" style="padding: 0; margin: 0;">
                    <div class="list-group" style="margin: 0;">
                        <a href="#" class="list-group-item">
                            <i class="fa fa-comment fa-fw"></i>Contact No : &nbsp;&nbsp;&nbsp;&nbsp;	 <span class=" text-muted "><em>
                                <asp:Label ID="lblCompanyMobileNo" runat="server" Text="Label"></asp:Label></em> </span></a>
                        <a href="#" class="list-group-item"><i class="fa fa-twitter fa-fw"></i>Email Id :	
                         <span class="text-muted"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCompanyEmailID" runat="server" Text="Label"></asp:Label></em> </span></a>
                        <a href="#" class="list-group-item"><i class="fa fa-envelope fa-fw"></i>Time : 
                        <span class="text-muted"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;10:30 AM to 1:00 PM
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2:30 PM to 5: 30 PM
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Monday to Friday)
                        </em></span></a>
                    </div>
                    <!-- /.list-group -->

                </div>
                <!-- /.panel-body -->
            </div>
        </div>
        <div class="col-md-8 agile-info-stat" style="display: none;">
            <div class="stats-info stats-last widget-shadow">
                <h4>Training Information</h4>
                <asp:GridView ID="Grd_training" runat="server" AutoGenerateColumns="False" Style="width: 100%;" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="Grd_training_PageIndexChanging">
                    <EmptyDataTemplate>
                        <div style="text-align: center;">Updates not found.  </div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="Meeting">
                            <ItemTemplate>
                                <asp:Label ID="lbl_meeting" runat="server" Text='<%#Bind("Heading") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Location" runat="server" Text='<%#Bind("Location") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Details" runat="server" Text='<%#Bind("Training_Details") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
</asp:Content>
