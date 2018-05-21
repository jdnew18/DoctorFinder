app.controller("patientsController", function ($scope, $http) {
    angular.element(document).ready(function () {
        $scope.title = "Patients Directory";

        $scope.getPatients();
    });

    $scope.getPatients = function () {
        $http({
            method: "GET",
            url: "/api/patient/GetAll"
        }).then(function (response) {
            $scope.patients = response.data;
        }, function (response) {
            console.log(response.data);
        });
    }
});