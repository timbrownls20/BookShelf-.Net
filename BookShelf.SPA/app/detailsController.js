(function () {
    'use strict';

    angular
        .module('app')
        .controller('detailsController', detailsController);

    function detailsController($scope, $http, $routeParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'detailsController';
        var id = $routeParams.id;
        var url = 'https://www.googleapis.com/books/v1/volumes/' + id;

        console.log(url);

        $http.get(url)
            .then(function (response) {
                $scope.book = response.data;
            });

    }
})();
