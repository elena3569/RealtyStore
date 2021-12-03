document.addEventListener("DOMContentLoaded", () => {

    

    status = document.getElementById("statusTypeVal").value;
    realtyType = document.getElementById("RealtyTypeVal").value;
    cityId = document.getElementById("CityIdVal").value;
    selectRealtyType = document.getElementById("realty-type");

    selectCity = document.getElementById("CityId");
    selectStatusType = document.getElementById("status-type");
    for (let i = 0; i < selectRealtyType.length; i++){
        if (selectRealtyType[i].value == realtyType) {
            selectRealtyType[i].selected = true;
        }
    }
    for (let i = 0; i < selectStatusType.length; i++) {
        if (selectStatusType[i].value == status) {
            selectStatusType[i].selected = true;
        }
    }
    selectCity[+cityId - 1].selected = true;

    let lastname = document.getElementById('lastname').value;
    document.getElementById('lastname').addEventListener('input', (e) => {
        lastname = e.target.value;
        check();
    })
    let firstname = document.getElementById('firstname').value;
    document.getElementById('firstname').addEventListener('input', (e) => {
        firstname = e.target.value;
        check();
    })
    let passport = document.getElementById('passport').value;
    document.getElementById('passport').addEventListener('input', (e) => {
        passport = e.target.value;
        check();
    })
    let phone = document.getElementById('phone').value;
    document.getElementById('phone').addEventListener('input', (e) => {
        phone = e.target.value;
        check();
    })
    let address = document.getElementById('address').value;
    document.getElementById('address').addEventListener('input', (e) => {
        address = e.target.value;
        check();
    })

    function check() {
        if (lastname && firstname && phone && passport && address) {
            document.getElementById('btnsave').disabled = false;
        }
    }
})