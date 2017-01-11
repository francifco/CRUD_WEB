
var app = angular.module("myAppBook", []);

app.controller("myCtrlBook", function ($scope, $http) {
    debugger;

    $scope.addBook = function () {

            var book = {
                bookName: $scope.inputName,
                tittle: $scope.inputTittle,
                edition: $scope.inputEdition,
                quality: $scope.inputQuality
            }

            $http({
                method: "post",
                url: "http://localhost:49550/Book/Add_New_Book",
                datatype: "json",
                data: JSON.stringify(book)
            }).then(function (response) {

                $scope.clearAllInput();

                alert(response.data);
            })
        

    }

    $scope.clearAllInput = function () {
        $scope.inputName = "";
        $scope.inputTittle = "";
        $scope.inputEdition = "";
        $scope.inputQuality = "";
    }

  


})