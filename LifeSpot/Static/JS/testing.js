
let elements = document.getElementsByTagName('*');
let arr = [1, 2, 3]

arr.forEach(function (item, index, array) {
    console.log(item);
});
alert(`Количество элементов на странице:  ${elements.length}`);
