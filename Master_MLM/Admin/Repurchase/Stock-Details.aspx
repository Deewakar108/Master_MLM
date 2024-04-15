<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Stock-Details.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Stock_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Stock Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .tbl-styl {
            border: 1px solid #CCCCCC;
            padding: 0px;
            margin: 10px;
            width: 50%;
            font-family: arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            background-color: #FFFFFF;
            float: right;
        }

        @media only screen and (max-width:800px) {

            .tbl-styl {
                float: left;
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="../home.aspx" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Franchise</a>
                <a href="#" class="current"> Stock Details</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5> Stock Details</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal width-forty" id="basic_validate">

                                <div class="control-group">
                                    <label class="control-label">Product Name :</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_product_name" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Panel ID="pnl_btn_add" runat="server">
                                            <asp:Button ID="btnfind" runat="server" Text="Find" CssClass="btn btn-success" OnClick="btnfind_Click" />
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lblmessage" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                            <asp:Panel ID="panel_view" runat="server" Visible="false">
                                <div class="form-horizontal">
                                    <div class="grd-wprr">
                                        <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered data-table dataTable"
                                            AutoGenerateColumns="False" AutoGenerateEditButton="false" AutoGenerateSelectButton="false" OnRowDataBound="gridview_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Product_name" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Product_id" runat="server" Visible="false" Text='<%#Bind("Product_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mrp">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Bv" runat="server" Text='<%#Bind("Bv") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_unit" runat="server" Text='<%#Bind("Unit") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Quantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Gst_perc" runat="server" Text='<%#Bind("Gst_perc") %>'></asp:Label>
                                                        <asp:Label ID="lbl_gst_amt" runat="server" Text='<%#Bind("Gst_amt") %>'></asp:Label>
                                                        <asp:Label ID="lbl_net_mrp" runat="server" Text='<%#Bind("Net_Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("id")%>'></asp:Label>
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
                                                <td style="text-align: right; padding: 0px 18px 0px 0px">Total MRP -
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
