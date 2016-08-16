(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('searchController', SearchController);

    SearchController.$inject = ['$scope'
                                , '$baseController'
                                , '$searchService'
                                , '$uibModal'
                                , '$listingsService'
                                , '$analyticsService'
                                , '$geoService'
                                , '$addressService'];

    function SearchController(
        $scope
        , $baseController
        , $searchService
        , $uibModal
        , $listingsService
        , $analyticsService
        , $geoService
        , $addressService
      ) {


        var vm = this;
        vm.items = null;
        vm.map = null;
        vm.newSearch = null;
        vm.selectedSearch = null;
        vm.searchForm = null;
        vm.searchResults = null;
        vm.searchHeader = false;
        //pagination
        vm.pageIndex = 0;
        vm.currentPage = 1;
        vm.totalCount = 0;
        vm.latitude = 34.024212;
        vm.longitude = -118.496475;
        vm.miles = 20;

        vm.numberOfPages = null;
        vm.listingItems = {};
        vm.newListing = {};
        vm.mapItems = {}

        vm.$searchService = $searchService;
        vm.$listingsService = $listingsService;
        vm.$addressService = $addressService;
        vm.$geoService = $geoService;

        //
        vm.analyticsObj = {};
        vm.$analyticsService = $analyticsService;
        vm.isOnListingsSuccessful = false;
        vm.listingsRenderIdArr = null;
        vm.setDataArrProp = _setDataArrProp;

        //

        vm.$scope = $scope;
        vm.$uibModal = $uibModal;

        //pagination functions
        vm.changePage = _changePage;
        vm.numberOfPages = _numberOfPages;
        vm.searchSuccess = _searchSuccess;

        vm.getItems = _getItems;
        vm.filterSearch = _filterSearch;
        vm.onSubmitSuccess = _onSubmitSuccess;
        vm.onSubmitError = _onSubmitError;
        vm.openModal = _openModal;
        vm.receiveSearchResults = _receiveSearchResults;
        vm.submitSearch = _submitSearch;
        vm.receiveItems = _receiveItems;

        vm.onSubmitSuccess = _onSubmitSuccess;
        vm.onSubmitError = _onSubmitError;
        vm.onListingsSuccess = _onListingsSuccess;
        vm.onListingsError = _onListingsError;
        vm.onAddressError = _onAddressError;

        $baseController.merge(vm, $baseController);

        vm.notify = vm.$searchService.getNotifier($scope);

        render();

        //START UP

        function render() {

            if (vm.map == null) {
                var mapProp = {
                    center: new google.maps.LatLng(34.024212, -118.496475),
                    zoom: 12
                };
                vm.map = vm.$geoService.getMap(document.getElementById("home_map_canvas"), mapProp);
            }

            _getItems();
        }


        function _getItems() {
            vm.$listingsService.getFeatured(vm.onListingsSuccess, vm.onListingsError);
            vm.$addressService.getPopular(vm.latitude, vm.longitude, vm.miles, vm.receiveItems, vm.onAddressError);
        }

        function _receiveItems(data) {
            vm.notify(function () {
                if (data) {
                    if (!data.item) {
                        return null;
                    }
                    else if (data.item) {
                        vm.mapItems = data.item;

                    }
                }

                // _removeMarkers();
                vm.markers = vm.$geoService.placeMarkers(vm.map, vm.mapItems, contentProvider, designMarker);
            });
        }



        function contentProvider(singleItem) {
            if (!singleItem) {
                vm.$log.error("singleItem does not exist");
                return null;
            }

            var content = null;

            if (!singleItem.listings) {
                content = singleItem.line1;
            }

            else if (!singleItem.listings[0]) {
                content = singleItem.line1;
            }

            else if (singleItem.listings[0]) {
                content = singleItem.listings[0].headline +
               "<br/> Rent: $" + singleItem.listings[0].rentCost +
               "<br/>" + singleItem.line1;
            }

            return content;
        }


        function designMarker(singleItem) {

            var customIcon;
            var customAnimation;

            if (singleItem.listings == null) {
                customIcon = '/images/modern-marker-red.png';
            }

            else if (singleItem.listings[0]) {
                customIcon = '/images/modern-marker-green.png';
            }

            vm.customMapSettings = { icon: customIcon };

            return vm.customMapSettings;
        }




        //

        function _setDataArrProp(anaObj) {
            anaObj = anaObj || {};
            anaObj.data = null;
            anaObj.dataArr = vm.listingsRenderIdArr;
            anaObj.categoryId = vm.$analyticsService.anaCategoryIds.LISTING;
            return anaObj;
        }

        function _filterSearch(aListing) {
            vm.selectedSearch = aListing;
            vm.openModal();
        }

        function _openModal() {
            var modalInstance = vm.$uibModal.open({
                animation: true,
                templateUrl: 'searchFilterModal.html',
                controller: 'searchModalController as srchMC',
                size: 'lg',
                resolve: {
                    item: function () {
                        return vm.selectedSearch;
                    }
                }
            });
            modalInstance.result.then(_actionRequested, _dismissed);
        }


        function _dismissed() {
            console.log('Modal dismissed at: ' + new Date());
        }

        function _actionRequested(modalObject) {
            if (!modalObject.isDelete) {
                vm.$searchService.getSearchByFilter(modalObject.item, vm.onSubmitSuccess, vm.onSubmitError);
                console.log("your search was filtered");
            }
            else {
                console.log("your search was NOT filtered");

            }
        }

        function _submitSearch() {
            vm.$searchService.getSearchByFilter(vm.selectedSearch, vm.pageIndex, vm.itemsPerPage, vm.searchSuccess, vm.onSubmitError);
        }

        function _onSubmitSuccess(data) {
            vm.$alertService.success("Search submitted", "Success!");
            if (data == null) {
                vm.$log.error("this is null");
            } else {
                vm.receiveSearchResults(data);
                vm.searchHeader = true;
            }
        }

        function _searchSuccess(data) {
            vm.notify(function () {
                vm.items = data.item.pagedItems;
                vm.totalCount = data.item.totalCount;
                vm.pageIndex = data.item.pageIndex;
                vm.totalPages = data.item.totalPages;
            });
        }


        function _receiveSearchResults(data) {
            vm.notify(function () {
                vm.items = data.items;
            })
        }

        function _onSubmitError(jqXhr, error) {
            vm.showErrors(jqXhr.responseJSON);
        }

        function _onListingsSuccess(data) {
            var dataArr = [];

            vm.notify(function () {
                vm.items = data.items;


                for (var i = 0; i < data.items.length; i++) {
                    dataArr.push(data.items[i].id);
                }
                vm.listingsRenderIdArr = dataArr;
                vm.isOnListingsSuccessful = true;
            })

        }

        function _onAddressError(jqXhr, error) {
            vm.showErrors(jqXhr.responseJSON);
        }

        function _onListingsError(jqXhr, error) {
            vm.showErrors(jqXhr.responseJSON);
        }

        function _changePage() {
            vm.pageIndex = vm.currentPage - 1;
            _submitSearch();
        }
        function _numberOfPages() {

            return vm.totalPages;
        }
    }



})();


