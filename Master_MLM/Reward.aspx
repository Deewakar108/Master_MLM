<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Reward.aspx.cs" Inherits="Master_MLM.Reward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Reward
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.rew {
            color: #70c108;
        }

        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
            border: 1px solid #000;
            text-align: center;
            color: #000;
            padding: 5px 10px;
            vertical-align: middle;
        }

        .table > thead:first-child > tr:first-child > th {
            border-top: 0;
            border: 1px solid #000;
            color: #fff;
            font-size: 16px;
            line-height: 22px;
        }

        .plan-inner-h2:before {
            width: 125px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section>
        <div class="other-page-sec">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <h2 class="other-page-head">Rewards</h2>
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
                                <%--<p class="plan-inner-p">Welcome To Ocean Health Pariwar</p>--%>
                                <h2 class="plan-inner-h2">Rewards</h2>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="plan-bg">
                    <div class="row">
                        <div class="col-lg-2 col-md-2 col-sm-12 colxs-12"></div>
                        <div class="col-lg-8 col-md-8 col-sm-12 colxs-12">
                            <p>Coming Soon</p>
                            <%--<div class=" reward-wrap">
                                <table class="table table-hover">
                                    <thead>
                                        <tr style="background: #73bd15; color: #fff; text-align: center; width: 100%;">
                                            <th>S.No.</th>
                                            <th>Pair Topup</th>
                                            <th>Rank</th>
                                            <th>Rewards</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <tr>
                                            <td class="td-padd">1</td>
                                            <td class="td-padd">10</td>
                                            <td class="td-padd">Star</td>
                                            <td class="td-padd">5,000/-</td>
                                        </tr>

                                        <tr>
                                            <td class="td-padd">2</td>
                                            <td class="td-padd">+20</td>
                                            <td class="td-padd">Silver Star</td>
                                            <td class="td-padd">8,000/-</td>
                                        </tr>

                                        <tr>
                                            <td class="td-padd">3</td>
                                            <td class="td-padd">+50</td>
                                            <td class="td-padd">Pearl Star</td>
                                            <td class="td-padd">20,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">4</td>
                                            <td class="td-padd">+100</td>
                                            <td class="td-padd">Gold Star</td>
                                            <td class="td-padd">75,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">5</td>
                                            <td class="td-padd">+250</td>
                                            <td class="td-padd">Emerald Star</td>
                                            <td class="td-padd">2,25,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">6</td>
                                            <td class="td-padd">+1000</td>
                                            <td class="td-padd">Platinum Star</td>
                                            <td class="td-padd">6,25,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">7</td>
                                            <td class="td-padd">+3000</td>
                                            <td class="td-padd">Diamond Star</td>
                                            <td class="td-padd">14,00,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">8</td>
                                            <td class="td-padd">+7500</td>
                                            <td class="td-padd">Royal Diamond Star</td>
                                            <td class="td-padd">25,00,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">9</td>
                                            <td class="td-padd">+15000</td>
                                            <td class="td-padd">Crowan Diamond Star</td>
                                            <td class="td-padd">45,00,000/-</td>
                                        </tr>
                                        <tr>
                                            <td class="td-padd">10</td>
                                            <td class="td-padd">+35000</td>
                                            <td class="td-padd">Crowan Ambassador Star</td>
                                            <td class="td-padd">1,00,000,00/-</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>--%>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 colxs-12"></div>
                    </div>
                </div>

            </div>
        </div>

    </section>
</asp:Content>
