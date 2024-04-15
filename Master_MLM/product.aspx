<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Master_MLM.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
    <style>
        .menubar nav > ul > li > a.product {
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
                        <h2 class="other-page-head">Product</h2>
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
                            <%--<p class="plan-inner-p">Welcome To Ocean Health Pariwar</p>--%>
                            <h2 class="plan-inner-h2">Product</h2>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" data-ng-app="productsApp">
                <div class="product-secti" data-ng-controller="myProductsCtrl">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" data-ng-repeat="x in products">
                        <div class="pr-images">
                            <img src="{{x.Image_path}}" class="img-responsive product-oce" title="Company" />
                            <h2 class="pr-images-h2">{{x.Product_name}}</h2>
                            <p class="pr-images-p">Packing : {{x.Packing}}</p>
                        </div>
                    </div>

                    <%--<div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                            <img src="images/product_syrup/2.jpg" class="img-responsive product-oce" title="Company" />
                            <h2 class="pr-images-h2">GRITMUKT SYRUP</h2>

                            <p class="pr-images-p">Packing : 200ml</p>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                            <img src="images/product_syrup/3.jpg" class="img-responsive product-oce" title="Company" />
                            <h2 class="pr-images-h2">OCEDIAB  SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                            <img src="images/product_syrup/4.jpg" class="img-responsive product-oce" title="Company" />
                            <h2 class="pr-images-h2">OCITUS COUGH SYRUP</h2>
                            <p class="pr-images-p">Packing : 100ml</p>
                        </div>
                    </div>--%>
                </div>
            </div>

            <%--  <div class="row">
                <div class="product-secti">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/5.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">LIVKRIT - DS SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/6.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">OCIRON SYRUP</h2>

                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/7.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">KRITZYME SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/8.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">OCIVIT SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>
                </div>
                </div>

                <div class="row">
                <div class="product-secti">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/9.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">LIVKRIT SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/10.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">OCERAKT SYRUP</h2>

                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/11.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">COUGH SYRUP</h2>
                            <p class="pr-images-p">Packing : 100ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/12.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">OCECID SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>
                </div>
                </div>

                <div class="row">
                <div class="product-secti">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/13.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">CEREBRO SYRUP</h2>
                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/14.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">OCEFEM SYRUP</h2>

                            <p class="pr-images-p">Packing : 200ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/15.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">ACTIVATOR SYRUP</h2>
                            <p class="pr-images-p">Packing : 100ml</p>
                          </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="pr-images">
                           <img src="images/product_syrup/16.jpg" class="img-responsive product-oce" title="Company" />
                           <h2 class="pr-images-h2">PYNACE PAIN OIL</h2>
                            <p class="pr-images-p">Packing : 50ml</p>
                          </div>
                    </div>
                </div>
                </div>--%>
        </div>
    </div>

     <script type="text/javascript">
         var app = angular.module('productsApp', []);
         app.controller('myProductsCtrl', function ($scope, $http) {
             $http.get("WebService1.asmx/fetch_product_details").then(function (response) {
                 $scope.products = response.data;
                 if ($scope.products == "") {
                     alert("Sorry no data found");
                 }
             })
         });
    </script>
</asp:Content>
