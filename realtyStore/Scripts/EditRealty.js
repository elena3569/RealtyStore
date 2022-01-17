document.addEventListener("DOMContentLoaded", () => {

    if (document.getElementById('typeForm').value == 'Edit') {

        statusRealty = document.getElementById("statusTypeRealty").value;
        newStatus = document.getElementById("status-type-realty");
        if (statusRealty == 'Сдается' || statusRealty == 'Сдается посуточно')
        {
            document.getElementById('btn').disabled = true;

            for (let i = 0; i < newStatus.length; i++) {
                if (newStatus[i].value == 'Сдано') {
                    newStatus[i].selected = true;
                }
            }
            document.getElementById('date').style.display = 'block';
            dateValue = document.getElementById("dateValue").addEventListener('input', (e) => {
                if (!e.target.value || Date.parse(e.target.value) <= new Date()) {
                    document.getElementById('error').style.display = 'block';
                } else {
                    document.getElementById('error').style.display = 'none';
                    document.getElementById('btn').disabled = false;
                }
            });
        }

        if (statusRealty == 'Продается') {
            for (let i = 0; i < newStatus.length; i++) {
                if (newStatus[i].value == 'Продано') {
                    newStatus[i].selected = true;
                }
            }
            document.getElementById('date').style.display = 'none';
        }
    }
    
})