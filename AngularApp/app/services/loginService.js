(function () {
	'use strict';

	angular
      .module('angularApp')
      .service('loginService', loginService);

	/**
      * @ngdoc service
      * @name angularApp.service:loginService
      * @description
      *
      */
	/*@ngInject*/
	function loginService($rootScope, localStorageService) {

		var service = {
			assignCurrentUser: assignCurrentUser
		};

		return service;

		function assignCurrentUser(user) {
			//localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });
			$rootScope.currentUser = user;
			return user;
		}
	}
})();
