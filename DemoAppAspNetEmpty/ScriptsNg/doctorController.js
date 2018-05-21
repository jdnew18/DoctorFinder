app.controller("doctorController", function ($scope, $http, $routeParams) {
    angular.element(document).ready(function () {
        $scope.title = "Doctor";

        $scope.getDoctor();
    });

    $scope.getDoctor = function () {
        $http({
            method: "GET",
            url: "/api/doctor/Get",
            params: { id: $routeParams.id }
        }).then(function (response) {
            $scope.doctor = response.data;
        }, function (response) {
            console.log(response.data);
        });
    }
});