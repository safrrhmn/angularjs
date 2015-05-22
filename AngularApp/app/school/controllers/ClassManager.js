(function () {
	'use strict';

	angular
		.module('angularApp')
		.controller('ClassManager', ClassManager);

	/**
	 * @ngdoc controller
	 * @name angularApp.controller:ClassManager
	 * @description
	 *
	 */
	/* @ngInject */
	function ClassManager(classService, $stateParams, $state) {
		var vm = this;

		// PUBLIC PROPERTIES
		vm.class = {};

		// PUBLIC FUNCTIONS
		vm.update = update;
		vm.destroy = destroy;

		// init
		activate();

		//
		// PRIVATE FUNCTIONS

		function activate() {
			var classId = $stateParams.id;
			var classObj = classService.get({id: classId}, function () {
				vm.class = classObj;
			})
		}

		function update() {
			classService.update(vm.class);
		}

		function destroy() {
			classService.delete({id: vm.class.classId}, function () {
				vm.class = {};
				$state.go('main.school.home');
			})
		}
	}

})();
