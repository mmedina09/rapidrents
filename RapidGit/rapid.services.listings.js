rapid.services.listings = rapid.services.listings || {};

rapid.services.listings.add = function (listingsData, onSuccess, onError) {
    var url = "/api/listings/";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: listingsData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

rapid.services.listings.update = function (listingsId, listingsData, onUpdateSuccess, onUpdateError) {

    var url = "/api/listings/" + listingsId;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: listingsData
    , dataType: "json"
    , success: onUpdateSuccess
    , error: onUpdateError
    , type: "PUT"
    };

    $.ajax(url, settings);

}

rapid.services.listings.get = function (onGetSuccess, onGetError) {

    var settings = {
        url: "/api/listings/",
        context: this,
        cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetSuccess
      , error: onGetError
      , type: "GET"
    };
    $.ajax(settings);
}

rapid.services.listings.getListingsbyId = function (listingsid, onGetIdSuccess, onGetIdError) {
    var settings = {
        url: "/api/listings/" + listingsid,
        cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetIdSuccess
      , error:onGetIdError
      , type: "GET"
    };
    $.ajax(settings);
}

rapid.services.listings.getFeatured = function (onGetFeaturedSuccess, onGetFeaturedError) {
        var settings = {
        url: "/api/listings/featured",
        cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetFeaturedSuccess
      , error: onGetFeaturedError
      , type: "GET"
    };
    $.ajax(settings);
}

rapid.services.listings.getListingByAddressId = function (addressId, onGetAddressSuccess, onGetAddressError) {
    var settings = {
    url:"/api/listings/address/" + addressId,
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetAddressSuccess
      , error:onGetAddressError
      , type: "GET"
};
    $.ajax(settings);
}

rapid.services.listings.GetListingByLiId = function (listingid, onGetIdSuccess, onGetIdError) {
    var settings = {
        url: "/api/listings/id/" + listingid,
        cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetIdSuccess
      , error: onGetIdError
      , type: "GET"
    };
    $.ajax(settings);
}

rapid.services.listings.delete = function (listingsid, onDeleteSuccess, onDeleteError) {
    
    var settings = {
        url: "/api/listings/" + listingsid,
        cache: false
     , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
     , dataType: "json"
     , success: onDeleteSuccess
     , error: onDeleteError
     , type: "DELETE"
    };
    $.ajax(settings);
}

rapid.services.listings.getListingUtilities = function (onGetSuccess, onGetError) {
    var settings = {
        url: "/api/listings/Utilities"
      , cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetSuccess
      , error: onGetError
      , type: "GET"
    };
    $.ajax(settings);
}

rapid.services.listings.plw_insert = function (plwObject, onSuccess, onError) {
    var url = "/api/listings/AddressListing";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: plwObject
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

rapid.services.listings.getpage = function (PageIndex, PageSize, onGetSuccess, onGetError) {

    var settings = {
        url: "/api/Listings/" + PageIndex + "/" + PageSize
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

sabio.services.listings.getfavorite = function (onGetSuccess, onGetError) {

    var settings = {
        url: "/api/listings/favorite/"
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

rapid.services.listings.getPopular = function (PageIndex, PageSize, onGetSuccess, onGetError) {

    var settings = {
        url: "/api/Listings/" + PageIndex + "/" + PageSize
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

rapid.services.listings.getLatest = function (onGetSuccess, onGetError) {

    var settings = {
        url: "/api/listings/latest",
        context: this,
        cache: false
      , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
      , dataType: "json"
      , success: onGetSuccess
      , error: onGetError
      , type: "GET"
    };
    $.ajax(settings);
}
