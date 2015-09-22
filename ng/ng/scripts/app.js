var app = angular.module('MyApp', []);
app.directive('myDirective', function() {
    return {
        template: 'hello from directive'
    };
})