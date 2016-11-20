(function () {
    'use strict';

    angular
        .module('app')
        .controller('Demo', demo);

    function demo() {
        var vm = this;
        vm.food = 'pizza';
    }

})();