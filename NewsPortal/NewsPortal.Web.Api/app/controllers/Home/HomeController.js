(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$location'];

    function HomeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'HomeController';
        vm.listTopArticles = '';
        activate();

        function activate() {
            ArticleService.listTopArticles().then(
               function onSuccess(response) {
                   vm.listTopArticles = response.data;
               },
               function onFailure(response) {
                   alert(response);
               }
               );
        }
    }
})();
