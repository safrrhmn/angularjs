(function () {
	'use strict';

	angular
		.module('angularApp')
		.config(routeConfig);

	/*@ngInject*/
	function routeConfig($stateProvider) {
		var viewsPath = 'app/school/views/';

		$stateProvider
			.state('main.school', {
				url: 'school',
				abstract: true,
				views: {
					'content@': {
						templateUrl: viewsPath + 'index.html',
						controller: 'School',
						controllerAs: 'school'
					}
				}
			})
			.state('main.school.home', {
				//views: {
				//	'classdetail': {
				//		templateUrl: viewsPath + 'students.html'
				//	}
				//}
			})
			.state('main.school.class', {
				url:'/class/:id',
				views: {
					'classdetail': {
						templateUrl: viewsPath + 'class.html',
						controller: 'ClassManager',
						controllerAs: 'classmgr'
					}
				}
			})

	}

})();
