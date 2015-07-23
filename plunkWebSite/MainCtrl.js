// Code goes here
//alert();
(function() {
  var myApp = angular.module("myModule");
  myApp.controller('MainCtrl', function($scope, $http, servicex, $interval, $log, $location, $anchorScroll) {
    $scope.itemToShow = 28;
    $scope.name = "Persons";

    $scope.countDown = 5;

    var incrementCountDown = function() {
      $scope.countDown -= 1;
    }
    var objInterval = null;
    $scope.startCountDown = function() {
      $log.info('startCountDown');
      objInterval = $interval(incrementCountDown, 700, 5);
    }

    $scope.stopCountDown = function() {
      $log.info('stopCountDown');
      $interval.cancel(objInterval);
    }

$scope.moveout = function()
{
  $location.path("/user/odetocode");
}

    $scope.getUserFromCustomService = function() {
      console.log('fgdgdfgfd');
      servicex.getUsers().then(function(data) {
        $scope.personsX = data;
      });
      console.log('end');
    }

    $scope.persons = $http.get("https://api.github.com/users").then(function(response) {
      $scope.persons = response.data;
      $location.hash("filterArea");
      $anchorScroll();
    })

  })

}());