
function showModal(modalName, hf, idReserva) {
    $("#" + modalName).css({ 'display': "block" });
    $("#" + hf).val(idReserva);
}

function validaFecha90(source, arguments) {
    var txt1 = document.getElementById("txtFechaInicio");
    var txt2 = document.getElementById("txtFechaFin");
    var dias = restaFechas(txt1.value, txt2.value);

    if (dias > 90) {
        arguments.IsValid = false;
        return;
    } else {
        arguments.IsValid = true;
        return true;
    }
}


// Función para calcular los días transcurridos entre dos fechas
restaFechas = function (f1, f2) {
    var aFecha1 = f1.split('/');
    var aFecha2 = f2.split('/');
    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
    var dif = fFecha2 - fFecha1;
    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
    return dias;
}

//function showimagepreview(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();
//        reader.onload = function (e) {
//            document.getElementsByTagName("img")[0].setAttribute("src", e.target.result);
//        }
//        reader.readAsDataURL(input.files[0]);
//    }
//}


function showimagepreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementsByTagName("img")[2].setAttribute("src", e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

//function showimagepreview(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();
//        reader.onload = function (e) {

//            //var foto = document.getElementById('<%= imgFoto.ClientID %>');
//            //foto.setAttribute("src", e.target.result);

//            //document.getElementsByClassName("imgFotoCochera").setAttribute("src", e.target.result);
//            document.getElementById("ContentPlaceHolder_Principal_Base_ContentPlaceHolder_Principal_imgFoto").setAttribute("src", e.target.result);
//        }
//        reader.readAsDataURL(input.files[0]);
//    }
//}

//function pageLoad() {


//    $(document).ready(function () {
//        //carga FOTO
//        $("#fuFoto").on('change', function () {

//            var file = document.querySelector('#<%=fuFoto.ClientID %>');
           
//                var preview = document.querySelector("#img");
//                file = file.files[0];
//                var reader = new FileReader();
//                reader.onloadend = function () {
//                    preview.src = reader.result;
//                }
//                if (file) {
//                    reader.readAsDataURL(file);
//                } else {
//                    preview.src = "";
//                }
//        });

//    });
//}


function LimpiaControles() {
    $("input[type=text]").val("");
    $("select").val("");
}

function mostrarImagen(elem) {
    $("#imgFoto").attr('src', elem.value);
}





// A $( document ).ready() block.
$(document).ready(function () {
    $('select').material_select();
    //$('select:([multiple])').material_select();
    $('.modal-trigger').leanModal();

    if ($("#txtHorarioInicio").length && $("#txtHorarioFin").length && $("#txtFechaInicio").length && $("#txtFechaFin").length) {
        $("#txtHorarioInicio,#txtHorarioFin,#txtFechaInicio,#txtFechaFin").keyup(function () {
            if ($("input[id$='txtHorarioInicio']").val().length == 5 && $("input[id$='txtHorarioInicio']").val().substr(2, 1) == ":" && $("input[id$='txtHorarioFin']").val().length == 5 && $("input[id$='txtHorarioFin']").val().substr(2, 1) == ":" && $("input[id$='txtFechaInicio']").val().length == 10 && $("input[id$='txtFechaFin']").val().length == 10) {
                var hi = parseFloat(parseInt(($("input[id$='txtHorarioInicio']").val().substr(0, 2))) + parseFloat(($("input[id$='txtHorarioInicio']").val().substr(3, 2)) / 60))
                var hf = parseFloat(parseInt(($("input[id$='txtHorarioFin']").val().substr(0, 2))) + parseFloat(($("input[id$='txtHorarioFin']").val().substr(3, 2)) / 60))
                var fi = $("input[id$='txtFechaInicio']").val();
                var ff = $("input[id$='txtFechaFin']").val();
                var precioHora = document.getElementById('lblPrecioHora').innerHTML;
                var precioTotal = document.getElementById('lblPrecioTotal').innerHTML;

                //dias = DiferenciaDeDias(fecha fin,  fecha inicio)  ­ 
                //horas = DiferenciaDeHoras(hora salida, hora entrada)  ­ 
                //horas totales = horas * dias  ­ 
                //precio total = horas totales * precio hora

                var dias = restaFechas(fi, ff);
                var horas = hf - hi;
                var horasTotales = horas * dias;
                var precioTotal = horasTotales * precioHora;

                //Si es un Numero
                if (!isNaN(precioTotal)) {
                    document.getElementById('lblPrecioTotal').innerHTML = precioTotal.toFixed(2);
                    document.getElementById('hfPrecioTotal').value = precioTotal.toFixed(2);
                }
                else
                    document.getElementById('lblPrecioTotal').innerHTML = "";

                console.log(dias);
                console.log(horas);
                console.log(horasTotales);
                console.log(precioTotal);
            }
            else
                if (document.getElementById('lblPrecioTotal').length)
                    document.getElementById('lblPrecioTotal').innerHTML = "";
        });
    }


});


function myMap() {

    var myLatLng = { lat: -34.684101, lng: -58.558074 };

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: myLatLng
    });

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'Cochera'
    });
};



function loadMap(numlat, numlon) {
    console.log("latlong:");
    console.log(numlat);
    console.log(numlon);

    var myLatLng = { lat: parseFloat(numlat), lng: parseFloat(numlon) };

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: myLatLng
    });

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'Cochera'
    });
};


function loadMapGrid(numlat, numlon, id) {
    console.log("latlong:");
    console.log(numlat);
    console.log(numlon);
    console.log(id);
    console.log('map' + id);
    var myLatLng = { lat: parseFloat(numlat), lng: parseFloat(numlon) };

    var map = new google.maps.Map(document.getElementById('ContentPlaceHolder_Principal_Base_ContentPlaceHolder_Principal_gvCocheras_map_' + id), {
        zoom: 14,
        center: myLatLng
    });

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'Cochera'
    });
};
