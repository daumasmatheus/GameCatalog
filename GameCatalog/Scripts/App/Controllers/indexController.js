(function () {
    'use strict';

    var appModule = angular.module('myApp');

    appModule.controller('indexController', ['$scope', 'gamesService',
       function ($scope, gamesService) {
           $scope.games = [];
           
            getData();

            function getData() {
                gamesService.getGames()
                    .then(function (result) {
                        $scope.games = result;
                })
           }           

           $scope.removeGame = function (id) {
               gamesService.removeGame(id)
                   .then(function () {
                       alert('Game removed successfully!');
                       getData();
                   }, function (data) {
                       alert('Fail to remove the data');
                       console.log(data);
                    });
            }

       }
    ]);

    appModule.controller('editGameController', ['$scope', '$routeParams', '$location', 'gamesService', 'publishersService', 'developersService',
        function ($scope, $routeParams, $location, gamesService, publishersService, developersService) {
            $scope.game = {};
            $scope.devs = {};
            $scope.publishers = {};

            getPublishers();
            getDevs();

            gamesService.getGameById($routeParams.id)
                .then(function (result) {
                    $scope.game = result;
                }, function () {
                    alert('Error fetching the data');
                });

            $scope.editGame = function (game) {
                gamesService.editGame(game)
                    .then(function () {
                        alert('Game updated successfully!');
                        $location.path('/');
                    }, function () {
                        alert('Fail to update the data');
                    });
            }

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
        }
    ])
})();