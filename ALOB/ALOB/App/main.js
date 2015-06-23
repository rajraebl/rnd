/// <reference path="E:\myProject\Projects\RnD\ALOB\ALOB\js/angular-ui-router.js" />
/// <reference path="products/productDetailView.html" />

(function() {
    "use strict";
    var app = angular.module("productManagement", ['productResourceMock', 'common.services','ui.router']);

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
                url: "/products/edit/:productId",
                templateUrl: "app/products/productEditView.html",
                controller: "ProductListCtrl as vm"
            })
            .state("productDetail", {
                url: "/products/:productId",
                templateUrl: "app/products/productDetailView.html",
                controller: "ProductDetailCtrl as vm",
                resolve : {
                    productResource: "productResource",
                    product: function(productResource, $stateParams) {
                        var productId = $stateParams.productId;
                        return productResource.get({ productId: productId }).$promise;
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