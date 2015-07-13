(function() {
    "use strict";

    angular.module("productManagement")
        .factory("productService", productService);

    function productService() {
        function calculatepercentage(price, cost) {
            return price * cost / 100;
        }

        function calculateMarginPercentage(price, cost) {
            return price * cost / 100;
        }

        function calculateMarginAmount(price, cost) {
            return price / cost * 100;
        }

        return {
            calculatepercentage: calculatepercentage,
            calculateMarginPercentage: calculateMarginPercentage,
            calculateMarginAmount: calculateMarginAmount
        };
    }

}());