(function() {

    'use strict';

    angular
        .module('cu.about')
        .controller('about', about);


    about.$inject = [];


    function about() {
        var vm = this;

        vm.title = 'About';

        // initialize
        init();

        function init() {
        }
    }

})();