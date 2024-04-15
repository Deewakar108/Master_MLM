<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Master_MLM.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
    <link href="css/custom.css" rel="stylesheet" />
    <link href="ProductSlider/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">



        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <section>
            <div class="welcome-text" data-ng-app="productsApp">
                <div class="background-bg" data-ng-controller="myProductsCtrl">
                    <div class="container">
                        <div class="welcome-text-iner">
                            <div class="leading-text">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <h2 class="our-product-h2">Rewards - </h2>

                                    <ul id="flexiselDemo2">
                                        <li class="nbs-flexisel-item" data-ng-repeat="x in products">
                                            <div class="image-box">
                                                <figure>
                                                    <a href="#">
                                                        <img src="{{x.Image_path}}" alt="Ocean Health Pariwar" /></a>
                                                    <div class="bike-sec">
                                                        <p class="figure-p">{{x.Product_name}}</p>
                                                    </div>
                                                </figure>
                                            </div>
                                        </li>
                                    </ul>

                                    <%--<section class="about-section">
                                    <div class="owl-sec">
                                        <div class="three-column-carousel">



                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/2.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">GRITMUKT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/3.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCEDIAB SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/4.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCITUS COUGH SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/5.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">LIVKRIT - DS SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/6.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCIRON SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/7.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">KRITZYME SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/8.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCIVIT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/9.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">LIVKRIT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/10.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCERAKT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/11.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">COUGH SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/12.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCECID SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/13.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">CEREBRO SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/14.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCEFEM SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/15.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">ACTIVATOR SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>

                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/16.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">PYNACE PAIN OIL</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


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

        <!-- //banner slider -->
        <script type="text/javascript">
            $(window).load(function () {
                $("#flexiselDemo2").flexisel({
                    visibleItems: 4,
                    animationSpeed: 1000,
                    autoPlay: true,
                    autoPlaySpeed: 3000,
                    pauseOnHover: true,
                    enableResponsiveBreakpoints: true,
                    responsiveBreakpoints: {
                        portrait: {
                            changePoint: 480,
                            visibleItems: 1
                        },
                        landscape: {
                            changePoint: 640,
                            visibleItems: 1
                        },
                        tablet: {
                            changePoint: 768,
                            visibleItems: 1
                        }
                    }
                });

            });
        </script>
        <script src="js/jquery.js"></script>
        <script src="ProductSlider/jquery.flexisel.js"></script>
    </form>
</body>
</html>
