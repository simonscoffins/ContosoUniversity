(function () {

    'use strict';

    angular
        .module('cu.courses')
        .controller('coursesController', coursesController);

    coursesController.$inject = [];


    function coursesController() {

        var vm = this;

        // scope data
        vm.title = 'Courses';

        // initialize
        init();

        function init() {
        }
    }

})();