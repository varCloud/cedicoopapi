function SuccessGuardarAsamblea(data) {
    notificacion(data.TipoAlerta, data.Mensaje);
    $('#mdlAgregarAsamblea').modal('hide');
    PintarAsambleas();
}

function SuccessEliminaAcuerdo(data) {
    console.log(data);
    notificacion(data.TipoAlerta, data.Mensaje);
    PintarAcuerdos(data.Model.IdAsamblea, "Agregar");
}

function SuccessGuardarAcuerdo(data) {
    console.log(data);
    $("#Descripcion").val('');
    notificacion(data.TipoAlerta, data.Mensaje);
    PintarAcuerdos(data.Model.IdAsamblea,"Agregar");
}

function iniScroll() {
    $('.scroll_dark').mCustomScrollbar({
        theme: "minimal-dark",
        setHeight: false,
        mouseWheel: {
            normalizeDelta: true,
            scrollAmount: '200px',
            contentTouchScroll: true,
            deltaFactor: '200px'
        },
        advanced: {
            autoScrollOnFocus: 'a[tabindex]'
        }
    });
}

function initForm() {
    $("#frmAsamblea").validate({
        rules: {
            NombreAsamblea: "required",
            FechaAsamblea: "required",
            Direccion: "required",
        },
        messages: {
            NombreAsamblea: "Este campo no puede estar vacio",
            FechaAsamblea: "Este campo no puede estar vacio",
            Direccion: "Este campo no puede estar vacio",
        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the `help-block` class to the error element
            error.addClass("help-block");
            error.css("color", "#e3324c");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents(".col-sm-5").addClass("has-error").removeClass("has-success");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents(".col-sm-5").addClass("has-success").removeClass("has-error");
        }
    });
}

function InitDataTable() {

    table = $('#tblAsam').DataTable({

        "language": {
            "lengthMenu": "Muestra _MENU_ registros por pagina",
            "zeroRecords": "No existen registros",
            "info": "Pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No existe informacion para mostrar",
            "infoFiltered": "(filtered from _MAX_ total records)",
            "search": "Buscar:",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Siguiente",
                "previous": "Anterior"
            },
        },
        //"dom": 'Bfrtip',
        "bDestroy": true, // es necesario para poder ejecutar la funcion LimpiaTabla()
    });

    $('#tblAsam_filter input').addClass('form-control');
    $('#tblAsam_filter').append('&nbsp;&nbsp;<button value=""  title="Agregar Asamblea" data-toggle="tooltip"  class="tooltip-wrapper btn btn-icon btn-round btn-outline-dark" name="" id="btnAgregarAsamblea"><i class="fa fa-plus"></i></button>');
    InitBtnAgregar();
    initTooltip();

    $('#tblAsam tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var idAsamblea = $(tr).find('td:eq( 1 )').html();
        console.log(idAsamblea);

        var row = table.row(tr);   
        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
            $(this).find('a').find('i').removeClass("fa fa-search-minus");
            $(this).find('a').find('i').addClass("fa fa-search-plus");

            console.log('no se  muestra');
        }
        else {
            // Open this row
            verAcuerdos(idAsamblea, row);
            tr.addClass('shown');
            $(this).find('a').find('i').removeClass("fa fa-search-plus")
            $(this).find('a').find('i').addClass("fa fa-search-minus")
        }
    });
}

