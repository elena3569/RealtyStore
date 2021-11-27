const realtyTypeDailyEl = document.getElementById('realty-type-daily')
const realtyTypeRentEl = document.getElementById('realty-type-rent')
const realtyTypeSaleEl = document.getElementById('realty-type-sale')

const numRoomsEl = document.getElementById('numRooms')
const squreEl = document.getElementById('squre')
const floorEl = document.getElementById('floor')

document.getElementById('status-type').addEventListener('change', (e) => {
    switch (e.target.value) {
        case 'Сдается посуточно':
            realtyTypeDailyEl.style.display = 'block';
            realtyTypeRentEl.style.display = 'none';
            realtyTypeSaleEl.style.display = 'none';
            break;
        case 'Сдается':
            realtyTypeDailyEl.style.display = 'none';
            realtyTypeRentEl.style.display = 'block';
            realtyTypeSaleEl.style.display = 'none';
            break;
        case 'Продается':
            realtyTypeDailyEl.style.display = 'none';
            realtyTypeRentEl.style.display = 'none';
            realtyTypeSaleEl.style.display = 'block';
            break;
    }
})

realtyTypeDailyEl.addEventListener('change', (event) => {
    if (event.target.value == 'Комната' || event.target.value == 'Койко-место') {
        numRooms.style.display = 'none';
    } else {
        numRooms.style.display = 'block';
    }
})


function check(e) {
    if (e.target.value == 'Гараж' || e.target.value == 'Участок' || e.target.value == 'Здание') {
        floorEl.style.display = 'none'
    } else {
        floorEl.style.display = 'block'
    }

    if (e.target.value == 'Комната' || e.target.value == 'Койко-место') {
        squreEl.style.display = 'none';
        numRooms.style.display = 'none';
    }

    if (e.target.value == 'Квартира') {
        squreEl.style.display = 'none';
        numRooms.style.display = 'block';
    }  else {
        numRooms.style.display = 'none';
        squreEl.style.display = 'block';
    }
}

realtyTypeRentEl.addEventListener('change', check)

realtyTypeSaleEl.addEventListener('change', check)

