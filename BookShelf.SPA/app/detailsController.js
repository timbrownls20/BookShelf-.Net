(function () {
    'use strict';

    angular
        .module('app')
        .controller('detailsController', detailsController);

    function detailsController($scope, $routeParams, bookService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'detailsController';
        var id = $routeParams.id;
        
        bookService.get(id)
            .then(function (response) {
                $scope.book = response.data;
            });

    }
})();
