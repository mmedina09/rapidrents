(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('addressToApnMainController', addressToApnMainController);

    addressToApnMainController.$inject = ['$scope', '$baseController', '$addressService', '$propertyService', '$uibModal'];

    function addressToApnMainController(
      $scope
      , $baseController
      , $addressService
      , $propertyService
      , $uibModal
      ) {

        var vm = this;
        vm.$addressService = $addressService;
        vm.$propertyService = $propertyService;

        vm.addressObject = {};


        vm.searchItem = null;
        vm.displayedSearchItem = null;
        vm.searchButtonClicked = false;
        vm.selectButtonClicked = false;
        vm.searchList = null;
        vm.searchListLength = null;
        vm.addressObject.addressId = null;

        vm.searchForAddress = _searchForAddress;
        vm.add_searchSuccess = _add_searchSuccess;
        vm.add_searchErrror = _add_searchError;
        vm.launchModal = _launchModal;
        vm.openModal = _openModal;
        vm.$uibModal = $uibModal;


        $baseController.merge(vm, $baseController);
        vm.notify = vm.$addressService.getNotifier($scope);


        function _searchForAddress(searchItem) {
            vm.searchButtonClicked = true;
            vm.taskDisabled = true;
            if (searchItem == null) {
                vm.taskDisabled = false;
            }
            else {
                vm.$addressService.aWoP_search(searchItem, vm.add_searchSuccess, vm.add_searchErrror);
            }
        }

        function _add_searchSuccess(data) {
            vm.taskDisabled = false;
            vm.notify(function () {
                vm.searchList = data.items;
                vm.displayedSearchItem = vm.searchItem;
                vm.selectButtonClicked = false;
                vm.addressObject.address = null; //or else addobject.addressId is still bounded to previous data from the search before

                if (vm.searchList == null) {
                    vm.searchListLength = 0;
                }
                else {
                    vm.searchListLength = data.items.length;
                }
            });

        }

        function _openModal(addObj) {

            var modalInstance = vm.$uibModal.open({
                animation: true,
                templateUrl: 'modalContent.html',       //  this tells it what html template to use. it must exist in a script tag OR external file
                controller: 'addressApnModalController as mc',    // this controller must exist and be registered with angular for this to work
                size: 'md',
                resolve: {  //  anything passed to resolve can be injected into the modal controller as shown below
                    selectedAddObj: function () {
                        return addObj;
                    }
                }
            });

            modalInstance.result.then(_onModalSubmitted, _onModalDismissed);

        }

        function _launchModal(arg) {
            var des = arg;
            vm.selectButtonClicked = true;
            vm.openModal(des);
        }

        function _add_searchError() {
            vm.taskDisabled = false;
        }

        function _onModalSubmitted() {

            vm.modalSelected = vm.selectedAddOb;
        }

        function _onModalDismissed() {
            console.log('Modal dismissed at: ' + new Date());
        }

        function _stringsToInt(string) {
            var int = parseInt(string);
            return int;
        }


    }

})();