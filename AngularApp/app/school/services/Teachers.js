(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('Teachers', Teachers);

	/**
	 * @ngdoc service
	 * @name angularApp.service:Teachers
	 * @description
	 *
	 */
	/* @ngInject */
	function Teachers($resource) {
		return $resource('/api/teachers/:id', {id: '@teacherId'});
	}

})();
