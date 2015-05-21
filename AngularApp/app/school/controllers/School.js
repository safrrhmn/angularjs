(function () {
	'use strict';

	angular
		.module('angularApp')
		.controller('School', School)
		.controller('AddClassModal', AddClassModal)
		.controller('AddTeacherModal', AddTeacherModal);

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
		vm.teachers = [];

		// PUBLIC FUNCTIONS
		vm.addClass = addClass;
		vm.showClass = showClass;
		vm.addTeacher = addTeacher;

		// init
		activate();

		//
		// PRIVATE FUNCTIONS

		function activate() {
			var classes = classService.query(function () {
				vm.classes = classes;
			});

			var teachers = teacherService.teacherResource.query(function(){
				vm.teachers = teachers;
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

		function addTeacher(){
			var modal = $modal.open({
				templateUrl: 'app/school/views/addTeacherModal.html',
				controller: AddTeacherModal,
				controllerAs: 'vm',
				size: 'lg'
			});

			modal.result.then(function (result) {
				vm.teachers.push(result.newTeacher);
			});
		}
	}

	/*@ngInject*/
	function AddClassModal($modalInstance, classService) {
		var vm = this;

		vm.class = {};

		vm.submit = function () {
			var newClassId = classService.save(vm.class, function () {
				vm.class.classId = newClassId;
				$modalInstance.close({newClass: vm.class});
			});
		}
	}

	/*@ngInject*/
	function AddTeacherModal($modalInstance, teacherService) {
		var vm = this;

		vm.opened = false;
		vm.teacher = {};

		vm.open = function($event){
			$event.preventDefault();
			$event.stopPropagation();

			vm.opened = true;
		};

		vm.submit = function () {
			var newTeacherId = teacherService.teacherResource.save(vm.teacher, function () {
				vm.teacher.teacherId = newTeacherId;
				$modalInstance.close({newTeacher: vm.teacher});
			});
		}
	}

})();