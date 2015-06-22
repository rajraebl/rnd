(function() {

    "use strict";
    var app = angular.module("productResourceMock", ["ngMockE2E"]);
    app.run(function($httpBackend) {
                var products = [
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

                var productUrl = "/api/products";
        $httpBackend.whenGET(productUrl).respond(products);

    });
}());