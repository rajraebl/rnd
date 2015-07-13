/// <reference path="E:\myProject\Projects\RnD\ALOB\ALOB\js/angular-ui-router.js" />
/// <reference path="products/productDetailView.html" />

(function() {
    "use strict";
    var app = angular.module("productManagement", ['productResourceMock', 'common.services', 'ui.router', 'ui.mask', 'ui.bootstrap','angularCharts']);

    app.config(function($provide) {
        $provide.decorator("$exceptionHandler", [
            '$delegate', function($delegate) {
                return function(exception, cause) {
                    exception.message = "Something went wrong. Message: " + exception.message;
                    $delegate(exception, cause); //default beahviour of base class i.e. log to console window
                    alert(exception.message);
                };
            }
        ]);
    });

    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("home", {
                url: "/",
                templateUrl: "app/welcomeView.html"
            })
            .state("productList", {
                url: "/products",
                templateUrl: "app/products/productListView.html",
                controller: "ProductListCtrl as vm"
            })
            .state("productEdit", {
                abstract: true,
                url: "/products/edit/:productId",
                templateUrl: "app/products/productEditView.html",
                controller: "ProductEditCtrl as vm",
                resolve: {
                    productResource: "productResource",
                    product: function(productResource, $stateParams) {
                        var productId = $stateParams.productId;
                        return productResource.get({ productId: productId }).$promise;
                    }
                }
            })
            .state("productEdit.info", { url: "/info", templateUrl: "app/products/productEditInfoView.html" })
            .state("productEdit.price", { url: "/price", templateUrl: "app/products/productEditPriceView.html" })
            .state("productEdit.tags", { url: "/tags", templateUrl: "app/products/productEditTagView.html" })
            .state("productDetail", {
                url: "/products/:productId",
                templateUrl: "app/products/productDetailView.html",
                controller: "ProductDetailCtrl as vm",
                resolve: {
                    productResource: "productResource",
                    product: function(productResource, $stateParams) {
                        var productId = $stateParams.productId;
                        return productResource.get({ productId: productId }).$promise;
                    }
                }
            })
            .state("priceAnalytics", {
                url: "/priceAnalytics",
                templateUrl: "app/prices/priceAnalyticsView.html",
                controller: "PriceAnalyticsCtrl",  //we are not using as syntax bcz charts were not working w/o $scope parameter
                resolve: {
                    productResource: "productResource", 
                    products: function(productResource) {
                        return productResource.query().$promise;
                    }
                }
            });


    }]);
    //angular.module("productManagement")
    //    .controller("ProductListCtrl", ['productResource', ProductListCtrl]);

    //function ProductListCtrl(productResource) {
    //    var vm = this;
    //    vm.showImage = false;

    //    vm.toggleImage = function() {
    //        //alert(vm.showImage);
    //        vm.showImage = !vm.showImage;
    //    };

    //    //productResource.query(function (data) {
    //    //    vm.products = data; 
    //    //});

    //    vm.products = productResource.then(function(response) {
    //        //alert(data);
    //        vm.products = response.data;
    //    }, function(err) {
    //        alert(err);
    //    });


    //    //angular.module("productManagement", []);
    //}
}());