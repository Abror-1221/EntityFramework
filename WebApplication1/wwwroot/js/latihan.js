//1 dimensi
let array = [1, 2, 3, 4];
//multi dimensi
let arrayMultiDimensi = ['a', 'b', 'c', 1, 2, [3, 4, 5], true];
//console.log(array);
//console.log(arrayMultiDimensi[5]);
//add array member in the last order
array.push("halo");
//console.log(array);
//Remove last value from array
array.pop();

//console.log(array)
//array.shift();

let student = {
    name: "jono",
    age: 18,
    hobby: ['makan', 'minum']
}
//console.log(student.name);

let user = {};
user.name = "nathan";
user.lokasi = "jakarta";
//console.log(user);

//arrow function
const hitung = (num1, num2) => num1 + num2;
//console.log(hitung(2, 3));

const animals = [
    { name: "taro", species: "cat", kelas: { name: "mamalia"}},
    { name: "dandan", species: "dog", kelas: { name: "vertebrata"}},
    { name: "bimbim", species: "cat", kelas: { name: "mamalia" } }
    ]
//console.log(animals);

let onlyCat = animals.filter(x => x.species === 'cat');
//console.log(onlyCat);

let Cat = [];
for (let i = 0; i < animals.length; i++) {
    if (animals[i].species === 'cat') {
        Cat.push(animals[i]);
    }
}
//console.log(Cat);

//!!!
let overMamal = [];
for (var i = 0; i < animals.length; i++) {
    if (animals[i].kelas.name !== 'mamalia') {
        overMamal.push(animals[i])
        overMamal[i].kelas.name = 'non mamalia';
    }
    else {
        overMamal.push(animals[i]);
    }
    
}
//console.log(animals);
//console.log(overMamal);

//ajax
//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon"
//}).done((hasil) => {
//    console.log(hasil);
//    //console.log(hasil.results[0]);
//    var text = "";
    
//    $.each(hasil.results, function (key, val) {
//        text += `<tr>
//                    <td>${val.name}</td>
//                    <td><button type="button" class="btn btn-primary" data-toggle="modal" onclick="detail('${val.url}')" data-target="#exampleModal">
//                    Detail</button>
//                    </td>
//                 </tr>`;
//    });
//    $(".tabelSW").html(text);
//}).fail((error) => {
//    console.log(error);
//});

(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()

function detail(stringURL) {
    $.ajax({
        url: stringURL
    }).done((hasil) => {
        //console.log(hasil);
        //console.log(hasil.results[0]);
        var dataPokemon = "";
        dataPokemon += `<p>Pokemon Name : ${hasil.name}</p>
                        <p>Moves        : ${hasil.moves[0].move.name}</p>
                        <p>Height       : ${hasil.height}</p>
                        <p>Weight       : ${hasil.weight}</p>
                        <p><img src=${hasil.sprites.front_default} width="200" height="200"></p>`;
                                        
        $(".modal-body").html(dataPokemon);
    }).fail((error) => {
        console.log(error);
    });
}


function Insert() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.NIK = $("#nik").val();
    obj.FirstName = $("#firstName").val();
    obj.LastName = $("#lastName").val();
    obj.Phone = $("#phone").val();
    obj.BirthDate = $("#birthDate").val();
    obj.Salary = $("#salary").val();
    obj.Email = $("#email").val();
    obj.Password = $("#password").val();
    obj.Degree = $("#degree").val();
    obj.GPA = $("#gpa").val();
    obj.University = $("#university").val();
    //var json = ;
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        type: "POST",
        url: "https://localhost:44361/API/accounts/Register",
        data: JSON.stringify(obj),
        contentType : "application/json; charset=utf-8",
        datatype: "json",
        success: function (result) {
            $("#insertForm").DataTable().ajax.reload(null, false)
        }
    }).done((result) => {
        alert("Submit Succeess")
        //$("#insertForm").DataTable().ajax.reload(null, false)
        //setTimeout(alert.bind(null, "The paragraph gone!"));
    }).fail((error) => {
        alert("Submit Error")
    })
}

