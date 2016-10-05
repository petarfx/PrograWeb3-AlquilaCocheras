function validaAlMenosUnCampoIngresado(source, arguments) {
            var txt1 = document.getElementById("txtUbicacion");
            var txt2 = document.getElementById("txtFechaInicio");
            var txt3 = document.getElementById("txtFechaFin");            
           if (txt1.value == "" && txt2.value == "" && txt3.value == "") {
               arguments.IsValid = false;
               return;
           } else {
               arguments.IsValid = true;
               return true;
           }
       }