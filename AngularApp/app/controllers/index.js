
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
    function Index($rootScope) {
    	var vm = this;

    	vm.currentUser = $rootScope.currentUser;
    }
})();
