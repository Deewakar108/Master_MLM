<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Master_MLM.Admin.Package.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
    <script>
        function AlertMe() { document.getElementById("sksButton").click(); }
    </script>
    <style>
        .table-bordered th, .table-bordered td {
            border: 1px solid #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Package</a>
                <a href="#" class="current">Product Creation</a>
            </div>
        </div>


        <div class="container-fluid">
            <!--Chart-box-->
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Product Creation</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <h5>Add Product</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <div class="form-horizontal sks">
                                            <div class="control-group">
                                                <label class="control-label">Name :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txt_productname" runat="server" placeholder="Name" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Price :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txtPrice" runat="server" placeholder="Price" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="control-group" style="display: none;">
                                                <label class="control-label">BV :</label>
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:TextBox ID="txtBV" runat="server" placeholder="BV" Text="0" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <div class="controls">
                                                    <div class="span9">
                                                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-sm" runat="server" Text="Add" OnClick="btnSubmit_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <h5>Product List</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <asp:GridView ID="grdProduct" runat="server" CssClass="table table-bordered data-table dataTable" AutoGenerateColumns="false"
                                            OnRowCommand="grdProduct_RowCommand">
                                            <EmptyDataTemplate>
                                                <div style="text-align: center;">
                                                    No record found.
                                                </div>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProduct_id" runat="server" Text='<%# Bind("Product_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProduct_name" runat="server" Text='<%# Bind("Product_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="BV" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBV" runat="server" Text='<%# Bind("BV") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BV">
                                                    <ItemTemplate>
                                                        <i class="grid-icon icon-trash" onclick="$('#ContentPlaceHolder1_grdProduct_btnDelete_<%# Container.DataItemIndex %>').click();"></i>
                                                        <asp:Button ID="btnDelete" CommandArgument='<%# Bind("Product_id") %>' CommandName="IsDelete" style="display: none;" runat="server" Text="Delete" CssClass="btn btn-danger" />
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
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="gritter-bottom"></div>
        </div>
    </div>
</asp:Content>
