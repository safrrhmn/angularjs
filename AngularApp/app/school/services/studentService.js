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
		return {
			studentResource: $resource('/api/student/:id', {id: '@studentId'}),
			studentClassResource: $resource('/api/studentclass/:id/:classId', {id: '@studentId', classId: '@classId'})
		}
	}

})();
