(function () {
    'use strict';

    angular
        .module('app')
        .factory('ArticleService', ArticleService);

    ArticleService.$inject = ['$http'];

    function ArticleService($http) {
        var service = {
            listTopArticles: listTopArticles
        };

        return service;

        function listTopArticles() {
            var promise = $http.get('/api/article/get');
            return promise;
        }
    }
})();