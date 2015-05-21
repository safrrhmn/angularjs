(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('classService', classService);

	/**
	 * @ngdoc service
	 * @name angularApp.service:classService
	 * @description
	 *
	 */
	/* @ngInject */
	function classService($resource) {
		return $resource('/api/class/:id', { id: '@classId' });
	}

})();
