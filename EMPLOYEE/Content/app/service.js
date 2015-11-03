(function() {
    angular.module('myApp').service('myService', function($http) {
        this.getEmps = function() {
            return $http.get('/emp/getAll');
        };

        this.DeleteEmp = function(empId) {
            var response = $http({
                method: "post",
                url: "/emp/DeleteEmp",
                params: {
                    empId: JSON.stringify(empId)
                }
            });

            return response;
        }

        this.addEditEmp = function(emp) {
            var response = $http(
            {
                method: 'post',
                url: '/emp/AddUpdateEmp',
                data: JSON.stringify(emp),
                dataType:"json"
        
            });

            return response;
        }

        this.editEmp = function(emp) {
           return this.addEmp(emp);
        };

    });
}());