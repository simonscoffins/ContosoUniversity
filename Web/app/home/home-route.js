(function() {

    'use struct';

    angular
        .module('cu.home')
        .run(appRun);


    appRun.$inject = ['routerHelperProvider'];

    function appRun(routerHelperProvider) {

        routerHelperProvider.configureStates(getStates(), '/home');
    }

    function getStates() {

        return [
        {
            state: 'home',
            config: {
                url: '/home',
                controller: 'home',
                controllerAs: 'vm',
                templateUrl: '/app/home/home.html'
                }
            }
        ];

    }

})();
