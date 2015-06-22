(function() {
    //"use strict";
    angular.module("common.services")

    .factory('productResource', ['$resource', function ($resource) {
        return $resource("/api/products");
        //return { xx: function() { alert(); } }
    }
    ]);
    //function productResource(x) {
    //    return x("/api/products/:productId");
    //};

}());



