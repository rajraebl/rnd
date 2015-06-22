(function() {
    //"use strict";

    angular.module("common.services")
        .factory('productResource', ['$resource', function($resource) {
                return $resource("/api/products/:productId");
        }
]);

    //function productResource(x) {
    //    return x("/api/products/:productId");
    //};

});