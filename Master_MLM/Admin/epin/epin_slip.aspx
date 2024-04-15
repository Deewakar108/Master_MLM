<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="epin_slip.aspx.cs" Inherits="Master_MLM.Admin.epin.epin_slip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       printDivCSS = new String('<link href="itemprint.css" rel="stylesheet" type="text/css">')
       function printDiv(divId) {
           window.frames["print_frame"].document.body.innerHTML = printDivCSS + document.getElementById(divId).innerHTML
           window.frames["print_frame"].window.focus()
           window.frames["print_frame"].window.print()
       }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">E-Pin History</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-briefcase"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="printDiv('printme')"></i></span>
                        <h5>E-Pin Invoice</h5>
                    </div>
                    <div class="widget-content" id="printme">
                        <div class="row-fluid">
                            <div class="span6">
                                <table class="">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <h4>Your Company Name</h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Your Town</td>
                                        </tr>
                                        <tr>
                                            <td>Your Region/State</td>
                                        </tr>
                                        <tr>
                                            <td>Mobile Phone: +4530422244</td>
                                        </tr>
                                        <tr>
                                            <td>me@company.com</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="span6">
                                <table class="table table-bordered table-invoice">
                                    <tbody>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td class="width30">Invoice ID:</td>
                                            <td class="width70"><strong>TD-6546</strong></td>
                                        </tr>
                                        <tr>
                                            <td>Issue Date:</td>
                                            <td><strong>March 23, 2013</strong></td>
                                        </tr>
                                        <tr>
                                            <td>Due Date:</td>
                                            <td><strong>April 01, 2013</strong></td>
                                        </tr>
                                        <tr>
                                            <td class="width30">Client Address:</td>
                                            <td class="width70"><strong>Cliente Company name.</strong>
                                                <br>
                                                501 Mafia Street., washington,
                                                <br>
                                                NYNC 3654
                                                <br>
                                                Contact No: 123 456-7890
                                                <br>
                                                Email: youremail@companyname.com </td>
                                        </tr>
                                    </tbody>

                                </table>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <table class="table table-bordered table-invoice-full">
                                    <thead>
                                        <tr>
                                            <th class="head0">Type</th>
                                            <th class="head1">Desc</th>
                                            <th class="head0 right">Qty</th>
                                            <th class="head1 right">Price</th>
                                            <th class="head0 right">Amount</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>E-Pin</td>
                                            <td>E-Pin should be used to register New Members, Transfer. Not For Resale. </td>
                                            <td class="right">10</td>
                                            <td class="right">2000</td>
                                            <td class="right"><strong>2000</strong></td>
                                        </tr>
                                    </tbody>
                                </table>
                                    <div class="widget-box">
                                        <div class="widget-title">
                                            <span class="icon"><i class="icon-play-circle"></i></span>
                                            <h5>E-Pin List</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div class="row-fluid">
                                                <div class="span12 btn-icon-pg">
                                                    <ul>
                                                        <li><i class="icon-lock"></i>EP12345</li>
                                                        <li><i class="icon-lock"></i>EP12345</li>
                                                        <li><i class="icon-lock"></i>EP12345</li>
                                                        <li><i class="icon-lock"></i>EP12345</li>
                                                        <li><i class="icon-lock"></i>EP12345</li>
                                                        <li><i class="icon-lock"></i>EP12345</li>
                                                        
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                <table class="table table-bordered table-invoice-full">
                                    <tbody>
                                        <tr>
                                            <td class="msg-invoice" width="85%">
                                                <h4>Payment method: </h4>
                                                <a href="#" class="tip-bottom" data-original-title="Wire Transfer"><b>Cash</b></a></td>
                                            <td class="right"><strong>Subtotal</strong>
                                                <br>
                                                <strong>Tax (5%)</strong>
                                                <br>
                                                <strong>Discount</strong></td>
                                            <td class="right"><strong>$7,000
                                                <br>
                                                $600
                                                <br>
                                                $50</strong></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="pull-right">
                                    <h4><span>Amount Due:</span> $7,650.00</h4>
                                    <br>
                                    <a class="btn btn-primary btn-large pull-right" href="">Pay Invoice</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
</asp:Content>
