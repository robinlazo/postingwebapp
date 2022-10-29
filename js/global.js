const switchNmlPassButton = document.querySelector(".normalpass-field");
const switchCfmPassButton = document.querySelector(".confirmpass-field");
const replyButtons = document.querySelectorAll(".reply-button");


function switchPasswordVisibility(id) {
    let elementToChange = document.querySelector(`#${id}`); 

    if (elementToChange.dataset.ispassvisible == "false") {
        elementToChange.setAttribute("type", "password");
        elementToChange.setAttribute("data-ispassvisible", "true");
    } else {
        elementToChange.setAttribute("type", "text");
        elementToChange.setAttribute("data-ispassvisible", "false");
    }
}

function switchRepliesVisibility() {
    let replyId = this.dataset.replyId;
    let selectedReply = document.querySelector(replyId);

    if (selectedReply.classList.contains("reply-hidden")) {
        selectedReply.classList.remove("reply-hidden");
    } else {
        selectedReply.classList.add("reply-hidden");
    }
    
}


replyButtons.forEach(replyButton => replyButton.addEventListener("click", switchRepliesVisibility));
switchNmlPassButton?.addEventListener("click", () => switchPasswordVisibility("password"));
switchCfmPassButton?.addEventListener("click", () => switchPasswordVisibility("confirm"));