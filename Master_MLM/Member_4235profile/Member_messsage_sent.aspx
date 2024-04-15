<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Member_messsage_sent.aspx.cs" Inherits="Master_MLM.Member_4235profile.Member_messsage_sent" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.seventh
        {
            background-color: #F700A9;
            color: #fff;
        }
        @media print
        {
            .noPrint
            {
                display: none;
            }
    </style>

    <script type="text/javascript">
        printDivCSS = new String('<link href="itemprint.css" rel="stylesheet" type="text/css">')
        function printDiv(divId) {
            window.frames["print_frame"].document.body.innerHTML = printDivCSS + document.getElementById(divId).innerHTML
            window.frames["print_frame"].window.focus()
            window.frames["print_frame"].window.print()
        }

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row" style="padding: 30px 0px 0px 0px;">
                <p style="margin: 0px auto; padding: 0px; width: 100%; height: 30px; text-align: center;">
                    <asp:Label ID="lbl_message" runat="server" ForeColor="#CC0000" Font-Bold="True"></asp:Label></p>
                <div style="float: left; width: 100%; padding: 0px; margin: 0px; height: auto; text-align: center;">
                    <asp:Panel ID="pnl_view_message" runat="server" Visible="False" Style="margin: 0px;">
                        <table border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #CCCCCC;
                            padding: 0px; margin: 0px auto 20px auto; width: 943px; font-family: arial, Helvetica, sans-serif;
                            font-size: 12px; background-color: #FFFFFF;" class="round shadow">
                            <tr>
                                <td class="blue_bg round_top" colspan="6" height="25" style="padding: 10px 0px 10px 30px; text-align: left;
                                    color: #FFFFFF; font-family: arial, Helvetica, sans-serif;   font-weight: bold;
                                    border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;"  >
                                    <h2 style="text-align: center; width: 88%; margin: 0px; float: left; text-align: left;">
                                        Messages Sent
                                    </h2>
                                    <h2 style="text-align: center; width: 10%; margin: 0px; float: left; text-align: left;"
                                        class="noPrint">
                                        <a href="javascript:printDiv('message')">
                                            <img src="../images/printer.png" height="20" width="20" border="0" alt=" "  /></a>
                                        <asp:ImageButton ID="img_expord" runat="server"  height="20" width="20" ImageUrl="~/images/Excelicons.png"
                                            Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px">
                                    <asp:GridView ID="grd_view_sent_message" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                        Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 12px;"
                                        Width="931px" AutoGenerateColumns="False">
                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPreviousFirstLast" NextPageImageUrl="~/Images/next_button.png"
                                            NextPageText="" PreviousPageImageUrl="~/Images/previous_button.png" />
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#000000" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subject">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_subject" runat="server" Font-Names="Arial" Text='<%#bind("Subject") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Message">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_message" runat="server" Font-Names="Arial" Text='<%#bind("Message") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="400px" />
                                                <ItemStyle Width="400px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#bind("Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_to" runat="server" Font-Names="Arial" Text='<%#bind("Receiver_id") %>'></asp:Label>
                                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Text='<%#bind("Receiver_name") %>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Font-Names="Arial" Text='<%#bind("id") %>'></asp:Label>
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
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
            <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank">
            </iframe>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
