(function () {

    'use struct';

    angular
        .module('cu.departments')
        .run(appRun);


    appRun.$inject = ['routerHelperProvider'];

    function appRun(routerHelperProvider) {

        routerHelperProvider.configureStates(getStates());
    }

    function getStates() {

        return [
            {
                state: 'departments',
                config: {
                    url: '/departments',
                    controller: 'departmentsController',
                    controllerAs: 'vm',
                    templateUrl: '/app/departments/departments.html'
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
