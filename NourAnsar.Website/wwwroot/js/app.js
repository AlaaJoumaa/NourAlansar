var app = angular.module('app', ["kendo.directives", "ngMaterial"])
    .controller('appController', ['$scope', '$timeout',
        function ($scope, $timeout) {

        }
    ]);
//app.config(function ($mdIconProvider) {
//    //$mdIconProvider.iconSet('communication', 'img/icons/sets/communication-icons.svg', 24);
//});

app.directive('enterClick', function () {

    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {

            if (event.which === 13) {

                scope.$apply(function () {
                    scope.$eval(attrs.enterClick);
                });
                event.preventDefault();
            }
        });
    };
});