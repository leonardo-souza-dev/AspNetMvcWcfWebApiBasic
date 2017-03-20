
(function () {
    
    var app = angular.module('testeLeonardoApp', ['ngRoute']);

    app.controller('HomeController', function ($scope) {
        $scope.Mensagem = "Foo";
    });
})();