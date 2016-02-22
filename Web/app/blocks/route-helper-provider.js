(function() {

    'use strict';

    angular
        .module('blocks')
        .provider('routerHelperProvider', routerHelperProvider);


    routerHelperProvider.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider'];


    function routerHelperProvider($locationProvider, $stateProvider, $urlRouterProvider) {

        this.$get = routerHelper;

        $locationProvider.html5Mode(true);

        routerHelper.$inject = ['$state'];
        /* @ngInject */
        function routerHelper($state) {
            var hasOtherwise = false;

            var service = {
                configureStates: configureStates,
                getStates: getStates
            };

            return service;

            ///////////////

            function configureStates(states, otherwisePath) {
                states.forEach(function (state) {
                    $stateProvider.state(state.state, state.config);
                });
                if (otherwisePath && !hasOtherwise) {
                    hasOtherwise = true;
                    $urlRouterProvider.otherwise(otherwisePath);
                }
            }

            function getStates() { return $state.get(); }

        }

    }


})();


