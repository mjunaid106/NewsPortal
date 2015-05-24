(function () {
    'use strict';

    var app = angular.module('uiApp', ['ngRoute']);
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/app', {
            controller: 'LoginController',
            templateUrl: 'app/partial/Login/Login.html'
        }).
        otherwise({
            redirectTo: '/login'
        });
    }]);
})();