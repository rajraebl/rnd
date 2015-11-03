(function() {
    angular.module('myApp').controller('myCtrl', function($scope,myService) {
        var vm = this;
        vm.emps = [{ Name: 'Rajesh' }, { Name: 'Shri Ram' }];

        vm.emp = {};

        vm.getAll = function() {
            myService.getEmps().then(function (emp) {
                vm.emps = emp.data;
                console.log(vm.emps);

                //debugger;
            }, function () { alert('some error'); });
        };

        vm.getAll();


        vm.DeleteEmp = function(id) {
            console.log('deleting:' + id);
            myService.DeleteEmp(id).then(function(data) {
                console.log(data);
                alert('deleted');
                vm.getAll();
            }, function() { alert('error while deleting'); });
        };

        vm.addEmp = function() {
            console.log('adding: ' + vm.emp);
            myService.addEditEmp(vm.emp).then(function (data) {
                console.log('response id:'+ JSON.stringify( data));
                alert(data.data);
                vm.getAll();
            }, function() { alert('error while adding'); });
        }

        vm.editEmp = function (emp) {
            //vm.emp = emp; //it was giving error of 2 way binding
            vm.LoadEmp(emp);

            
            console.log('editing' + vm.emp);
           /* myService.editEmp(vm.emp).then(function () {
                vm.getAll();
                alert('editied');
            }, function() { alert('error while editing'); });*/
        };

        vm.Action = 'Add';

        vm.SetAction = function() {
            vm.Action = vm.emp.Id ? 'Update' : 'Add';
        };


        vm.clearEmp = function () {
            vm.emp = {};
            vm.SetAction();
        };

        vm.LoadEmp = function (emp) {
            vm.emp.Id = emp.Id;
            vm.emp.Name = emp.Name;
            vm.emp.Email = emp.Email;
            vm.emp.Mobile = emp.Mobile;
            vm.SetAction();
        }

    });
}());