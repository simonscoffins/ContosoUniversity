(function () {

    'use struct';

    angular
        .module('cu.courses')
        .run(appRun);


    appRun.$inject = ['routerHelperProvider'];

    function appRun(routerHelperProvider) {

        routerHelperProvider.configureStates(getStates());
    }

    function getStates() {

        return [
            {
                state: 'courses',
                config: {
                    url: '/courses',
                    controller: 'coursesController',
                    controllerAs: 'vm',
                    templateUrl: '/app/courses/courses.html'
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
