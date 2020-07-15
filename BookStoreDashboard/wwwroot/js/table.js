function Toggle(event) {
    var row = document.getElementById(`book-` + event.target.id);
    if (row.classList.contains("hide")) {
        row.classList.remove("hide");
        event.target.innerText = "Hide";
    } else {
        row.classList.add("hide");
        event.target.innerText = "Details";
    }
}