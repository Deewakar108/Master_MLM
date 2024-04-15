<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Repurchase_product.aspx.cs" Inherits="Master_MLM.Repurchase_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Repurchase Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.product {
            color: #70c108;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <section>
        <div class="other-page-sec">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <h2 class="other-page-head">Repurchase Product</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="business-plan-wrap">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="business-plan-sec">
                        <div class="plan-inner">
                            <h2 class="plan-inner-h2">Repurchase Product</h2>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" data-ng-app="myProductApp">
                <div id="products" class="product-secti" data-ng-controller="ctrlapp">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" data-ng-repeat="x in products">
                        <div class="pr-images">
                            <div class="row" style="margin: 0px; background-color: #fff;">


                                <h2 class="pr-images-h2">{{x.Product_name}}</h2>
                                <p class="pr-images-p">MRP :Rs. {{x.Mrp}}/-</p>
                                <p class="pr-images-p">BV : {{x.Bv}} bv</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>






        </div>
    </div>
    <script type="text/javascript">
        var app = angular.module('myProductApp', []);
        app.controller('ctrlapp', function ($scope, $http) {

            $http.get("WebService1.asmx/fetch_rep_products_details").then(function (response) {
                $scope.products = response.data;
                if ($scope.products == "") {
                    $("#products").empty();
                    $("#products").html('<p>Sorry No Data Found!</p>');
                }
            })


        });
    </script>

</asp:Content>
