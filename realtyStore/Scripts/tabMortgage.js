

function ipoteka(price, pay, percent, years) {

    const i = parseFloat(+percent / 100 / 12);
    const n = parseFloat(+years * 12);
    const r = (+price - +pay) * ((i * Math.pow(1 + i, n)) / (Math.pow(1 + i, n) - 1));
    return r.toFixed(2);
}



const sliderPrice = document.getElementById("priceRange");
const outputPrice = document.getElementById("priceValue");
outputPrice.innerHTML = sliderPrice.value;

const sliderYears = document.getElementById("yearsRange");
const outputYears = document.getElementById("yearsValue");
outputYears.innerHTML = sliderYears.value;

const sliderPercent = document.getElementById("percentRange");
const outputPercent = document.getElementById("percentValue");
outputPercent.innerHTML = sliderPercent.value;

const sliderContribution = document.getElementById("contributionRange");
const outputContribution = document.getElementById("contributionValue");
outputContribution.innerHTML = sliderContribution.value;

const inputPrice = document.getElementById("inputPrice")
const inputContribution = document.getElementById("inputContribution")
const inputYears = document.getElementById("inputYears")

const outputPay = document.getElementById("pay")
//const buttonEl = document.getElementById('btn-calculate')

//buttonEl.onclick = function () {
//    if (+inputPrice.value >= 500000) {
//        document.getElementById('calculator');
//    }
//}

inputContribution.oninput = function () {

    outputContribution.innerHTML = this.value;
    sliderContribution.value = this.value;
    if (!this.value) {
        outputContribution.innerHTML = 0;
        sliderContribution.value = 0;
    }
    outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'
}

inputPrice.oninput = function () {
    if (+inputPrice.value >= 500000) {
        outputPrice.innerHTML = this.value;
        sliderPrice.value = this.value;
        outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'
    }
    
}

inputYears.oninput = function () {
    outputYears.innerHTML = this.value;
    sliderYears.value = this.value;
    outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'

}

sliderPrice.oninput = function () {

    outputPrice.innerHTML = this.value;
    outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'

}

sliderContribution.oninput = function () {
    outputContribution.innerHTML = this.value;
    outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'
}

sliderYears.oninput = function () {
    outputYears.innerHTML = this.value;
    outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'
}


sliderPercent.oninput = function () {
    outputPercent.innerHTML = this.value;
    outputPay.innerHTML = ipoteka(+outputPrice.innerHTML, +outputContribution.innerHTML, +outputPercent.innerHTML, +outputYears.innerHTML) + 'руб.'
}
