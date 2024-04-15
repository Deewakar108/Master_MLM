<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Received_message.aspx.cs" Inherits="Master_MLM.Admin.Received_message"
    Title=" View Received Message" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View Received Message
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.ninth {
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
                <a href="#" class="current">Messages Received</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%=print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_expord.ClientID %>').click();"></i></span>
                        <h5>Messages Received</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid" id="tblPrintIQ">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server"  CssClass="label label-warning"></asp:Label>
                            </div>
                            <div style="display: none;">
                                <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                    Style="margin-left: 0px;" OnClick="img_expord_Click" />
                            </div>
                            <asp:Panel ID="pnl_view_message" runat="server" Visible="False">
                                <asp:GridView ID="grd_view_received_message" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_view_received_message_PageIndexChanging">

                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk_reply" runat="server" OnClick="lnk_reply_Click" CssClass="noPrint">Reply</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                                        <asp:TemplateField HeaderText="FROM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_from" runat="server" Font-Names="Arial" Text='<%#Bind("Sender_id") %>'></asp:Label>,
                                            <asp:Label ID="lbl_name" runat="server" Font-Names="Arial" Text='<%#Bind("Sender_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_receiver_id" runat="server" Font-Names="Arial" Text='<%#Bind("Receiver_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ID" runat="server" Font-Names="Arial" Text='<%#Bind("id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </asp:Panel>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_reply_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>

                        <asp:Panel ID="pnl_reply" runat="server" Visible="False">
                            <div class="row-fluid">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <h5>Reply Message</h5>
                                    </div>
                                    <div class="widget-content">
                                        <div class="row-fluid">
                                            <div class="form-horizontal" method="post" action="#" name="basic_validate" id="basic_validate" novalidate="novalidate">
                                                <div class="control-group">
                                                    <label class="control-label">To :</label>
                                                    <div class="controls">
                                                        <asp:Label ID="lbl_to" runat="server" ForeColor="Maroon"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">Subject :</label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_subject" runat="server" CssClass="span6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_subject"
                                                            Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">Message : </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_message" runat="server" Rows="5" CssClass="span6"
                                                            TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_message"
                                                            Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <div class="controls">
                                                        <asp:Button ID="btn_send" Text="Send" runat="server" CssClass="btn btn-success" OnClick="btn_send_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
