<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print_joining_voucher.aspx.cs"
    Inherits="Master_MLM.print_slip.print_joining_voucher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Voucher</title>
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
            if (window.print) {
                window.print();
            }
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

</head>
<body onload="changeHashOnLoad();">
    <form id="form1" runat="server">
        <table style="margin: 20px auto 0px auto; font-size: 16px; height: auto; width: 800px; border-spacing: 0px; background-color: #FFFFFF; font-family: calibri; border: 1px solid #ccc;"
            border="0"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align: center" colspan="4" valign="top">
                    <div style="margin: 0px auto; text-align: center;">
                            <img src="../images/logo.png" style="margin: 0px auto; padding: 7px;"
                                alt=" " />
                    </div>
                </td>
                <%--<td style="text-align: center" colspan="3" valign="top">
                    <div style="margin: 0px auto; text-align: left;">
                            <img src="../images/header.png" style="margin: 0px auto; padding: 7px;"
                                alt=" " />
                    </div>
                </td>--%>
            </tr>
            <tr>
                <td style="border-top: 1px solid #ccc; border-bottom: 1px solid #ccc; padding: 0px; text-align: center; font-weight: bold; font-size: 22px; height: 45px; color: #078615;"
                    colspan="4"><%--(  REGISTRATION CONFIRMATION RECEIPT/ WELCOME LETTER )--%> REGISTRATION RECEIPT
                </td>
            </tr>


            <tr>
                <td style="padding: 0px; color: #000000;" colspan="4">
                    <p style="float: left; padding: 4px 10px 0px 10px; margin: 0px; width: 98%; font-family: calibri; font-size: 17px; text-align: center;">
                        Your registration details are as follow :-
                    </p>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Name :
                <asp:Label ID="lbl_name0" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">&nbsp;</td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Member Code :
                <asp:Label ID="lbl_code" runat="server"></asp:Label>
                <asp:Label ID="lbl_username" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">&nbsp;
                <asp:Label ID="lblpassword" runat="server" Visible="false"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">User ID :
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">Password :
                <asp:Label ID="lblPasswordPwd" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Sponsor Code :
                <asp:Label ID="lbl_introcode" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">Sponsor Name :
                <asp:Label ID="lbl_sponsorname" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>

            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Spiller Code :
                <asp:Label ID="lbl_Referralcode" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">Spiller Name :
                <asp:Label ID="lbl_Referral_name" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>

            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Joining Package :
                <asp:Label ID="lbl_joiningpackage" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">Amount Paid :
                <asp:Label ID="lbl_amountpaid" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>
            
            <%--<tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Bank Name :
                <asp:Label ID="lblBankName" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">DD Number :
                <asp:Label ID="lblDDNumber" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
            </tr>--%>
            <tr>
                <td style="text-align: left; padding: 10px 10px 0px 50px;">Position :
                <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;</td>
                <td style="text-align: left; padding: 10px 10px 0px 30px;">Mobile No. :
                    <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: left; padding-top: 10px;">&nbsp;
                    </td>
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
        </table>
        <%--<table style="margin: 20px auto 0px auto; display: none; font-size: 16px; height: auto; width: 800px; border-spacing: 0px; background-color: #FFFFFF; font-family: calibri; border: 1px solid #ccc;"
            border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2"  style="text-align: center; padding-top: 15px; ">
                    <b><u>DECLARATION</u></b>
                </td></tr>
            <tr>
                <td colspan="2" style="padding: 15px; text-align: justify;">
                    I undertake and declare that I am over 18 years of age and have passed class - 8th examinations. I have read and fully understood the Terms and Conditions 
                    (Legal's) and all other information provided by  <b style="font-size: 12px;">RSOVISION</b>  on their site http://rsovision.com. I accept and agree to all the Terms & conditions 
                    set by RSOVISION and signing this undertaking on my own free will and for this I am under no pressure, undue influence or inducement. I am fully aware that 
                    any dispute arising out of my dealings with <b style="font-size: 12px;">RSOVISION</b> will be resolved by the company in terms of the extant Terms & Conditions of the company failing the 
                    which the dispute may be resolved only in courts with jurisdiction at Patna only.
                    <br /><br /><br />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 25px; ">
                    Verified that the above information provided and the declaration made by me is correct in all respects.
                    <br /><br /><br /><br /><br />
                    Signatue 
                </td>
                <td style="text-align: right; padding: 25px; ">
                    Verified that the signatures of the Purchasing Associate are authentic and he/she is atleast 18 years of age.
                     <br /><br /><br /><br /><br />
                    Signatue 
                </td>
            </tr>
        </table>--%>
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
                        Font-Bold="True" ForeColor="White" OnClick="btn_print_Click" CssClass="noPrint" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
