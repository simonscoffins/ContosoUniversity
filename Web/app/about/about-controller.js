(function() {

    'use strict';

    angular
        .module('cu.about')
        .controller('about', about);


    about.$inject = [];


    function about() {
        var vm = this;

        vm.title = 'About Page';
        vm.test = '';


        // initialize
        init();

        function init() {
            vm.test = 'Check This';
        }
    }

})();