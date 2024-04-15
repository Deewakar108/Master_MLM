<%@ Page Title="Pin Request" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Request_pin.aspx.cs" Inherits="Master_MLM.Member_4235profile.Request_pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            background-color: #F700A9;
            color: #fff;
        }

        .border {
            border: 1px solid red;
        }

        .form-control {
            padding: 6px 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="javascript:">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Send Request for Pin Purchase</a></h4>
            <div class="panel-body panel-footer">

                <div class="row" style="padding: 30px 0px 0px 0px;">
                    <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                        <p style="margin: 0px; padding: 0px; float: left; width: 100%; text-align: center">
                            <asp:Label ID="lbl_message" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="Red"></asp:Label>
                        </p>
                    </div>


                    <div class="col-lg-3">
                    </div>
                    <div class="col-lg-6" style="padding: 10px 0px; border: 1px solid #5cb85c;">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_paename">Select Package</label>
                                <asp:DropDownList ID="ddl_package" CssClass="form-control" runat="server" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_bankname">Enter Pin Qty.</label>
                                <asp:TextBox ID="txt_pinqty" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_pinqty"
                                    ErrorMessage="**" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_accno">Amount Deposited</label>
                                <asp:TextBox ID="txt_amount" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_amount"
                                    ErrorMessage="**" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_ifsccode">Bank Name</label>
                                <asp:TextBox ID="txt_bank_name" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_bank_name"
                                    ErrorMessage="**" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_bankbranch">Transaction No.</label>
                                <asp:TextBox ID="txt_transitionno" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_transitionno"
                                    ErrorMessage="**" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txtPANNumber" style="float: left; width: 100%;">Date</label>
                                <asp:DropDownList ID="ddl_day" runat="server" CssClass="form-control"
                                    Style="color: Green; width: 60px; font-weight: bold; float: left;">
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;<asp:DropDownList ID="ddl_month" CssClass="form-control" runat="server"
                                    Style="padding-left: 10px; color: Green; width: 60px; float: left; font-weight: bold;">
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;<asp:DropDownList ID="ddl_year" runat="server" CssClass="form-control" Style="padding-left: 10px; float: left; color: Green; width: 80px; font-weight: bold;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-12 text-right">
                            <div class="form-group">
                                <label for="btn_update">&nbsp;</label>

                                <asp:Button ID="btn_submit" CssClass="btn btn-success" runat="server" Text="Send request" Width="150px"
                                    Height="30px" OnClick="btn_submit_Click" />
                                <br />
                                <asp:Label ID="lbl_msg" runat="server" Font-Bold="False" Font-Size="12px" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                    </div>

                </div>
            </div>
        </div>
    </div>






</asp:Content>


