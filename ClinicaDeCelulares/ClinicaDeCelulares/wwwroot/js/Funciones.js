﻿
var getParameterByName = (name) => {
    //El método replace () busca una cadena para un valor específico, o una expresión regular , y devuelve una nueva cadena donde se reemplazan los valores especificados.
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
   // La función decodeURIComponent() decodifica un componente URI.
    return results === null ? null : decodeURIComponent(results[1].replace(/\+/g, " "));
}
