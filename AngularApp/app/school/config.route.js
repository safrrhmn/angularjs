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
						templateUrl: viewsPath + 'index.html'
					}
				}
			})
			.state('main.school.home', {
				views: {
					'classes': {
						templateUrl: viewsPath + 'classes.html'
					},
					'students': {
						templateUrl: viewsPath + 'students.html'
					}
				}
			});
		//.state('school.home', {
		//	url: 'home',
		//	views: {
		//		'': {
		//			templateUrl: '',
		//			controller: '',
		//			controllerAs: ''
		//		}
		//	}
		//})
		//.state('school.home', {
		//	url: 'home',
		//	views: {
		//		'': {
		//			templateUrl: '',
		//			controller: '',
		//			controllerAs: ''
		//		}
		//	}
		//});

	}

})();
