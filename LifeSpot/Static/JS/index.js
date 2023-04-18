
function handleSession(sessionLog, checkAge) {

    if (window.sessionStorage.getItem("startDate") == null) {
        window.sessionStorage.setItem("startDate", new Date().toLocaleString());
    }

    if (window.sessionStorage.getItem("userAgent") == null) {
        window.sessionStorage.setItem("userAgent", window.navigator.userAgent);
    }

    if (window.sessionStorage.getItem("age") == null) {
        window.sessionStorage.setItem("age", prompt("Пожалуйста, введите ваш возраст?"));
        checkAge(true);
    }
    else {
        checkAge(false);
    }

    sessionLog();
}

const checkAge = function (visit) {
    if (window.sessionStorage.getItem("age") >= 18) {
        if (visit) {
            alert("Приветствуем на LifeSpot! " + '\n' + "Текущее время: " + new Date().toLocaleString());
        } 
    }
    else {
        alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
        window.location.href = "http://www.google.com";
    }
}

let sessionLog = function logSession() {
    console.log(window.sessionStorage.age);
    console.log(window.sessionStorage.userAgent);
    console.log(window.sessionStorage.startDate);
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