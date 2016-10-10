function afterLoad() {
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
    }
}

function pageLoad() {
    $(document).ready(function () {
        // Variable global para activar la edicion en los combobox.
        //esEdicion = true;
        esEdicion = $("#esEdicion").val() == "true" ? true : false;
        alert(esEdicion);
        afterLoad();
    });
}

// A $( document ).ready() block.
$( document ).ready(function() {
    console.log( "ready!" );
	$('.modal-trigger').leanModal();
});

function showDiv(nomWn, titulo) {
    console.log("showdiv1");
            var hei = 180;
            var wid = 600;
            if ($.browser.msie) {
                hei += "px";
                wid += "px";
            }
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
            console.log("showdiv2");
            var t = Math.max(0, (((parent.document.body.clientHeight - $("#tabs", parent.document).position().top - 50) - $("#" + nomWn).parent().height()) / 2) + $(window).scrollTop()) + "px";
            var l = Math.max(0, ((parent.document.body.clientWidth - $("#" + nomWn).parent().width()) / 2) + $(window).scrollLeft()) + "px";
            $("#" + nomWn).parent().css("top", t);
            $("#" + nomWn).parent().css("left", l);
        }
		
function closeWn(nomWn) {
	$("#" + nomWn).wijdialog("close");
}