     function activaMenu(activar) {
         $.each($("#dvTabsMenus a"), function () {
             var menu = $(this).text();
             if (menu == activar) {
                 cambiaClase($(this));
             }
         });
     }

     function cambiaClase($el) {
         if (!$el.closest("div").hasClass('Menu-top-azul')) {
             $("#dvTabsMenus div.Menu-top-azul")
                 .removeClass("Menu-top-azul")
                    .addClass("Menu-top-blanco");
             $el.closest("div")
                    .removeClass("Menu-top-blanco")
				        .addClass("Menu-top-azul");
         }
     }

     $(function () {
         $("#dvTabsMenus a").click(function () {
             cambiaClase($(this));
         });
     });