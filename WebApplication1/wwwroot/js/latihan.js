//const { data, error } = require("jquery");

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

//CREATE FUNCTION
//$(document).ready(function () {
//    $("#insertAccess").on('click', '#btnInsert', function () {
//        $("#insertModal").modal("show");
//        $("#insertForm").on('submit', function () {
//            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
//            obj.NIK = $("#nik").val();
//            obj.FirstName = $("#firstName").val();
//            obj.LastName = $("#lastName").val();
//            obj.Phone = $("#phone").val();
//            obj.BirthDate = $("#birthDate").val();
//            obj.Salary = $("#salary").val();
//            obj.Email = $("#email").val();
//            obj.Password = $("#password").val();
//            obj.Degree = $("#degree").val();
//            obj.GPA = $("#gpa").val();
//            obj.University = $("#university").val();
//            //var json = ;
//            //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
//            $.ajax({
//                type: "POST",
//                url: "https://localhost:44361/API/accounts/Register",
//                data: JSON.stringify(obj),
//                contentType: "application/json; charset=utf-8",
//                datatype: "json",
//                beforeSend: function () {
//                    $("#insert").val("Inserting");
//                },
//                success: function (data) {
//                    //$('#insertForm')[0].reset();
//                    $('#insert').val("Insert");
//                    //$("#insertModal").modal("hide");
//                    $("#myTable").DataTable().ajax.reload();

//                }
//            })
//        })
//    })
//}) 
//function Insert() {
//}

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
                

                "render": function (data, type, row) {
                    //var data = row.data();
                    return '<button class="btn btn-primary" data-bs-toggle="modal" type="button" data-id="' + row.nik + '" data-firstname="' + row.firstName + '" data-lastname="' + row.lastName + '" data-role="' + row.role
                        + '" data-phone=" +62' + row.phone.substr(1) + '" data-date="' + row.birthDate.slice(0,10) + '" data-salary="' + row.salary + '" data-email="' + row.email + '" data-degree="' + row.degree
                        + '" data-gpa="' + row.gpa + '" data-university="' + row.university
                        + '" data-bs-target="#staticBackdrop">Details</button >  <button id="btnEdit" type="button"  class="btn btn-secondary"> Edit </button>  <button id="btnDelete" type="button"  class="btn btn-warning"> Delete </button>'
                }
            }
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

    t.on('order.dt search.dt', function () {
        t.column(0, {search:'applied', order:'applied'}).nodes().each( function (cell, i) {
            cell.innerHTML = i+1;
        } );
    }).draw();

    //DELETE
    $("#myTable tbody").on('click', '#btnDelete', function () {
        var data = t.row($(this).parents('tr')).data();
        $("#deleteModal").modal("show");
        console.log(data);
        $("#deleteModal").on('click', '#delete', function () {
            //console.log(data);
            //var nik = ;
            $.ajax({
                type: "DELETE",
                url: "https://localhost:44361/API/persons/" + data.nik,
                success: function (result) {
                    console.log(data.nik);
                    //$("#deleteModal").modal("hide");
                    //$("#deleteModal").ajax.reload();
                    //$("myTable").DataTable().ajax.reload();
                }
            })

            $.ajax({
                type: "DELETE",
                url: "https://localhost:44361/API/educations/" + data.educationId,
                success: function (result) {
                    console.log(data.nik);
                    $("#deleteModal").modal("hide");
                    //$("#deleteModal").ajax.reload();
                    $("myTable").DataTable().ajax.reload();
                }
            })
        })
    })

    //REGISTRATION
    $("#insertAccess").on('click', '#btnInsert', function () {
        $("#insertModal").modal("show");
        $("#insertForm").on('submit', function () {
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
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                beforeSend: function () {
                    $("#insert").val("Inserting");
                },
                success: function (data) {
                    //$('#insert').val("Insert");
                    //t.ajax.reload();
                    alert("Success submit");
                }
            })
        })
    })


    //UPDATETE
    $("#myTable tbody").on('click', '#btnEdit', function () {
        var data = t.row($(this).parents('tr')).data();

        $("#nikE").val(data.nik);
        $("#firstNameE").val(data.firstName);
        $("#lastNameE").val(data.lastName);
        $("#phoneE").val(data.phone);
        $("#birthDateE").val(data.birthDate);
        $("#salaryE").val(data.salary);
        $("#emailE").val(data.email);
        $("#degreeE").val(data.degree);
        $("#gpaE").val(data.gpa);
        $("#universityE").val(data.university);
        $("#editModal").modal("show");
        //console.log(data);
        $("#editModal").on('click', '#edit', function () {
            console.log(data);
            //var nik = ;
            var obj1 = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            obj1.NIK = $("#nikE").val();
            obj1.FirstName = $("#firstNameE").val();
            obj1.LastName = $("#lastNameE").val();
            obj1.Phone = $("#phoneE").val();
            obj1.BirthDate = $("#birthDateE").val();
            obj1.Salary = $("#salaryE").val();
            obj1.Email = $("#emailE").val();
            var obj2 = new Object();
            obj2.Id = data.educationId;
            obj2.Degree = $("#degreeE").val();
            obj2.GPA = $("#gpaE").val();
            obj2.University_Id = $("#universityE").val();
            $.ajax({
                type: "PUT",
                url: "https://localhost:44361/API/persons",
                data: JSON.stringify(obj1),
                contentType: "application/json; charset=utf-8",
                datatype: "json"
                //beforeSend: function () {
                //    $("#edit").val("Saving...");
                //},
                //success: function (data) {
                //    //$('#insert').val("Insert");
                //    //t.ajax.reload();
                //    alert("Success submit");
                //}
            }).done((result) => {
                $.ajax({
                    type: "PUT",
                    url: "https://localhost:44361/API/educations",
                    data: JSON.stringify(obj2),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    beforeSend: function () {
                        $("#edit").val("Saving...");
                    }
                    //,success: function (data) {
                    //    //$('#insert').val("Insert");
                    //    //t.ajax.reload();
                    //    alert("Success submit");
                    //}
                }).done((result) => {
                    alert("Update Success");
                    $("myTable").DataTable().ajax.reload();
                }).fail((error) => {
                    alert("Update Error");
                })
            })
        })
    })



    //function Insert() {
    //    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //    obj.NIK = $("#nik").val();
    //    obj.FirstName = $("#firstName").val();
    //    obj.LastName = $("#lastName").val();
    //    obj.Phone = $("#phone").val();
    //    obj.BirthDate = $("#birthDate").val();
    //    obj.Salary = $("#salary").val();
    //    obj.Email = $("#email").val();
    //    obj.Password = $("#password").val();
    //    obj.Degree = $("#degree").val();
    //    obj.GPA = $("#gpa").val();
    //    obj.University = $("#university").val();
    //    //var json = ;
    //    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    //    $.ajax({
    //        type: "POST",
    //        url: "https://localhost:44361/API/accounts/Register",
    //        data: JSON.stringify(obj),
    //        contentType: "application/json; charset=utf-8",
    //        datatype: "json",
    //        //beforeSend: function () {
    //        //    $("#insert").val("Inserting");
    //        //},
    //        success: function (data) {
    //            //$('#insertForm')[0].reset();
    //            //$('#insert').val("Insert");
    //            //$("#insertModal").modal("hide");
    //            $("myTable").DataTable().ajax.reload();
    //        }
    //    })
    //}
})

