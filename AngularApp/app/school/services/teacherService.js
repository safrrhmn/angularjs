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

		return{
			teacherResource: $resource('/api/teacher/:id', {id: '@teacherId'}),
			teacherClassResource: $resource('/api/teacherclass/:id/:classId', {id: '@teacherId', classId: '@classId' })
		}
	}

})();
