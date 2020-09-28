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
                            <th>Color</th>
                            <th>Icon</th>
                            <th>Id</th>
                        </tr>
                        `);
    }
    else {
        $.ajax({
            type: "GET",
            url: "/api/Search/results/" + searchString,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //alert(JSON.stringify(data));
                $("#Table").html('');
                $('#Table').append(`
                        <tr>
                            <th>Name</th>
                            <th>Type</th>
                            <th>Color</th>
                            <th>Icon</th>
                            <th>Id</th>
                        </tr>
                        `);

                $.each(data, function (i, item) {
                    var linkColumn = item.id;
                    if (item.type === "Item") {
                        linkColumn = "<a href='../Item/Details/" + item.id + "' class='bg-transparent hover:bg-" + item.color + "-100 text-" + item.color + "-700 font-semibold hover:text-white py-2 px-4 border border-" + item.color + "-700 hover:border-transparent rounded'> " +
                            " Details " +
                            " </a > ";
                    }

                    var rows = " <tr class=' bg-" + item.color + "-500 border-l-4 border-" + item.color +"-700' > " +
                        "<td id='Name'>" + item.name + "</td> " +
                        "<td id='Type'>" + item.type + "</td> " +
                        "<td id='Color'>" + item.color + "</td> " +
                        "<td id='Icon'> " + item.icon + " </td> " +
                        "<td id='Id'>" + linkColumn + "</td> " +
                        "</tr> ";
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