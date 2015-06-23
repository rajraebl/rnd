(function() {
    "use strict";
    angular.module("productManagement")
        .controller("ProductDetailCtrl", ["product", ProductDetailCtrl]);

    function ProductDetailCtrl(product) {
        var vm = this;
        //vm.product = {
        //    'productId': 7,
        //    'productName': 'Leaf LAke7',
        //    'productCode': 'GDN-0014',
        //    'releaseDate': 'March 1, 2015',
        //    'price': 339.95,
        //    'imgUrl': '/oo.jpg',
        //    'category': 'garden',
        //    'description': 'this is the description'
        //};
        vm.product = product;
        vm.title = "Product Detail: " + vm.product.productName;

    }
}());