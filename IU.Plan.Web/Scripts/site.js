
function getDetails(type, uid) {
    $.ajax({
        url: '/' + type + '/MiniDetails?uid=' + uid,
        success: function (data) {
            $('#MiniDetailsResult').html(data);

            $("#MiniDetailsResult").dialog({
                modal: true,
                width: 'auto',
                buttons: {
                    "Редактировать": function () {
                        $(this).dialog("close");
                        openEditPopup(type, uid);
                    },
                    "Удалить": function () {
                        $(this).dialog("close");
                        deleteEvent(type, uid);
                    },
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    });
}

function deleteEvent(type, uid, callback) {
    $.ajax({
        url: '/' + type + '/Delete',
        type: 'post',
        data: { "uid": uid },
        success: function (data) {
            if (data.Error) {
                alert(data.Error);
            }
            else if (callback) {
                setTimeout(callback, 1 * 1000);
            }
        }
    });
}

function saveEvent(type, callback) {
    $.ajax({
        url: '/' + type + '/Save',
        type: 'post',
        data: $('form#' + type + 'SaveForm').serialize(),
        success: function (data) {
            $('#EditPopup').html(data);
            if (callback) {
                setTimeout(callback, 1 * 1000);
            }
        }
    });
}

function openCreatePopup(type) {
    $.ajax({
        url: '/' + type + '/Create',
        success: function (data) {
            $('#EditPopup').html(data);
            var editPopup = $("#EditPopup").dialog({
                modal: true,
                width: 'auto',
                buttons: {
                    "Сохранить": function () {
                        saveEvent(type, function () {
                            editPopup.dialog("close");
                            document.location.reload();
                        });
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    });
}

function openEditPopup(type, uid) {
    $.ajax({
        url: '/' + type + '/Edit?uid=' + uid,
        success: function (data) {
            $('#EditPopup').html(data);
            var editPopup = $("#EditPopup").dialog({
                modal: true,
                width: 'auto',
                buttons: {
                    "Сохранить": function () {
                        saveEvent(type, function () {
                            editPopup.dialog("close");
                            document.location.reload();
                        });
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    });
}

window.timer = 0;

function search(force) {
    var find = $("#searchRequest").val();
    if (!!force && find.length >= 3) {

        $.ajax({
            url: '/Search/Filter',
            type: 'post',
            data: { "searchRequest": find },
            success: function (data) {
                $('#searchResult').html(data);
            }
        });

    }
    else {
        clearTimeout(window.timer);
        window.timer = setTimeout(function () { search(true); }, 4 * 100);
    }
}


function checkEvents(url, id) {
    $.ajax({
        url: '/Notify/Info' + url,
        type: 'get',
        success: function (data) {
            if (data > 0) {
                $('#' + id + ' span').html(data);
            } else {
                $('#' + id + ' span').html('');
            }
        }
    });
}