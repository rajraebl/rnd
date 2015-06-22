(function() {
    angular
        .module('app', ['ngAnimate'])
        .factory('FileUploadService', function($http, $q) {
            var fac = {};
            fac.UploadFile = function(file) {
                var formData = new FormData();
                formData.append("file", file);
                var defer = $q.defer();
                $http.post("/api/Image/", formData,
                    {
                        withCredentials: true,
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    })
                    .success(function(d) {
                        defer.resolve(d);
                    })
                    .error(function() {
                        defer.reject("File Upload Failed!");
                    });

                return defer.promise;
            }

        return {
            UploadFile: fac.UploadFile
    }
        });

        angular.module('app')
        .controller('ctrl', ['$location', '$scope', '$timeout', '$rootScope', '$window', '$http', "FileUploadService",
             function ($location, $scope, $timeout, $rootScope, $window, $http, x) {

                $scope.date = new Date();
                $scope.MyName = "Rajesh";
                $scope.Imagename = "";
                $scope.ShowImage = false;
                $scope.Description = "";
                $scope.AnimationImageName = "1.jpg";
                $scope.Images = [];
                $scope.icountval = 0;

        $http.get('/api/Image/')
            .success(function(data) {
                $scope.Images = data;
                if ($scope.Images.length > 0) {
                    $scope.onShowImage($scope.Images[0].Image_Path);
                }
            })
            .error(function() {
            $scope.error = "some eror came";
            });

        $scope.onShowImage = function(imagePath) {
            $scope.ShowImage = false;
            $scope.AnimationImageName = imagePath;
            $scope.ShowImage = true;
        };

        $scope.SaveFile = function () {
            //$scope.IsFormSubmitted = true;

            //$scope.Message = "";
            var SelectedFileForUpload = document.getElementById('file').files[0];
            $scope.Imagename = SelectedFileForUpload.name;
            ////$scope.ChechFileValid($scope.SelectedFileForUpload);

            //if ($scope.IsFormValid && $scope.IsFileValid)
            {

                x.UploadFile(SelectedFileForUpload).then(function (d) {

                    var ItmDetails = {
                        Image_Path: $scope.Imagename,
                        Description: $scope.Description
                    };
                    //$http.post('/api/Image/', ItmDetails).success(function (data) {
                    //    alert("Added Successfully!!");
                    //    $scope.addMode = false;
                    $scope.Images.push(ItmDetails);
                    //    $scope.loading = false;
                    //}).error(function (data) {
                    //    $scope.error = "An Error has occured while Adding Image! " + data;
                    //    $scope.loading = false;
                    //});
                    alert(d.Data.Message + " !");
                    $scope.IsFormSubmitted = false;
                    //ClearForm();
                }, function (e) {
                    alert(e);
                });
            }
            //else {
            //    $scope.Message = "All the fields are required.";
            //}
        };

    }]);
    //ctrl.$inject = []

})();