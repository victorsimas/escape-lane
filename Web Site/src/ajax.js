searchUsers();

function searchUsers() {
    $.ajax({
        url: 'src/search.php',
        type: 'POST',
        success: function (response) {
            $("#result").html(response);
        },
        error: function () {
            alert("error");
        }
    });
}