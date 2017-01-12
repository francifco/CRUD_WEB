var app = angular.module("myAppClient", []);

app.controller("myCtrlClient", function ($scope, $http) {
    debugger;

    $scope.addClient = function () {

        var client = {
            clientName: $scope.inputName,
            idIdenti: $scope.inputIdenty
        }

        $http({
            method: "post",
            url: "http://localhost:49550/Client/Add_New_Client",
            datatype: "json",
            data: JSON.stringify(client)
        }).then(function (response) {
            $scope.clearAllInput();
            alert(response.data);
        })

    }


    $scope.clearAllInput = function () {
        $scope.inputName = "";
        $scope.inputIdenty = "";
    }


    $scope.goToBookIndex = function () {
        window.location.pathname = 'Book/index';
    }

})