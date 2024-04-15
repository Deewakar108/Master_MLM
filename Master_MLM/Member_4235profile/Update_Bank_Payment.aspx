<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Update_Bank_Payment.aspx.cs" Inherits="Master_MLM.Member_4235profile.Update_Bank_Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            background-color: #F700A9;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb"><li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li></ol>
    
      <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Update Bank Payment Status</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 30px 0px 0px 0px;">
        <div class="block">
            <div class="block1">
                <table cellspacing="0" cellpadding="0" border="0" style="margin: 25px auto 21px auto; background-color: White; border: 1px solid #666666; width: 504px; height: 120px;"
                    class="round shadow">
                    
                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Amount deposited <sup>*</sup>:
                        </td>
                        <td colspan="2" style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;">
                            <asp:TextBox ID="txt_amount" CssClass="form-control" Width="252px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_amount"
                                ErrorMessage="**" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align:middle; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Bank name <sup>*</sup>:
                        </td>
                        <td colspan="2" style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;">
                            <asp:TextBox ID="txt_bank_name" CssClass="form-control"  runat="server" Width="252px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_bank_name"
                                ErrorMessage="**" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Transaction No.<%--<sup>*</sup> --%>:
                        </td>
                        <td colspan="2" style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;">
                            <asp:TextBox ID="txt_transitionno"  CssClass="form-control"  runat="server" Width="252px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_transitionno"
                                ErrorMessage="**" ForeColor="#CC0000"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">IFSC Code<sup>*</sup> :
                        </td>
                        <td colspan="2" style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;">
                            <asp:TextBox ID="txt_ifsccode" CssClass="form-control"  runat="server" Width="252px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ifsccode"
                                ErrorMessage="**" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>


                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Date <sup>*</sup> :
                        </td>
                        <td colspan="2" style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;">
                            <asp:DropDownList ID="ddl_day" runat="server"  CssClass="form-control" 
                                Style="color: Green; width: 70px; font-weight: bold; float: left;"
                                >
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
                            &nbsp;<asp:DropDownList ID="ddl_month"  CssClass="form-control" runat="server" 
                                Style="color: Green; float: left; width: 70px; font-weight: bold;"
                                >
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
                            &nbsp;<asp:DropDownList ID="ddl_year" CssClass="form-control"  runat="server" 
                                Style="color: Green; width: 100px; font-weight: bold; float: left;"
                                >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Time<sup>*</sup> :
                        </td>
                        <td style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;" colspan="2">
                            <asp:TextBox ID="txt_time" CssClass="form-control"  runat="server" Width="252px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_time"
                                ErrorMessage="**" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;">Uploade Slip<%-- <sup>*</sup>--%> :
                        </td>
                        <td style="text-align: left; padding: 10px 0px 0px 0px; font-family: ebrima; font-size: 15px;" colspan="2">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Width="252px"/>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="text-align: right; padding: 10px 20px 0px 0px; font-family: ebrima; font-size: 15px;"></td>
                        <td style="padding: 10px 0px 10px 0px; text-align: left;" colspan="2">
                            <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-success" Text="Send" Width="150px" Height="30px" OnClick="btn_submit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0px 10px 0px; text-align: center;" colspan="3">
                            <asp:Label ID="lbl_msg" runat="server" Font-Bold="False" Font-Size="12px" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
            </div>
        </div>
    </div>

   

</asp:Content>
