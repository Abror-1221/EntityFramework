// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const judul = document.querySelectorAll("button");
//console.log(judul);


function changeMargin1() {
    // Create our stylesheet
    var style = document.createElement('style');
    style.innerHTML =
        '#a {' +
        'margin-bottom: 30px;' +
        'border : 1px solid #808080;' +
        '}';

    // Get the first script tag
    var ref = document.querySelector('script');

    // Insert our new styles before the first script tag
    ref.parentNode.insertBefore(style, ref);
    //const body = document.querySelectorAll(".col-6 div")[1];
    //body.style.backgroundColor = 'red';
}

function changeMargin2() {
    // Create our stylesheet
    var style = document.createElement('style');
    style.innerHTML =
        '#a {' +
        'margin-bottom: 0px;' +
        'border : none;' +
        '}';

    // Get the first script tag
    var ref = document.querySelector('script');

    // Insert our new styles before the first script tag
    ref.parentNode.insertBefore(style, ref);
    //const body = document.querySelectorAll(".col-6 div")[1];
    //body.style.backgroundColor = 'red';
}

var color = ["#EC7063", "#AF7AC5", "#5DADE2", "#48C9B0", "#F4D03F", "#EB984E", "#AAB7B8", "#FDFEFE"];
var i = 0;
document.querySelector('button:nth-child(7)').addEventListener('click',
    function (){
        i = 1 < color.length ? ++i : 0;
        document.querySelector('#container1').style.backgroundColor = color[i];
    })

$('.btnBgr').click(function () {
    $('#container1').css('background-color', 'red');
})





