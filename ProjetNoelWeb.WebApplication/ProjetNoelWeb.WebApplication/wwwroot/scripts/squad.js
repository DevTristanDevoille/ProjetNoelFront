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
    var textAreaCommentaire = document.createElement('input');
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

    inputIsTake.name = "inputIsTake"
    inputIsTake.type = "hidden"
    inputIsTake.value = "False"

    textAreaCommentaire.name = "textAreaCommentaire"
    textAreaCommentaire.type = "hidden"
    textAreaCommentaire.value = "";

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

    var lastChild = ul.children[ul.children.length - 1];
    ul.insertBefore(li, lastChild);
}

function deleteInput(caller) {
    if (caller.srcElement == undefined) {
        caller.parentNode.remove();
    }
    else {
        caller.srcElement.parentNode.remove(); // find the parent div and remove it
    }
}