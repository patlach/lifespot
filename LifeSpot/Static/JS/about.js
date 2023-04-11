function getComment() {

    let comment = {};

    comment["username"] = prompt('Enter your name');
    if (comment["username"] == null) {
        return;
    }

    comment["commentText"] = prompt('Enter your review');
    if (comment["commentText"] == null) {
        return;
    }

    comment["date"] = new Date().toLocaleString();

    publishComment(comment);
}

const publishComment = comment => {
    let elements = document.getElementsByClassName('reviews')[0].innerHTML += '<div class="comment-text">'
        + `<p><b>${comment['username']}</b> <i>${comment['date']}</i></p>`
        + `<p>${comment['commentText']}</p>`
        + '</div >';
}