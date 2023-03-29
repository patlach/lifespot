let map = new Map();

map.set('UserData', window.navigator.userAgent);
map.set('DateTime', new Date());
map.set('Age', prompt('Enter your age'));

if (map.get('Age') < 18) {
    alert("Only over 18 years of age can use this site. You will redirect to google.com.");
    window.location.href = "http://www.google.com";
}
else {
    alert('Welcome to LifeSpot');
    map.set('DateTime', new Date());
}

for (let element of map) {
    console.log(element);
}
