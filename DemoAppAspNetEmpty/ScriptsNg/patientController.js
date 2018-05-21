app.controller("patientController", function ($scope, $http, $routeParams) {
    angular.element(document).ready(function () {
        $scope.title = "Patient";

        $scope.getPatient();
    });

    $scope.getPatient = function () {
        $http({
            method: "GET",
            url: "/api/patient/Get",
            params: { id: $routeParams.id }
        }).then(function (response) {
            $scope.patient = response.data;
        }, function (response) {
            console.log(response.data);
        });
    }
});