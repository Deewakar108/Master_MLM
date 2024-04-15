<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="Stock_Details.aspx.cs" Inherits="Master_MLM.Repurchase.Stock_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Stock Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        td, th {
            padding: 5px 10px;
        }

            td span {
                padding: 0px 0px;
            }

        .panel-body {
            padding: 15px 0px;
        }

        .btn {
            vertical-align: top;
        }

        option {
            color: #222 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Purchase Stock History</a></h4>
            <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
            <asp:Panel ID="panel_view" runat="server">
                <div class="panel-body panel-footer">
                    <div role="form" class="form-horizontal">
                        <div class="grd-over-flow" style="margin: 0px 0px 15px 0px">
                            <p style="width: 100px; float: left;">
                                Product -
                            </p>
                            <asp:DropDownList ID="ddl_product_name" runat="server" class="form-control" Style="height: 36px; width: 252px; color: #222; float: left; margin: 0px 10px 0px 0px;">
                            </asp:DropDownList>
                            <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Find" OnClick="btn_find_Click" />
                        </div>
                        <div class="grd-over-flow">
                            <asp:GridView ID="gridview" runat="server" Style="width: 100%; margin: 5px; padding: 0px; text-align: center; font-weight: normal;"
                                AutoGenerateColumns="False"
                                BorderColor="#186B80" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Ebrima"
                                Font-Size="12px" ForeColor="#333333">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Description" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                            <asp:Label ID="lbl_Productnameid" runat="server" Text='<%#Bind("Product_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MRP/Pcs">

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
                                    <asp:TemplateField HeaderText="Tot Mrp" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totalmrp" runat="server" Text='<%#Bind("Tot_mrp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tot BV" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Tot_bv" runat="server" Text='<%#Bind("Tot_bv") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" />
                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#CC0000" />
                                <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                                    ForeColor="White" Height="40px" BackColor="#00A4CC" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
