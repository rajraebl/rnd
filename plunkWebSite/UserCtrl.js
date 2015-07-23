// Code goes here
//alert();
(function() {
  var myApp = angular.module("myModule");
  myApp.controller('UserCtrl', function($scope, $http, servicex, $interval, $log, $location, $anchorScroll, $routeParams) {
    console.log("inside user controller");
    $scope.itemToShow = 1;
    $scope.name = $routeParams.username;

    $scope.countDown = 5;

    var incrementCountDown = function() {
      $scope.countDown -= 1;
    }
    var objInterval = null;
    $scope.startCountDown = function() {
      $log.info('startCountDown');
      objInterval = $interval(incrementCountDown, 700, 5);
    }
$scope.moveout = function()
{
  $location.path("/main");
}
    $scope.stopCountDown = function() {
      $log.info('stopCountDown');
      $interval.cancel(objInterval);
    }

    $scope.getUserFromCustomService = function() {
      console.log('fgdgdfgfd');
      servicex.getUsers().then(function(data) {
        $scope.personsX = data;
      });
      console.log('end');
    }

    $scope.persons = $http.get("https://api.github.com/users/odetocode").then(function(response) {
       console.log("https://api.github.com/users/");
       console.log(JSON.stringify(response.data));
       $scope.persons = null;
      $scope.persons = response.data;
      $scope.itemToShow = 1;
      //$location.hash("filterArea");
      //$anchorScroll();
    },function(ex){console.log(ex)})

  })

}());