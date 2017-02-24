angular.module("umbraco.resources").factory("QuantizeResource", function ($q, $http, umbRequestHelper) {

    return {
        // READ
        getPresetJsonDataFromId: function (id) {
            debugger;
            return umbRequestHelper.resourcePromise(
                $http.get(`/umbraco/backoffice/bjw/QuantizeService/GetPresetJsonDataFromId?id=${id}`),
                "Failed to get models out-of-date status");
        },
        getPresets: function () {
            return umbRequestHelper.resourcePromise(
                $http.get(`/umbraco/backoffice/bjw/QuantizeService/GetPresets`),
                "Failed to get models out-of-date status");
        },
        addPresets: function (name, value) {
            return umbRequestHelper.resourcePromise(
                $http.post(`/umbraco/backoffice/bjw/QuantizeService/AddPreset?name=${name}&value=${value}`),
                "Failed to get models out-of-date status");
        },
        loadCurrentPresetForProperty: function (id, alias, value) {
            return umbRequestHelper.resourcePromise(
            $http.get(`/umbraco/backoffice/bjw/QuantizeService/GetCurrentJsonDataForProperty?id=${id}&alias=${alias}&value=${value}`),
            "Failed to get models out-of-date status");
    }
    };
});
