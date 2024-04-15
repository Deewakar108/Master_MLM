<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Distribute-stock-via-stock-point-wise.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Distribute_stock_via_stock_point_wise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Distribute Stock Via Stock Point Wise
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
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="../home.aspx" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Franchise</a>
                <a href="#" class="current">Distribute Stock</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Add Franchise</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal width-forty" id="basic_validate">
                                <div class="control-group">
                                    <label class="control-label">Franchise Code  :</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_stockcode" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Category  :</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_product" runat="server"></asp:DropDownList>
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
                                <div class="control-group">
                                    <label class="control-label">Level :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_level" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>
                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </div>
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
                                                <asp:TemplateField HeaderText="Entry No" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Stockpoint_code" runat="server" Text='<%#Bind("Stockpoint_code") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Product"> 
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Description" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Productnameid" runat="server" Text='<%#Bind("Product_id") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate> 
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mrp/Pcs">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="BV/Pcs">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Quantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tot Mrp">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_totMrp" runat="server" Text='<%#Bind("Tot_mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Tot BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_totBV" runat="server" Text='<%#Bind("Tot_bv") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="grd-wprr">
                                        <table border="0" cellpadding="0" cellspacing="0" class="tbl-styl">
                                            <tr>
                                                <td style="text-align: right; padding: 0px 18px 0px 0px">Total Price -
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
