
const realtyTypeEl = document.getElementById('realty-type-sale')
const squareEl = document.getElementById('square-sale')
const numRoomsDiv = document.getElementById('numRooms-sale')
realtyTypeEl.addEventListener('change', check)

function check(e) {
    if (e.target.value == 'Квартира' || e.target.value == "Дом") {
        squareEl.style.display = 'none';
        numRoomsDiv.style.display = 'block';
    } else if (e.target.value == 'Комната' || e.target.value == 'Койко-место' ) {
        squareEl.style.display = 'none';
        numRoomsDiv.style.display = 'none';
    } else {
        numRoomsDiv.style.display = 'none';
        squareEl.style.display = 'block';
    }
}


