(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('studentService', studentService);

	/**
	 * @ngdoc service
	 * @name angularApp.service:studentService
	 * @description
	 *
	 */
	/* @ngInject */
	function studentService($resource) {
		return $resource('/api/students/:id', {id: '@studentId'});
	}

})();
