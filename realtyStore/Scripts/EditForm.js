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
    //console.log(+cityId - 1, selectCity[+cityId - 1])
    selectCity[+cityId - 1].selected = true;
})