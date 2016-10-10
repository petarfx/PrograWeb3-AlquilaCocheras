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

// A $( document ).ready() block.
$(document).ready(function () {
    $('select').material_select();
});

function showDiv(nomWn, titulo, mensaje) {
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