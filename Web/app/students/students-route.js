(function () {

    'use struct';

    angular
        .module('cu.students')
        .run(appRun);


    appRun.$inject = ['routerHelperProvider'];

    function appRun(routerHelperProvider) {

        routerHelperProvider.configureStates(getStates());
    }

    function getStates() {

        return [
            {
                state: 'students',
                config: {
                    url: '/students',
                    controller: 'studentsController',
                    controllerAs: 'vm',
                    templateUrl: '/app/students/students.html'
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
