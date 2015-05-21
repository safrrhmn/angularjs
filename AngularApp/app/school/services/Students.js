(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('Students', Students);

	/**
	 * @ngdoc service
	 * @name angularApp.service:Students
	 * @description
	 *
	 */
	/* @ngInject */
	function Students($resource) {
		return $resource('/api/students/:id', {id: '@studentId'});
	}

})();
