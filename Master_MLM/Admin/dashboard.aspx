<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Master_MLM.Admin.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="http://www.chartjs.org/dist/2.7.2/Chart.bundle.js"></script>
    <script src="http://www.chartjs.org/samples/latest/utils.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfPieData" runat="server" Value="[0, 0]" />
    <asp:HiddenField ID="hdfPieLabel" runat="server" Value="['FREE', 'PAID']" />
    <asp:HiddenField ID="hdfBarFree" runat="server" Value="[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]" />
    <asp:HiddenField ID="hdfBarPaid" runat="server" Value="[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]" />

    <asp:HiddenField ID="hdfPiePackageWiseLabel" runat="server" Value="[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]" />
    <asp:HiddenField ID="hdfPiePackageWiseData" runat="server" Value="[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]" />

    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Distribute E-Pin</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distribute E-Pin</h5>
                    </div>
                    <div class="widget-content">
                        <canvas id="bar-chart"></canvas>

                        <script>
                            var MONTHS = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
                            var color = Chart.helpers.color;
                            var barChartData = {
                                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                                datasets: [{
                                    label: 'FREE',
                                    backgroundColor: color(window.chartColors.red).alpha(0.5).rgbString(),
                                    borderColor: window.chartColors.red,
                                    borderWidth: 2,
                                    data: [
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor()
                                    ]
                                }, {
                                    label: 'PAID',
                                    backgroundColor: color(window.chartColors.yellow).alpha(0.5).rgbString(),
                                    borderColor: window.chartColors.yellow,
                                    borderWidth: 2,
                                    data: [
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor(),
                                        randomScalingFactor()
                                    ]
                                }]

                            };

                            function randomScalingFactor() {
                                return Math.round(Math.random() * 100);
                            };

                            var FreeData = $('#<%= hdfBarFree.ClientID %>').val();
                            var PaidData = $('#<%= hdfBarPaid.ClientID %>').val();

                            barChartData.datasets[0].data = JSON.parse(FreeData);
                            barChartData.datasets[1].data = JSON.parse(PaidData);
                            var myData = [0, 8];
                            var labelData = ['FREE', 'PAID'];

                            var config = {
                                type: 'pie',
                                data: {
                                    datasets: [{
                                        data: myData,
                                        backgroundColor: [
                                            window.chartColors.red,
                                            window.chartColors.yellow,
                                            window.chartColors.green,
                                            window.chartColors.grey,
                                        ],
                                        label: 'Year - 2018'
                                    }],
                                    labels: labelData //['FREE', 'PAID']
                                },
                                options: {
                                    responsive: true
                                }
                            };

                            window.onload = function () {
                                //Bar Chart
                                var ctxBar = document.getElementById('bar-chart').getContext('2d');
                                window.myBar = new Chart(ctxBar, {
                                    type: 'bar',
                                    data: barChartData,
                                    options: {
                                        responsive: true,
                                        legend: {
                                            position: 'top',
                                        },
                                        title: {
                                            display: true,
                                            text: 'Year - 2018'
                                        },

                                    }
                                });

                                
                                //alert(labelData);

                                //Pie Chart
                                myData = $('#<%= hdfPieData.ClientID %>').val();
                                config.data.datasets[0].data = JSON.parse(myData);
                                config.data.labels = JSON.parse(JSON.stringify(labelData));
                                //alert(config.data.labels + JSON.parse(JSON.stringify(labelData)) + JSON.parse(myData));
                                var ctx = document.getElementById('chart-area').getContext('2d');
                                window.myPie = new Chart(ctx, config);

                                //Pie Chart - Package Wise
                                alert(config.data.labels + JSON.parse(JSON.stringify(labelData)));
                                myData = $('#<= hdfPiePackageWiseData.ClientID %>').val(); 
                                labelData = $('#<= hdfPiePackageWiseLabel.ClientID %>').val();
                                alert(labelData);
                                config.data.datasets[0].data = JSON.parse(myData);
                                config.data.labels = JSON.parse(labelData);
                                alert(config.data.labels + JSON.parse(JSON.stringify(labelData)) + JSON.parse(myData));
                                var ctxY = document.getElementById('piePackageWise').getContext('2d');
                                window.myPie = new Chart(ctxY, config);
                                alert(config.data.labels + JSON.parse(JSON.stringify(labelData)) + JSON.parse(myData));
                            };

                        </script>
                    </div>
                </div>
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Joined Members</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div id="canvas-holder">
                                <canvas id="chart-area"></canvas>

                                <canvas id="piePackageWise"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
