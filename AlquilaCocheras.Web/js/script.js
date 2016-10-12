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

// A $( document ).ready() block.
$(document).ready(function () {
    $('select').material_select();
    $('.modal-trigger').leanModal();

    $("#txtHorarioInicio,#txtHorarioFin,#txtFechaInicio,#txtFechaFin").keyup(function ()
    {
        if ($("input[id$='txtHorarioInicio']").val().length == 5 && $("input[id$='txtHorarioFin']").val().length == 5 && $("input[id$='txtFechaInicio']").val().length == 10 && $("input[id$='txtFechaFin']").val().length == 10) {
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
            if(!isNaN(precioTotal))
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

function showDiv(nomWn, titulo) {
    var hei = 180;
    var wid = 600;
    $("#" + nomWn).wijdialog({
        autoOpen: true,
        height: 390, //350
        width: 650,
        modal: true,
        title: titulo,
        captionButtons: {
            pin: { visible: false },
            refresh: { visible: false },
            toggle: { visible: false },
            minimize: { visible: false },
            maximize: { visible: false },
            close: { visible: true }
        }
    });
    /*var t = Math.max(0, (((parent.document.body.clientHeight - $("#tabs", parent.document).position().top - 50) - $("#" + nomWn).parent().height()) / 2) + $(window).scrollTop()) + "px";
    var l = Math.max(0, ((parent.document.body.clientWidth - $("#" + nomWn).parent().width()) / 2) + $(window).scrollLeft()) + "px";
    $("#" + nomWn).parent().css("top", t);
    $("#" + nomWn).parent().css("left", l);*/
}

function showDiv2(nomWn, titulo, mensaje) {
    var hei = 180;
    var wid = 600;
    $("#lblMensaje").val = mensaje;
    $("#" + nomWn).wijdialog({
        autoOpen: true,
        height: 390, //350
        width: 650,
        modal: true,
        title: titulo,
        captionButtons: {
            pin: { visible: false },
            refresh: { visible: false },
            toggle: { visible: false },
            minimize: { visible: false },
            maximize: { visible: false },
            close: { visible: true }
        }
    });
    /*var t = Math.max(0, (((parent.document.body.clientHeight - $("#tabs", parent.document).position().top - 50) - $("#" + nomWn).parent().height()) / 2) + $(window).scrollTop()) + "px";
    var l = Math.max(0, ((parent.document.body.clientWidth - $("#" + nomWn).parent().width()) / 2) + $(window).scrollLeft()) + "px";
    $("#" + nomWn).parent().css("top", t);
    $("#" + nomWn).parent().css("left", l);*/
}

function closeWn(nomWn) {
    $("#" + nomWn).wijdialog("close");
}

function LimpiaControles() {
    $("input[type=text]").val("");
    $("select").val("");
}

function mostrarImagen(elem) {
    $("#imgFoto").attr('src', elem.value);
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