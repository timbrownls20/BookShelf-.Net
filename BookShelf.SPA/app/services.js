(function () {
    'use strict';


    var BookService = angular.module('BookService', [])
    .service('bookService', ['$http', function ($http) {

        this.search = function(searchTerm, startIndex) {

            var url = 'https://www.googleapis.com/books/v1/volumes?maxResults=12&q=' + searchTerm + '&startIndex=' + startIndex;
            console.log(url);
            return $http.get(url);
        }

        this.get = function(id)        {
            var url = 'https://www.googleapis.com/books/v1/volumes/' + id;
            console.log(url);
            return $http.get(url);
        }

    }]);
})();


