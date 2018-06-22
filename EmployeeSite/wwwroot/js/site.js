// Write your JavaScript code.
$("#navigationMenu").click(function () {
    $("#navigationMenu").next().toggle();
});

function changeSchedule(id) {
    var div = document.getElementById(id);
    div.innerHTML = "test";

}