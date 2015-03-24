(function () {
	'use strict';

	angular
		.module('angularApp')
		.controller('Pictures', Pictures);

	/**
	 * @ngdoc controller
	 * @name angularApp.controller:Pictures
	 * @description
	 *
	 */
	/*@ngInject*/
	function Pictures(flickrSerivce) {
		var vm = this;


		// PUBLIC PROPERTIES
		vm.title = 'Pictures';
		vm.searchval = '';
		vm.pics = [];


		// PUBLIC FUNCTIONS
		vm.loadimages = loadimages;

		// init
		activate();


		//
		// PRIVATE FUNCTIONS

		function activate() {
			loadimages();
		}

		function loadimages() {
            flickrSerivce.getFlickrImages(vm.searchval).then(function(data){
		        vm.pics = data.items;
	        });
		}

	}

})();
