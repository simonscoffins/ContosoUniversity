(function () {

    'use strict';

    angular
        .module('cu.departments')
        .controller('departmentsController', departmentsController);

    departmentsController.$inject = [];


    function departmentsController() {

        var vm = this;

        // scope data
        vm.title = 'Departments';

        // initialize
        init();

        function init() {
        }
    }

})();