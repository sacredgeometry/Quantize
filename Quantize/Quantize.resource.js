angular.module("umbraco.resources").factory("QuantizeResource", function ($q, $http, umbRequestHelper) {

    return {
        getCurrentJsonDataForProperty: function (id, alias) {
            return umbRequestHelper.resourcePromise(
                $http.get(`/umbraco/bjw/QuantizeService/GetCurrentJsonDataForProperty?id=${id}&alias=${alias}`),
                "Failed to get models out-of-date status");
        },
        loadCurrentPresetForProperty: function (id, alias, value) {
        return umbRequestHelper.resourcePromise(
            $http.get(`/umbraco/bjw/QuantizeService/GetCurrentJsonDataForProperty?id=${id}&alias=${alias}&value=${value}`),
            "Failed to get models out-of-date status");
    }
    };
});
