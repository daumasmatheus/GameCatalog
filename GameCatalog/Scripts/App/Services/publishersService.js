(function () {
    'use strict';

    var appModule = angular.module('myApp');

    appModule.factory('publishersService', ['$http', '$q',
        function ($http, $q) {
            var service = {};
            var api = '/api/publishers';

            service.getPublishers = function () {
                var deferred = $q.defer();
                $http.get(api)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject;
                    });
                return deferred.promise;
            }

            service.addPublisher = function (pub) {
                var deferred = $q.defer();
                $http.post(api, pub)
                    .then(function () {
                        deferred.resolve();
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            }

            service.removePublisher = function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/GamePublisher/DeletePublisher/',
                    method: 'DELETE',
                    params: { id: id }
                }).then(function () {
                    deferred.resolve();
                }, function (err) {
                    console.log(err);
                    deferred.reject();
                });
                return deferred.promise;
            }

            return service;
        }
    ])
})();