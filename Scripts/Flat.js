document.addEventListener('DOMContentLoaded', function () {
    const buttonEl = document.getElementById('showPhone');
        console.log(buttonEl);
    const phoneEl = document.getElementById('Phone');
    buttonEl.addEventListener('click', function (e) {
        buttonEl.style.display = 'none';
        phoneEl.style.display = 'block';
    })
})