angular.module("umbraco").controller("Quantize.controller", function ($scope, umbRequestHelper, $log, $http, QuantizeResource, editorState) {

    if (!$scope.model.value) { 
        $scope.model.value = {
            presets: [],
            selectedPreset: {}
        }
    }

    //debugger
    //editorState.current.tabs
    // NOTE: I DONT NEED TO DO ANY OF THIS NONSENSE
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })) // gets flattened list of properties on content
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.editor == "Umbraco.Grid"}) // Gets all grid properties
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias == "content"})[0].value // Get property by alias
    // [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias == "content"})[0].value // Get property by alias and then get value

    $scope.makePreset = () => {
        if ($scope.presetName) {            

            var values = angular.copy([].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias == "content" })[0].value);

            $scope.model.value.presets.push(
                {
                    name: $scope.presetName,
                    preset: values
                });

            $scope.presetName = null;
            $scope.model.value.selectedPreset = $scope.model.value.presets[$scope.model.value.presets.length - 1]
        }
    }

    $scope.loadPreset = () => {
        if ($scope.presetName) {
            [].concat.apply([], editorState.current.tabs.map((e) => { return e.properties; })).filter((y) => { return y.alias == "content" })[0].value = $scope.model.value.selectedPreset.preset;
        }
    }

    $scope.deletePreset = () => {
        delete $scope.model.value.presets[$scope.model.value.presets.indexOf($scope.model.value.selectedPreset)];
        $scope.model.value.selectedPreset = $scope.model.value.presets[$scope.model.value.presets.length - 1];
    }
});
