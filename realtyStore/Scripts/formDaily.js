
const realtyTypeDailyEl = document.getElementById('realty-type-daily')
const numRoomsDailyDiv = document.getElementById('numRooms-daily')
realtyTypeDailyEl.addEventListener('change', check)

function check(event) {
    if (event.target.value == 'Комната' || event.target.value == 'Койко-место' ) {
        numRoomsDailyDiv.style.display = 'none';
    } else {
        numRoomsDailyDiv.style.display = 'block';
    } 
}


