function Comment() {

    this.author = prompt("What is your name?")
    if (this.author == null) {
        this.empty = true;
        return;
    }

    this.text = prompt("Add your rewiev");
    if (this.text == null) {
        this.empty = true;
        return;
    }

    this.date = new Date().toLocaleString();
}

function getComment() {

    let comment = new Comment();

    if (comment.empty) {
        return;
    }

    let enableRatings = confirm("Does your comment has raiting other users?");

    if (enableRatings) {
        let review = Object.create(comment);

        review.rate = 0;

        publishComment(review);
    }
    else {
        publishComment(comment);
    }
}

const publishComment = comment => {
    let rateCounter = '';

    if (comment.hasOwnProperty('rate')) {
        let commentId = Math.random();
        rateCounter = `<button id="${commentId}" style="border: none" onclick="addLike(this.id)">❤️ ${comment.rate}</button>`;
    }

    let elements = document.getElementsByClassName('reviews')[0].innerHTML += '<div class="comment-text">'
        + `<p><b>${comment.author}</b> <i>${comment.date} ${rateCounter}</i></p>`
        + `<p>${comment.text}</p>`
        + '</div >';
}

function addLike(id) {
    let element = document.getElementById(id);

    let array = element.innerText.split(' ');

    let resultNum = parseInt(array[array.length - 1], 10);

    resultNum++;

    array[array.length - 1] = `${resultNum}`;

    element.innerText = array.join(' ');
}