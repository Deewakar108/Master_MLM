<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Create_Joining_Products_Kit.aspx.cs"
    Inherits="Master_MLM.Admin.Create_Joining_Products_Kit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
    <link href="../css/custom.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.third {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        .input {
        }

        .table-bordered th, .table-bordered td {
            border: 1px solid #ddd;
        }

        .form-actions {
            text-align: right;
            margin: 20px -15px -15px -15px;
        }


    </style>

    <script>
        function AlertMe() { document.getElementById("sksButton").click();  }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                class="closenotificationpan" alt="" />
        </div>
    </div>--%>
    <!--main-container-part-->
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Package</a>
                <a href="#" class="current">Package Creation</a>
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
                        <h5>Package Creation</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <h5>Select Product</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <div class="form-horizontal sks">
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">Product Name :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txt_productname" runat="server" placeholder="Product Name" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="span2">
                                                        <asp:Button ID="btn_add_product" CssClass="btn btn-primary btn-sm" runat="server" Text="Add" OnClick="btn_add_product_Click" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="sks-div">
                                                <asp:GridView ID="gridview_product_info" runat="server" AutoGenerateColumns="False" 
                                                    CssClass="table table-bordered data-table dataTable">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkProduct" runat="server"  />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Product Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Productname" runat="server" Text='<%# Bind("Product_name") %>' Style="margin-left: 10px;"></asp:Label>
                                                                <asp:Label ID="lbl_product_id" runat="server" Text='<%# Bind("Product_id") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                                                <asp:ImageButton ID="img_delete" runat="server" Height="16px" Style="margin: 0 auto;" ImageUrl="~/Admin/img/icons/delete-icon.png"
                                                                    OnClientClick="return confirm('Are you sure want delete this data ?')" OnClick="img_delete_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="span6" id="panel_btn1" runat="server">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <h5>Create Package</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <div class="form-horizontal sks">
                                            <div class="control-group">
                                                <label class="control-label">Package Name<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txt_packagename" runat="server" CssClass="input"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Package Amount<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txt_amount" runat="server" CssClass="input" Text="0" onfocus="this.select();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">Repurchase BV<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txtRepurchaseBV" runat="server" CssClass="input" Text="0" onfocus="this.select();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">BV<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txtBV" runat="server" CssClass="input" Text="0" onfocus="this.select();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">Matching Income<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <%--<asp:TextBox ID="txt_pv" Visible="false" runat="server" CssClass="input" Text="0"></asp:TextBox>--%>
                                                        <asp:TextBox ID="txtMatchingIncome" runat="server" CssClass="input" Text="0" onfocus="this.select();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">Capping<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txt_capping" runat="server" CssClass="input" Text="0" onfocus="this.select();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">Reward Point<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txtRewardPoint" runat="server" CssClass="input" Width="221px" Text="0"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">Package Type<sup>*</sup> :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:DropDownList ID="ddlIsActivation" runat="server">
                                                            <asp:ListItem Text="Joining and Activation" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Joining Package" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Activation" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            
                                            <div class="control-group">
                                                <label class="control-label">Description  :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="input" Width="221px" Text="0" onfocus="this.select();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-actions">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" CssClass="btn btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


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
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></p>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="gritter-bottom"></div>
        </div>
    </div>
</asp:Content>
