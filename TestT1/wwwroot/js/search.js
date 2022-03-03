
var employeeListDiv;

function request_page() {

    employeeListDiv = document.getElementById("employeeListDiv");

    employeeListDiv.innerHTML = "";

    for (var i = 0; i < employeeList; i++) {

    }


    /*employees.inner*/
}

function loadAllEmployees(str, type) {
    console.log("im in");
    //let title = document.getElementById('title');
    var searchStr = $("#SearchStr").val();
    
    $.ajax({
        url: "/Employee/GetEmployees/",
        type: "GET",
        data: {
            searchStr: searchStr
        },
        success: function (data) {

            employeeList = JSON.parse(data);
            //console.log(data);
            request_page();
        },
        error: function (err) {
            console.log(err);
        }
    });
}
