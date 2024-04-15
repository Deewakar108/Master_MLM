<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="Purchase-Stock History.aspx.cs" Inherits="Master_MLM.Repurchase.Purchase_Stock_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Purchase Stock History
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
            overflow: auto;
            padding: 15px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Purchase Stock History</a></h4>
            <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <div class="grd-over-flow">
                        <asp:GridView ID="gridview" runat="server" CssClass="form-control1" AutoGenerateColumns="false"
                            AllowPaging="True">
                            <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#000000" />
                            <EmptyDataTemplate>
                                <div style="text-align: center;">
                                Message not found.</di>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="View Details">
                                    <ItemTemplate>
                                        <a href="#" onclick='openWindow("<%# DataBinder.Eval(Container.DataItem,"Stockpoint_code")+"&Distribution="+DataBinder.Eval(Container.DataItem,"Distribution")%>")'>
                                            <asp:Label ID="lbl_Referalcode" runat="server" Text="View Details"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Distribution No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Distribution" runat="server" Text='<%#Bind("Distribution") %>'></asp:Label>
                                        <asp:Label ID="lbl_Stockpoint_code" runat="server" Text='<%#Bind("Stockpoint_code") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Mrp">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total BV">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
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
        </div>
    </div>
    <script type="text/javascript">
        function openWindow(code) {
            window.open('popup_history_Purchase_stock.aspx?Stockpoint_code=' + code, 'open_window', ' width=1100, height=480, left=0, top=0');
        }
    </script>
</asp:Content>
