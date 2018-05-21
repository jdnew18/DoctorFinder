var app = angular.module('myApp', ['ngRoute']);

app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode(true);
    $locationProvider.hashPrefix('');
}]);

app.run(['$rootScope', function ($rootScope) {
    $rootScope.$on('$routeChangeError', function () {
        // what you want to do if an error occurs 
        // ex: $rootScope.displayErrorMessage = true
        var a = 5;
        return a;
    });

    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        var a = 5;
        return a;
    });
}]);