(function () {
    //"use strict";
    angular.module("productManagement")
        .controller("ProductListCtrl", ProductListCtrl);

    function ProductListCtrl() {
        var vm = this;
        vm.showImage = false;

        vm.toggleImage = function () {
            //alert(vm.showImage);
            vm.showImage = !vm.showImage;
        };

        //productResource.query(function (data) {
        //    vm.products = data;
        //});

        vm.products = [
            {
                'productId': 1,'productName': 'Leaf LAke1','productCode': 'GDN-0011','releaseDate': 'March 19, 2009','price': 9.95,'imgUrl': 'a.jpg',
                'category': 'garden','description': 'this is the description'
            },
            {
                'productId': 2, 'productName': 'Leaf LAke2', 'productCode': 'GDN-0012', 'releaseDate': 'March 11, 2002', 'price': 19.90, 'imgUrl': '',
                'category': 'garden', 'description': 'this is the description'
            },
            {
                'productId': 3, 'productName': 'Leaf LAke3', 'productCode': 'GDN-0013', 'releaseDate': 'March 12, 2003', 'price': 11.95, 'imgUrl': '',
                'category': 'garden', 'description': 'this is the description'
            },
            {
                'productId': 4, 'productName': 'Leaf LAke4', 'productCode': 'GDN-0014', 'releaseDate': 'March 1, 2015', 'price': 339.95, 'imgUrl': '',
                'category': 'garden', 'description': 'this is the description'
            },
        {
                'productId': 5,'productName': 'Leaf LAke5','productCode': 'GDN-0012','releaseDate': 'March 11, 2002','price': 19.90,'imgUrl': '',
                'category': 'garden','description': 'this is the description'
    },
{
                'productId': 6,'productName': 'Leaf LAke6','productCode': 'GDN-0013','releaseDate': 'March 12, 2003','price': 11.95,'imgUrl': '',
                'category': 'garden','description': 'this is the description'
},
            {
                'productId': 7,'productName': 'Leaf LAke7','productCode': 'GDN-0014','releaseDate': 'March 1, 2015','price': 339.95,'imgUrl': '',
                'category': 'garden','description': 'this is the description'
            }
];
    }
}());