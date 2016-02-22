(function() {

    'use strict';

    angular.module('cu.core', [
        /*
         * Angular modules
         */
        'ngAnimate',
        //'ngRoute',
        //'ui.router',
        'ngSanitize',

        /*
         * Our reusable cross app code modules
         */
        //'blocks.exception', 'blocks.logger', 'blocks.router',
        'blocks'

        /*
         * 3rd Party modules
         */
        //'ngplus'
    ]);

    //.config(['$locationProvider', '$stateProvider', '$urlRouterProvider', '$routeProvider',
    //    function ($locationProvider, $stateProvider, $urlRouterProvider, $routeProvider) {

    //.config(['$locationProvider', function ($locationProvider) {

    //$stateProvider

        //// Home
        //.state('home', {
        //    url: '/home',
        //    controller: 'home',
        //    controllerAs: 'vm',
        //    templateUrl: '/app/home/home.html'
        //})

        //// About
        //.state('about', {
        //    url: '/about',
        //    controller: 'about',
        //    controllerAs: 'vm',
        //    templateUrl: '/app/about/about.html'
        //});

//            $locationProvider.html5Mode(true);

            //$routeProvider
            //    .when('/home', {
            //        controller: 'home',
            //        controllerAs: 'vm',
            //        templateUrl: '/app/home/home.html'
            //    })
            //    .when('/about', {
            //        controller: 'about',
            //        controllerAs: 'vm',
            //        templateUrl: '/app/about/about.html'
            //    })

            //.otherwise({redirectTo: '/home'});

            //$urlRouterProvider.otherwise('/home');
            //$locationProvider.html5Mode(true);
            //$locationProvider.hashPrefix('!');
 //       }]);


})();