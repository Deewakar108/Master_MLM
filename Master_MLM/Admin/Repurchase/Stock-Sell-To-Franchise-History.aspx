<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Stock-Sell-To-Franchise-History.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Stock_Sell_To_Franchise_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Stock Sell To Franchise History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-horizontal .control-group {
            width: 50%;
            float: left;
        }

        .table th {
            font-size: 12px;
            text-align: left;
        }

        .tbl-styl {
            border: 1px solid #CCCCCC;
            padding: 0px;
            margin: 10px;
            width: 605px;
            font-family: arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            background-color: #FFFFFF;
            float: right;
        }

        @media only screen and (max-width:800px) {
            .form-horizontal .control-group {
                width: 100%;
            }

            .tbl-styl {
                float: left;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="../home.aspx" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Franchise</a>
                <a href="#" class="current">Distribute Stock History</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distribute Stock History</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal width-forty" id="basic_validate">
                                <div class="control-group">
                                    <label class="control-label">Sell Franchise Code  :</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_main_franchise_code" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_main_franchise_code_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Franchise Code  :</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_stockcode" runat="server"></asp:DropDownList>
                                        <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="btn btn-success" OnClick="btn_find_Click" />
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Name :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_membername" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">City :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_city" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Mobile No :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_mobileno" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>
                                </div>
                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <asp:Panel ID="panel_view" runat="server" Visible="false">
                                <div class="form-horizontal">
                                    <div class="grd-wprr" style="margin: 20px 0px 0px 0px;">
                                        <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered data-table dataTable"
                                            AutoGenerateColumns="False" AutoGenerateSelectButton="false" AutoGenerateEditButton="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="View Details">
                                                    <ItemTemplate>

                                                        <a href="#" onclick='openWindow("<%# DataBinder.Eval(Container.DataItem,"Stockpoint_code")+"&Distribution="+DataBinder.Eval(Container.DataItem,"Distribution")%>")'>
                                                            <asp:Label ID="lbl_Referalcode" runat="server" Text="View Details"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Distribution No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Distribution" runat="server" Text='<%#Bind("Distribution") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Stockpoint_code" runat="server" Text='<%#Bind("Stockpoint_code") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mrp">

                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <script type="text/javascript">
          function openWindow(code) {
              window.open('Distribute-Stock-History-Details.aspx?Stockpoint_code=' + code, 'open_window', ' width=1100, height=480, left=0, top=0');
          }
    </script>
</asp:Content>
