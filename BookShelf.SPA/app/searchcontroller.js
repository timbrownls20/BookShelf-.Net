(function () {
    'use strict';

    angular
        .module('app')
        .controller('searchController', searchController);

    function searchController($scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'searchController';
        var page = 1;
        
        $scope.search = function () {
            $scope.searchResults = null;
            getResults();
        };

        $scope.loadMore = function () {
            getResults();
        }

        function getResults()        {
            var url = 'https://www.googleapis.com/books/v1/volumes?maxResults=12&q=' + $scope.searchTerm + '&startIndex=' + getStartIndex();

            console.log(url);

            page += 1;
            $http.get(url)
                .then(function (response) {

                    if ($scope.searchResults) {
                        for (var i = 0; i < response.data.items.length; i++) {
                            $scope.searchResults.items.push(response.data.items[i]);
                        }
                    }
                    else {
                        $scope.searchResults = response.data;
                    }
                });
        }

        function getStartIndex() {
            return (page - 1) * 12
        }
    }
})();

