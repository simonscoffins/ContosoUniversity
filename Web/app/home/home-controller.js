(function() {

    'use strict';

    angular
        .module('cu.home')
        .controller('home', home);


    home.$inject = [];


    function home() {

        var vm = this;

        vm.title = 'Home Page';

        // initialize
        init();


        function init() {
        }
    }


})();