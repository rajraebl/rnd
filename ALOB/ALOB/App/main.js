﻿(function() {
    //"use strict";
    angular.module("productManagement", ['productResourceMock'])
        .factory('productResource', ['$http', function($http) {
                return $http.get("/api/products/");
                //return { xx: function() { alert(); } }
            }
        ]);

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