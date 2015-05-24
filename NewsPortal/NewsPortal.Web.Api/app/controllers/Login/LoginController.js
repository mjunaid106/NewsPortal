(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'LoginService'];

    function LoginController($location, LoginService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'LoginController';
        vm.login = login;
        vm.username = '';
        vm.password = '';
        activate();

        function activate() { }

        function login() {
            if (vm.username != '' && vm.password != '') {
                LoginService.login(vm.username, vm.password).then(
                    function onSuccess() {
                        $location.path('/home');
                    },
                    function onFailure(response) {
                        alert(response);
                    }
                );
            }
        }
    }
})();
