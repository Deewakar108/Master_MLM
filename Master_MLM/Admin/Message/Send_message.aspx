<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Send_message.aspx.cs" Inherits="Master_MLM.Admin.Send_message"
    Title="   View Sent Message"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View Sent Message
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.ninth
        {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function printTable() {
            var printContent = document.getElementById("tblPrintIQ");
            var windowUrl = 'abount:blank';
            var num;
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(num, windowName, 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Messages</a>
                <a href="#" class="current">Messages Sent</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%=print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_expord.ClientID %>').click();"></i></span>
                        <h5>Messages Sent</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                    Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_view_message" runat="server" Visible="False" Style="margin: 0px;">
                        <div class="row-fluid" id="tblPrintIQ" >
                            <asp:GridView ID="grd_view_sent_message" runat="server"  CssClass="table table-bordered data-table dataTable" 
                                AutoGenerateColumns="False">
                                
                                <Columns>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_subject" runat="server" Font-Names="Arial" Text='<%#Bind("Subject") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Message">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_message" runat="server" Font-Names="Arial" Text='<%#Bind("Message") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="400px" />
                                        <ItemStyle Width="400px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TO">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_to" runat="server" Font-Names="Arial" Text='<%#Bind("Receiver_id") %>'></asp:Label>,
                                            <asp:Label ID="Label1" runat="server" Font-Names="Arial" Text='<%#Bind("Receiver_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" runat="server" Font-Names="Arial" Text='<%#Bind("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                        </div>
                        </asp:Panel>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
