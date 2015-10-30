(function() {
    angular.module('shipments.home', ['auth0'])
        .controller('HomeCtrl', function ($scope, auth) {
           // .controller('LoginCtrl', function ($scope, auth, $location) {

        alert(77);
            $scope.shipments = [];

        $scope.logout = function() {
            alert('signingout');
            auth.signout();

        };
    });
}());