var rootUrl = 'https://t1809ecoinmarket20200608234615.azurewebsites.net';
//var rootUrl = 'https://localhost:44361';
$('document').ready(() => {
    $('#loading-image').hide();
    $('#alert-login').hide();
});

function login() {
    var loginData = {
        grant_type: 'password',
        username: $("#username").val(),
        password: $("#password").val()
    };

    $('#loading-image').show();
    $.ajax({
        type: 'POST',
        url: rootUrl + '/Token',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Bearer " + sessionStorage.getItem("AccessToken")
        },
        data: loginData
    }).done(function (data) {
        sessionStorage.setItem("AccessToken", data.access_token);
        redirect("/admin");
        $('#loading-image').hide();
    }).fail(() => {
        $('#alert-login').show();
        $('#loading-image').hide();
    });
}

function redirect(url) {
    var u = rootUrl + url;
    $('#loading-image').show();
    $.ajax({
        type: 'POST',
        url: u,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Bearer " + sessionStorage.getItem("AccessToken")
        }
    }).done(function (data) {
        window.location.href = u;
    }).fail();
}

function logout() {
    var u = rootUrl + '/api/Account/Logout';
    $.ajax({
        type: 'POST',
        url: u,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Bearer " + sessionStorage.getItem("AccessToken")
        }
    }).done(function (data) {
        sessionStorage.removeItem("AccessToken");
        window.location.href = rootUrl;
    }).fail();
}

function changeStatus(status) {

}