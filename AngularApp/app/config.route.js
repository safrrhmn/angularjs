(function() {
  'use strict';

  angular
    .module('angularApp')
    .config(routeConfig);

  /*@ngInject*/
  function routeConfig($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/home");

    $stateProvider
      .state('main', {
        url: '/',
        abstract: true,
        views: {
          'navbar@': {
            templateUrl: 'app/views/partials/navbar.html'
          },
          'footer@': {
            templateUrl: 'app/views/partials/footer.html'
          }
        }
      })
      .state('main.home', {
        url: 'home',
				views: {
					'@': {
						templateUrl: "app/views/index.html",
						controller: 'Index',
						controllerAs: 'main'
					}
				}

      })
      .state('main.pictures', {
        url: 'pictures',
				views: {
					'@': {
						templateUrl: 'app/views/pictures.html',
						controller: 'Pictures',
						controllerAs: 'vm'
					}
				}
      })
  }
})();
