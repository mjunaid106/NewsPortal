(function () {
    'use strict';

    angular
        .module('uiApp')
        .factory('LoginService', LoginService);

    LoginService.$inject = ['$http'];

    function LoginService($http) {
        var service = {
            login: login
        };

        return service;

        function login(username, password) {
            var promise = $http.post('/api/login/', { 'username': username, 'password': password });
            return promise;
        }
    }
})();