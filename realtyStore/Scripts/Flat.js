document.querySelector('.btn-heart').addEventListener('click', (e) => {
    e.preventDefault();
    $.ajax({
                url: `@Url.RouteUrl(new { controller = "Home", action = "toogleFavorite"})?id=${e.target.parentNode.id}`,
                success: function (partialView) {
                    $(`#${e.target.parentNode.id}`).html(partialView);
                }
        });
});

document.addEventListener('DOMContentLoaded', function () {
    const buttonEl = document.getElementById('showPhone');
    const phoneEl = document.getElementById('Phone');
    const carouselItems = document.querySelectorAll('.item');
    const prev = document.querySelector('.left');
    const next = document.querySelector('.right');
    const indicators = document.querySelectorAll('button[name="indicator"]');

    buttonEl.addEventListener('click', function (e) {
        buttonEl.style.display = 'none';
        phoneEl.style.display = 'block';
    })

    for (var i = 0; i < indicators.length; i++) {
        indicators[i].addEventListener('click', e => {
            activeList = document.querySelectorAll('.active');
            for (var item of activeList) {
                item.classList.remove('active');
            }
            document.querySelector(`button[data-index="${e.target.dataset.index}"]`).classList.add('active');
            document.querySelector(`div[data-index="${e.target.dataset.index}"]`).classList.add('active');
        })
    }

    prev.addEventListener('click', () => {
        changeSlide(-1);
    })
    next.addEventListener('click', () => {
        changeSlide(1);
    })

    function changeSlide(inc) {
        newSlideIndex = +document.querySelector('.active').dataset.index + inc;
        console.log(newSlideIndex)
        if (newSlideIndex == carouselItems.length) {
            newSlideIndex = 0;
        }
        if (newSlideIndex == -1) {
            newSlideIndex = carouselItems.length-1;
        }
        activeList = document.querySelectorAll('.active');
        for (var item of activeList) {
            item.classList.remove('active');
        }
        document.querySelector(`button[data-index="${newSlideIndex}"]`).classList.add('active');
        document.querySelector(`div[data-index="${newSlideIndex}"]`).classList.add('active');
        
    }

})
