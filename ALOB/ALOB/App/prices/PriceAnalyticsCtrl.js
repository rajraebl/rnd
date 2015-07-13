(function() {

    angular.module("productManagement")
        .controller("PriceAnalyticsCtrl", ["$scope","$filter", "products", "productService", PriceAnalyticsCtrl]);

    function PriceAnalyticsCtrl($scope, $filter, products, productService) {

        $scope.title = "Price Analytics";

        for (var i = 0; i < products.length; i++) {
            products[i].marginPercent = productService.calculateMarginPercentage(products[i].price, products[i].cost);
            products[i].marginAmount = productService.calculateMarginAmount(products[i].price, products[i].cost);
        }

        var orderedProductAmount = $filter("orderBy")(products, "marginAmount");
        var filteredProductAmount = $filter("limitTo")(orderedProductAmount, 11);
        var chartDataAmount = [];
        for (var j = 0; j < filteredProductAmount.length; j++) {
            chartDataAmount.push({
                x: filteredProductAmount[j].productName,
                y: [
                    filteredProductAmount[j].cost,
                    filteredProductAmount[j].price,
                    filteredProductAmount[j].marginAmount
                ]
            });
        }

        $scope.dataAmount = {
            series: ["Cost", "Price", "Margin Amount"],
            data: chartDataAmount
        };

        $scope.configAmount = {
            title:"ola pola",
            tooltips: true,
            labels:false,
            legend: {
                display:true,
                position:'right'
            }
        }

        var orderedProductPercent = $filter("orderBy")(products, "marginPercent");
        var filteredProductPercent = $filter("limitTo")(orderedProductPercent, 11);
        var chartDataPercent = [];
        for (var j = 0; j < filteredProductPercent.length; j++) {
            chartDataPercent.push({
                x: filteredProductPercent[j].productName,
                y: [
                    //filteredProductPercent[j].cost,
                    filteredProductPercent[j].price,
                    filteredProductPercent[j].marginPercent
                ]
            });
        }
        $scope.dataPercent = {
            series: [ "Price", "Margin %"],
            data: chartDataPercent
        };
        $scope.configPercent = {
            title: "ola pola",
            tooltips: true,
            labels: false,
            legend: {
                display: true,
                position: 'right'
            }
        }

    }
}());