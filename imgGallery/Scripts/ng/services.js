//var appx = angular.module('app');

//appx.factory('FileUploadService', function($http, $q) {
//    var fac = {};
//    fac.UploadFile = function(file) {
//        var formData = new FormData();
//        formData.append("file", file);
//        var defer = $q.defer();
//        $http.post("/Home/UploadFile", formData,
//            {
//                withCredentials: true,
//                headers: { 'Content-Type': undefined },
//                transformRequest: angular.identity
//            })
//            .success(function(d) {
//                defer.resolve(d);
//            })
//            .error(function() {
//                defer.reject("File Upload Failed!");
//            });

//        return defer.promise;
//    }
//});