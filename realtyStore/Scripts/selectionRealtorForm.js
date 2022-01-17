let statusType = document.getElementById('status-type')
let realtyType = document.getElementById('realty-type')
let floor = document.getElementById('floor');
let floors = document.getElementById('floors');
let square = document.getElementById('square');
let numRoom = document.getElementById('numberRoom');


function checkStatus(e) {
    if (statusType.value == "Купить" || statusType.value == "Продается") {
        for (let i = 0; i < realtyType.length; i++) {
            if (realtyType[i].value == "Койко-место") {
                realtyType[i].disabled = true;
            } else {
                realtyType[i].disabled = false;
            }
        }
    } else {
        for (let i = 0; i < realtyType.length; i++) {
            if (realtyType[i].value == "Участок") {
                realtyType[i].disabled = true;
            } else {
                realtyType[i].disabled = false;

            }
        }
    }
}

checkStatus();

statusType.addEventListener('change', checkStatus)
function checkType() {

    if (realtyType.value == 'Квартира' || realtyType.value == "Дом") {
        square.style.display = 'none';
        numRoom.style.display = 'block';
    } else if (realtyType.value == 'Комната' || realtyType.value == 'Койко-место') {
        square.style.display = 'none';
        numRoom.style.display = 'none';
    } else {
        numRoom.style.display = 'none';
        square.style.display = 'block';
    }

    if (realtyType.value == 'Участок') {
        floor.style.display = 'none'
        floors.style.display = 'none'
    } else {
        floor.style.display = 'block'
        floors.style.display = 'block'
    }
}
checkType();

realtyType.addEventListener('change', checkType)
