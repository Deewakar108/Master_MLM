<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="epin_distribute.aspx.cs" Inherits="Master_MLM.Admin.epin_distribute"
    Title="Distribute E-pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Distribute E-pin
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
    </style>

    <script>
        function AlertMe() { document.getElementById("sksButton").click(); }

        function printDiv(divId) {
            window.frames["print_frame"].document.body.innerHTML = printDivCSS + document.getElementById(divId).innerHTML
            window.frames["print_frame"].window.focus()
            window.frames["print_frame"].window.print()
        }
    </script>

    <style type="text/css">
        @media print {
            .noPrint {
                display: none;
            }
        }

        span {
            color: #666;
        }
    </style>

    <script type="text/javascript">
        function printit() {
            var divId = document.getElementById("tblSlip");
            alert(divId);
            printDiv(divId)
            //if (window.print) {
            //    window.print();
            //}
        }

        function printTable() {
            var printContent = document.getElementById("tblSlip");
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
            return false;
        }
    </script>

    <script type="text/javascript">
        function changeHashOnLoad() {
            window.location.href += "#";
            setTimeout("changeHashAgain()", "50");
        }

        function changeHashAgain() {
            window.location.href += "1";
        }

        var storedHash = window.location.hash;
        window.setInterval(function () {
            if (window.location.hash != storedHash) {
                window.location.hash = storedHash;
            }
        }, 50);


    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="notification" style="display: none;">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message1" runat="server" Style="padding: 10px 20px 0px 10px; background-position: left center; background-image: url('../images/warningicon.png' ); background-repeat: no-repeat; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>

    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Distribute E-Pin</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distribute E-Pin</h5>
                    </div>
                    <div class="widget-content">
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="row-fluid">
                                <div class="span2">
                                    Member Code : 
                                </div>
                                <div class="span3">
                                    <asp:TextBox ID="txtMemberCode" runat="server" placeholder="Member Code"></asp:TextBox>
                                </div>
                                <div class="span1">
                                    <asp:Button ID="btnMemberFind" runat="server" Text="Find" CssClass="btn btn-primary btn-sm" OnClick="btnMemberFind_Click" />
                                    <asp:HiddenField ID="hdfMemberCode" Value="0" runat="server" />
                                </div>
                                <div class="span4">
                                    <asp:Label ID="lblMemberName" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                            <hr />
                            <div class="row-fluid">
                                <div class="controls">
                                    <div class="span3">
                                        Package : 
                                    <asp:DropDownList ID="ddl_package" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_package_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </div>
                                    <div class="span2">
                                        Available Quantity :  
                                    <asp:TextBox ID="txtAvailableQuantity" runat="server" placeholder="Available Quantity" Enabled="false"  style="max-width: 120px;"></asp:TextBox>
                                    </div>

                                    <div class="span2">
                                        Amount : 
                                    <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount" Enabled="false" style="max-width: 120px;"></asp:TextBox>
                                    </div>
                                    
                                    <div class="span2">
                                        Quantity :  
                                    <asp:TextBox ID="txtQuantity" runat="server" placeholder="Quantity" style="max-width: 120px;"></asp:TextBox>
                                    </div>
                                    <div class="span2">
                                        <br />
                                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="Add" CssClass="btn btn-info btn-sm" />
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <asp:GridView ID="grdDistributedPin" AutoGenerateColumns="false" OnRowCommand="grdDistributedPin_RowCommand" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true" runat="server">
                                <EmptyDataTemplate>
                                    <div style="text-align: center;">
                                        No Record Found.
                                    </div>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Package Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger btn-sm" Text="Delete" CommandArgument='<%# Bind("ID") %>' CommandName="IsDelete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <hr />
                            <div class="row-fluid">
                                <div class="span6" style="text-align: left;">
                                    Total Amount :
                                <asp:Label ID="lblTotal" runat="server" Text="0" CssClass="label label-warning"></asp:Label>
                                </div>
                                <div class="span6" style="text-align: right">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn  btn-success" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                            <div class="row-fluid">
                                <div class="span12" id="tblSlip">
                                    <table style="margin: 20px auto 0px auto; font-size: 16px; height: auto; width: 800px; border-spacing: 0px; background-color: #FFFFFF; font-family: calibri; border: 1px solid #ccc;"
                                        border="0"
                                        cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="text-align: center" colspan="4" valign="top">
                                                <div style="margin: 0px auto; text-align: center;">
                                                    <img src="../../Content/Images/logo/logo.png" style="margin: 0px auto; padding: 7px;"
                                                        alt=" " />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-top: 1px solid #ccc; border-bottom: 1px solid #ccc; padding: 0px; text-align: center; font-weight: bold; font-size: 22px; height: 45px; color: #078615;"
                                                colspan="4">E-Pin Transfer Slip
                                            </td>
                                        </tr>


                                        <tr>
                                            <td style="padding: 0px; color: #000000;" colspan="4">
                                                <p style="float: left; padding: 4px 10px 0px 10px; margin: 0px; width: 98%; font-family: calibri; font-size: 17px; text-align: center;">
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding: 10px 10px 0px 50px;">Member Name :
                <asp:Label ID="lbl_name0" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="text-align: left; padding-top: 10px;">Date :</td>
                                            <td style="text-align: left; padding: 10px 10px 0px 30px;">&nbsp;</td>
                                            <td style="text-align: left; padding-top: 10px;">
                                                <asp:Label ID="lblDate" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding: 10px 10px 0px 50px;">Member Code :
                <asp:Label ID="lbl_code" runat="server"></asp:Label>
                                            </td>
                                            <td style="text-align: left; padding-top: 10px;">Transaction ID : </td>
                                            <td style="text-align: left; padding: 10px 10px 0px 30px;">&nbsp;
                <asp:Label ID="lblpassword" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td style="text-align: left; padding-top: 10px;">
                                                <asp:Label ID="lblTransactionID" runat="server"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 0px; color: #000000;" colspan="4"></td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: center; height: 20px; font-weight: bold; font-size: 16px;"
                                                colspan="4">
                                                <asp:Label ID="lbl_date" runat="server" Visible="False" Style="float: right; margin: 0px 0px 0px 0px;"></asp:Label>
                                                <asp:Label ID="lbl_formno" runat="server" Style="float: left; margin: 0px 0px 0px 0px;"
                                                    Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center; padding: 20px;">
                                                <asp:GridView ID="grdSlip" Style="width: 100%;" AutoGenerateColumns="false" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true" runat="server">
                                                    <EmptyDataTemplate>
                                                        <div style="text-align: center;">
                                                            No Record Found.
                                                        </div>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl. No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Package Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: left; padding: 15px;">Total Amount :
                                            <asp:Label ID="lblTotalAmountSlip" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />

                                </div>
                                <div class="span12">
                                    <table style="margin: 0px auto 0px auto; font-size: 16px; height: auto; width: 780px; border-spacing: 0px;"
                                        border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="height: 50px; text-align: left" colspan="2">
                                                <asp:Button ID="btn_back" runat="server" Text="Back" Height="35px" Width="115px"
                                                    BackColor="#FF5A1F" BorderColor="#FF5A1F" BorderStyle="Outset" BorderWidth="2px"
                                                    Font-Bold="True" ForeColor="White" OnClick="btn_back_Click" CssClass="noPrint" />
                                            </td>
                                            <td style="height: 50px; text-align: right" colspan="2">
                                                <asp:Label ID="lbl_session" runat="server" Text="" Visible="False"></asp:Label>
                                                <asp:Button ID="btn_print" runat="server" Text="Print" Height="35px" Width="115px"
                                                    BackColor="#FF5A1F" BorderColor="#FF5A1F" BorderStyle="Outset" BorderWidth="2px"
                                                    Font-Bold="True" ForeColor="White" OnClick="btn_print_Click" OnClientClick="return printTable();" CssClass="noPrint" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="btn btn-success" style="display: none;" id="sksButton" onclick="$('#gritter-notice-wrapper1').show().fadeOut(8000);">
        SKS
    </div>
    <div id="gritter-notice-wrapper1" style="display: none;">
        <div id="gritter-item-1" class="gritter-item-wrapper  hover" style="">
            <div class="gritter-top"></div>
            <div class="gritter-item">
                <div class="gritter-close" style="display: block;" onclick="$('#gritter-notice-wrapper1').fadeOut(500);"></div>
                <img src="../img/demo/envelope.png" class="gritter-image" />
                <div class="gritter-with-image">
                    <span class="gritter-title">Message</span>
                    <p>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="gritter-bottom"></div>
        </div>
    </div>

    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
</asp:Content>
