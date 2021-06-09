"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/activityHub")
    .build();

document.getElementById("sendButton").disabled = true; //disabling button untill connection is established

connection.on("ReceiveActivity", function (a) {

    let li = createLiNode();
    let paragraph = createParagraphNode(a.userName, a.activityOption.description);
    let img = createImageNode(a.activityOption.flag);

    appendLi(li, img, paragraph);
    
    document.getElementById("activitiesList").insertBefore(li, activitiesList.firstChild);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var userName = document.getElementById("userNameInput").value;
    var activityOptionId = parseInt(document.getElementById("activityOptionId").value);

    if (userName == "") {
        alert("Name must be filled out!");
    }
    else {
        connection.invoke("SendActivity", userName, activityOptionId)
            .catch(function (err) {
                return console.error(err.toString());
            });
    }

    event.preventDefault();
});

function createLiNode() {
    let li = document.createElement("li");
    li.classList = "activity-item";
    return li;
}

function createParagraphNode(userName, description) {
    let paragraph = document.createElement("P");
    paragraph.classList = "activity-item-text";
    paragraph.appendChild(document.createTextNode(userName + " " + description));
    return paragraph;
}

function createImageNode(src) {
    let img = document.createElement("img");
    img.src = src;
    return img;
}

function appendLi(li, img, paragraph) {
    li.appendChild(img);
    li.appendChild(paragraph);
    li.appendChild(document.createTextNode("You should do it too, its good for you!"));
}