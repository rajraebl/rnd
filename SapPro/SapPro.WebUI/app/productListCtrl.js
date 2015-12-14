(function () {
    //"use strict";
    angular.module("productManagement")
        .controller("ProductListCtrl", ['productResource', 'priceResource', ProductListCtrl]);

    function ProductListCtrl(productResource, priceResource) {
        var vm = this;
        vm.filterCategory = '';

        vm.filter = function () {
            //alert(vm.filterCategory);
            

            productResource.query({ filterCategory: vm.filterCategory }, function (response) {
                //alert(data);
                vm.products = response;
            });
        };

        vm.currentElements = null;
        vm.showPrice = function (cat, $event) {
            console.log($event.currentTarget);
            vm.currentElements = $event.currentTarget;
            vm.currentCategory = cat;
            vm.getPrice($event.currentTarget);
        }

        vm.currentCategory = '';

        vm.getPrice = function(ele) {
            
            var pp = priceResource.query({ filterCategory: vm.currentCategory }, function (response) {
                //alert(response);
                console.log(response);
                $(ele).closest('td').prev('td').html(response);

                //console.log(response);
                //vm.products = response;
            });

            //console.log(pp);/**/


            //var pp = priceResource.get({ filterCategory: vm.currentCategory }, function (response, data, data2) {
            //    console.log(data2);
            //    $(ele).closest('td').prev('td').html(response);

            //    //console.log(response);
            //    //vm.products = response;
            //});



            //priceResource.query({ filterCategory: vm.currentCategory}).$promise.then(function (d) { console.log(d); });

            //var ins = new priceResource();
            //var kk = ins.query({ filterCategory: vm.currentCategory },function(d) {
            //    alert(d);
            //    console.log(d);
            //});
        };

        productResource.query(function (response) {
            //alert(data);
            vm.products = response;
        });



    }
}());