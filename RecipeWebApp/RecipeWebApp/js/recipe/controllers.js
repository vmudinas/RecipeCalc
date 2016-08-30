/* global angular */
(function () {
    "use strict";

    var app = angular.module("recipeApp.controllers", []);

    app.controller("recipeCtrl", ["$scope", "$http",
        function ($scope, $http) {

            init();

            $scope.calculateRecipe = function () {

                $scope.recipeTotals = [];
                $http.post('/GetTotal/', $scope.recipes)
                         .success(function (response) {
                             console.log(response);
                        $scope.recipeTotals = response.Recipies;
                    });
             

            };

            $scope.testFunction = function () {
                return true;
            };

            function init() {
                $http.get("/GetAllRecipies")
             .success(function (data, status) {
                 console.log(data);
                 $scope.recipes = data;
            
             })
             .error(function () {
                 console.log("Recipe Api call error");
             });
            };
        }
    ]);
})();

