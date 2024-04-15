<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Delete_distributed_epin.aspx.cs" Inherits="Master_MLM.Admin.Delete_distributed_epin"
    Title="Delete Distributed E-pin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Delete Distributed E-pin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.second {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        .block {
            margin: 0px;
            padding: 0px 0px 30px 0px;
            width: 100%;
            text-align: center;
            float: left;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }

        .minimum-height {
            min-height: 517px;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function PrintPage() {
            var printContent = document.getElementById('<%= pnl_view.ClientID %>');
            var printWindow = window.open("All Records", "Print Panel", 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
        }

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Delete Distributed E-Pin</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= ImageButton1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_exportgrd.ClientID %>').click();"></i></span>
                        <h5>Delete Distributed E-Pin</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none;">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/images/printer.png"
                                                OnClientClick="PrintPage();" />
                                            
                                            <asp:ImageButton ID="img_exportgrd" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                OnClick="img_exportgrd_Click" Style="margin-left: 20px" />
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: right;">
                                <asp:Button ID="btn_checkall" runat="server" OnClick="btn_checkall_Click" Text="Check All"
                                                 CssClass="btn btn-info" />
                            </div>
                        </div>
                        <br />
                         <asp:Panel ID="pnl_view" runat="server" Visible="false">

                        <div class="row-fluid">
                            
                            <asp:GridView ID="grd_epin_distributed" runat="server" CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_distributed_PageIndexChanging"
                                EnableModelValidation="True">
                                <PagerStyle  CssClass="pagination-sks" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_membercode" runat="server" Font-Names="Arial" Text='<%#bind("distributed_to") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_membername" runat="server" Font-Names="Arial" Text='<%#bind("Member_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Epin">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_pin" runat="server" Font-Names="Arial" Text='<%#bind("Epin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Package">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#bind("Package") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#bind("ID") %>'
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="CheckBox1" runat="server" ToolTip="Check for delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            
                        </div>
                        
                                        </asp:Panel>
                        <div class="row-fluid">
                            <div class="span6">
                                <asp:Label ID="lbl_message_d" runat="server" ></asp:Label>
                                <asp:Label ID="lbl_msg" runat="server" Font-Size="14px" CssClass="label label-warning"></asp:Label>
                            </div>
                            <div class="span6" style="text-align: right;">
                                <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" 
                                                    OnClientClick="return confirm('Are you sure want delete this data ?')"  CssClass="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
