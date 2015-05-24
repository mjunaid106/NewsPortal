(function () {
    'use strict';

    var app = angular.module('app', ['ngRoute']);
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/login', {
            controller: 'LoginController',
            templateUrl: 'app/partial/Login/Login.html'
        }).
        when('/home', {
            controller: 'HomeController',
            templateUrl: 'app/partial/Home/Home.html'
        }).
        otherwise({
            redirectTo: '/login'
        });
    }]);
})();