(function() {

    'use strict';

    angular
        .module('cu.home')
        .controller('home', home);


    home.$inject = [];


    function home() {

        var vm = this;

        vm.title = 'Home Page';
        vm.test = '';


        // initialize
        init();


        function init() {
            vm.test = 'BLAH BLAH';
        }
    }


})();