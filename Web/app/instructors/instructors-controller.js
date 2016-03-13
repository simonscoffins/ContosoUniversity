(function () {

    'use strict';

    angular
        .module('cu.instructors')
        .controller('instructorsController', instructorsController);

    instructorsController.$inject = [];


    function instructorsController() {

        var vm = this;

        // scope data
        vm.title = 'Instructors';

        // initialize
        init();

        function init() {
        }
    }

})();