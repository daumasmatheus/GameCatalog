(function () {
    'use strict';

    var appModule = angular.module('myApp');

    appModule.controller('developersController', ['$scope', '$location','developersService',
        function ($scope, $location, developersService) {
            $scope.devs = {};

            getDevs();

            function getDevs() {
                developersService.getDevelopers()
                    .then(function (result) {
                        $scope.devs = result;
                    });
            }

            $scope.newDeveloper = function (dev) {
                developersService.addDeveloper(dev)
                    .then(function () {
                        alert('New developer added successfully!!');
                        $location.path('/Developers');
                    }, function () {
                        alert('Error while adding new developer');
                    });
            }

            $scope.removeDev = function (id) {
                developersService.removeDev(id)
                    .then(function () {
                        alert('Developer register removed successfully!');
                        getDevs();
                    }, function (data) {
                        alert('Fail to remove the data');
                        console.log(data);
                    });
            }
        }
    ]);
})();