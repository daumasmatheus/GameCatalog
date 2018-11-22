(function () {
    'use strict';

    var appModule = angular.module('myApp', ['ngRoute', 'ngResource']);

    appModule.config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/', {
                    controller: 'indexController',
                    templateUrl: 'Scripts/App/Templates/index.html'
                })
                .when('/addGame', {
                    controller: 'gamesController',
                    templateUrl: 'Scripts/App/Templates/add.html'
                })
                .when('/edit-game/:id', {
                    controller: 'editGameController',
                    templateUrl: 'Scripts/App/Templates/editGame.html'
                })
                .when('/Developers', {
                    controller: 'developersController',
                    templateUrl: 'Scripts/App/Templates/developers.html'
                })
                .when('/addDeveloper', {
                    controller: 'developersController',
                    templateUrl: 'Scripts/App/Templates/add-developer.html'
                })
                .when('/Publishers', {
                    controller: 'publishersController',
                    templateUrl: 'Scripts/App/Templates/publishers.html'
                })
                .when('/addPublisher', {
                    controller: 'publishersController',
                    templateUrl: 'Scripts/App/Templates/add-publisher.html'
                })
                .otherwise({
                    redirectTo: '/'
                });
        }]);
})();