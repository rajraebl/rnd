(function() {
    "use restrict";
    angular.module("productManagement")
        .controller("ProductEditCtrl", ["product", "$state", "productService", ProductEditCtrl]);

    function ProductEditCtrl(product, $state, productService) {
        var vm = this;
        vm.product = product;

        if (vm.product && vm.product.productId) {
            vm.title = "Edit: " + vm.product.productName;
        } else {
            vm.title = "New Product";
        }

        vm.open = function($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.opened = !vm.opened;
        };

        vm.submit = function() {
            vm.product.$save(function(data) {
                toastr.success("Save Successfull");
            });
        };
        vm.cancel = function() {
            $state.go('productList');
        };

        if (!vm.product.cost) {
            vm.product.cost = 10;
            vm.product.percentage = 0;
        }

        

        vm.percentage = function() {
            vm.product.percentage= productService.calculatepercentage(vm.product.price, vm.product.cost);
        }



        vm.addTags = function(tags) {
            if (tags) {
                var array = tags.split(',');
                vm.product.tags = vm.product.tags ? vm.product.tags.concat(array) : array;

            } else {
                alert('plz enter one or more tags separated by commas');
            }
        };

        vm.removeTag = function(index) {
            vm.product.tags.splice(index, 1);
        };
    }
}());