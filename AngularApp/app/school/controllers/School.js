(function () {
	'use strict';

	angular
		.module('angularApp')
		.controller('School', School)
		.controller('AddClassModal', AddClassModal);

	/**
	 * @ngdoc controller
	 * @name angularApp.controller:School
	 * @description
	 *
	 */
	/* @ngInject */
	function School(classService, studentService, teacherService, $modal, $state) {
		var vm = this;

		// PUBLIC PROPERTIES
		vm.title = 'School';
		vm.classes = [];

		// PUBLIC FUNCTIONS
		vm.addClass = addClass;
		vm.showClass = showClass;

		// init
		activate();

		//
		// PRIVATE FUNCTIONS

		function activate() {
			var classes = classService.query(function () {
				vm.classes = classes;
			});
		}

		function showClass(classObj) {
			$state.go('main.school.class', {id: classObj.classId});
		}

		function addClass() {
			var modal = $modal.open({
				templateUrl: 'app/school/views/addClassModal.html',
				controller: AddClassModal,
				controllerAs: 'vm',
				size: 'lg'
			});

			modal.result.then(function (result) {
				vm.classes.push(result.newClass);
			});
		}

	}

	/*@ngInject*/
	function AddClassModal($modalInstance, classService) {
		var vm = this;

		vm.className = '';
		vm.classDescription = '';

		vm.submitClass = function () {
			var classObj = {
				name: vm.className,
				description: vm.classDescription
			};

			var newClass = classService.save(classObj, function () {
				$modalInstance.close({newClass: newClass});
			});
		}
	}

})();