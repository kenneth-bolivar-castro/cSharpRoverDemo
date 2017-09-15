
jQuery.crearDataTable = function (gvDatos, hdfIdentificador, gTable) {

    $(gvDatos).each(function () {
        var grid = $(this);

        // Por cada GridView que se encuentre modificar el código HTML generado para agregar el THEAD.
        if (grid.find("tbody > tr > th").length > 0) {
            grid.find("tbody").before("<thead><tr></tr></thead>");
            grid.find("thead:first tr").append(grid.find("th"));
            grid.find("tbody tr:first").remove();

            //Agregar Clase Sortable
            grid.find("th").each(function () {
                $(this).addClass('sortable');
            }); 
        }

        // Si el GridView tiene la clase "sortable" aplicar el plugin DataTables si tiene más de 10 elementos.
        if (grid.hasClass("sortable") && grid.find("tbody:first > tr").length > 10) {
            grid.dataTable({
                sPaginationType: "full_numbers",
                aoColumnDefs: [
                                { bSortable: false, aTargets: grid.metadata().disableSortCols }
                            ]
            });
        }

        // Ocultar la primer columna
        grid.find("th:eq(0)").css("display", "none");
        grid.find("tbody tr").each(function () {
            var elemento = $(this).find("td:eq(0)");
            if ($.trim(elemento.text()) != "No se encontraron datos.") {
                elemento.css("display", "none");
            }
        });

    });

    $(gvDatos + " tbody tr").click(function (e) { 

        if ($(this).hasClass('row_selected')) {
            $(this).removeClass('row_selected');
            $(hdfIdentificador).val(null);
        }
        else {
            gTable.$('tr.row_selected').removeClass('row_selected');
            $(this).addClass('row_selected');
        }

        var id = gTable.$("tr.row_selected").find("td:eq(0)").text();
        $(hdfIdentificador).val(id);

    });

    //Crear el dataTable a partir del GridView
    gTable = $(gvDatos).dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "oLanguage": {
            "sLengthMenu": "Mostrar_MENU_ registros por pagina",
            "sSearch": "Buscar:",
            "sZeroRecords": "La busqueda no contiene registros",
            "sInfo": "Mostrando _START_ de _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 de 0 de 0 registros",
            "sInfoFiltered": "(Filtrado de _MAX_ registros totales)",
            "oPaginate": {
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Ultima",
                "sFirst": "Primera"
            }
        }
    });

}