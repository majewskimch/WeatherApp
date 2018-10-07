angular.module('WeatherController', [])
    .controller('WeatherCtrl', ['$scope', '$http', function ($scope, $http) {

        $scope.locations = [];
        $scope.search = {};
        $scope.show = { error: false };

        $scope.states = {
            showAddingForm: false
        };

        $scope.showAddingForm = function (value) {
            $scope.states.showAddingForm = value;
            $scope.search = {};
        };

        $scope.showErrorMessage = function (value) {
            $scope.show.error = value;
        };

        $scope.addCity = function () {
            $http({
                method: 'GET',
                url: 'api/weather/' + $scope.search.City + '/' + $scope.search.Country,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                var result = response.data;

            if (result.city != null)
            {
                $scope.locations.push({ city: result.city, country: result.country, temperature: result.temperature, humidity: result.humidity });
            }
            else
            {
                $scope.showErrorMessage(true);
            }

            $scope.showAddingForm(false);
        });
        }
    }]);