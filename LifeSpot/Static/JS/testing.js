
let elements = document.getElementsByTagName('*');
let arr = [1, 2, 3]

arr.forEach(function (item, index, array) {
    console.log(item);
});
alert(`Количество элементов на странице:  ${elements.length}`);


const saveInput = function () {
    let currentInput = document.getElementsByTagName('input')[0].value.toLowerCase();

    alert('Последний ввод: ' + this.lastInput + '\n' + 'Текущий ввод: ' + currentInput);

    this.lastInput = currentInput;
}