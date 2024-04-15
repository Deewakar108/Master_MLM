<%@ Page Title="Uploaded Bank Payment History List" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Upload_Bank_Payment_History_List.aspx.cs" Inherits="Master_MLM.Member_4235profile.Upload_Bank_Payment_History_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            background-color: #F700A9;
            color: #fff;
        }

        @media print {
            .noPrint {
                display: none;
            }
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb"><li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li></ol>
    
      <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Uploaded Bank Payment History List</a><span style="float: right;"> <asp:ImageButton ID="img_export" runat="server" Height="20px" Width="20px" ImageUrl="~/images/Excelicons.png"
                            Style="margin-left: 20px" OnClick="img_export_Click" /></span></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 3px 0px 0px 0px;">
        <div id="epin_generated" style="margin: 0px auto 0px auto; padding: 30px 0px 30px 0px; width: 960px; height: auto;">
            <table style="width: 100%; height: auto; margin: 0px; border-spacing: 0px; float: none; background-color: White;"
                border="0" cellpadding="0" cellspacing="0" class="shadow round">
                
                <tr>
                    <td style="padding: 0px 5px 5px 5px" valign="top">
                        <p style="text-align: center; float: left; width: 100%; padding: 0px; margin: 10px 0px 15px 0px">
                            <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#CC0000"
                                Font-Names="Bell MT"></asp:Label>
                        </p>
                        <asp:Panel ID="pnl_view" runat="server" Visible="false">
                            <div style="margin: 0px 0px 0px 10px; padding: 0px; float: left; width: 930px; height: auto; text-align: center;"
                                class="round">
                                <asp:GridView ID="grd_epin" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto;"
                                    Width="930px" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Serial No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Bankname" runat="server" Text='<%#bind("Bankname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Transaction" runat="server" Font-Names="Arial" Text='<%#bind("Transaction_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="IFSC Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ifscecode" runat="server" Font-Names="Arial" Text='<%#bind("IFSCCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Amount" runat="server" Text='<%#bind("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Date" runat="server" Text='<%#bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_txt_time" runat="server" Text='<%#bind("Time") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Slip">
                                            <ItemTemplate>
                                                    <a href='<%#Eval("Slippath") %>' target="_blank" style="padding: 25px 0px 0px 26px; background-image: url('../images/icon-download.png'); background-repeat: no-repeat; background-position: left top; font-family: ebrima; font-size: 14px; color: #0066CC; text-decoration: none;"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#bind("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#00A4CC" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
            </div>
        </div>
    </div>

   
</asp:Content>