function verAcuerdos(idAsamblea ,row) {

    var data ="<div>No existen acuerdos</div>"
    $.ajax({
        url: rootUrl("/Asamblea/ObtenerAcuerdos"),
        data: { idAsamblea: idAsamblea },
        method: 'post',
        dataType: 'json',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (datos) {
            if (datos.length > 0) {
                data = ' <div class="card-body"><ul class="activity">';
                $(datos).each(function (index, item) {
                    data += '<li class="activity-item primary"><div class="activity-info">';
                    data += '<h5 class="mb-0">' + item.Descripcion + '</h5><span>Votos a favor: <b class="text-success">' + item.votosTotalesFavor + '</b> Votos en contra: <b class="text-danger">' + item.votosTotalesEnContra +'</b></span>';
                    data += '</div></li>';
                });
                data += '</ul></div>';
                console.log(data);
            }
            row.child(data).show();
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });

}

function InitBtnAgregar() {
    $('#btnAgregarAsamblea').click(function (e) {
        $('#btnReseFrm').trigger('click');
        $('#mdlAgregarAsamblea').modal({ backdrop: 'static', keyboard: false, show: true });
        $('#mdlAgregarAsambleaTitle').html("Agregar Asamblea")
    });
}

function AsignarSociosAsamblea(idAsamblea) {
    
    console.log("idAsamblea: " + idAsamblea);
    $.ajax({
        url: rootUrl("/Asamblea/_ObtenerSociosEnAsamblea"),
        method: 'post',
        dataType: 'html',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (data) {
            $('#tabSociosAsambleas').html(data);
            $('#mdlAsignarSociosAsamblea').modal({ backdrop: 'static', keyboard: false, show: true });
            $('.checkSocio').click(function () {
                console.log($(this).attr("idsocio"))
                if ($(this).prop("checked") == true) {
                    
                }
                else if ($(this).prop("checked") == false) {
                    
                }
            });
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });
}
function EditarAsamblea(idAsamblea) {

    $.ajax({
        url: rootUrl("/Asamblea/ObtenerAsamblea"),
        data: { idAsamblea: idAsamblea },
        method: 'post',
        dataType: 'json',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (datos) {
            $('#btnReseFrm').trigger('click');
            $('#idAsamblea').val(datos.IdAsamblea);
            $('#NombreAsamblea').val(datos.NombreAsamblea);
            $('#FechaAsamblea').datepicker("setDate", new Date(Date.parseJSON(datos.FechaAsamblea)));
            //$('#FechaAsamblea').val(Date.parseJSON(datos.FechaAsamblea)).trigger('change');
            $('#Direccion').val(datos.Direccion);

            $('#mdlAgregarAsamblea').modal({ backdrop: 'static', keyboard: false, show: true });
            $('#mdlAgregarAsambleaTitle').html("Editar Asamblea");
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });

}

function EliminarAsamblea(idAsamblea) {

   
        swal({
            title: '?',
            text: "Estas seguro que deseas eliminar la Asamblea, se borraran los acuerdos que se tiene asociados",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar!',
            cancelButtonText: 'cancelar!',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: true,
            reverseButtons: true
        }).then((result) => {
            if (result.value) {
                $.ajax({
                       url: rootUrl("/Asamblea/EliminarAsamblea"),
                        data: { idAsamblea: idAsamblea },
                        method: 'post',
                        dataType: 'json',
                        async: false,
                        beforeSend: function (xhr) {
                        },
                        success: function (datos) {
                            swal('', datos.Mensaje, (datos.Estatus == 200 ? 'success' : 'error'));
                            PintarAsambleas();

                        },
                        error: function (xhr, status) {
                            console.log('Disculpe, existió un problema');
                            console.log(xhr);
                            console.log(status);
                        }
                });

            }
        })

}

function ActivarAsamblea(idAsamblea) {
    swal({
        title: 'Estas seguro que deseas Activar la Asamblea.',
        text: "Los socios podran comenzar a votar los acuerdos",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, activar!',
        cancelButtonText: 'cancelar!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: true,
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: rootUrl("/Asamblea/ActivarAsamblea"),
                data: { idAsamblea: idAsamblea },
                method: 'post',
                dataType: 'json',
                async: false,
                beforeSend: function (xhr) {
                },
                success: function (datos) {
                    console.log(datos);
                    swal('', datos.Mensaje, (datos.Estatus == 200 ? 'success' : 'error'));
                    PintarAsambleas();
                },
                error: function (xhr, status) {
                    console.log('Disculpe, existió un problema');
                    console.log(xhr);
                    console.log(status);
                }
            });

        }
    })

}

function FinalizarAsamblea(idAsamblea) {
    swal({
        title: 'Estas seguro que deseas Finalizar la Asamblea.',
        text: "Los socios ya No podran emitir votas a  los acuerdos",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Finalizar!',
        cancelButtonText: 'cancelar!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: true,
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: rootUrl("/Asamblea/FinalizarAsamblea"),
                data: { idAsamblea: idAsamblea },
                method: 'post',
                dataType: 'json',
                async: false,
                beforeSend: function (xhr) {
                },
                success: function (datos) {
                    console.log(datos);
                    swal('', datos.Mensaje, (datos.Estatus == 200 ? 'success' : 'error'));
                    PintarAsambleas();
                },
                error: function (xhr, status) {
                    console.log('Disculpe, existió un problema');
                    console.log(xhr);
                    console.log(status);
                }
            });

        }
    })

}

