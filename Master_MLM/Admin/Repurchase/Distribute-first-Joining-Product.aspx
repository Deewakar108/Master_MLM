<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Distribute-first-Joining-Product.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Distribute_first_Joining_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Distribute First Joining Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-horizontal .control-group {
            width: 50%;
            float: left;
        }

        .table th {
            font-size: 12px;
            text-align: left;
        }

        .tbl-styl {
            border: 1px solid #CCCCCC;
            padding: 0px;
            margin: 10px;
            width: 605px;
            font-family: arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            background-color: #FFFFFF;
            float: right;
        }

        @media only screen and (max-width:800px) {
            .form-horizontal .control-group {
                width: 100%;
            }

            .tbl-styl {
                float: left;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hd_franchise_code" runat="server" />
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="../home.aspx" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Franchise</a>
                <a href="#" class="current">Distribute First Joining Product  </a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distribute First Joining Product  </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal width-forty" id="basic_validate">
                                <div class="control-group" style="width: 100%">
                                    <label class="control-label">Franchise Code  :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_stock_point_code" runat="server"></asp:TextBox>
                                        <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="btn btn-success" OnClick="btn_find_Click" />
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Name :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_membername" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">City :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_city" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Mobile No :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_mobileno" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>

                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="panel_member_details" runat="server" Visible="false">
                            <div class="row-fluid">
                                <div class="form-horizontal">
                                    <asp:Panel ID="panel_add_data" runat="server" Visible="true">
                                        <div class="control-group">
                                            <label class="control-label">Date :</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_date" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Distribution No :</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_distributionno" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Product :</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddl_product" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">MRP/Pcs :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mrp" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_mrp" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Sell Quantity  :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_sell_quantity" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_sell_quantity" runat="server"></asp:TextBox><span><asp:RegularExpressionValidator ID="valEmailID0" runat="server" ControlToValidate="txt_sell_quantity"
                                                    ErrorMessage="only digit allowed in quantity" ValidationExpression="^\d+$" Font-Size="13px"
                                                    Display="Dynamic" ForeColor="Red" ValidationGroup="a"></asp:RegularExpressionValidator></span>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls">
                                                <asp:Button ID="btn_add" runat="server" Text="Add" ValidationGroup="a" CssClass="btn btn-success" OnClick="btn_add_Click" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="row-fluid">
                            <asp:Panel ID="panel_view" runat="server" Visible="false">
                                <div class="form-horizontal">
                                    <div class="grd-wprr" style="margin: 20px 0px 0px 0px;">
                                        <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered data-table dataTable"
                                            AutoGenerateColumns="False" AutoGenerateSelectButton="false" AutoGenerateEditButton="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Product Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_productname" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Productid" runat="server" Text='<%#Bind("Product_id") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText=" MRP.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Quantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Total MRP.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_totalmrp" runat="server" Text='<%#Bind("Total_Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="link_delete" runat="server" OnClick="link_delete_Click" OnClientClick='return confirm("Are you sure want to delete ?")' CausesValidation="False"><i class="grid-icon icon-trash"</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="grd-wprr">
                                        <table border="0" cellpadding="0" cellspacing="0" class="tbl-styl">
                                            <tr>
                                                <td style="text-align: right; padding: 0px 18px 0px 0px">Total Pur. Price -
                                                </td>
                                                <td style="text-align: justify;">
                                                    <asp:Label ID="lbl_totalamount" runat="server" ForeColor="#CC0000"></asp:Label>
                                                </td>
                                                <td style="text-align: right; padding: 10px 18px 10px 0px;">Total BV -
                                                </td>
                                                <td style="text-align: justify; padding: 10px 18px 10px 0px;">
                                                    <asp:Label ID="lbl_totalbv" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="padding: 5px 0px 5px 0px; text-align: center;">
                                                    <asp:Button ID="btn_final_submit" runat="server" Text="Submit" Style="background-color: #ff6666; font-weight: bold; height: 30px; width: 145px; color: #fff;"
                                                        ValidationGroup="a" OnClick="btn_final_submit_Click" CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
