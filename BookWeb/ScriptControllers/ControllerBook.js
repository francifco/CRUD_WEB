
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

    
    $scope.getAllBooks = function () {

        $http({
            method: "get",
            url: "http://localhost:49550/Book/fetch_All_Book"
        }).then(function (response) {

            $scope.books = response.data;
        }, function () {
            alert("Error Occur");
        })
    }

 
    $scope.findClientByIdenty = function () {

        $http({
            method: "get",
            url: "http://localhost:49550/Client/find_client_By_Identy",
            datatype: "json",
            params: { idIdenti: $scope.inputClientIdenty }
        }).then(function (response) {

            $scope.labelClientName = response.data.clientName;
            $scope.labelClientId = response.data.id;
        })
    }


    $scope.selectBook = function (book) {
        $scope.labelBookName = book.bookName;
        $scope.labelBookId = book.id;
    }

    $scope.TakeBook = function (book) {

        var clientBook = {
            id_book : $scope.labelBookName,
            id_user : $scope.labelBookId
        }

        $http({
            method: "get",
            url: "http://localhost:49550/Book/Take_Book",
            datatype: "json",
            data: JSON.stringify(clientBook)
        }).then(function (response) {


            $scope.labelBookName = "";
            $scope.labelBookId = "";
            $scope.labelClientName = "";
            $scope.labelClientId = "";

            alert(response.data);

        }, function () {
            alert("Error Occur");
        })


    }

    $scope.goToBookIndex = function () {
        window.location.pathname = 'Book/index';
    }

    $scope.BookManagement = function () {
        window.location.pathname = 'Book/BookManagement';
    }

    $scope.ClientManagement = function () {
        window.location.pathname = 'Client/ClientManagement';
    }



  


})