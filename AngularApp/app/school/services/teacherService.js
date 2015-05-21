(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('teacherService', teacherService);

	/**
	 * @ngdoc service
	 * @name angularApp.service:teacherService
	 * @description
	 *
	 */
	/* @ngInject */
	function teacherService($resource) {
		return $resource('/api/teachers/:id', {id: '@teacherId'});
	}

})();
