﻿(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)

        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions

        // 3rd Party Modules
        'ui.bootstrap',      // ui-bootstrap (ex: carousel, pagination, dialog)
        'breeze.angular',       // configures breeze for an angular app
        'breeze.directives',    // contains the breeze validation directive 
    ]);

    // Handle routing errors and success events
    app.run(['$route', function ($route) {
        // Include $route to kick start the router.
    }]);
})();