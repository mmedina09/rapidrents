sabio.services.comment = sabio.services.comment || {};


sabio.services.comment.add = function (commentData, onInsertSuccess, onInsertError) {
    var url = "/api/comments";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: commentData
        , dataType: "json"
        , success: onInsertSuccess
        , error: onInsertError
        , type: "POST"
    };
    $.ajax(url, settings);
}   

sabio.services.comment.update = function (currentId, commentData, onUpdateSuccess, onUpdateError) {
    var url = "/api/comments/" + currentId;
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: commentData
        , dataType: "json"
        , success: onUpdateSuccess
        , error: onUpdateError
        , type: "PUT"
    };
    $.ajax(url, settings);
}  

sabio.services.comment.getById = function (commentData, onGetAllSuccess, onGetAllError) {
    var url = "/api/comments/" + commentData;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , data: commentData
    , success: onGetAllSuccess
    , error: onGetAllError
    , type: "Get"
    };

    $.ajax(url, settings);
} 

sabio.services.comment.getByTypeId = function (requestId, onGetAllSuccess, onGetAllError) {
    var url = "/api/comments/" + requestId+ "/get";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , data: { 'EntityId': requestId, 'typeId': 'MR'}
    , success: onGetAllSuccess
    , error: onGetAllError
    , type: "Get"
    };

    $.ajax(url, settings);
}



    sabio.services.comment.getList = function (onGetAllSuccess, onGetAllError) {
        var url = "/api/comments";
        var settings = {
            cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onGetAllSuccess
        , error: onGetAllError
        , type: "Get"
        };

        $.ajax(url, settings);
    }

    sabio.services.comment.deleteById = function (deleteId, onGetAllSuccess, onGetAllError) {
        var url = "/api/comments/" + deleteId;
        var settings = {
            cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , data: deleteId
        , success: onGetAllSuccess
        , error: onGetAllError
        , type: "Delete"
        };

        $.ajax(url, settings);
    }

