(function() {
    "use strict";
    angular.module("common.services")
        .factory('productResource', [
            '$resource', function($resource) {
                return $resource('http://localhost:21135/api/product/');
            }
        ]);

}());



(function () {
    "use strict";
    angular.module("common.services")
        .factory('priceResource', [
            '$resource', function ($resource) {
                return $resource('http://localhost:46616/api/Price/');
            }
        ]);

}());



