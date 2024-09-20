const rangeInput = document.getElementById('rangeInput');
const numberInput = document.getElementById('numberInput');
const seedInput = document.querySelector("#seed");

let page = 0;
let isAvaliable = false;

function SetValueInBoundaries(value, min, max) {
    return Math.min(Math.max(value, min), max);
}

rangeInput.addEventListener('input', function () {
    numberInput.value = SetValueInBoundaries(rangeInput.value, 0, 10);
    rangeInput.value = SetValueInBoundaries(rangeInput.value, 0, 10);
});

numberInput.addEventListener('input', function () {
    numberInput.value = SetValueInBoundaries(numberInput.value, 0, 1000);
    rangeInput.value = SetValueInBoundaries(numberInput.value, 0, 10);
});

seedInput.addEventListener('input', function () {
    seedInput.value = SetValueInBoundaries(seedInput.value, 0, 1000);
});