app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/ViewsNg/doctors.html",
            controller: "doctorsController"
        })
        .when("/index.html", {
            templateUrl: "/ViewsNg/doctors.html",
            controller: "doctorsController"
        })
        .when("/index.html/home", {
            templateUrl: "/ViewsNg/doctors.html",
            controller: "doctorsController"
        })
        .when("/index.html/doctors", {
            templateUrl: "/ViewsNg/doctors.html",
            controller: "doctorsController"
        })
        .when("/index.html/doctor/:id", {
            templateUrl: "/ViewsNg/doctor.html",
            controller: "doctorController"
        })
        .when("/index.html/patients", {
            templateUrl: "/ViewsNg/patients.html",
            controller: "patientsController"
        })
        .when("/index.html/patient/:id", {
            templateUrl: "/ViewsNg/patient.html",
            controller: "patientController"
        })
        .otherwise({ redirectTo: '/index.html/doctors' });
}]);