(function () {
    'use strict';

    angular
        .module('app')
        .controller('searchController', searchController);

    //searchController.$inject = ['$location']; 

    function searchController($scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'searchController';

        activate();

        function activate() { }

        $scope.searchTerm = "";
        $scope.debugMessage = "Hello World";

        $scope.search = function () {
            //alert(msg);
            alert($scope.searchTerm);
        };
    }
})();

//var ngApp = angular.module('myapp', []);

//ngApp.controller('searchController', function ($scope) {
//    $scope.debugMessage = "Hello World!";
//});
