<%@ Page Title="View Tree" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Binary_team_structure.aspx.cs"
    Inherits="Master_MLM.Member_4235profile.Binary_team_structure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
            background-color: #F700A9;
            color: #fff;
        }

        .tooltip {
            display: none;
            position: absolute;
            border: 1px solid #333;
            border-radius: 5px;
            padding: 10px;
            color: #000;
            font-size: 12px;
            background-color: #F6FF71;
            font-family: sans-serif,'Open Sans',Arial;
        }

        #top {
            margin-right: 0px;
        }

        .style1 {
            height: 20px;
        }
    </style>

    <script>
        function hoverdiv(e, divid) {
            //alert(divid);
            var left = e.clientX + "px";
            var top = e.clientY + "px";

            var div = document.getElementById(divid);
            //alert(div);
            div.style.left = left;
            div.style.top = top;

            $("#" + divid).toggle();
            return false;
        }
    </script>

    <script type="text/javascript">


        $(function () {
            $("#<%= LinkButton1.ClientID %>").mouseover(function () {
                // var code = $("#<%= LinkButton1.ClientID %>").text();

                var code = document.getElementById('<%=LinkButton1.ClientID %>').getAttribute("cmdname");


                var ele = $("#<%= LinkButton1.ClientID %>");
                var pos = ele.offset();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Binary_team_structure.aspx/GetData",
                    data: "{'membercode':'" + code + "'}",
                    dataType: "json",
                    success: function (data) {


                        var infos = data.d;
                        $.each(infos, function (index, info) {

                            //var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                            var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                            // alert(str);
                            $('<p class="tooltip"></p>').css({
                                top: pos.top - 0,
                                left: pos.left + ele.width() + 15
                            }).append(str).appendTo('body').fadeIn('slow');

                        });
                    }
                    //                   ,
                    //                    error: function (result) {
                    //                        alert("Error");
                    //                    }
                });

            });


            $("#<%= LinkButton1.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });




            $("#<%= LinkButton2.ClientID %>").mouseover(function () {
                // var code = $("#<%= LinkButton2.ClientID %>").text();
                var code = document.getElementById('<%=LinkButton2.ClientID %>').getAttribute("cmdname");

                if (code != "Add Team Here") {
                    var ele = $("#<%= LinkButton2.ClientID %>");
                    var pos = ele.offset();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Binary_team_structure.aspx/GetData",
                        data: "{'membercode':'" + code + "'}",
                        dataType: "json",
                        success: function (data) {

                            var infos = data.d;
                            $.each(infos, function (index, info) {
                                //var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                                //var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right;
                                var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                                $('<p class="tooltip"></p>').css({
                                    top: pos.top - 100,
                                    left: pos.left + ele.width() + 15
                                }).append(str).appendTo('body').fadeIn('slow');

                            });
                        }
                        //                   ,
                        //                    error: function (result) {
                        //                        alert("Error");
                        //                    }
                    });
                }

            });


            $("#<%= LinkButton2.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });



            $("#<%= LinkButton3.ClientID %>").mouseover(function () {
                // var code = $("#<%= LinkButton3.ClientID %>").text();
                var code = document.getElementById('<%=LinkButton3.ClientID %>').getAttribute("cmdname");

                if (code != "Add Team Here") {
                    var ele = $("#<%= LinkButton3.ClientID %>");
                    var pos = ele.offset();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Binary_team_structure.aspx/GetData",
                        data: "{'membercode':'" + code + "'}",
                        dataType: "json",
                        success: function (data) {

                            var infos = data.d;
                            $.each(infos, function (index, info) {

                                //var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                                var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                                $('<p class="tooltip"></p>').css({
                                    top: pos.top - 100,
                                    left: pos.left + ele.width() + 15
                                }).append(str).appendTo('body').fadeIn('slow');

                            });
                        }
                        //                   ,
                        //                    error: function (result) {
                        //                        alert("Error");
                        //                    }
                    });
                }

            });


            $("#<%= LinkButton3.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });



            $("#<%= LinkButton4.ClientID %>").mouseover(function () {
                // var code = $("#<%= LinkButton4.ClientID %>").text()
                var code = document.getElementById('<%=LinkButton4.ClientID %>').getAttribute("cmdname");

                if (code != "Add Team Here") {
                    var ele = $("#<%= LinkButton4.ClientID %>");
                    var pos = ele.offset();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Binary_team_structure.aspx/GetData",
                        data: "{'membercode':'" + code + "'}",
                        dataType: "json",
                        success: function (data) {

                            var infos = data.d;
                            $.each(infos, function (index, info) {

                                // var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                                var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                                $('<p class="tooltip"></p>').css({
                                    top: pos.top - 100,
                                    left: pos.left + ele.width() + 15
                                }).append(str).appendTo('body').fadeIn('slow');

                            });
                        }
                        //                   ,
                        //                    error: function (result) {
                        //                        alert("Error");
                        //                    }
                    });
                }

            });


            $("#<%= LinkButton4.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });



            $("#<%= LinkButton5.ClientID %>").mouseover(function () {
                //var code = $("#<%= LinkButton5.ClientID %>").text()
                var code = document.getElementById('<%=LinkButton5.ClientID %>').getAttribute("cmdname");

                if (code != "Add Team Here") {
                    var ele = $("#<%= LinkButton5.ClientID %>");
                    var pos = ele.offset();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Binary_team_structure.aspx/GetData",
                        data: "{'membercode':'" + code + "'}",
                        dataType: "json",
                        success: function (data) {

                            var infos = data.d;
                            $.each(infos, function (index, info) {

                                //var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                                var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                                $('<p class="tooltip"></p>').css({
                                    top: pos.top - 100,
                                    left: pos.left + ele.width() + 15
                                }).append(str).appendTo('body').fadeIn('slow');

                            });
                        }
                        //                   ,
                        //                    error: function (result) {
                        //                        alert("Error");
                        //                    }
                    });
                }

            });


            $("#<%= LinkButton5.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });



            $("#<%= LinkButton6.ClientID %>").mouseover(function () {
                // var code = $("#<%= LinkButton6.ClientID %>").text()
                var code = document.getElementById('<%=LinkButton6.ClientID %>').getAttribute("cmdname");


                if (code != "Add Team Here") {
                    var ele = $("#<%= LinkButton6.ClientID %>");
                    var pos = ele.offset();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Binary_team_structure.aspx/GetData",
                        data: "{'membercode':'" + code + "'}",
                        dataType: "json",
                        success: function (data) {

                            var infos = data.d;
                            $.each(infos, function (index, info) {
                                //var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                                var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                                $('<p class="tooltip"></p>').css({
                                    top: pos.top - 100,
                                    left: pos.left + ele.width() + 15
                                }).append(str).appendTo('body').fadeIn('slow');

                            });
                        }
                        //                   ,
                        //                    error: function (result) {
                        //                        alert("Error");
                        //                    }
                    });
                }

            });


            $("#<%= LinkButton6.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });



            $("#<%= LinkButton7.ClientID %>").mouseover(function () {
                //var code = $("#<%= LinkButton7.ClientID %>").text()

                var code = document.getElementById('<%=LinkButton7.ClientID %>').getAttribute("cmdname");


                if (code != "Add Team Here") {
                    var ele = $("#<%= LinkButton7.ClientID %>");
                    var pos = ele.offset();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Binary_team_structure.aspx/GetData",
                        data: "{'membercode':'" + code + "'}",
                        dataType: "json",
                        success: function (data) {

                            var infos = data.d;
                            $.each(infos, function (index, info) {

                                //var str = "Purchase Date:" + info.doj + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>Active Date:" + info.odj + "<br/>   Package: " + info.joiningpackage;//+ "<br/>   Sponsor code: " + info.sponsorcode + "<br/>   Sponsor name: " + info.sponsorname
                                var str = "Purchase Date:" + info.doj + "<br/>   Package: " + info.joiningpackage + "<br/>   Sponsor name: " + info.sponsorname + "<br/>   Left: " + info.left + "&nbsp;&nbsp;&nbsp;Right: " + info.right + "<br/>   Left PV : " + info.leftpv + "&nbsp;&nbsp;&nbsp;Right PV : " + info.right_pv;

                                $('<p class="tooltip"></p>').css({
                                    top: pos.top - 100,
                                    left: pos.left + ele.width() + 15
                                }).append(str).appendTo('body').fadeIn('slow');

                            });
                        }
                        //                   ,
                        //                    error: function (result) {
                        //                        alert("Error");
                        //                    }
                    });
                }

            });


            $("#<%= LinkButton7.ClientID %>").mouseout(function (e) {
                $('.tooltip').remove();
            });
        });
    </script>


    <style type="text/css">
        .colun_round {
            border: 1px solid #000;
            width: 20px;
            height: 20px;
            line-height: 25px;
            margin: 0px 0px 0px 0px;
            padding: 0px;
            float: left;
            -webkit-border-radius: 70px 70px 70px 70px;
            border-radius: 70px 70px 70px 70px;
            text-align: center;
        }

        .parastyle {
            height: 20px;
            line-height: 25px;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 5px;
            float: left;
            text-align: center;
        }

        .bg_rd {
            background-color: red;
        }

        .bg_blue {
            background-color: blue;
        }

        .bg_grien {
            background-color: green;
        }
    </style>

    <%--SKS-BINARY TREE CSS LINKS--%>
    <%--<link href="sks_tree/css/bootstrap.min.css" rel="stylesheet" />--%>

    <style type="text/css">
        .jqstooltip {
            position: absolute;
            left: 30px;
            top: 0px;
            display: block;
            visibility: hidden;
            background: rgb(0, 0, 0) transparent;
            background-color: rgba(0,0,0,0.6);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000);
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000)";
            color: white;
            font: 10px arial, san serif;
            text-align: left;
            white-space: nowrap;
            border: 0px solid white;
            border-radius: 3px;
            -webkit-border-radius: 3px;
            z-index: 10000;
        }

        .jqsfield {
            color: white;
            padding: 5px 5px 5px 5px;
            font: 10px arial, san serif;
            text-align: left;
        }
    </style>


    <style>
        .align {
            text-align: center;
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb" style="background-color: lightgray;">
        <li class="breadcrumb-item"><a href="/">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>


    <%--<div id="divtoshow" style="position: fixed;display:none; z-index: 1; background-color: green; 
                    border-radius: 5px; padding: 10px; color: white; font-size: 12px;">
                        Purchase Date:18/02/2017&nbsp;08:31:43 AM<br />   
                            Package: TULSI DROP//GREEN TEA//APPLE 9B<br />   
                            Sponsor name: PRAVIN KUMAR SRIVASTAVA<br />   
                            Left: 0&nbsp;&nbsp;&nbsp;Right: 3290<br />   
                            Left PV : 0  &nbsp;&nbsp;&nbsp;Right PV : 32640
                    </div>
<br /><br />
<span onmouseover="hoverdiv(event,'divtoshow')" onmouseout="hoverdiv(event,'divtoshow')">Mouse over this</span>--%>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>View Tree</a></h4>
            <div class="panel-body panel-footer" style="background-color: white; overflow-y: auto">
                <div class="row" style="padding: 3px 0px 0px 0px; text-align: center; background-color: white;">
                    <div style="margin: 0 auto; padding: 0px 0px 30px 0px; background-color: white;">
                        <div style="margin: 0 auto; padding-top: 20px; text-align: center;">

                            <table style="margin: 0px auto; padding: 0px; width: 100%; height: auto">
                                <tr>
                                    <td style="text-align: left; padding: 5px 0px 0px 0px; font-family: ebrima; font-size: 15px; display: none;">
                                        <h2 style="margin: 0 auto; padding: 0px;">
                                            <asp:ImageButton ID="imgbtn" runat="server" Height="36px" ImageUrl="~/images/back-button.png" Enabled="false" Style="margin-top: 6px" OnClick="imgbtn_Click" />
                                            <asp:GridView ID="grdmemberlist" runat="server" Visible="False">
                                            </asp:GridView>
                                        </h2>
                                    </td>
                                    <td style="text-align: left; padding: 5px 0px 0px 20px; font-family: ebrima; font-size: 15px;">
                                        <asp:TextBox ID="txt_memberid" CssClass="form-control" runat="server" placeholder="Enter member code"
                                            Visible="false"></asp:TextBox>
                                        &nbsp
                                    </td>
                                    <td style="padding: 15px 10px 10px 10px; text-align: left;">
                                        <asp:Button ID="btn_find" CssClass="btn btn-success" runat="server" Text="Home" OnClick="btn_find_Click1"
                                            Width="100px" />
                                    </td>
                                    <td style="padding-left: 30px; font-family: Roboto;">
                                        <div class="row" style="width: 121px; float: left; margin: 0px; padding: 5px 0px 5px 0px">
                                            <div class="colun_round bg_rd">
                                            </div>
                                            <p class="parastyle">
                                                Free
                                            </p>
                                        </div>
                                        <div class="row" style="width: 121px; float: left; margin: 0px; padding: 5px 0px 5px 0px">
                                            <div class="colun_round bg_grien">
                                            </div>
                                            <p class="parastyle">
                                                Paid
                                            </p>
                                        </div>
                                        <div class="row" style="width: 121px; float: left; margin: 0px; padding: 5px 0px 5px 0px">
                                            <div class="colun_round  bg_vacant" style="background-color: white;">
                                            </div>
                                            <p class="parastyle">
                                                Vacant
                                            </p>
                                        </div>

                                        <asp:Label ID="lbl_leftred" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl_leftgreen" runat="server" Visible="false"></asp:Label>


                                        <asp:Label ID="lbl_rightred" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl_rightgreen" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; padding: 5px 0px 0px 0px;" colspan="4">
                                        <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="Red"
                                            Font-Names="Bell MT" Text="View Tree"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <hr />
                        <div style="margin: 0px; padding: 0px; float: left; height: auto; width: 100%;">
                            <asp:Panel ID="panel_view_tree" runat="server" Visible="false">
                                <table style="width: 970px; height: auto; margin: 0px auto 40px auto; border-spacing: 0px; display: none;">

                                    <tr>
                                        <td style="width: 250px;" colspan="2">&nbsp;</td>
                                        <td style="width: 375px; text-align: center;" colspan="3">
                                            <div style="padding: 0px; margin: 0px; width: 30%; float: left">
                                                Left PV - 
                                <asp:Label ID="lbl_leftpv" runat="server"></asp:Label>
                                            </div>
                                            <div style="padding: 0px; margin: 0px; width: 40%; float: left">
                                                <asp:Image ID="Image1" runat="server" Style="padding: 5px; height: 100px; width: 100px;" /><br />
                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" CssClass="link"></asp:Label><br />
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="link"></asp:LinkButton>
                                            </div>
                                            <div style="padding: 0px; margin: 0px; width: 30%; float: left">
                                                Right PV-   
                                <asp:Label ID="lbl_rightpv" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                        <td style="width: 250px;" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 250px;" colspan="2"></td>
                                        <td style="width: 375px; text-align: center;" colspan="3">
                                            <img src="../images/binary_team_back.png" alt=" " />
                                        </td>
                                        <td style="width: 250px;" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 125px;"></td>
                                        <td style="width: 230px; text-align: center;" colspan="2">
                                            <asp:Image ID="Image2" runat="server" Style="padding: 5px; height: 100px; width: 100px;" /><br />
                                            <asp:Label ID="Label2" runat="server" CssClass="link"></asp:Label><br />
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="link"></asp:LinkButton>
                                        </td>
                                        <td style="width: 270px;"></td>
                                        <td style="width: 250px; text-align: center;" colspan="2">
                                            <asp:Image ID="Image3" runat="server" Style="padding: 5px; height: 100px; width: 100px;" /><br />
                                            <asp:Label ID="Label3" runat="server" CssClass="link"></asp:Label><br />
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="link"></asp:LinkButton>
                                        </td>
                                        <td style="width: 125px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 125px;"></td>
                                        <td style="width: 250px; text-align: center;" colspan="2">
                                            <asp:Image ID="img_back1" runat="server" ImageUrl="../images/binary_team_back2.png" />
                                        </td>
                                        <td style="width: 125px;"></td>
                                        <td style="width: 250px; text-align: center;" colspan="2">
                                            <asp:Image ID="img_back2" runat="server" ImageUrl="../images/binary_team_back2.png" />
                                        </td>
                                        <td style="width: 125px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 250px; text-align: center" colspan="2">
                                            <asp:Image ID="Image4" runat="server" Style="padding: 5px; height: 100px; width: 100px; margin-left: 39px;" /><br />
                                            <asp:Label ID="Label4" runat="server" CssClass="link"></asp:Label><br />
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="link"></asp:LinkButton>
                                        </td>
                                        <td style="width: 200px; text-align: center">
                                            <table style="width: 100%; height: auto; border-spacing: 0px; margin-left: 84px;"
                                                border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="text-align: center; width: 150px;">
                                                        <asp:Image ID="Image5" runat="server" Style="padding: 5px; height: 100px; width: 100px; float: right; margin: 0px 34px 0px 0px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; width: 150px;">
                                                        <asp:Label ID="Label5" runat="server" CssClass="link"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; width: 150px;">
                                                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" CssClass="link"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 200px; text-align: center" colspan="2">
                                            <asp:Image ID="Image6" runat="server" Style="padding: 5px; height: 100px; width: 100px; margin: 0px 0px 0px 102px" />
                                            <br />
                                            <asp:Label ID="Label6" runat="server" Style="margin: 0px 0px 0px 102px" CssClass="link"></asp:Label>
                                            <br />
                                            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" Style="margin: 0px 0px 0px 102px"
                                                CssClass="link"></asp:LinkButton>
                                        </td>
                                        <td style="width: 250px; text-align: center" colspan="2">
                                            <asp:Image ID="Image7" runat="server" Style="padding: 5px; height: 100px; width: 100px; margin-right: 2px;" /><br />
                                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label><br />
                                            <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>

                        <div class="align" style="background-color: white;">
                            <!--SKS-TREE-->

                            <div class="btn btn-success" style="margin: 0 auto; margin-top: 20px; margin-bottom: 30px; border-radius: 5px; display: none;">
                                <table style="width: 100%;">
                                    <tbody id="topMember" runat="server"></tbody>
                                </table>
                            </div>
                            <br />
                            <table style="width: 100%; margin-left: 0px; border: none;" id="Table1">
                                <tbody>
                                    <tr>
                                        <td colspan="8" style="height: 23px;" class="align">
                                            <span runat="server" id="spTopMemberName"></span>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8" class="align">
                                            <img src="images/Top1.gif" style="border-width: 0px;" />&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td colspan="4" style="height: 61px;" class="align">
                                            <span runat="server" id="spLeft" style='font-size: 13px;'></span>
                                            <br />
                                        </td>
                                        <td colspan="4" style="height: 61px;" class="align">
                                            <span runat="server" id="spRight" style='font-size: 13px;'></span>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="align">
                                            <img src="images/Top1.gif" style="border-width: 0px; width: 50%" /></td>
                                        <td class="align" colspan="4">
                                            <img src="images/Top1.gif" style="border-width: 0px; width: 50%;" /></td>
                                    </tr>

                                    <tr>
                                        <td class="align" colspan="2">
                                            <span runat="server" id="Span1" style='font-size: 12px;'></span>
                                            <br />
                                        </td>
                                        <td class="align" colspan="2">
                                            <span runat="server" id="Span2" style='font-size: 12px;'></span>
                                            <br />
                                        </td>
                                        <td class="align" colspan="2">
                                            <span runat="server" id="Span3" style='font-size: 12px;'></span>
                                            <br />
                                        </td>
                                        <td class="align" colspan="2">
                                            <span runat="server" id="Span4" style='font-size: 12px;'></span>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td class="align" colspan="2">
                                            <img src="images/Top2.gif" style="border-width: 0px;" /></td>
                                        <td class="align" colspan="2">
                                            <img src="images/Top2.gif" style="border-width: 0px;" /></td>
                                        <td class="align" colspan="2">
                                            <img src="images/Top2.gif" style="border-width: 0px;" /></td>
                                        <td class="align" colspan="2">
                                            <img src="images/Top2.gif" style="border-width: 0px;" /></td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td class="align">
                                            <span runat="server" id="Span5" style='font-size: 11px;'></span>
                                            <br />
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span6" style='font-size: 11px;'></span>
                                            <br />
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span7" style='font-size: 11px;'></span>
                                            <br />
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span8" style='font-size: 11px;'></span>
                                            <br />
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span9" style='font-size: 11px;'></span>
                                            <br />
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span10" style='font-size: 11px;'></span>
                                            <br />
                                            <%--<img src="images/grey.jpg" />--%>
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span11" style='font-size: 11px;'></span>
                                            <br />
                                            <%--<img src="images/grey.jpg" />--%>
                                        </td>
                                        <td class="align">
                                            <span runat="server" id="Span12" style='font-size: 11px;'></span>
                                            <br />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>

                        <div style="text-align: center !important; display: none;">
                            <!--UNLIMITED TREE-->
                            <asp:TreeView ID="treeMembers" runat="server" Style="margin: 0 auto;"></asp:TreeView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
