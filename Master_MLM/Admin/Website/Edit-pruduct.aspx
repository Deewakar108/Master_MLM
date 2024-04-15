<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Edit-pruduct.aspx.cs" Inherits="Master_MLM.Admin.Website.Edit_pruduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Edit Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <asp:HiddenField ID="hd_product_id" runat="server" />
        <asp:HiddenField ID="hd_id" runat="server" />
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Website</a>
                <a href="#" class="current">Edit Product</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Edit Product</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <div class="row-fluid">
                            <div class="form-horizontal" id="basic_validate">
                                <asp:Panel ID="panel_product_edit" runat="server" Visible="false">
                                    <div class="span6" id="panel_btn1" runat="server">
                                        <div class="widget-box">
                                            <div class="widget-title bg_lg">
                                                <span class="icon"><i class="icon-signal"></i></span>
                                                <h5>Edit Product</h5>
                                            </div>
                                            <div class="widget-content nopadding">
                                                <div class="form-horizontal sks">
                                                    <div class="control-group">
                                                        <label class="control-label">Product Name<sup>*</sup> :</label>
                                                        <div class="controls">
                                                            <div class="span9">
                                                                <asp:TextBox ID="txt_productname" runat="server" CssClass="input"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_productname"
                                                                    Display="Dynamic" ErrorMessage="**" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="control-group" style="display: none">
                                                        <label class="control-label">MRP<%--<sup>*</sup>--%> :</label>
                                                        <div class="controls">
                                                            <div class="span9">
                                                                <asp:TextBox ID="txt_mrp" runat="server" CssClass="input"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_mrp"
                                                                    Display="Dynamic" ErrorMessage="**" ForeColor="#990033" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                                                <asp:RegularExpressionValidator
                                                                    ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Mrp Price" Display="Dynamic"
                                                                    ControlToValidate="txt_mrp" ValidationGroup="a" ValidationExpression="[-+]?[0-9]*\.?[0-9]*" ForeColor="#CC3300"></asp:RegularExpressionValidator>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="control-group">
                                                        <label class="control-label">Packing<sup>*</sup> :</label>
                                                        <div class="controls">
                                                            <div class="span9">
                                                                <asp:TextBox ID="txt_packing" runat="server" CssClass="input"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_packing"
                                                                    Display="Dynamic" ErrorMessage="**" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="control-group" style="display: none">
                                                        <label class="control-label">DP :</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_dp" runat="server" onKeyUp="CheckLimit();" CssClass="span3"></asp:TextBox>
                                                            <span>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dp"
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
                                                            <asp:TextBox ID="txt_bv" runat="server" onKeyUp="CheckLimit();" CssClass="span3"></asp:TextBox>
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
                                                        <label class="control-label">Product Image<sup>*</sup> :</label>
                                                        <div class="controls">
                                                            <div class="span9">
                                                                <asp:Label ID="lbl_image_path" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="control-group">
                                                        <label class="control-label"></label>
                                                        <div class="controls">
                                                            <div class="span9">
                                                                <asp:Button ID="btn_ad" runat="server" Text="Update" ValidationGroup="a"
                                                                    CssClass="btn btn-success" OnClick="btn_ad_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-actions">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div style="margin: 0px auto; padding: 0px; width: 695px; height: auto;">
                                <div style="margin: 10px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">

                                    <table style="border: 1px solid #666666; height: auto; margin: 0px; border-spacing: 0px; width: 100%; float: left;"
                                        border="0" cellpadding="0" cellspacing="0" class="round shadow">

                                        <tr>
                                            <td style="text-align: left; padding: 3px 10px 3px 25px; font-family: ebrima; font-size: 15px; font-weight: bold;"
                                                class="blue_bg" colspan="5">Edit Product Product
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lefttd">Product Name<sup>**</sup> :</td>
                                            <td style="text-align: left;">

                                                <asp:TextBox ID="" runat="server" Wrap="False" TabIndex="1" Width="260px"
                                                    class=""></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lefttd">MRP <sup>**</sup> :</td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="" runat="server" Wrap="False" TabIndex="1" Width="210px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lefttd">Description <sup>**</sup> :</td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="" runat="server" Style="width: 260px; height: 60px;" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lefttd">Product Image <sup>**</sup> :</td>
                                            <td style="text-align: left; padding: 10px 0px 0px 5px;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center; padding: 20px 10px 0px 0px">
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>--%>
                                </asp:Panel>

                                <asp:Panel ID="panel_avilabel_product" runat="server" Visible="false">
                                    <div>
                                        <table style="width: 100%; margin: 10px 0px;">
                                            <tr>
                                                <td>
                                                    <div class="grd-wprr">
                                                        <asp:GridView ID="grd_available" runat="server" CellPadding="4" Font-Bold="False"
                                                            Font-Italic="False" GridLines="Horizontal" CssClass="table table-bordered data-table dataTable"
                                                            AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnk_select" runat="server" OnClick="lnk_select_Click">Select</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Product Code" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_product_code" runat="server" Text='<%#Bind("Product_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Product Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_product_name" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Packing">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Packing" runat="server" Text='<%#Bind("Packing") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mrp"  Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DP " Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_dp" runat="server" Text='<%#Bind("DP") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="BV " Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_bv" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Product Image">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image2" runat="server" Height="50" ImageUrl='<%# Bind("Image_path") %>' Style="margin: 0 5px 5px 0; border: 2px solid #f93; padding: 2px" Width="70" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>' Visible="false"></asp:Label>
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/images/delete-icon.png"
                                                                            OnClick="ImageButton1_Click" OnClientClick="return confirm('Are you sure want delete this data ?')" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </asp:Panel>


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
