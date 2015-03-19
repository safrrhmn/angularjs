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
	function login($scope, $http, $state, loginService, authService) {

		// PUBLIC FUNCTIONS
		$scope.submit = function () {
			loginService.assignCurrentUser($scope.user);
			$state.go("Welcome");
		}


	}
})();
