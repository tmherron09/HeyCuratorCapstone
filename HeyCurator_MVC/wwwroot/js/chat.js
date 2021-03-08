var loggedUsers;
var selectedChatBoxUser = "";
var dateRecieved;
var INDEX = 0;
//var userListSize = 1;
//$('#availableList').attr('size', 1);



$(document).ready(function () {

    console.log(userName);


    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    connection.start().then(function () {
        console.log("connected");

        connection.invoke('SendMessage', userName)
            .then(function (connectionId) {
                sessionStorage.setItem('conectionId', connectionId);
                // Send the connectionId to controller
            }).catch(err => console.error(err.toString()));

        var conn = sessionStorage.getItem('connectionId');

        console.log("Your connection Id is:" + conn);

    });

    $("#sendmessage").click(function () {
        var connectionId = sessionStorage.getItem('conectionId');
        connection.invoke("Send", connectionId);
    });

    connection.on("ReceiveMessage", function (userRecieve) {
        console.log(userRecieve);
        //AddMessageLineUser(userRecieve);
        //AddMessageLineSelf(userRecieve);

    });

    connection.on("ChatMessageSelf", function (selfRecieve) {
        console.log(userRecieve);
        //AddMessageLineUser(userRecieve);
        //AddMessageLineSelf(userRecieve);
    });
    connection.on("ChatMessageUser", function (sender, reciever, msg) {
        console.log(sender);
        if (reciever === "everyone") {
            msg = "(ALL): " + msg;
            if (sender === userName) {
                AddMessageLineSelf(msg);
            } else {
                AddMessageLineUser(sender, msg);
            }
        }
        else if (sender === userName) {
            if (reciever === "everyone") {
                msg = "(ALL): " + msg;
            }
            else {
                msg = `(To:${reciever}): ` + msg;
            }
            AddMessageLineSelf(msg);
        }
        else {
            msg = `(${sender}): ` + msg;
            AddMessageLineUser(sender, msg);
        }

        


    });


    connection.on("ListOfUsers", function (dictUsers) {
        console.log(dictUsers);
        loggedUsers = dictUsers;

        populateAvailableList();

    });

    connection.on("RecieveTime", function (date) {
        console.log("You recieved this as date." + date);
        dateRecieved = date;
    });

    connection.on("ControllerMessage", function (msg) {
        console.log(msg);
    });

    connection.on("AreYouThere", function () {
        connection.invoke("UserHere", userName);
    });

    connection.on("DirectMessage", function () {
        connection.invoke("UserHere", userName);
    });

    connection.on("PopToasts", function (title, msg) {
        PopToast(title, msg);
    });

    connection.on("PopCustomToast", function (title, msg, color, icon) {
        PopNewToast(title, msg, color, icon);
    });




    $('#getButton').click(function () {
        connection.invoke('GetListOfUsers');
    });

    $('#getDate').click(function () {
        connection.invoke('GetDateTime');
    });

    $('#messageJosh').click(function () {
        connection.invoke('MessageUser', userName, "JoshH", "Hey There!!");
    });

    $('#messageTim').click(function () {
        connection.invoke('MessageUser', userName, "TimH", "Hey There!!");
    });

    $('#checkItem').click(function () {
        connection.invoke('CheckItemPersistence');
    });
    $('#testToast').click(function () {
        connection.invoke('CustomToastTest');
    });

    $("#chat-submit").click(function (e) {
        e.preventDefault();
        var msg = $("#chat-input").val();
        if (msg.trim() == '') {
            return false;
        }

        var reciever = $("#availableList option:selected").val();


        connection.invoke('ChatToUser', userName, reciever, msg);

        $("#chat-input").val('');
    });



});


function populateUserList(item, index) {
    var nextUser = item;
    var li = document.createElement("li");
    li.textContent = nextUser;
    document.getElementById("userList").appendChild(li);
}

var globItem;

function populateAvailableList() {
    $('#availableList').html('');
    $('#availableList').append('<option value="everyone">Everyone</option>');
    //var selectListSize = loggedUsers.length >= 5 ? 5 : loggedUsers.length + 1;
    //$('#availableList').attr('size', selectListSize);
    $.each(loggedUsers, function (index, item) {
        if (item === userName) {

        }
        else {

            //console.log("The dictUser is:" + item)
            $('#availableList').append(
                `<option value="${item}">${String(item)}</option>`
            );
        }
    });
}


