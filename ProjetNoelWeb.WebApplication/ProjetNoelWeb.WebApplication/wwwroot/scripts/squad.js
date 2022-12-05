﻿// function slist() {
//    var target = document.getElementById("sortlist");
//    target.classList.add("slist");
//    //let items = target.querySelectorAll("li.QuestionInstruction");
//    let items = target.getElementsByTagName("li");

//    current = null;

//    var index = 0;
//    // (B) MAKE ITEMS DRAGGABLE + SORTABLE
//    for (let i of items) {
//        // (B1) ATTACH DRAGGABLE
//        index++;
//        i.draggable = true;

//        // (B2) DRAG START - YELLOW HIGHLIGHT DROPZONES
//        i.ondragstart = (ev) => {
//            current = i;
//        };

//        // When we passed with item in mouse on other item
//        i.ondragenter = (ev) => {
//            if (i != current) {
//                i.classList.add("active");
//            }
//        };

//        // When we passed with item in mouse on other item
//        i.ondragleave = () => {
//            i.classList.remove("active");
//        };

//        // (B5) DRAG END - REMOVE ALL HIGHLIGHTS
//        i.ondragend = () => {
//            for (let it of items) {
//                it.classList.remove("active");
//            }
//        };

//        // (B6) DRAG OVER - PREVENT THE DEFAULT "DROP", SO WE CAN DO OUR OWN
//        i.ondragover = (evt) => {
//            evt.preventDefault();
//        };

//        // (B7) ON DROP - DO SOMETHING
//        i.ondrop = (evt) => {
//            evt.preventDefault();
//            if (i != current) {
//                let currentpos = 0,
//                    droppedpos = 0;
//                for (let it = 0; it < items.length; it++) {
//                    if (current == items[it]) {
//                        currentpos = it;
//                    }
//                    if (i == items[it]) {
//                        droppedpos = it;
//                    }
//                }
//                if (currentpos < droppedpos) {
//                    i.parentNode.insertBefore(current, i.nextSibling);
//                } else {
//                    i.parentNode.insertBefore(current, i);
//                }
//            }
//        };
//    }

//}

function addInput(name) {
    event.preventDefault();
    var ul = document.getElementById('sortlist'); // get the list 
    var i = document.createElement('i'); // create i 
    var li = document.createElement('li'); // Create parent div
    var inputListId = document.createElement('input'); // Create input
    var inputName = document.createElement('input');
    var inputUrl = document.createElement('input');
    var inputPrice = document.createElement('input');
    var inputIsTake = document.createElement('input');
    var inputListPosition = document.createElement('input');

    li.classList.add("roundedOrangeInput"); // Add class to parent div
    li.classList.add("bigInput"); // Add class to parent div

    if (name != "Introduction") {
        li.classList.add("QuestionInstruction"); // Add class to parent div
    }

    i.onclick = deleteInput; // When click on i call deleteInput
    i.classList.add("fas"); // Add trash style to i
    i.classList.add("fa-trash-alt"); // Add trash style to i

    inputListPosition.name = 'inputListPosition';
    inputListPosition.type = 'number';
    inputListPosition.value = name;

    inputIsTake.name = "inputIsTake"
    inputIsTake.type = "hidden"
    inputIsTake.value = "False"

    inputListId.name = "inputListId"
    inputListId.type = "hidden"
    inputListId.value = ""

    //input.placeholder = "Ajouter un " + name; // Add placeholder in input
    //input.name = "inputQuestionInstruction";

    inputName.placeholder = "Entrer votre nom d'idée"
    inputName.name = "inputListName"
    inputName.style.marginTop = "auto";
    inputName.style.marginBottom = "auto";

    inputUrl.placeholder = "Entrer l'url vers votre idée"
    inputUrl.name = "inputListUrl"
    inputUrl.style.marginTop = "auto";
    inputUrl.style.marginBottom = "auto";

    inputPrice.placeholder = "Entrer le prix de votre idée"
    inputPrice.name = "inputListPrice"
    inputPrice.type = "number"
    inputPrice.style.marginTop = "auto";
    inputPrice.style.marginBottom = "auto";

    //p.textContent = name + " : ";
    //p.style.marginTop = "auto";
    //p.style.marginBottom = "auto";

    //li.appendChild(p);
    li.appendChild(inputListId)
    li.appendChild(inputListPosition);
    li.appendChild(inputIsTake); // Add input to div
    li.appendChild(inputName);
    li.appendChild(inputUrl);
    li.appendChild(inputPrice);
    li.appendChild(i);


    // If it's a introduction field
    if (name == 'Introduction') {
        // Check if there is already one intruction field
        // var firstIntroduction = document.querySelector("input[value='Introduction']");

        var firstChild = ul.childNodes[0];
        ul.insertBefore(li, firstChild);
    }
    else {
        var lastChild = ul.children[ul.children.length - 1];
        ul.insertBefore(li, lastChild);
    }
    slist();
}

function deleteInput(caller) {
    if (caller.srcElement == undefined) {
        caller.parentNode.remove();
    }
    else {
        caller.srcElement.parentNode.remove(); // find the parent div and remove it
    }
}