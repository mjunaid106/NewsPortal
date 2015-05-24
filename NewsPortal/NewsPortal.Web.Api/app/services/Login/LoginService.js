(function () {
    'use strict';

    angular
        .module('app')
        .factory('LoginService', LoginService);

    LoginService.$inject = ['$http'];

    function LoginService($http) {
        var service = {
            login: login
        };

        return service;

        function login(username, password) {
            var promise = $http.get('/api/authentication/login/' + username + '/' + password );
            return promise;
        }
    }
})();