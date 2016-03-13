(function () {

    'use struct';

    angular
        .module('cu.instructors')
        .run(appRun);


    appRun.$inject = ['routerHelperProvider'];

    function appRun(routerHelperProvider) {

        routerHelperProvider.configureStates(getStates());
    }

    function getStates() {

        return [
            {
                state: 'instructors',
                config: {
                    url: '/instructors',
                    controller: 'instructorsController',
                    controllerAs: 'vm',
                    templateUrl: '/app/instructors/instructors.html'
                }
            }

            //,

            //{
            //    state: 'creditUnions.detail',
            //    config: {
            //        url: '/:id',
            //        controller: '',
            //        controllerAs: 'vm',
            //        templateUrl: '/app/creditUnions/creditunions-detail.html',
            //        params: { selectedCu: null }
            //    }
            //}

        ];

    }

})();
