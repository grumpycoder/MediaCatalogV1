(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            //$routeProvider.when(r.url, r.config);
            setRoute(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });

        function setRoute(url, definition) {
            // Sets resolvers for all of the routes
            // by extending any existing resolvers (or creating a new one).
            definition.resolve = angular.extend(definition.resolve || {}, {
                prime: prime
            });
            $routeProvider.when(url, definition);
            return $routeProvider;
        }
    }

    prime.$inject = ['datacontext'];
    function prime(dc) { return dc.prime(); }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/mediacatalog',
                config: {
                    title: 'mediacatalog',
                    templateUrl: 'app/media/mediacatalog.html',
                    controller: 'mediacatalog',
                    controllerAs: 'vm',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-book"></i> Catalog'
                    }
                }
            }, {
                url: '/media/:id',
                config: {
                    title: 'medai',
                    templateUrl: 'app/media/media.html',
                    controller: 'media',
                    controllerAs: 'vm',
                    settings: {}
                }
            }
        ];
    }
})();