let session = new Map();
let startDate = new Date().toLocaleString();

function getAge() {

    session.set("age", prompt("Пожалуйста, введите ваш возраст?"));

    if (session.get("age") >= 18) {

        alert("Приветствуем на LifeSpot! " + '\n' + "Текущее время: " + startDate);
    }
    else {
        alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
        window.location.href = "http://www.google.com";
    }
}

function handleSession() {

    session.set("userAgent", window.navigator.userAgent);
    session.set("startDate", startDate);

    return session;
}

let sessionLog = function logSession() {
    for (let result of session) {
        console.log(result);
    }
}

function searchResult() {
let elements = document.getElementsByClassName('video-container');

for (let i = 0; i <= elements.length; i++) {
    let videoText = elements[i].querySelector('h3').innerText;
    if (!videoText.toLowerCase().includes(search().toLowerCase())) {
            elements[i].style.display = 'none';
        } else {
            elements[i].style.display = 'inline-block';
        }
    }
}