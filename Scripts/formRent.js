
const realtyTypeRentEl = document.getElementById('realty-type')
const squareRentEl = document.getElementById('square')
const numRoomsRentDiv = document.getElementById('numRooms')
realtyTypeRentEl.addEventListener('change', check)

function check(e) {
    if (e.target.value == 'Квартира' || e.target.value ==  "Дом") {
        squareRentEl.style.display = 'none';
        numRoomsRentDiv.style.display = 'block';
    } else if (e.target.value == 'Комната' || e.target.value == 'Койко-место' ) {
        squareRentEl.style.display = 'none';
        numRoomsRentDiv.style.display = 'none';
    } else {
        numRoomsRentDiv.style.display = 'none';
        squareRentEl.style.display = 'block';
    }
}