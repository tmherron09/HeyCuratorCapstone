searchBar.addEventListener('keyup', (e) => {
    console.log(e);
    searchString = e.target.value;
    itemSearch(searchString);

});


$(document).ready(function () {

});


function itemSearch(searchString) {
    if (searchString === "" || searchString === null) {
        $("#Table").html('');
        $("#Table").append(`
                        <tr>
                            <th>Name</th>
                            <th>Type</th>
                            <th>Id</th>
                        </tr>
                        `);
    }
    else {
        $.ajax({
            type: "GET",
            url: "/api/Search/itemResults/" + searchString,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //alert(JSON.stringify(data));
                $("#Table").html('');
                $('#Table').append(`
                        <tr>
                            <th>Name</th>
                            <th>Type</th>
                            <th>Id</th>
                        </tr>
                        `);

                $.each(data, function (i, item) {
                    var rows = "<tr>" +
                        "<td id='Name'>" + item.name + "</td>" +
                        "<td id='Type'>" + item.type + "</td>" +
                        "<td id='Id'>" + item.id + "</td>" +
                        "</tr>";
                    $('#Table').append(rows);
                }); //End of foreach Loop
                console.log(data);
            }, //End of AJAX Success function

            failure: function (data) {
                //alert(data.responseText);
            }, //End of AJAX failure function
            error: function (data) {
                //alert(data.responseText);
            } //End of AJAX error function

        });
    }


}