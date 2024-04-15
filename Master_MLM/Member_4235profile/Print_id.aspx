<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_id.aspx.cs" Inherits="Master_MLM.Member_4235profile.Print_id" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Id Card</title>
    <style>
        body, #form1 {
            width: 100%;
            height: auto;
            margin: 0px;
            padding: 0px;
            color: black;
            font-family: 'Open Sans';
            font-weight: bold;
        }

        .main {
            margin: 0px;
            padding: 0px;
            float: left;
            height: auto;
            width: 100%;
            position: relative;
        }

        .main_auto {
            margin: 0px auto;
            width: 600px;
            height: auto;
            padding: 0px;
        }

        .main_const {
            margin: 0px;
            width: 610px;
            height: auto;
            padding: 0px;
            padding: 5px;
            float: left;
            position: relative;
        }
    </style>
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
    <style type="text/css">
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

</head>
<body onload="changeHashOnLoad();">
    <form id="form1" runat="server">
        <div class="main">
            <asp:Button ID="btn_back" runat="server" Text="Back" Height="35px" Width="115px"
                BackColor="#003366" BorderColor="#3333FF" BorderStyle="Outset" BorderWidth="2px"
                Font-Bold="True" ForeColor="White" OnClick="btn_back_Click" CssClass="noPrint" Style="position: absolute; top: 15px; left: 45px;" />

            <asp:Button ID="btn_print" runat="server" Text="Print" Height="35px" Width="115px"
                BackColor="#003366" BorderColor="#333399" BorderStyle="Outset" BorderWidth="2px"
                Font-Bold="True" ForeColor="White" OnClick="btn_print_Click" CssClass="noPrint" Style="position: absolute; left: 1170px; top: 17px;" />
            <div class="main_auto">
                <div class="main_const">

                    <img src="../Content/images/id_card_blank.png" alt="Id Card" />
                    <asp:Image ID="Image1" runat="server" BorderStyle="None" Style="border-style: none; border-color: inherit; border-width: medium; position: absolute; height: 119px; width: 118px; top: 148px; left: 42px;" />
                    <asp:Label ID="lbl_name" runat="server" Style="color: #06458c; position: absolute; top: 147px; left: 317px; font-size: 14px; width: 275px; height: 17px;"></asp:Label>
                    <asp:Label ID="lbl_id" runat="server" Style="color: #222222; position: absolute; top: 172px; left: 317px; font-size: 14px; width: 275px; height: 17px;"></asp:Label>
                    <asp:Label ID="lbl_mob" runat="server" Style="color: #222222; position: absolute; top: 248px; left: 317px; font-size: 14px; width: 275px; height: 17px;"></asp:Label>
                     <asp:Label ID="lbl_dob" runat="server" Style="color: #222222; position: absolute; top: 195px; left: 317px; font-size: 14px; width: 275px; height: 17px;"></asp:Label>
                     <asp:Label ID="lbl_doj" runat="server" Style="color: #222222; position: absolute; top: 222px; left: 317px; font-size: 14px; width: 275px; height: 17px;"></asp:Label>

                    <asp:Label ID="lbl_district" runat="server" Style="color: #222222; position: absolute; top: 273px; left: 317px; font-size: 14px; width: 275px; height: 17px;"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
