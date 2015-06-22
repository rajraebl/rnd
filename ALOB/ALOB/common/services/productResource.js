(function() {
    //"use strict";

    angular.module("common.services")
        .factory('productResource', ['$http', function ($http) {
            //return $http.get("/api/products/");
            return {xx:function () { alert(); }}
        }
]);

    //function productResource(x) {
    //    return x("/api/products/:productId");
    //};

});