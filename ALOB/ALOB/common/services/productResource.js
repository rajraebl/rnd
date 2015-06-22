(function() {
    //"use strict";
    angular.module("productManagement")

    .factory('productResource', ['$http', function($http) {
        return $http.get("/api/products/");
        //return { xx: function() { alert(); } }
    }
    ]);
    //function productResource(x) {
    //    return x("/api/products/:productId");
    //};

}());



