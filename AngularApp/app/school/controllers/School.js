(function () {
	'use strict';

	angular
		.module('angularApp')
		.controller('School', School);

	/**
	 * @ngdoc controller
	 * @name angularApp.controller:School
	 * @description
	 *
	 */
	/* @ngInject */
	function School() {
		var vm = this;


		// PUBLIC PROPERTIES
		vm.title = 'School';

		// PUBLIC FUNCTIONS
		vm.doSomething = doSomething;

		// init
		activate();

		//
		// PRIVATE FUNCTIONS

		function activate() { }

		function doSomething() { }

	}

})();