﻿<%@ Page Title="Transfer Pin List" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Transfer_243254_pin_list.aspx.cs" Inherits="Master_MLM.Member_4235profile.Transfer_243254_pin_list" %>

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

    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i>Transfer Pin</li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Transfer Pin
            </a><span style="float: right"><a href="javascript:printDiv('epin_generated')">
                <img src="../images/printer.png" height="20" width="20" border="0" alt=" " /></a>
                <asp:ImageButton ID="img_export" runat="server" Height="20px" Width="20px" ImageUrl="~/images/Excelicons.png"
                    Style="margin-left: 20px" OnClick="img_export_Click" /></span></h4>


            <div class="row" style="padding: 3px 0px 0px 0px; margin:0px; border-top: 1px solid #ddd;">
                <div id="epin_generated" style="margin: 0px auto 0px auto; padding: 10px 25px; width: 100%; height: auto; overflow-y: auto;">
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
                                    <asp:TemplateField HeaderText="Transfer Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_transfer_date" runat="server" Text='<%#Bind("Transfer_date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="E-Pin">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_epin" runat="server" Text='<%#Bind("Epin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Participate Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_used_to" runat="server" Text='<%#Bind("Transfer_to") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Participate Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_transferto_name" runat="server" Text='<%#Bind("Transferto_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#00A4CC" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    <p style="text-align: center; float: left; width: 100%; padding: 0px; margin: 10px 0px 15px 0px">
                        <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#CC0000"
                            Font-Names="Bell MT"></asp:Label>
                    </p>
                </div>
            </div>
            <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>


        </div>
    </div>




</asp:Content>
