<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="First-Purchase-Stock-History.aspx.cs" Inherits="Master_MLM.Repurchase.First_Purchase_Stock_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    First Purchase Stock History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        td, th {
            padding: 5px 10px;
            text-align: left;
        }

            td span {
                padding: 0px 0px;
            }

        .panel-body {
            overflow: auto;
            padding: 15px 0px;
        }

        .btn {
            vertical-align: top;
        }

        option {
            color: #222 !important;
        }

        .textbx-box {
            margin: 0px;
            padding: 0px;
            width: 50%;
            height: auto;
            float: left;
            border-top: 1px solid #eeeeee;
            border-bottom: 1px solid #eeeeee;
        }

        .textbx-lbl-name {
            padding-top: 15px;
            width: 180px;
            float: left;
            text-align: right;
            font-size: 14px;
            font-weight: normal;
            line-height: 20px;
            display: block;
            margin-bottom: 5px;
        }

        .textbx-wpr {
            margin-left: 200px;
            padding: 10px 0;
        }

        .btn {
            padding: 4px 15px;
        }

        @media only screen and (max-width:800px) {
            .textbx-box {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>First Purchase Stock History</a></h4>
            <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>

            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <asp:Panel ID="panel_view" runat="server" Visible="false">
                        <asp:GridView ID="gridview" runat="server" Style="width:100%; margin: 10px 0px 0px 0px; float: left; padding: 0px; text-align: center; font-weight: normal;"
                            AutoGenerateColumns="False"
                            BorderColor="#186B80" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Ebrima"
                            Font-Size="12px" ForeColor="#333333">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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

                                <asp:TemplateField HeaderText="Mrp">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Quantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_total_amount" runat="server" Text='<%#Bind("Total_Mrp") %>'></asp:Label>
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
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openWindow(code) {
            window.open('Re_history_first_joining_distribute_product.aspx?Stockpoint_code=' + code, 'open_window', ' width=1100, height=480, left=0, top=0');
        }
    </script>
</asp:Content>
