app.controller('projectController', ['$scope', 'ProjectService', '$timeout', '$interval',  
    function ($scope, $projectService, $timeout, $interval) {

        $scope.projects = [];
        $scope.contentProgress = true;
        $scope.search = "";

        $scope.createImage = (index) => {

            var img = new Image();
            img.setAttribute('alt', $scope.projects[index].title);
            img.setAttribute('src', (document.baseURI + "/images/" + $scope.projects[index].img));
            img.setAttribute('class', 'card-image');
            $('.card-image-' + $scope.projects[index].id).each(function (item) { $(this).replaceWith(img); });
        };

        $scope.renderProjects = () => {

            for (var i = 0; i < $scope.projects.length; i++) { $scope.createImage(i); }
            $('.card-title').each(function (item) { $(this).removeClass('loading'); });
        };

        $scope.searchProject = () => {

            $scope.contentProgress = true;
            $projectService.searchProjects($scope.search,0, 10, function (data) {

                $scope.projects = data.Data.result;
                $scope.contentProgress = false;
            });
            var handler = $interval(() => {

                if ($scope.contentProgress == false) {
                    $scope.renderProjects();
                    $interval.cancel(handler);
                }
            }, 100);
        };

        $timeout(() => {
            
            $projectService.getProjects(0, 10, function (data) {

                $scope.projects = data.Data.result;                
                $scope.contentProgress = false;
            });
            var handler = $interval(() => {

                if ($scope.contentProgress == false) {
                    $scope.renderProjects();
                    $interval.cancel(handler);
                }
            }, 100);
        });
    }
]);

app.factory('projFactory', function ($http) {

    return {
        getData: function (url,data) {

            return $http({
                method: 'GET',
                url: url,
                data: data
            });
        },
        postData: function (url,data) {

            return $http({
                method: 'POST',
                url: url,
                data: data
            });
        }
    };
});

app.service("ProjectService", ['projFactory', function ($projFactory) {

    this.getProjects = function (from, to, cb) {

        var data = $projFactory
            .getData("/Dashboard/GetProjects?from=" + from + "&to=" + to)
            .then((result) => {
                if (cb != null && typeof (cb) == "function") {
                    cb(result.data);
                }
            })
            .catch((error) => {
                
            });
    };

    this.saveProject = function (data, cb) {

        
    };

    this.searchProjects = function (search, from, to, cb) {

        var data = $projFactory
            .getData(`/Dashboard/GetSearchProjects?search=${search}&from=${from}&to=${to}`)
            .then((result) => {
                if (cb != null && typeof (cb) == "function") {
                    cb(result.data);
                }
            })
            .catch((error) => {

            });
    };

    this.deleteProject = function (data, cb) {

        
    };

}]);

//app.controller('projectsLstCtrl', function ($scope) {

//    var imagePath = 'images/logo.png';

//    $scope.itemClk = function () {
//        console.log("clicked");
//    };

//    $scope.todos = [
//        {
//            face: imagePath,
//            what: 'Brunch this weekend?',
//            who: 'Min Li Chan',
//            when: '3:08PM',
//            notes: " I'll be in your neighborhood doing errands"
//        },
//        {
//            face: imagePath,
//            what: 'Brunch this weekend?',
//            who: 'Min Li Chan',
//            when: '3:08PM',
//            notes: " I'll be in your neighborhood doing errands"
//        },
//        {
//            face: imagePath,
//            what: 'Brunch this weekend?',
//            who: 'Min Li Chan',
//            when: '3:08PM',
//            notes: " I'll be in your neighborhood doing errands"
//        },
//        {
//            face: imagePath,
//            what: 'Brunch this weekend?',
//            who: 'Min Li Chan',
//            when: '3:08PM',
//            notes: " I'll be in your neighborhood doing errands"
//        },
//        {
//            face: imagePath,
//            what: 'Brunch this weekend?',
//            who: 'Min Li Chan',
//            when: '3:08PM',
//            notes: " I'll be in your neighborhood doing errands"
//        }
//    ];
//});