//DataTables
$(document).ready(function () {
    
    var t = $("#myTable").DataTable({
        "ajax": {
            "url": "https://localhost:44361/API/accounts/UserData",
            "datatype": "json",
            "dataSrc" : ""
        },
        dom: 'lBfrtip',
        buttons: [
            'excel'
        ],
        "columns": [
            { "data": null },
            { "data": "firstName" },
            { "data": "lastName" },
            { "data": "phone",
                render: function (data, type, row) {
                    return '+62' + data.substr(1)
                }
            },
            { "data": "salary" },
            { "data": null,
                //"data": 
                //    {
                //        "buttons":
                //        {
                //            text: 'Test'
                //            //action: function (e, dt, node, config) {
                //            //    dt.ajax.reload();
                //            //}
                //        }
                //    }
                //}

                "render": function (data, type, row) {
                    //var data = row.data();
                    return '<button class="btn btn-primary" data-bs-toggle="modal" type="button" data-id="' + row.nik + '" data-firstname="' + row.firstName + '" data-lastname="' + row.lastName + '" data-role="' + row.role
                        + '" data-phone=" +62' + row.phone.substr(1) + '" data-date="' + row.birthDate + '" data-salary="' + row.salary + '" data-email="' + row.email + '" data-degree="' + row.degree
                        + '" data-gpa="' + row.gpa + '" data-university="' + row.university + '" data-bs-target="#staticBackdrop">Details</button >'
                }
                //"responsive": {
                //    "details": {
                //        "display": $.fn.dataTable.Responsive.display.modal({
                //            "header": function (row) {
                //                var data = row.data();
                //                return 'Details for ' + data[0] + ' ' + data[1];
                //            }
                //        }),
                //        "renderer": $.fn.dataTable.Responsive.renderer.tableAll()
                //    }
                //}

            }
            //,{ "data": "lastName" }
        ],
        "columnDefs": [{
            "searchable": false,
            "orderable": true,
            "targets": [0, 5]
        }]
        ,"order": [[1, 'asc']]
    });

    $("#staticBackdrop").on('show.bs.modal', function (e) {
        let triggerLink = $(e.relatedTarget);
        let id = triggerLink[0].dataset['id'];
        let name1 = triggerLink[0].dataset['firstname'];
        let name2 = triggerLink[0].dataset['lastname'];
        let role = triggerLink[0].dataset['role'];
        let phone = triggerLink[0].dataset['phone'];
        let date = triggerLink[0].dataset['date'];
        let salary = triggerLink[0].dataset['salary'];
        let email = triggerLink[0].dataset['email'];
        let degree = triggerLink[0].dataset['degree'];
        let gpa = triggerLink[0].dataset['gpa'];
        let univ = triggerLink[0].dataset['university'];

        $("#staticBackdropLabel").text(name1 + " " + name2);
        $(this).find(".modal-body").html("<p>NIK : " + id
            + "</p> <p>First Name : " + name1
            + "</p> <p>Last Name  : " + name2
            + "</p> <p>Role       : " + role
            + "</p> <p>Phone      : " + phone
            + "</p> <p>Birth Date : " + date
            + "</p> <p>Salary     : " + salary
            + "</p> <p>Email      : " + email
            + "</p> <p>Degree     : " + degree
            + "</p> <p>GPA        : " + gpa
            + "</p> <p>University : " + univ + "</p>");

    });

    //$('#myTable').on('click', '#insert', function () {
    //    var name = $('td', this).eq(2).text();
    //    $('#exampleModal').modal("show");
    //    $('.modal-body').text(name);
    //});

    //$("#myTable").on('click', '#insert', function () {

    //    // show Modal
    //    $('#exampleModal').modal('show');
    //});

    t.on('order.dt search.dt', function () {
        t.column(0, {search:'applied', order:'applied'}).nodes().each( function (cell, i) {
            cell.innerHTML = i+1;
        } );
    } ).draw();
})