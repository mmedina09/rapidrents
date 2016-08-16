(function () { // move this into a properties service file 
    "use strict";

    angular.module(APPNAME).factory('$propertiesService', PropertiesServiceFactory);
    PropertiesServiceFactory.$inject = ['$baseService']
    function PropertiesServiceFactory($baseService) {
        var aSabioServiceObject = sabio.services.properties;
        var newService = $baseService.merge(true, {}, aSabioServiceObject, $baseService);

        return newService;
    }
})();