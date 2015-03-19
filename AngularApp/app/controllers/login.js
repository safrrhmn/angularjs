(function () {
	'use strict';

	angular
      .module('angularApp')
      .controller('Login', login);

	/**
      * @ngdoc controller
      * @name angularApp.controller:Login
      * @description
      *
      */
	/*@ngInject*/
	function login($http, $state, loginService) {
		var vm = this;

		vm.user = '';

		// PUBLIC FUNCTIONS
		vm.submit = function () {
			loginService.assignCurrentUser(vm.user);
			$state.go("Welcome");
		}


	}
})();
