<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print-id-back.aspx.cs" Inherits="Master_MLM.Member_4235profile.Print_id_back" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Id Card Back</title>
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
<body>
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
                    <img src="../Content/images/id_back.png" alt="ID Card" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
