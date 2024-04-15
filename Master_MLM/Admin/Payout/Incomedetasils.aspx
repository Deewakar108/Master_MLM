<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incomedetasils.aspx.cs" Inherits="Master_MLM.Admin46gt64.Incomedetasils" %>

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
                    <asp:Panel ID="pnl_view" runat="server" Width="100%">
                        <table cellspacing="0" cellpadding="0" border="0" style="margin: 25px 0px 0px 0px; border: 1px solid #666666; width: 100%; height: auto; float: left;"
                            class="round shadow">
                            <tr>
                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                    valign="top" class="blue_bg">Binary Income
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
                                                    <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Start_date" runat="server" Font-Names="Arial" Text='<%# Bind("Start_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_End_date" runat="server" Font-Names="Arial" Text='<%# Bind("End_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%# Bind("Totalamount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%# Bind("Tds") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%# Bind("Servicecharge") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Net Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%# Bind("Final_amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Font-Names="Arial" Text='<%# Bind("Status") %>'></asp:Label>
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

                        <table border="0" style="margin: 25px 0px 0px 0px; border: 1px solid #666666; width: 100%; height: auto; float: left;"
                            class="round shadow">
                            <tr>
                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                    valign="top" class="blue_bg">Referral Income
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdReferral" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 10px; height: auto; width: 100%; margin-top: 4px; margin-bottom: 16px; margin-right: 0px;">
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Start_date" runat="server" Font-Names="Arial" Text='<%# Bind("Start_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_End_date" runat="server" Font-Names="Arial" Text='<%# Bind("End_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%# Bind("Totalamount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%# Bind("Tds") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%# Bind("Servicecharge") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Net Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%# Bind("Final_amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Font-Names="Arial" Text='<%# Bind("Status") %>'></asp:Label>
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
                                <asp:Label ID="lblReferral" runat="server" Text="0.00"></asp:Label>.
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 20px 0px 250px; text-align: right; margin: 0px;">&nbsp;
                                </td>
                            </tr>
                        </table>

                        <table border="0" style="margin: 25px 0px 0px 0px; border: 1px solid #666666; width: 100%; height: auto; float: left; display: none;"
                            class="round shadow">
                            <tr>
                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                    valign="top" class="blue_bg">Royalty Income
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdRoyalty" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 10px; height: auto; width: 100%; margin-top: 4px; margin-bottom: 16px; margin-right: 0px;">
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Start_date" runat="server" Font-Names="Arial" Text='<%# Bind("Start_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_End_date" runat="server" Font-Names="Arial" Text='<%# Bind("End_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%# Bind("Totalamount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%# Bind("Tds") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%# Bind("Servicecharge") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Net Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%# Bind("Final_amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Font-Names="Arial" Text='<%# Bind("Status") %>'></asp:Label>
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
                                <asp:Label ID="lblRoyalty" runat="server" Text="0.00"></asp:Label>
                                    including Lapse amount.
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 20px 0px 250px; text-align: right; margin: 0px;">&nbsp;
                                </td>
                            </tr>
                        </table>

                        <table border="0" style="margin: 25px 0px 0px 0px; border: 1px solid #666666; width: 100%; height: auto; float: left; display: none;"
                            class="round shadow">
                            <tr>
                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                    valign="top" class="blue_bg">CTO Income
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdCTO" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 10px; height: auto; width: 100%; margin-top: 4px; margin-bottom: 16px; margin-right: 0px;">
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Start_date" runat="server" Font-Names="Arial" Text='<%# Bind("Start_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_End_date" runat="server" Font-Names="Arial" Text='<%# Bind("End_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%# Bind("Totalamount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%# Bind("Tds") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%# Bind("Servicecharge") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Net Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%# Bind("Final_amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Font-Names="Arial" Text='<%# Bind("Status") %>'></asp:Label>
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
                                <asp:Label ID="lblCTO" runat="server" Text="0.00"></asp:Label>
                                    including Lapse amount.
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 20px 0px 250px; text-align: right; margin: 0px;">&nbsp;
                                </td>
                            </tr>
                        </table>

                        <table border="0" style="margin: 25px 0px 0px 0px; border: 1px solid #666666; width: 100%; height: auto; float: left; display: none;"
                            class="round shadow">
                            <tr>
                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;" class="blue_bg">Spill Income
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grd_spill" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 10px; height: auto; width: 100%; margin-top: 4px; margin-bottom: 16px; margin-right: 0px;">
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Start_date" runat="server" Font-Names="Arial" Text='<%# Bind("Start_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_End_date" runat="server" Font-Names="Arial" Text='<%# Bind("End_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%# Bind("Totalamount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%# Bind("Tds") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cds">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%# Bind("Servicecharge") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Net Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%# Bind("Final_amount") %>'></asp:Label>
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
                                <asp:Label ID="lbl_salary" runat="server" Text=""></asp:Label>
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
