(function(){
    'use strict';

    angular
        .module('angularApp')
        .config(routeConfig);

	/*@ngInject*/
    function routeConfig($stateProvider){
        $stateProvider
            .state('school', {
                url: '/school',
								abstract: true,
                views: {
                    '': {
                        templateUrl: '',
                        controller: '',
                        controllerAs: ''
                    }
                }
            });

    }

})();
