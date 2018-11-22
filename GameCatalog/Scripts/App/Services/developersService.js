(function () {
    'use strict';

    var appModule = angular.module('myApp');

    appModule.factory('developersService', ['$http', '$q',
        function ($http, $q) {
            var service = {};
            var api = '/api/developers';

            service.getDevelopers = function () {
                var deferred = $q.defer();
                $http.get(api)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject;
                    });
                return deferred.promise;
            };

            service.addDeveloper = function (dev) {
                var deferred = $q.defer();
                $http.post(api, dev)
                    .then(function () {
                        deferred.resolve();
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            }

            service.removeDev = function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/Developers/DeleteDeveloper/',
                    method: 'DELETE',
                    params: { id: id }
                }).then(function success () {
                    deferred.resolve();
                }, function error (err) {
                    console.log(err);
                    deferred.reject();
                });

                return deferred.promise;
            }

            return service;
        }
    ]);
})();