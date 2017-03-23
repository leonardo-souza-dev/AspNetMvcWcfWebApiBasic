(function () {

    var app = angular.module('testeLeonardoApp', []);

    app.controller('HomeController', function ($scope, $http) {

        var guid = "";
        var expiraEm = "";

        $scope.tokenGerado = false;

        $scope.guid = "XXXX-XX-XXXXXXX-XXXX-XXXX-XXXXX-XXXX";
        $scope.expiraEm = "1 minuto";

        $scope.gerarToken = function () {

            $http({
                method: 'GET',
                url: '/api/token'
            }).then(function successCallback(response) {

                var dt = new Date(response.data.expiraEm);
                var hr = dt.getHours();
                var mm = dt.getUTCMinutes();
                var ss = dt.getUTCSeconds();

                expiraEm = padZero(hr) + ":" + padZero(mm) + ":" + padZero(ss);

                $scope.expiraEm = expiraEm;

                guid = response.data.guid;
                
                $scope.guid = guid.toUpperCase();

                $('#tokenExpirado').addClass('ng-hide');
                $scope.tokenExpirado = false;

                $scope.tokenGerado = true;                

            }, function erroCallback(response) {
                console.log('Error');
                console.log(response);
            });
        }

        function padZero(element) {
            return element < 10 ? "0" + element : element;
        }

        $scope.buscarProdutosMVC = function () {

            if ($scope.tokenGerado == false) {
                alert('É necessário gerar um token!');
                return;
            }
                

            $('.produtos').remove();

            console.log(guid);
            console.log(expiraEm);

            $http({
                method: 'GET',
                url: '/api/produtos',
                params: { token: guid, expiraEm: expiraEm }
            }).then(function successCallback(response) {

                console.log('response.data == null');
                console.log(response.data == null);

                if (response.data == null) {
                    $scope.tokenExpirado = true;
                }

                $scope.produtosMVC = response.data;

                angular.forEach($scope.produtosMVC, function (value, key) {
                    value.preco = formataReal(value.preco);
                });

            }, function erroCallback(response) {
                console.log('Error');
                console.log(response);
            });
        }
    });
})();