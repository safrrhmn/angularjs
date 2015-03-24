(function () {
	'use strict';

	angular
		.module('angularApp')
		.factory('flickrSerivce', flickrSerivce);

	/**
	 * @ngdoc service
	 * @name angularApp.service:flickrSerivce
	 * @description
	 *
	 */
	/*@ngInject*/
	function flickrSerivce($http, $q) {

		return {
			getFlickrImages: getFlickrImages,
		};


		/**
		 * Load images from flickr
		 * @returns {promise.<Object>}
		 */
		function getFlickrImages(tagname) {
			var deferred = $q.defer();

			$http.jsonp('https://api.flickr.com/services/feeds/photos_public.gne?tags=' + tagname + '&format=json&callback=jsonFlickrFeed');

			// hacky way of doing this. see https://github.com/angular/angular.js/issues/1551
			window.jsonFlickrFeed = function(data){
				deferred.resolve(data);
			};

			return deferred.promise;
		}
	}

})();
