app.controller("PrimeController", ["$scope", "$http", function ($scope, $http) {
    $scope.numPrimes = 0;

    $scope.getPrimesButton = function() {
        $http({ method: "POST", url: "/Home/GetPrimes?count=" + $scope.numPrimes })
            .success(function(data) {
                $scope.primeColumns = data;
            });
    };
}]);