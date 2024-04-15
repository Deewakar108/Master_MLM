<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome_letter.aspx.cs" Inherits="Master_MLM.Member_4235profile.Welcome_letter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Welcome Letter</title>
    <style type="text/css">
        @font-face {
            font-family: 'MTCORSVA';
            src: url('./MTCORSVA.eot');
            src: local('MTCORSVA'), url('./MTCORSVA.woff') format('woff'), url('./MTCORSVA.ttf') format('truetype');
        }
        /* use this class to attach this font to any element i.e. <p class="fontsforweb_fontid_6771">Text with this font applied</p> */
        .fontsforweb_fontid_6771 {
            font-family: 'MTCORSVA' !important;
        }

        body, #form1 {
            width: 100%;
            height: auto;
            margin: 0px;
            padding: 0px;
            color: black;
        }

        .row {
            width: 850px;
            height: auto;
            margin: 0px;
            padding: 0px;
            float: left;
            font-family: Arial;
        }

        #logo {
            width: 100%;
            height: 148px;
            margin: 10px 0px 0px 0px;
            padding: 0px;
            float: left;
            text-align: center;
        }

        .block {
            width: 100%;
            height: auto;
            margin: 10px 0px 0px 0px;
            padding: 0px;
            float: left;
        }

        .tableheaader {
            padding: 10px 0px 10px 15px;
            border-top-style: solid;
            border-top-width: 1px;
            border-top-color: #000000;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: #000000;
            border-right-style: solid;
            border-right-width: 1px;
            border-right-color: #000000;
        }

        .lefttd {
            padding: 10px 0px 10px 15px;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: #000000;
        }

        .righttd {
            padding: 10px 0px 10px 15px;
            border-left-style: solid;
            border-left-width: 1px;
            border-left-color: #000000;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: #000000;
        }

        .cell_dwon {
            width: 411px;
            height: auto;
            margin: 0px;
            padding: 0px;
            float: left;
            background-color: White;
            /*font-family: 'Terminal Dosis', Arial, sans-serif;*/
        }

            .cell_dwon h2 {
                padding: 10px 0px 0px 30px;
                margin: 0px;
                color: #333333;
                width: 424px;
                height: 22px;
                float: left;
                text-align: justify;
                font-size: 15px;
            }

            .cell_dwon p {
                padding: 0px 0px 5px 0px;
                margin: 0px;
                width: 370px;
                height: auto;
                float: left;
                text-align: justify;
                line-height: 20px;
            }

            .cell_dwon span {
                font-size: 13px;
                color: #333333;
            }

        ul {
            width: 362px;
            height: auto;
            margin: 10px 0px 0px 39px;
            padding: 0px;
            list-style-image: url( '../images/icons/arrow.png' );
            list-style-position: outside;
            float: left;
            font-size: 13px;
            font-family: ebrima;
        }

            ul li {
                padding: 0px 0px 5px 0px;
                margin: 0px;
                float: left;
                width: 345px;
                height: 20px;
            }

        @media print {
            .noPrint {
                display: none;
            }
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
<body>
    <form id="form1" runat="server">
        <div style="width: 58px; position: absolute; top: 13px; left: 82px; height: 36px; bottom: 435px;">
            <asp:ImageButton ID="Img_back" runat="server" Height="34px" ImageUrl="~/images/backbtn.png"
                OnClick="Img_back_Click" Width="43px" CssClass="noPrint" />
        </div>
        <div style="width: 48px; position: absolute; top: 15px; left: 1195px; height: 36px;">
            <asp:ImageButton ID="Img_print" runat="server" ImageUrl="~/Content/images/printer.png" Height="34px"
                OnClick="Img_print_Click" Width="44px" CssClass="noPrint" />
        </div>
        <div style="width: 702px; margin: 0px auto; padding: 0px;">
            <div class="row">
                <div class="block">

                    <table style="margin: 15px; font-size: 13px; height: auto; width: 668px; border-spacing: 0px; float: left;"
                        border="0" cellpadding="0" cellspacing="0">


                        <tr>


                            <td style="vertical-align: top">
                                <div class="block" style="width: 313px; float: left; margin: 0px;">
                                    <p class="block">
                                      <img src="../images/logo.png" style="margin: 0px 0px 5px 0px; width: 306px;"
                                            alt="" />
                                    
                                    </p>

                                </div>
                            </td>
                            <td style="vertical-align: top; padding-top: 10px;">
                                <div class="block" style="width: 324px; float: left; margin: 0px;">
                                    <p style="font-size: 30px; font-weight: bold; color: #098fdd; font-family: 'Terminal Dosis', Arial, sans-serif; margin: 0px; padding: 0px;">Welcome To</p>
                                    <div class="cell_dwon" style="width: 100%">

                                        <p style="padding-left: 10px; width: 310px; color: #31ACF7; font-size: 18px; font-weight: bold; text-align: center; line-height: 27px;">
                                            <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>
                                        <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: black; font-size: 15px; font-weight: bold;"> </span>
                                        </p>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img src="../Content/images/borderimage.png" style="width: 660px" /></td>

                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: top; padding-bottom: 5px; padding-top: 15px;">
                                <div class="cell_dwon" style="width: auto;">
                                    <p>
                                        Distributed ID : &nbsp; 
                                        <asp:Label ID="lbl_code" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p>
                                        Name : &nbsp;  
                                        <asp:Label ID="lbl_name" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p>
                                        Address :&nbsp; 
                                        <asp:Label ID="lbl_address" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p>
                                        City :&nbsp; 
                                        <asp:Label ID="lbl_city" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p>
                                        Mobile No :&nbsp; 
                                        <asp:Label ID="lbl_mobileno" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p>
                                        Purchase Package :&nbsp; 
                                        <asp:Label ID="lbl_joiningamount" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p>
                                        Date of Purchase :&nbsp; 
                                        <asp:Label ID="lbl_date" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                     <p>
                                        Level :&nbsp; 
                                        <asp:Label ID="lbl_level" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                </div>
                            </td>


                        </tr>
                        <tr>
                            <td colspan="2" style="padding-top: 15px;">
                                <div class="cell_dwon" style="width: 100%;">
                                    <p>
                                        Dear&nbsp; 
                                        <asp:Label ID="lbl_name1" runat="server" Font-Bold="true"></asp:Label>
                                    </p>
                                    <p style="padding-top: 5px;">
                                        Congratulations on Your Decision To Come with us
                                    </p>
                                    <p style="width: 100%; padding-top: 10px; line-height: 25px; color: #000;">
                                        You are now a part of the opportunity of the Year. <asp:Label ID="lblCompanyName1" runat="server" Text=""></asp:Label>  is an exciting "People Business".  A business, that has the potential, to turn your dreams, into reality. As you build your business, you will establish lifelong friendships and develop support systems unparalleled in any other business.&nbsp; We pledge our best efforts to provide the levels of continuing support necessary to ensure that your business is a total success. You are in this business for yourself, not by yourself. We have developed an effective and proven progress plan to help you launch a profitable business of your own.&nbsp;&nbsp; We are confident that you will receive gratification from your involvement with <asp:Label ID="lblCompanyName2" runat="server" Text=""></asp:Label>  and we wish you every Success! Please note we are providing you an opportunity to earn money which is optional, your earnings will depend directly in the amount of efforts you put to develop your business.
                                    </p>
                                    <p style="padding: 50px 0px 30px 30px; width: 95%; text-align: left;">
                                        <span>Thanking You!</span><br />
                                        <span style="padding-left: 40px; padding-top: 15px;"><asp:Label ID="lblCompanyName3" runat="server" Text=""></asp:Label> </span>
                                              <br />
                                     &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <span style="color:black;font-size: 12px;  "> </span>
                                    </p>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="background-color: #FFB40C; padding-top: 25px;"></td>
                        </tr>
                    </table>





                </div>
            </div>
        </div>
    </form>
</body>
</html>
