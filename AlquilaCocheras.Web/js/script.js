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
});