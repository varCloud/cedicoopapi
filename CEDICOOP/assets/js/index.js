
function initTooltip(){

    $(function () {
        var tootlTips = jQuery(".tooltip-wrapper");
        if (tootlTips.length > 0) {
            $('[data-toggle="tooltip"]').tooltip();
        }
    });

}



function notificacion(tipoNotificacion , mensaje) {

    switch (tipoNotificacion) {

        case "success":
            toastr.success(mensaje);
            break;
        case "Info":
            toastr.Info(mensaje);
            break;
        case "warning":
            toastr.warning(mensaje);
            break;
        case "Error":
            toastr.error(mensaje);
          break;

    }
    


}

$(document).ready(function () {

    toastr.options = {
        closeButton: true,
        debug: true,
        newestOnTop: true,
        positionClass: 'toast-top-right',
        preventDuplicates: true,
        onclick: null
    };


    Date.parseJSON = function (value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        var fecha = dt.getFullYear() + "/" + (dt.getMonth() + 1)+"/" + dt.getDate() ;
        console.log(fecha);
        return fecha;
    };

});