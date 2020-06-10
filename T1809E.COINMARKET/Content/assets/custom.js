var rootUrl = 'https://localhost:44361';

function login() {
    var loginData = {
        grant_type: 'password',
        username: $("#username").val(),
        password: $("#password").val()
    };
    $.ajax({
        type: 'POST',
        url: rootUrl + '/Token',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Bearer" + sessionStorage.getItem("AccessToken")
        },
        data: loginData
    }).done(function (data) {
        sessionStorage.setItem("AccessToken", data.access_token);
        redirect("/admin");
    }).fail();
}

function redirect(url) {
    var u = rootUrl + url;
    $.ajax({
        type: 'POST',
        url: u,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Bearer" + sessionStorage.getItem("AccessToken")
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
            'Authorization': "Bearer" + sessionStorage.getItem("AccessToken")
        }
    }).done(function (data) {
        sessionStorage.removeItem("AccessToken");
//        window.location.href = rootUrl;
        console.log(data);
    }).fail();
}