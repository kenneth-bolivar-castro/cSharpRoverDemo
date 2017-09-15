// Author:	 <Kenneth Bolivar >
// Fecha:    <01/08/2012>

$(function () {

    $("input.botonesForm[value='Cancelar']").click(function () {
        $.cierraiFrameModal();
    });

});

jQuery.cierraiFrameModal = function () {
    parent.$.modal.close();
}
