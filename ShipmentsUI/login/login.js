(function() {
    angular.module('shipments.login', ['auth0'])
        .controller('LoginCtrl', function ($scope, auth, $location) {
        alert(55);
            $scope.login = function() {
                auth.signin({}, function (profile, token) {
                    alert(profile);
                    console.log(profile);
                    $location.path('/');
                }, function(error) {
                    console.log("eror:" + error);
                });
            }
        });
}());