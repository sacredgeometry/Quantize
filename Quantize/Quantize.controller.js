angular.module("umbraco").controller("Quantize.controller", function ($scope, umbRequestHelper, $log, $http, QuantizeResource, editorState) {

    if (!$scope.model.value) { 
        $scope.model.value = {
            presets: [],
            selectedPreset: {}
        }
    }

    //debugger
    // $scope.model.config
    //editorState.current.tabs
    // NOTE: I DONT NEED TO DO ANY OF THIS NONSENSE
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })) // gets flattened list of properties on content
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.editor == "Umbraco.Grid"}) // Gets all grid properties
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias == "content"})[0].value // Get property by alias
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias == "content"})[0].value // Get property by alias and then get value

    QuantizeResource.getPresets().then((data) => {
        $scope.model.value.presets = data;
    });

    $scope.addPreset = () => {

        var value = angular.copy([].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias === "content" })[0].value);

        if ($scope.presetName && value) {
            QuantizeResource.addPresets($scope.presetName, JSON.stringify(value)).then((data) => {
                
                if (data) {
                    $scope.model.value.presets.push(data);
                    $scope.presetName = null;
                    $scope.model.value.selectedPreset = $scope.model.value.presets[$scope.model.value.presets.length - 1]
                }                
            });
           
        }
        else {
            // Throw notification about name requirement
        }
    }

    $scope.makePreset = () => {
       
    }

    $scope.loadPreset = () => {
        [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias === "content" })[0].value = angular.copy($scope.model.value.selectedPreset.Value);
    }

    $scope.deletePreset = () => {
        $scope.model.value.presets.splice($scope.model.value.presets.indexOf($scope.model.value.selectedPreset), 1);
        $scope.model.value.selectedPreset = $scope.model.value.presets[$scope.model.value.presets.length - 1];
    }
});
