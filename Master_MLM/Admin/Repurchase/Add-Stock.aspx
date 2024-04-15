<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Add-Stock.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Add_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Stock
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .control-group {
            width: 50%;
            float: left;
        }

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

        .nopadding {
            padding: 0 15px !important;
        }

        .table-bordered {
            border: 1px solid #ddd!important;
        }
        .table th { 
            text-align: left;
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
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Repurchase</a>
                <a href="#" class="current">Add Stock</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Add Stock</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <div class="row-fluid">
                            <div class="form-horizontal" id="basic_validate">
                                <div class="control-group">
                                    <label class="control-label">Date :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_date" runat="server" CssClass="span6" ReadOnly="true" Style="width: 100px; pointer-events: none;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Entry No. :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_enteryno" runat="server" CssClass="span6" ReadOnly="true" Style="width: 100px; pointer-events: none;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Product Name :<sup>*</sup></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_product_name" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_product_name_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">MRP :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_mrp" runat="server" ReadOnly="true" Style="width: 100px" CssClass="span6"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">BV :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_bv" runat="server" ReadOnly="true" Style="width: 100px" CssClass="span6"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Unit :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_unit" runat="server" Style="width: 100px" ReadOnly="true" CssClass="span6"></asp:TextBox>
                                    </div>
                                </div>
                                <div runat="server" visible="false">
                                    <div class="control-group">
                                        <label class="control-label">GST% :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_gst_perc" runat="server" Style="width: 100px" ReadOnly="true" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">GST Value :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_gst_value" runat="server" ReadOnly="true" Style="width: 100px; pointer-events: none;" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Net MRP :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_net_mrp" runat="server" ReadOnly="true" Style="width: 100px; pointer-events: none;" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Quantity :<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_quantity" Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_quantity" runat="server" Style="width: 100px;" CssClass="span6"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btn_add_stock" OnClick="btn_add_stock_Click" runat="server" ValidationGroup="D" Text="Add Stock" CssClass="btn btn-success" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="panel_view" runat="server">
                                <div class="form-horizontal">
                                    <div class="grd-wprr">
                                        <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered data-table dataTable"
                                            AutoGenerateColumns="False" AutoGenerateEditButton="false" AutoGenerateSelectButton="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entery No" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Entery_No" runat="server" Text='<%#Bind("Entry_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Product_name" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Product_id" runat="server" Text='<%#Bind("Product_id") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mrp/Pcs">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BV/Pcs">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("Bv") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Quantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tot Mrp">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_tot_mrp" runat="server" Text='<%#Bind("Total_Mrp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tot BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_totBV" runat="server" Text='<%#Bind("Total_Bv") %>'></asp:Label>
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
                                                <td style="text-align: right; padding: 0px 18px 0px 0px">Total Mrp -
                                                </td>
                                                <td style="text-align: justify;">
                                                    <asp:Label ID="lbl_totalmrp" runat="server" ForeColor="#CC0000"></asp:Label>
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
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblmessage" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
