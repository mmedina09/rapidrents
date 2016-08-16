(function () {
    "use strict";

    angular.module(APPNAME)
        .factory('$addressService', AddressServiceFactory);

    AddressServiceFactory.$inject = ['$baseService'];

    function AddressServiceFactory($baseService) {

        var aServiceAddressObject = sabio.services.address;

        var newService = $baseService.merge(true, {}, aServiceAddressObject, $baseService);

        return newService;
    }
})();
