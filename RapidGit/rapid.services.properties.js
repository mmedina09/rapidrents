rapid.services.properties = rapid.services.properties || {};

rapid.services.properties.add = function (propertyData,onSuccess, onError) {
    var url = "/api/properties/";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: propertyData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

rapid.services.properties.update = function (propertyId, propertyData, onSuccess, onError) {


    var url = "/api/properties/" + propertyId;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: propertyData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };

    $.ajax(url, settings);

}

rapid.services.properties.get = function (onAjaxSuccess, onAjaxError) {
    var url = "/api/properties/";
    var settings = {
        cache: false
            , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
            , dataType: "json"
            , success: onAjaxSuccess
            , error: onAjaxError
            , type: "GET"
    };

    $.ajax(url, settings);

}

rapid.services.properties.getById = function (propertyId, onSuccess, onError) {


    var url = "/api/properties/" + propertyId + "/edit";
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

rapid.services.properties.delete = function (propertyId, onSuccess, onError) {


    var url = "/api/properties/" + propertyId + "/delete";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: propertyId
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "DELETE"
    };

    $.ajax(url, settings);

}


sabio.services.properties.apn_search = function (searchItem, onSuccess, onError) {
        
        var url = "/api/properties/SearchForApn/" + searchItem;
        var settings = {
            cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: searchItem
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };

    $.ajax(url, settings);
}


rapid.services.properties.get = function (onAjaxSuccess, onAjaxError) {
    var url = "/api/properties/";
    var settings = {
        cache: false
            , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
            , dataType: "json"
            , success: onAjaxSuccess
            , error: onAjaxError
            , type: "GET"
    };

    $.ajax(url, settings);

}

rapid.services.properties.getByOwnerId = function (onSuccess, onError) {


    var url = "/api/properties/owner";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);

}  // This call will get the currentuserId through the endpoint

rapid.services.properties.getByUserId = function (userId, onSuccess, onError) {


    var url = "/api/properties/user/" + userId;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);

} //This call requires a paramenter of userId to get user properties 

rapid.services.properties.propertyOwnerRequest = function (ownerproperty,onSuccess, onError) {
    var url = "/api/properties/owner/request";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: ownerproperty
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}
