(function() {

    'use struct';

    angular
        .module('cu.about')
        .run(appRun);


    appRun.$inject = ['routerHelperProvider'];

    function appRun(routerHelperProvider) {

        routerHelperProvider.configureStates(getStates());
    }

    function getStates() {

        return [
        {
            state: 'about',
            config: {
                url: '/about',
                controller: 'about',
                controllerAs: 'vm',
                templateUrl: '/app/about/about.html'
                }
            }
        ];

    }

})();
