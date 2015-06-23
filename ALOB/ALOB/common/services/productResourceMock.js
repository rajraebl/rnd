﻿(function() {

    "use strict";
    var app = angular.module("productResourceMock", ["ngMockE2E"]);
    app.run(function($httpBackend) {
        var products = [
            {
                'productId': 1,
                'productName': 'Leaf LAke1',
                'productCode': 'GDN-0011',
                'releaseDate': 'March 19, 2009',
                'price': 9.95,
                'imgUrl': 'a.jpg',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 2,
                'productName': 'Leaf LAke2',
                'productCode': 'GDN-0012',
                'releaseDate': 'March 11, 2002',
                'price': 19.90,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 3,
                'productName': 'Leaf LAke3',
                'productCode': 'GDN-0013',
                'releaseDate': 'March 12, 2003',
                'price': 11.95,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 4,
                'productName': 'Leaf LAke4',
                'productCode': 'GDN-0014',
                'releaseDate': 'March 1, 2015',
                'price': 339.95,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 5,
                'productName': 'Leaf LAke5',
                'productCode': 'GDN-0012',
                'releaseDate': 'March 11, 2002',
                'price': 19.90,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 6,
                'productName': 'Leaf LAke6',
                'productCode': 'GDN-0013',
                'releaseDate': 'March 12, 2003',
                'price': 11.95,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 7,
                'productName': 'Leaf LAke7',
                'productCode': 'GDN-0014',
                'releaseDate': 'March 1, 2015',
                'price': 339.95,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 15,
                'productName': 'Leaf LAke15',
                'productCode': 'GDN-0012',
                'releaseDate': 'March 11, 2002',
                'price': 19.90,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 16,
                'productName': 'Leaf LAke16',
                'productCode': 'GDN-0013',
                'releaseDate': 'March 12, 2003',
                'price': 11.95,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            },
            {
                'productId': 17,
                'productName': 'Leaf LAke17',
                'productCode': 'GDN-0014',
                'releaseDate': 'March 1, 2015',
                'price': 339.95,
                'imgUrl': '',
                'category': 'garden',
                'description': 'this is the description'
            }

        ];

        var productUrl = "/api/products";

        $httpBackend.whenGET(productUrl).respond(products);

        //$httpBackend.whenGET("/api/products?productId=2").respond({
        //    'productId': 7,
        //    'productName': 'Leaf LAke7',
        //    'productCode': 'GDN-0014',
        //    'releaseDate': 'March 1, 2015',
        //    'price': 339.95,
        //    'imgUrl': '',
        //    'category': 'garden',
        //    'description': 'this is the description'
        //});

        //var editingregex = new RegExp("/api/products?productId=" + "[0-9][0-9]*", '');
        var editingregex = new RegExp(productUrl + "/[0-9][0-9]*", '');

        $httpBackend.whenGET(editingregex).respond(function(method,url,data) {
            //alert(url);
            var product = { "productId": 0 };
            var params = url.split('/');
            var length = params.length;
            var id = params[length - 1];
            if (id > 0) {
                for(var i = 0;i<products.length;i++)
                    if (id == products[i].productId) {
                        product = products[i];
                        break;
                    }
            }
            return [200, product, {}];

        });

        $httpBackend.whenPOST(productUrl).respond(function(method, url, data) {
            var product = angular.fromJson(data);

            if (!product.productId) {//new product
                product.productId = products[products.length - 1].productId + 1;
                products.push(product);

            } else {
                for (var i = 0; i < products.length; i++)
                    if (product.productId == products[i].productId) {
                        products[i] = product;
                        break;
                    }
            }

            return [200, product, {}];

        });

        //ignore any request for application file
        $httpBackend.whenGET(/app/).passThrough();
    });
}());