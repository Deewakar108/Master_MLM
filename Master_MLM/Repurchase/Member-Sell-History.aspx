<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="Member-Sell-History.aspx.cs" Inherits="Master_MLM.Repurchase.Member_Sell_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Member Sell History
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
            .textbx-lbl-name {
                width: 100%;
                text-align: left;
            }

            .textbx-wpr {
                margin-left: 0px;
                padding: 10px 0;
            }
        }
    </style>
    <style type="text/css">
        ul#tabmenu a.three {
            background-color: #e91b23;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
    
    <script type="text/javascript" language="javascript">
        $(function () {
            //var date = new Date();
            //var y = date.getUTCFullYear();
            //var m = date.getMonth();
            //var d = date.getDate();

            $("#<%=txt_fromdate.ClientID %>").datepicker({
                //minDate: new Date(y, m, d),
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2100"
            }).attr('readonly', 'true');

            $("#<%=txt_todate.ClientID %>").datepicker({
                //minDate: new Date(y, m, d),
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2100"
            }).attr('readonly', 'true');
        });
    </script>
    <script type="text/javascript">
        function printTable() {
            document.getElementById('myid').style.display = "none";
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Member Sell History</a></h4>
            <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>

            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <div class="grd-over-flow">
                        <div class="grd-over-flow" style="margin: 0px 0px 0px 0px">
                            <div class="textbx-box" style="width: 100%;">
                                <p class="textbx-lbl-name">From Date :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_fromdate" runat="server"></asp:TextBox><span> To </span>
                                    <asp:TextBox ID="txt_todate" runat="server"></asp:TextBox>
                                    <asp:Button ID="btn_search_by_date" runat="server" class="btn btn-success" Text="Search By Date" OnClick="btn_search_by_date_Click"  />
                                </div>
                            </div>
                            <div class="textbx-box" style="width: 100%;">
                                <p class="textbx-lbl-name">Member Code :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_memberid" runat="server"></asp:TextBox>
                                    <asp:Button ID="btn_search_by_id" runat="server" class="btn btn-success" Text="Search By Code" OnClick="btn_search_by_id_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="panel_view" runat="server" Visible="false">
                            <div id="tblPrintIQ" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #CCCCCC; padding: 5px; margin: 30px 0px 0px 0px; float: left; width: 1028px;">
                                <h4 class="breadcrumb-item" style="width: 85%; float: left"><a>View Sell History</a></h4>
                                <h2 id="myid" style="text-align: right; width: 15%; margin: 0px; float: left;" class="noPrint">
                                    <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="images/printer.png" height="25" width="25" border="0" /></asp:LinkButton>
                                </h2>
                                <asp:GridView ID="gridview" runat="server" Width="1015px" Style="margin: 10px 0px 0px 0px; float: left; padding: 0px; text-align: center; font-weight: normal;"
                                    AutoGenerateColumns="False"
                                    BorderColor="#186B80" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Ebrima"
                                    Font-Size="12px" ForeColor="#333333">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="View Details">
                                            <ItemTemplate>
                                                <a href="#" onclick='openWindow("<%# DataBinder.Eval(Container.DataItem,"Stock_code")+"&Billno="+DataBinder.Eval(Container.DataItem,"Billno")+"&Membercode="+DataBinder.Eval(Container.DataItem,"Membercode")%>")'>
                                                    <asp:Label ID="lbl_Referalcode" runat="server" Text="View Details"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Member code ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Membercode" runat="server" Text='<%#Bind("Membercode") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Bill No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Billno" runat="server" Text='<%#Bind("Billno") %>'></asp:Label>
                                                <asp:Label ID="lbl_Stockpoint_code" runat="server" Text='<%#Bind("Stock_code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         
                                        <asp:TemplateField HeaderText="Total BV">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("TotalBV") %>'></asp:Label>
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
                            </div>
                        </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openWindow(code) {
            window.open('popup_sell_history.aspx?Stockpoint_code=' + code, 'open_window', ' width=1100, height=480, left=0, top=0');
        }
    </script>
</asp:Content>
