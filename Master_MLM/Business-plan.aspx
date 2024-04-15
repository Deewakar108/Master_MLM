<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Business-plan.aspx.cs" Inherits="Master_MLM.Business_plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Business Plan
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.plan {
            color: #70c108;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section>
        <div class="other-page-sec">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <h2 class="other-page-head">Business Plan</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="business-plan-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="business-plan-sec">
                            <div class="plan-inner">
                                <h2 class="plan-inner-h2">Business Plan</h2>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="plan-bg">
                    <div class="row">
                        <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="float: right;">
                            <div class="plan-img">
                                <img src="images/binary-tree.png" class="img-responsive" style="border: 2px solid #ec888f; border-radius: 20px;" />
                            </div>
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12">
                            <div class="plan-content-inner" style="padding-bottom:0px;">
                                <p class="plan-p">
                                    <i class="fa fa-star-o plan-p-icon" aria-hidden="true"></i>Gold Package Rs. 3000/- 
                                </p>
                                <div class="plan-ul-sec">
                                    <ul class="plan-ul">
                                        <li>Product Value Rs. 5000/-</li>
                                        <li>Matching Bonus - 1:2 > Rs. 800/- ,  1:1 > Rs. 800/-</li>
                                        <li>3 Direct Joining - Royalty 5% of CTO</li>
                                          <li>Binary Royalty - You Must Repurchase 250 BV  </li>
                                    </ul>
                                </div>




                                <p class="plan-p">
                                    <i class="fa fa-star-o plan-p-icon" aria-hidden="true"></i>Carry Forward
                                </p>
                                <div class="plan-ul-sec">
                                    <ul class="plan-ul">
                                        <li>Daily Three Time Closing
                                            <br />
                                            6 AM To 12 PM, 12 PM To 6 PM, 6 PM To 12 PM
                                        </li>
                                        <li>Capping - 5 pair per closing
                                            <br />
                                            15 x 800 = 12000/- Per Day Income (Daily Closing & Weekly Payout). 
                                        </li>

                                        <%--<li>Condition
                                            <br />
                                            Your 2 direct distributors will be Topup Rs. 6000/-  then release monthly  payout</li>--%>
                                    </ul>
                                </div>



                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                             <div class="plan-content-inner" style="padding-top:0px; padding-right:0px">
                            <p class="plan-p">
                                <i class="fa fa-star-o plan-p-icon" aria-hidden="true"></i>Repurchase Plan
                            </p>
                            <div class="plan-ul-sec">
                                <ul class="plan-ul">
                                    <li>Self Repurchase Income = 10%
                                    </li>
                                    <li>Matching Repurchase Income = 20%
                                        <img src="images/bi-tree1.png" class="img-responsive col-md-5 col-sm-12 col-xs-12" style="border: 2px solid #ec888f; border-radius: 20px; float:right;" />
                                    </li>

                                    <li> <b>Diamond Achiever -</b><br />
                                        <img src="images/bi-tree2.png" class="img-responsive col-md-5 col-sm-12 col-xs-12" style="border: 2px solid #ec888f; border-radius: 20px; float:right; padding:0px;" />
                                       <%-- &nbsp;&nbsp;1 Lakh : 1 Lakh--%>
                                          
                                        After Diamond Achievement Member get Royalty Income Every Month Life Time
                                        <br />
                                        (5% of BV Repurchase C.T.O) Equally Divided to all Diamond Achiever.
                                    </li>
                                </ul>
                            </div>
                                 </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
