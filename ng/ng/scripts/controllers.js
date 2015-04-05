app.controller('BookController', function($scope) {
    $scope.Books = [
         { ISBN: "5674789", Name: "Asp.Net MVC", Price: 560, Quantity: 20 },
            { ISBN: "4352134", Name: "AngularJS", Price: 450, Quantity: 25 },
            { ISBN: "2460932", Name: "Javascript", Price: 180, Quantity: 15 }
    ];
});