function AgregarActivarAcuerdos(idAsamblea, accion) {
    console.log("idAsamblea: " + idAsamblea);
    $('#mdlAgregarAcuerdos').modal({ backdrop: 'static', keyboard: false, show: true });
    $('#mdlAgregarAcuerdosTitle').html((accion == 1 ? "Agregar Asamblea" : "Activar Acuerdos"));
    $("#IdAsambleaAcuerdo").val(idAsamblea);
    $("#Descripcion").val('');
    $('#frmAcuerdo').css('display', (accion == 1 ? '':'none'));
    PintarAcuerdos(idAsamblea, accion);
}

function PintarAcuerdos(idAsamblea, accion) {
    $.ajax({
        url: rootUrl("/Asamblea/_ObtenerAcuerdos"),
        data: { idAsamblea: idAsamblea, accionAcuerdo: accion},
        method: 'post',
        dataType: 'html',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (data) {
            $('#acuerdos').html(data);
            $("#noAcuerdo").val($("#indexNoAcuerdo").val());
            $("#lblContadorAcuerdo").html($("#indexNoAcuerdo").val());
            console.log("noAcuerdo" + $("#indexNoAcuerdo").val());
            iniScroll();
            initTooltip();
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });
}

function PintarAsambleas() {
    $.ajax({
        url: rootUrl("/Asamblea/_ObtenerAsambleas"),
        data: { },
        method: 'post',
        dataType: 'html',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (data) {
            table.destroy();
            $('#rowTblAsamblea').html(data);
            InitDataTable();
            iniScroll();
            initTooltip();
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });
}

function ActivarEditarAcuerdo(descripcion, idAsamblea, idAcuerdo) {
    $("#descAcuerdoEditar_" + idAcuerdo).css('display', '');
    $("#h4_" + idAcuerdo).css('display', 'none');
    $("#dvAcciones_" + idAcuerdo).css('display', 'none');
    $("#dvGuardaAcuerdo_" + idAcuerdo).css('display', '');

}

function ActivarAcuerdo(activarVotacion, idAsamblea,idAcuerdo, ) {

    $.ajax({
        url: rootUrl("/Asamblea/ActivarAcuerdo"),
        data: { IdAsamblea: idAsamblea, IdAcuerdo: idAcuerdo, activarVotacion: (activarVotacion == 1 ? false : true)},
        method: 'post',
        dataType: 'json',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (datos) {
            swal('', datos.Mensaje, (datos.Estatus == 200 ? 'success' : 'error'));
            $('.tooltip-wrapper').tooltip('hide');
            PintarAcuerdos(idAsamblea, 2);
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });
}

function GuardarEditarAcuerdo(descripcion, idAsamblea, idAcuerdo) {

    $("#descAcuerdoEditar_" + idAcuerdo).css('display', 'none');
    $("#h4_" + idAcuerdo).css('display', '');
    $("#dvGuardaAcuerdo_" + idAcuerdo).css('display', 'none');
    $("#dvAcciones_" + idAcuerdo).css('display', '');

    $.ajax({
        url: rootUrl("/Asamblea/AgregaraAcuerdo"),
        data: { IdAcuerdo: idAcuerdo, Descripcion: $("#descAcuerdoEditar_" + idAcuerdo).val(), IdAsamblea: idAsamblea },
        method: 'post',
        dataType: 'json',
        async: false,
        beforeSend: function (xhr) {
        },
        success: function (datos) {
            console.log(datos.TipoAlerta);
            notificacion(datos.TipoAlerta, datos.Mensaje);
            PintarAcuerdos(idAsamblea);
        },
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema');
            console.log(xhr);
            console.log(status);
        }
    });

}

function initDate() {

    $('#FechaAsamblea').datepicker({
        autoclose: true,
        orientation: "bottom",
        todayHighlight: true,
        //startDate: "today",
        format: 'yyyy/mm/dd',
        templates: {
            leftArrow: '<i class="fa fa-angle-left"></i>',
            rightArrow: '<i class="fa fa-angle-right"></i>'
        }
    });

}

$(document).ready(function () {
    InitDataTable();
    initDate();
});