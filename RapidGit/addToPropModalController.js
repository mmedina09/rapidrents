

(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('addressApnModalController', addressApnModalController);


    addressApnModalController.$inject = ['$scope', '$baseController', '$uibModalInstance', 'selectedAddObj', '$propertyService', '$addressService'];

    function addressApnModalController(
        $scope

        , $baseController
        , $uibModalInstance
        , selectedAddObj
        , $propertyService
        , $addressService

         ) {

        var vm = this;

        $baseController.merge(vm, $baseController);

        vm.$scope = $scope;
        vm.$uibModalInstance = $uibModalInstance;
        vm.$alertService = vm.$alertService;
        vm.selectedAddObj = selectedAddObj;
        vm.$propertyService = $propertyService;
        vm.$addressService = $addressService;
        vm.$alertService = vm.$alertService;


        vm.selected = {
            item: vm.modalItems
        };

      
        vm.geocoder = null;
        vm.map = null; 
        vm.addressId = null; 
        vm.geocodeResponse = null; 


        vm.newPropertyItems = null;
        vm.showApnSendErrors = false;
        vm.propertyFindForm = null;
        vm.searchButtonClicked = false;
        vm.displayedSearchItem = null
        vm.findProperty = null;
        vm.newComment = null;




        vm.propertyFindSuccess = _propertyFindSuccess;
        vm.propertyFindError = _propertyFindError;
        vm.findNewProperty = _findNewProperty;
        vm.attachProperty = _attachProperty;
        vm.addAandPSuccess = _addAandPSuccess;
        vm.addAandPError = _addAandPError;
        vm.submitAddress = _submitAddress; 

        vm.notify = vm.$propertyService.getNotifier($scope);


        _initialize();


        function _initialize() {

            vm.geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(34.024212, -118.496475);
            var mapOptions = {

                zoom: 15,
                center: latlng
            }

            window.setTimeout(function () {

                vm.map = new google.maps.Map($('#map-canvas')[0], mapOptions);
                _submitAddress();
            }, 800);

          

        }


        function _submitAddress() {

            var addressString = vm.selectedAddObj.line1 + " " + vm.selectedAddObj.city + " " + vm.selectedAddObj.state + " " + vm.selectedAddObj.zipCode;

            codeAddress(addressString);

        }


        function codeAddress(address) {
            console.log("address string -> " + address);

            vm.geocoder.geocode({ 'address': address }, _onCodeAddress);


        }


        function _onCodeAddress(results, status) {

            vm.notify(function () {

                vm.geocodeResponse = JSON.stringify(results, null, "    ");

            });

            if (status == google.maps.GeocoderStatus.OK) {

                var geometry = results[0].geometry;
                var loc = geometry.location;

                console.log('got a location from API', loc);

                vm.map.setCenter(loc);

                var marker = new google.maps.Marker({

                    map: vm.map,
                    position: loc
                });

                if (geometry.viewport)
                    vm.map.fitBounds(geometry.viewport);


                var lat = loc.lat();
                var lon = loc.lng();

                console.log("found coordinates in reply ->(%s,%s)", lat, lon);

                vm.address.latitued = lat;
                vm.address.longitude = lon;


            } else {
                alert('Geocode 3as not successful for the following reason: ' + status);
            }

        } 


        function _receiveComments(data) {

            vm.notify(function () {
                vm.newCommentItems = data.items;
            });
        }


        function _onReqError(jqXhr, error) {
            console.log("get comment error");
        }


        function _findNewProperty(findProperty) {
            console.log("APN Search fired!")
            vm.showApnSendErrors = true;
            vm.searchButtonClicked = true;

            if (vm.propertyFindForm.$valid) {
                vm.$propertyService.apn_search(vm.findProperty.apnSend, vm.propertyFindSuccess, vm.propertyFindError);
            }
            else {
                console.log("form submitted with invalid data :(")
            }
        }



        function _propertyFindSuccess(data) {
            vm.taskDisabled = false
            console.log("get property success!");

            vm.notify(function () {
                vm.newPropertyItems = data.items;
            });

        }

        function _propertyFindError(jqXhr, error) {
            console.log(" add comment error");
        }


        function _attachProperty(propId) {

            vm.selectButtonClicked = true;
            vm.$addressService.addAandP(propId, vm.selectedAddObj.id, vm.addAandPSuccess, vm.addAandPError);

        }


        function _addAandPSuccess(data) {

            vm.$alertService.success("Status update successful!")

        }

        function _addAandPError() {

            vm.$alertService.error("Status update error!")

        }


        vm.ok = function () {
            vm.$uibModalInstance.close(vm.selectedAddObj);
        };

        vm.cancel = function () {
            vm.$uibModalInstance.dismiss('close');
        };

    }
 })();

(function () {
    "use strict";

    angular.module(APPNAME).filter('typeIdFilter', typeIdFilter);

    function typeIdFilter() {

        return function (typeId) {

            switch (typeId) {
                case 1:
                    return "Single Family";
                case 2:
                    return "Multi-Family";
                case 3:
                    return "Non - Residential";
                case 4:
                    return "Vacant Residential";
            }
        }
    }
})();


