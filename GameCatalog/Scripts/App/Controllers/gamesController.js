(function () {
    'use strict';

    var appModule = angular.module('myApp');

    appModule.controller('gamesController', ['$scope', '$location', 'gamesService', 'developersService', 'publishersService',
        function ($scope, $location, gamesService, developersService, publishersService) {
            $scope.devs = {};
            $scope.publishers = {};

            getPublishers();
            getDevs();

            function getPublishers() {
                publishersService.getPublishers()
                    .then(function (result) {
                        $scope.publishers = result;
                    })
            }

            function getDevs() {
                developersService.getDevelopers()
                    .then(function (result) {
                        $scope.devs = result;
                    })
            }

            $scope.newGame = function (game) {
                gamesService.addGame(game)
                    .then(function () {
                        alert('New game added successfully!!');
                        $location.path('/');
                    }, function () {
                        alert('Error while adding new game');
                    });
            }
        }
    ]);
})();