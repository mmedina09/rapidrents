sabio.services.importedProperties = sabio.services.importedProperties|| {};



sabio.services.importedProperties.get = function (onAjaxSuccess, onAjaxError) {
    var url = "/api/imports/properties";//api/properties/imported
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

sabio.services.importedProperties.post = function (myData, onSuccess, onError) {
    var url = "/api/imports/properties"
    var settings = {
        cache: false
            , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
            , data: myData
            , type: "POST"
            , dataType: "json"
            , success: onSuccess
            , error: onError
    };

    $.ajax(url, settings)
}

sabio.services.importedProperties.postAll = function (myData, onSuccess, onError) {
    var url = "/api/imports/properties/bulk"
    var settings = {
        cache: false
            , contentType: "application/json"
            , data: JSON.stringify(myData) 
            , type: "POST"
            , dataType: "json"
            , success: onSuccess
            , error: onError
    };

    $.ajax(url, settings)
}

