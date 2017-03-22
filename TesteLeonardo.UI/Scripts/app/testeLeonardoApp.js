(function () {

    var app = angular.module('testeLeonardoApp', []);

    app.controller('HomeController', function ($scope, $http) {

        var guid = "";

        $scope.guid = "XXXX-XX-XXXXXXX-XXXX-XXXX-XXXXX-XXXX";
        $scope.expiraEm = "1 minuto";

        $scope.gerarToken = function () {

            $http({
                method: 'GET',
                url: '/api/token'
            }).then(function successCallback(response) {

                var dt = new Date(response.data.expiraEm);
                var hr = dt.getUTCHours();
                var mm = dt.getUTCMinutes();
                var ss = dt.getUTCSeconds();
                var expiraEm = padZero(hr) + ":" + padZero(mm) + ":" + padZero(ss);

                $scope.expiraEm = expiraEm;
                guid = response.data.guid.toUpperCase();
                
                $scope.guid = guid;

            }, function erroCallback(response) {
                console.log('Error');
                console.log(response);
            });
        }

        function padZero(element) {
            return element < 10 ? "0" + element : element;
        }

        $scope.buscarProdutosMVC = function () {

            $('.produtos').remove();

            $http({
                method: 'GET',
                url: '/api/produtos',
                params: { token: guid }
            }).then(function successCallback(response) {

                $scope.produtosMVC = response.data;

            }, function erroCallback(response) {
                console.log('Error');
                console.log(response);
            });
        }
    });
})();