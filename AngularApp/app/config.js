(function () {
	'use strict';

	angular
		.module('angularApp')
		.constant('$config', {
			idsrvUrl: "https://localhost:44333/core/",
			connect: "connect/token"
	});

})();