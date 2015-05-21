(function(){
	'use strict';

	angular
		.module('angularApp')
		.config(resourceConfig);

	/*@ngInject*/
	function resourceConfig ($resourceProvider) {
		$resourceProvider.defaults.actions.update = { method: 'PUT' };
	}
})();