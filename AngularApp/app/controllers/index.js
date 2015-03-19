
(function () {
    'use strict';

    angular
      .module('angularApp')
      .controller('Index', Index);

    /**
      * @ngdoc controller
      * @name angularApp.controller:Index
      * @description
      *
      */
    /*@ngInject*/
    function Index($rootScope, $scope) {

	    $scope.user = $rootScope.currentUser;


    }
})();
