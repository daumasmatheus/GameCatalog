(function () {
    'use strict';

    var appModule = angular.module('myApp');   

    appModule.factory('gamesService', ['$http', '$q',
        function ($http, $q) {
            var service = {};
            var api = '/api/games/';

            service.getGames = function () {
                var deferred = $q.defer();
                $http.get(api)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject;
                    });
                return deferred.promise;
            }

            service.getGameById = function (id) {
                var deferred = $q.defer();
                $http.get(api + id)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            }

            service.addGame = function (game) {
                var deferred = $q.defer();
                $http.post(api, game)
                    .then(function () {
                        deferred.resolve();
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            }            

            service.removeGame = function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/Game/DeleteGame/',
                    method: 'DELETE',
                    params: { id: id }
                }).then(function success () {
                    deferred.resolve();
                }, function error (data) {
                    console.log(data);
                    deferred.reject();
                });
                return deferred.promise;
            };
            
            service.editGame = function (game) {
                var deferred = $q.defer();
                $http.put('/api/games/edit/', game)
                    .then(function () {
                        deferred.resolve();
                    }, function (data) {
                        console.log(data);
                        deferred.reject();
                    });
                return deferred.promise;
            }

            return service;
        }
    ]);
})();