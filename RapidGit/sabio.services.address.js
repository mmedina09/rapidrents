sabio.services.address = sabio.services.address || {};

sabio.services.address.add = function (addressData, onSuccess, onError) {
    var url = "/api/addresses";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: addressData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.address.update = function (currentId, addressData, onSuccess, onError) {
    var url = "/api/addresses/" + currentId;
    
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: addressData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };

    $.ajax(url, settings);
}

sabio.services.address.get = function (onSuccess, onError) {
    var url = "/api/addresses";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };

    $.ajax(url, settings);
}

sabio.services.address.getById = function (currentId, onSuccess, onError) {
    var url = "/api/addresses/" + currentId;
    
    var settings = {
        contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    
    $.ajax(url, settings);
}

sabio.services.address.DeleteById = function (currentId, onSuccess, onError) {
    var url = "/api/addresses/" + currentId;

    var settings = {
        contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "DELETE"
    };

    $.ajax(url, settings);
}

sabio.services.address.getByGeo = function (loc, onSuccess, onError) {
    var url = "/api/addresses/radius";

    var settings = {
        data: loc
        , contentType: "application/x-www-form-urlendcoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };

    $.ajax(url, settings);
}

sabio.services.address.plw_search = function (searchItem, onSuccess, onError) {
    $.ajax({
        url: "/api/addresses/Search/" + searchItem,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    });
}

sabio.services.address.getpage = function (pageIndex, pageSize, onGetSuccess, onGetError) {
    var settings = {
        url: "/api/listings/maplist/" + pageIndex + "/" + pageSize
      , context: this
      , cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetSuccess
      , error: onGetError
      , type: "GET"
    };
    $.ajax(settings);
}

sabio.services.address.aWoP_search = function (searchItem, onSuccess, onError) {
    $.ajax({
        url: "/api/addresses/addPropSearch/" + searchItem,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    });
}


sabio.services.address.addAandP = function (propId, addId, onSuccess, onError) {
    var url = "/api/addresses/" + propId + "/" + addId;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };

    $.ajax(url, settings);
}


sabio.services.address.updateLatLong = function (currentId, longLatData, onSuccess, onError) {
    var url = "/api/addresses/LongLat/" + currentId;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: longLatData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };

    $.ajax(url, settings);
}

sabio.services.address.rentCheck = function (searchCost, onSuccess, onError) {

    var url = "/api/addresses/RentCheck";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: searchCost
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.address.rentCheckArea = function (searchCostArea, onSuccess, onError) {

    var url = "/api/addresses/RentCheckArea";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: searchCostArea
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.address.rentCheckAll = function (searchedAddress, onSuccess, onError) {


    var url = "/api/addresses/RentChecker";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: searchedAddress
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };

    $.ajax(url, settings);
}



sabio.services.address.findNearbyAddressListings = function (listingsId, onSuccess, onError) {
    var url = "/api/addresses/findNearId/" + listingsId;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };

    $.ajax(url, settings);
}

sabio.services.address.getPopular = function (Latitude, Longitude, radius, onGetSuccess, onGetError) {

    var settings = {
        url: "/api/listings/popularlistings/" + Latitude + "/" + Longitude + "/" + radius
      , context: this
      , cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetSuccess
      , error: onGetError
      , type: "GET"
    };
    $.ajax(settings);
}