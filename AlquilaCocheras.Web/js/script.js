function afterLoad() {
    console.log(esEdicion);
    if (esEdicion) {
        $("#txtFechaInicio").datepicker({
            changeMonth: true,
            changeYear: true,
            showOn: "button",
            buttonImage: "imagenes/calendario.png",
            buttonImageOnly: true,
            dateFormat: "dd/mm/yy",
            showButtonPanel: true
        });
        console.log("fechainiciooo");
    }
}

function pageLoad() {
    $(document).ready(function () {
        // Variable global para activar la edicion en los combobox.
        //esEdicion = true;
        esEdicion = $("#esEdicion").val() == "true" ? true : false;
        console.log(esEdicion);
        afterLoad();
        $('select').material_select();
    });
}


function showModal(modalName, hf, idReserva) {
    //document.getElementById('miModal').style.display = "block";
    $("#" + modalName).css({ 'display': "block" });
    $("#" + hf).val(idReserva);
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

function showimagepreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementsByTagName("img")[0].setAttribute("src", e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function LimpiaControles() {
    $("input[type=text]").val("");
    $("select").val("");
}

function mostrarImagen(elem) {
    $("#imgFoto").attr('src', elem.value);
}

/*
function InitializeMap() {
    var latlng = new google.maps.LatLng(-34.397, 150.644);
    var myOptions = {
        zoom: 8,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), myOptions);
}
window.onload = InitializeMap;*/

/*
function initMap() {
    // Create a map object and specify the DOM element for display.
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -34.397, lng: 150.644 },
        scrollwheel: false,
        zoom: 8
    });
}*/

function init_map() {
    var myOptions = { zoom: 10, center: new google.maps.LatLng(-34.684166254941246, -58.55828472006833), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(-34.684166254941246, -58.55828472006833) }); infowindow = new google.maps.InfoWindow({ content: '<strong>Título</strong><br>san justo, argentina<br>' }); google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); infowindow.open(map, marker);
} google.maps.event.addDomListener(window, 'load', init_map);


/*
function iniciar() {
    var mapOptions = {
        center: new google.maps.LatLng(25.80, -80.30),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}*/


// A $( document ).ready() block.
$(document).ready(function () {
    $('select').material_select();
    //$('select:([multiple])').material_select();
    $('.modal-trigger').leanModal();


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
            if (!isNaN(precioTotal))
                document.getElementById('lblPrecioTotal').innerHTML = precioTotal.toFixed(2);
            else
                document.getElementById('lblPrecioTotal').innerHTML = "";

            console.log(dias);
            console.log(horas);
            console.log(horasTotales);
            console.log(precioTotal);
        }
        else
            document.getElementById('lblPrecioTotal').innerHTML = "";
    });



});

