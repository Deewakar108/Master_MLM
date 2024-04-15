<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Add-product.aspx.cs" Inherits="Master_MLM.Admin.Website.Add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Website</a>
                <a href="#" class="current">Add Product</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Add Product</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <div class="row-fluid">
                            <div class="form-horizontal" id="basic_validate">
                                <div class="control-group">
                                    <label class="control-label">Product Name :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_productname" runat="server" onKeyUp="CheckLimit();" CssClass="span5"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_productname"
                                                Display="Dynamic" ErrorMessage="*">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                        <asp:TextBox ID="txt_product_code" runat="server" Wrap="False" Visible="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group" style="display: none">
                                    <label class="control-label">MRP :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_mrp" runat="server" onKeyUp="CheckLimit();" CssClass="span3"></asp:TextBox>
                                        <span>

                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Mrp Price" Display="Dynamic"
                                                ControlToValidate="txt_mrp" ValidationGroup="a" ValidationExpression="[-+]?[0-9]*\.?[0-9]*" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Packing :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_packing" runat="server" Text="0" CssClass="span3"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_packing"
                                                Display="Dynamic" ErrorMessage="*">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </div>
                                </div>
                                <div class="control-group" style="display: none">
                                    <label class="control-label">DP :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_dp" runat="server" Text="0" onKeyUp="CheckLimit();" CssClass="span3"></asp:TextBox>
                                        <span>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dp"
                                                Display="Dynamic" ErrorMessage="*">
                                            </asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid DP Price" Display="Dynamic"
                                                ControlToValidate="txt_dp" ValidationGroup="a" ValidationExpression="[-+]?[0-9]*\.?[0-9]*" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                </div>

                                <div class="control-group" style="display: none">
                                    <label class="control-label">BV :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_bv" runat="server" Text="0" onKeyUp="CheckLimit();" CssClass="span3"></asp:TextBox>
                                        <span>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_bv"
                                                Display="Dynamic" ErrorMessage="*">
                                            </asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid BV Price" Display="Dynamic"
                                                ControlToValidate="txt_bv" ValidationGroup="a" ValidationExpression="[-+]?[0-9]*\.?[0-9]*" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                </div>


                                <div class="control-group">
                                    <label class="control-label">Product Image :</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />

                                    </div>
                                </div>

                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btnupload" runat="server" Text="Add Product" CssClass="btn btn-success" OnClick="btnupload_Click" />
                                    </div>
                                </div>

                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lblmessage" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