// User to Message Selection

$('#availableList')
    .change(function () {
        var str = "";
        $("#availableList option:selected").each(function () {
            str += $(this).text();
        });
        //$("#displayChoosen").text(str);
        INDEX = 0;
    })
    .change();




// Chat box popup



$(document).delegate(".chat-btn", "click", function () {
    var value = $(this).attr("chat-value");
    var name = $(this).html();
    $("#chat-input").attr("disabled", false);
    generate_message(name, 'self');
})

$("#chat-circle").click(function () {
    $("#chat-circle").toggle('scale');
    $(".chat-box").toggle('scale');
})

$(".chat-box-toggle").click(function () {
    $("#chat-circle").toggle('scale');
    $(".chat-box").toggle('scale');
})



function AddMessageLineSelf(msg) {
    var typeUser = "self";
    var color = "warning";


    INDEX++;
    var str = "";
    str += "<div id='cm-msg-" + INDEX + "' class=\"chat-msg " + typeUser + "\">";
    str += "          <span class=\"msg-avatar\">";
    str += "            <span class=\"badge badge-" + color + "\">Josh<\/span>";
    str += "          <\/span>";
    str += "          <div class=\"cm-msg-text\">";
    str += msg;
    str += "          <\/div>";
    str += "        <\/div>";
    $(".chat-logs").append(str);
    $("#cm-msg-" + INDEX).hide().fadeIn(300);
    if (type == self) {
        $("#chat-input").val('');
    }
    $(".chat-logs").stop().animate({ scrollTop: $(".chat-logs")[0].scrollHeight }, 1000);

}

function AddMessageLineUser(otherName, msg) {
    var typeUser = "user";
    var color = "info";
    

    INDEX++;
    var str = "";
    str += "<div id='cm-msg-" + INDEX + "' class=\"chat-msg " + typeUser + "\">";
    str += "          <span class=\"msg-avatar\">";
    str += "            <span class=\"badge badge-" + color + "\">" + otherName +  "<\/span>";
    str += "          <\/span>";
    str += "          <div class=\"cm-msg-text\">";
    str += msg;
    str += "          <\/div>";
    str += "        <\/div>";
    $(".chat-logs").append(str);
    $("#cm-msg-" + INDEX).hide().fadeIn(300);
    if (type == self) {
        $("#chat-input").val('');
    }
    $(".chat-logs").stop().animate({ scrollTop: $(".chat-logs")[0].scrollHeight }, 1000);

}




// TOASTER

function PopToast(title, msg) {
    $('#toaster').hide().fadeIn(300);
    $('#toaster').append(
        `<div class="card pb-3" style="width: 18rem;">
    <div class="card-body">
        <h5 class="card-title">${title}</h5>
        <p class="card-text">${msg}</p>
        <button onclick="closeToast()" class="btn btn-danger">Close</button>
    </div>
</div>`
    )

    setTimeout(() => {
        closeToast()
    }, 10000);
};

function PopNewToast(title, msg, color, icon) {
    $('#toaster').hide().fadeIn(300);
    $('#toaster').append(
        `<div class="bg-white border-l-4 border-${color}-300 p-4 py-6 rounded shadow-lg flex items-center justify-between mb-6">
            <span class="fa-stack fa-2x sm:mr-2 mb-3">
                <i class="fas fa-circle text-${color}-dark fa-stack-2x"></i>
                <i class="fas ${icon} fa-stack-1x text-white"></i>
            </span>
            <div class="sm:text-left text-center sm:mb-0 mb-3 w-128">
                <p class="font-bold mb-1 text-lg">${title}</p>
                <p class="text-grey-dark inline-block">${msg}</p>
            </div>
            <button onclick="closeToast()"> <i class="fas fa-times mx-4 fa-2x text-grey-darker"></i> </button>
        </div>`
    )

    //setTimeout(() => {
    //    closeToast()
    //}, 10000);
};

function closeToast() {
    $('#toaster').fadeOut(600);
    setTimeout(() => {
        $('#toaster').html('');
    }, 2000);
    
}