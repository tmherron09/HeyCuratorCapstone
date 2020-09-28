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
                $("#grid-container").html('');
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
                        "<td id='Id'>" +
                        "<button onclick='itemConnectionSearch(" + item.id + ")' class='bg-white hover:bg-" + item.color + "-100 text-" + item.color + "-700 font-semibold hover:text-white py-2 px-4 border border-" + item.color + "-700 hover:border-transparent rounded'> " +
                        " Connections " +
                        " </button > ";
                        + "</td> " +
                        "</tr> ";
                    $('#Table').append(rows);


                    
                    var grids =
                        `<div class="w-full xl:w-1/3 lg:w-1/2 px-4 mb-4 lg:mb-0 ">
                        <div class="h-full border rounded shadow bg-white">
                            <div class="flex items-center justify-between py-3 px-4 border-b">
                                <h3 class="text-lg font-heading">${item.name}</h3>
                                <span class="py-1 px-3 text-sm text-white font-semibold bg-green-500 rounded-full">${item.type}</span>
                            </div>
                            <div class="flex flex-col p-4">
                                <h3 class="text-3xl mb-3 font-heading font-semibold">${item.icon}</h3>
                                <span></span><span class="text-green-500 text-xs"></span>
                            </div>
                        </div>
                    </div>`;
                    $('#grid-container').append(grids);



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


function itemConnectionSearch(searchId) {
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
            url: "/api/Search/itemConnect/" + searchId,
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
                $("#grid-container").html('');
                $.each(data, function (i, item) {
                    var linkColumn = item.id;
                    if (item.type === "Item") {
                        linkColumn = "<a href='../Item/Details/" + item.id + "' class='bg-transparent hover:bg-" + item.color + "-100 text-" + item.color + "-700 font-semibold hover:text-white py-2 px-4 border border-" + item.color + "-700 hover:border-transparent rounded'> " +
                            " Details " +
                            " </a > ";
                    }

                    var rows = " <tr class=' bg-" + item.color + "-500 border-l-4 border-" + item.color + "-700' > " +
                        "<td id='Name'>" + item.name + "</td> " +
                        "<td id='Type'>" + item.type + "</td> " +
                        "<td id='Color'>" + item.color + "</td> " +
                        "<td id='Icon'> " + item.icon + " </td> " +
                        "<td id='Id'>" + linkColumn + "</td> " +
                        "</tr> ";
                    $('#Table').append(rows);



                    var grids =
                        `<div class="w-full xl:w-1/3 lg:w-1/2 px-4 mb-4 lg:mb-0 ">
                        <div class="h-full border rounded shadow bg-white">
                            <div class="flex items-center justify-between py-3 px-4 border-b">
                                <h3 class="text-lg font-heading">${item.name}</h3>
                                <span class="py-1 px-3 text-sm text-white font-semibold bg-green-500 rounded-full">${item.type}</span>
                            </div>
                            <div class="flex flex-col p-4">
                                <h3 class="text-3xl mb-3 font-heading font-semibold">${item.icon}</h3>
                                <span></span><span class="text-green-500 text-xs"></span>
                            </div>
                        </div>
                    </div>`;
                    $('#grid-container').append(grids);



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