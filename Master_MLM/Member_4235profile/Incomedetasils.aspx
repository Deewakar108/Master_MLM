<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incomedetasils.aspx.cs" Inherits="Master_MLM.Member_4235profile.Incomedetasils" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/profile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="padding: 20px 0px 20px 0px;">
            <div class="block">
                <p style="margin: 0px; padding: 0px; width: 100%; float: left; text-align: center;">
                    <asp:Label ID="lbl_message" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <div class="block1">
                    <asp:Panel ID="pnl_view" runat="server" Width="1200px">
                        <table cellspacing="0" cellpadding="0" border="0" style="margin: 25px 0px 0px 0px; border: 1px solid #666666; width: 960px; height: auto; float: left;"
                            class="round shadow">
                            <tr>
                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                    valign="top" class="blue_bg">Repurchase Income
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 10px; height: auto; width: 100%; margin-top: 4px; margin-bottom: 16px; margin-right: 0px;">
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Income Type" ItemStyle-CssClass="sks-display" HeaderStyle-CssClass="sks-display">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncome_type" runat="server" Text='<%#Bind("Income_type") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;<asp:Label ID="lblTotalamount" runat="server" Text='<%#Bind("Totalamount", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS" SortExpression="idate" ItemStyle-CssClass="sks-display" HeaderStyle-CssClass="sks-display">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;<asp:Label ID="lblTDS" runat="server" Text='<%#Bind("TDS", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Admin Charge" ItemStyle-CssClass="sks-display" HeaderStyle-CssClass="sks-display">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;<asp:Label ID="lblServicecharge" runat="server" Text='<%#Bind("Servicecharge", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gross" ItemStyle-CssClass="sks-display" HeaderStyle-CssClass="sks-display">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;</i><asp:Label ID="lblFinal_amount" runat="server" Text='<%#Bind("Final_amount", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paid Date" ItemStyle-CssClass="sks-display" HeaderStyle-CssClass="sks-display">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaid_date" runat="server" Text='<%#Bind("Paid_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" BorderStyle="Solid" />
                                        <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#CC0000" />
                                        <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False"
                                            Font-Size="8pt" ForeColor="White" Height="40px" CssClass="blue_bg" BackColor="#0066CC" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>


                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 20px 0px 20px; text-align: right; margin: 0px;">Total Amount :-
                                <asp:Label ID="lbl_total_paout" runat="server" Text="0.00"></asp:Label>.
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 20px 0px 250px; text-align: right; margin: 0px;">&nbsp;
                                </td>
                            </tr>
                        </table>

                        
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
