(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$location', 'ArticleService'];

    function HomeController($location, ArticleService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'HomeController';
        vm.topArticles = '';
        activate();

        function activate() {
            ArticleService.listTopArticles().then(
               function onSuccess(response) {
                   vm.topArticles = response.data;
               },
               function onFailure(response) {
                   alert(response);
               }
               );
        }
    }
})();
