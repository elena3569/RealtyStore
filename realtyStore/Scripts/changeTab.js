  
    const links = document.querySelectorAll('.nav-link');
    const forSaleForm = document.getElementById('for-sale');
    const forRentForm = document.getElementById('for-rent');
    const forSaleMortgageForm = document.getElementById('for-sale-mortgage');
    const forRentDailyForm = document.getElementById('for-rent-daily');

    links.forEach(link => link.addEventListener('click', clickHandler));
   

    function clickHandler(event) {
        changeTab(event);
        changeActiveClass(event);
        console.log(event.target.value)
    }

    function changeActiveClass(event) {
        document.querySelector('.active').classList.remove('active');
        event.target.classList.add('active');
    }

    function changeTab(event) {
        switch (event.target.textContent) {
            case 'Снять':
                forSaleMortgageForm.style.display = 'none';
                forRentForm.style.display = 'block';
                forRentDailyForm.style.display = 'none';
                forSaleForm.style.display = 'none';
                break;
            case 'Посуточно':
                forSaleMortgageForm.style.display = 'none';
                forRentForm.style.display = 'none';
                forRentDailyForm.style.display = 'block';
                forSaleForm.style.display = 'none';
                break;
            case 'Купить':
                forSaleMortgageForm.style.display = 'none';
                forRentForm.style.display = 'none';
                forRentDailyForm.style.display = 'none';
                forSaleForm.style.display = 'block';
                break;
            case 'Ипотека':
                forSaleMortgageForm.style.display = 'block';
                forRentForm.style.display = 'none';
                forRentDailyForm.style.display = 'none';
                forSaleForm.style.display = 'none';
                break;
        }

    }
