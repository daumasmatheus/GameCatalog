(function () {
    'use strict';

    var appModule = angular.module('myApp');

    appModule.controller('publishersController', ['$scope', '$location', 'publishersService',
        function ($scope, $location, publishersService) {
            $scope.pubs = {};

            getPubs();

            function getPubs() {
                publishersService.getPublishers()
                    .then(function (result) {
                        $scope.pubs = result;
                    });
            }

            $scope.newPublisher = function (pub) {
                publishersService.addPublisher(pub)
                    .then(function () {
                        alert('New publisher added successfully!!');
                        $location.path('/Publishers');
                    }, function () {
                        alert('Error while adding new publisher');
                    });
            };

            $scope.removePublisher = function (id) {
                publishersService.removePublisher(id)
                    .then(function () {
                        alert('Publisher register removed successfully!');
                        getPubs();
                    }, function (err) {
                        alert('Fail to remove the data');
                        console(err);
                    });
            }
        }
    ]);
})();