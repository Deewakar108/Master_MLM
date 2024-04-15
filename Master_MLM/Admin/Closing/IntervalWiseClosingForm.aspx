<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="IntervalWiseClosingForm.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.IntervalWiseClosingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Closing
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function OnClick() {
            $("#<%= btnSubmit.ClientID%>").val("Work is in Progress...");
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Closing</a>
                <a href="#" class="current">Make Closing</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Make Closing</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblPreviousClosingDate" runat="server" Text="Previous Closing Date : 01/12/2017" CssClass="label label-warning"></asp:Label>
                                <asp:HiddenField ID="hdfClosingNumberInt" runat="server" />
                                <asp:HiddenField ID="hdfClosingNumber" runat="server" />
                                <asp:HiddenField ID="hdfDeleteID" runat="server" />
                            </div>
                            <div class="span12" style="text-align: center; display: none;">
                                Interval : 
                                <asp:DropDownList ID="ddlInterval" runat="server" Enabled="false">
                                    <asp:ListItem Value="1" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="2" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="3" Text="03">03</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                Start Date : 
                                <asp:DropDownList ID="ddlStartDate" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                    <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                    <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                    <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                    <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                    <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                    <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                    <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                    <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                    <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                                    <asp:ListItem Value="13" Text="13">13</asp:ListItem>
                                    <asp:ListItem Value="14" Text="14">14</asp:ListItem>
                                    <asp:ListItem Value="15" Text="15">15</asp:ListItem>
                                    <asp:ListItem Value="16" Text="16">16</asp:ListItem>
                                    <asp:ListItem Value="17" Text="17">17</asp:ListItem>
                                    <asp:ListItem Value="18" Text="18">18</asp:ListItem>
                                    <asp:ListItem Value="19" Text="19">19</asp:ListItem>
                                    <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                    <asp:ListItem Value="21" Text="21">21</asp:ListItem>
                                    <asp:ListItem Value="22" Text="22">22</asp:ListItem>
                                    <asp:ListItem Value="23" Text="23">23</asp:ListItem>
                                    <asp:ListItem Value="24" Text="24">24</asp:ListItem>
                                    <asp:ListItem Value="25" Text="25">25</asp:ListItem>
                                    <asp:ListItem Value="26" Text="26">26</asp:ListItem>
                                    <asp:ListItem Value="27" Text="27">27</asp:ListItem>
                                    <asp:ListItem Value="28" Text="28">28</asp:ListItem>
                                    <asp:ListItem Value="29" Text="29">29</asp:ListItem>
                                    <asp:ListItem Value="30" Text="30">30</asp:ListItem>
                                    <asp:ListItem Value="31" Text="31">31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                    <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                    <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                    <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                    <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                    <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                    <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                    <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                    <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                    <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="span2">
                                    <asp:ListItem Value="2018" Text="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019" Text="2019">2019</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                End Date : 
                                <asp:DropDownList ID="ddlEndDate" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                    <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                    <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                    <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                    <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                    <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                    <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                    <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                    <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                    <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                                    <asp:ListItem Value="13" Text="13">13</asp:ListItem>
                                    <asp:ListItem Value="14" Text="14">14</asp:ListItem>
                                    <asp:ListItem Value="15" Text="15">15</asp:ListItem>
                                    <asp:ListItem Value="16" Text="16">16</asp:ListItem>
                                    <asp:ListItem Value="17" Text="17">17</asp:ListItem>
                                    <asp:ListItem Value="18" Text="18">18</asp:ListItem>
                                    <asp:ListItem Value="19" Text="19">19</asp:ListItem>
                                    <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                    <asp:ListItem Value="21" Text="21">21</asp:ListItem>
                                    <asp:ListItem Value="22" Text="22">22</asp:ListItem>
                                    <asp:ListItem Value="23" Text="23">23</asp:ListItem>
                                    <asp:ListItem Value="24" Text="24">24</asp:ListItem>
                                    <asp:ListItem Value="25" Text="25">25</asp:ListItem>
                                    <asp:ListItem Value="26" Text="26">26</asp:ListItem>
                                    <asp:ListItem Value="27" Text="27">27</asp:ListItem>
                                    <asp:ListItem Value="28" Text="28">28</asp:ListItem>
                                    <asp:ListItem Value="29" Text="29">29</asp:ListItem>
                                    <asp:ListItem Value="30" Text="30">30</asp:ListItem>
                                    <asp:ListItem Value="31" Text="31">31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                    <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                    <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                    <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                    <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                    <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                    <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                    <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                    <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                    <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="span2">
                                    <asp:ListItem Value="2018" Text="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019" Text="2019">2019</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-bottom: 10px;" OnClientClick="return OnClick();" CssClass="btn btn-success"
                                    OnClick="btnSubmit_Click" />
                                <br />
                                <br />
                                <asp:Label ID="lblMessage" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
