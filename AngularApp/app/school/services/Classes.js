(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('Classes', Classes);

	/**
	 * @ngdoc service
	 * @name angularApp.service:Classes
	 * @description
	 *
	 */
	/* @ngInject */
	function Classes($resource) {

		return $resource('/api/classes/:id', { id: '@classId' });
	}

})();
