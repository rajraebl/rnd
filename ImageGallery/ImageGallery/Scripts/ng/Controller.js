/// <reference path="../angular.js" /> 
/// <reference path="../angular.min.js" />  
/// <reference path="../angular-animate.js" /> 
/// <reference path="../angular-animate.min.js" /> 

(function () {
    'use strict';
    angular
        .module('imgApp', [])
        .controller('imgController', imgController);

    function imgController($scope, $timeout, $rootScope, $window, $http, FileUploadService) {
        $scope.date = new Date();
        $scope.MyName = "Shanu";
        $scope.Imagename = "";
        $scope.ShowImage = false;
        $scope.Description = "";
        $scope.AnimationImageName = "1.jpg";
        $scope.ImagesALLVal = [];
        $scope.icountval = 0

        //get all image Details
        $http.get('/api/Image/').success(function (data) {
            $scope.Images = data;
            if ($scope.Images.length > 0) {
                $scope.onShowImage($scope.Images[0].Image_Path);
            }
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });

        $scope.onShowImage = function (Image_Path) {
            $scope.ShowImage = false;
            $scope.AnimationImageName = Image_Path
            $timeout(function () {
                $scope.ShowImage = true;
            }, 400);

        }
    }

}

());