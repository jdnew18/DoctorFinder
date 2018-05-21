app.controller("doctorsController", function ($scope, $http) {
    angular.element(document).ready(function () {
        $scope.title = "Doctors Directory";

        $scope.get();
    });

    $scope.get = function () {
        $http({
            method: "GET",
            url: "/api/doctor/GetAll"
        }).then(function (response) {
            $scope.doctors = response.data;
        }, function (response) {
            console.log(response.data);
        });
    }
});