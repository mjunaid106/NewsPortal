(function () {
    'use strict';

    angular
        .module('uiApp')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location'];

    function LoginController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'LoginController';
        vm.login = login;

        activate();

        function activate() { }

        function login(username, password) {
            LoginService.login(username, password).then(
                function onSuccess() {
                    alert("logged in");
                },
                function onFailure(response) {
                    alert(response);
                }
                );
        }
    }
})();
