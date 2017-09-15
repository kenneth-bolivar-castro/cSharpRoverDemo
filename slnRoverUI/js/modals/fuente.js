// Author:	 <Kenneth Bolivar >
// Fecha:    <01/08/2012>

jQuery.creaMensajeEmergente = function (mensaje) {
    $.modal("<div align='center'>" + mensaje + "</div>", { "overlayClose": true });
}

jQuery.defineOpcionesModal = function (opciones) {
    $("#simplemodal-container").css("height", opciones.alto);
    $("#simplemodal-container").css("width", opciones.ancho);
    $("#simplemodal-container").css("top", opciones.arriba);
    $("#simplemodal-container").css("left", opciones.izquierda);
}

jQuery.alertModal = function (mensaje) {
    var opciones = {
        "alto": "50",
        "ancho": "300",
        "arriba": "30%",
        "izquierda": "40%"
    };
    $.creaMensajeEmergente(mensaje);
    $.defineOpcionesModal(opciones);
}

jQuery.alertaDebeSeleccionarElemento = function () {
    $.alertModal("DEBE DE SELECCIONAR UN ELEMENTO");
}

jQuery.creariFrameModal = function (parametros) {
    $.modal('<iframe src="' + parametros.url + '" scrolling="no" height="' + parametros.alto + '" width="' + parametros.ancho + '" style="border:0">', {
        closeHTML: "",
        containerCss: {
            backgroundColor: "#fff",
            borderColor: "#fff",
            height: parametros.alto,
            padding: 0,
            width: parametros.ancho
        },
        overlayClose: true
    });
    return false;
}

jQuery.obtenIdentificador = function () {
    $el = $("input[id*=hdfIdentificador]");
    if ($el.val() != "" && $el.val() != null) {
        return $el.val();
    }
    return null;
}

jQuery.activaModals = function (configuraciones) {

    $("img#ImgNuevo").click(function () {
        var parametros = {
            "url": configuraciones.url + "?accion=insertar",
            "alto": configuraciones.nuevo[0].alto,
            "ancho": configuraciones.nuevo[0].ancho
        };
        $.creariFrameModal(parametros);
    });

    $("img#ImgEditar").click(function () {
        var identificador = $.obtenIdentificador();
        if (identificador != null) {
            var parametros = {
                "url": configuraciones.url + "?accion=actualizar&identificador=" + identificador + "",
                "alto": configuraciones.editar[0].alto,
                "ancho": configuraciones.editar[0].ancho
            };
            $.creariFrameModal(parametros);
        } else {
            $.alertaDebeSeleccionarElemento();
        }
    });

    $("img#ImgEliminar").click(function () {
        var identificador = $.obtenIdentificador();
        if (identificador != null) {
            var parametros = {
                "url": configuraciones.url + "?accion=eliminar&identificador=" + identificador + "",
                "alto": configuraciones.eliminar[0].alto,
                "ancho": configuraciones.eliminar[0].ancho
            };
            $.creariFrameModal(parametros);
        } else {
            $.alertaDebeSeleccionarElemento();
        }
    });
    
};