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
            $scope.averageRating = $scope.calculateAverageRating($scope.doctor.DoctorRatings);
        }, function (response) {
            console.log(response.data);
            });

        $scope.calculateAverageRating = function (data) {
            var sum = 0;
            for (var i = 0; i < data.length; i++) {
                sum += parseInt(data[i].Rating);
            }

            var avg = sum / data.length;

            return avg;
        };
    }
});