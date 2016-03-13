(function () {

    'use strict';

    angular
        .module('cu.students')
        .controller('studentsController', studentsController);

    studentsController.$inject = [];


    function studentsController() {

        var vm = this;

        // scope data
        vm.title = 'Students';

        // initialize
        init();

        function init() {
        }
    }

})();