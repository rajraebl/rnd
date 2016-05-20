var app = angular.module('app', ['ngTouch', 'ui.grid', 'ui.grid.pagination']);
app.controller('MainCtrl', [
'$scope', '$http', 'uiGridConstants', function ($scope, $http, uiGridConstants) {
    var paginationOptions = {
        pageNumber: 1,
        pageSize: 5,
        sort: null
    };
    $scope.gridOptions = {
        paginationPageSizes: [paginationOptions.pageSize, 2 * paginationOptions.pageSize, 3 * paginationOptions.pageSize, 4 * paginationOptions.pageSize],
        paginationPageSize: paginationOptions.pageSize,
        useExternalPagination: true,
        useExternalSorting: true,
        columnDefs: [
        { name: 'StudentId' },
        { name: 'FirstName', enableSorting: true },
        { name: 'LastName', enableSorting: false },
        { name: 'Age', enableSorting: false },
        { name: 'Gender', enableSorting: false },
        { name: 'Batch', enableSorting: false },
        { name: 'Address', enableSorting: false },
        { name: 'Class', enableSorting: false },
        { name: 'School', enableSorting: false },
        { name: 'Domicile', enableSorting: false },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                if (sortColumns.length == 0) {
                    paginationOptions.sort = null;
                } else {
                    paginationOptions.sort = sortColumns[0].sort.direction;
                }
                getPage();
            });
            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;
                getPage();
            });
        }
    };
    var getPage = function () {
        var urlPrefix = 'http://localhost:32060/myApiPrefix/'
        var url;
        switch (paginationOptions.sort) {
            case uiGridConstants.ASC:
                //URL of your Web Api running Path.
                url =  urlPrefix + 'GetStudentsAsc';
                break;
            case uiGridConstants.DESC:
                //URL of your Web Api running Path.
                url = urlPrefix + 'GetStudentsDesc';
                break;
            default:
                //URL of your Web Api running Path.
                url = urlPrefix + 'GetStudents';
                break;
        }

        $http.get(url)
        .success(function (data) {
            debugger;
            $scope.gridOptions.totalItems = data.length; //100;
            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            $scope.gridOptions.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);
        });
    };

    getPage();
}
]);