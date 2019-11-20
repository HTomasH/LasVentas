using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class DTrabajadores
    {

        /*
          Declaración de los CAMPOS con los que vamos a trabajar
          que son los campos de la tabla Trabadores.
          
          Vamos a ponerles un guion bajo  por delante para diferenciar los Campos  y  las Propiedades 
        */


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idTrabajador;    
        //                 Propiedades    :  Con Mayúscula la primera         IdTrabajador
        //                 Paremetros     :  Con minúscula la primera         idTrabajador

        //--@idTrabajador int,
        //--@cNombreTraba varchar(20),
        //--@cApellidos varchar(40),
        //--@cAcceso varchar(20),
        //--@Password varchar(20)
        
        //---------------------------------------------------------------------------------


        private int _idTrabajador;
        private string _cNombreTraba;
        private string _cApellidos;
        private string _cAcceso;
        private string _Password;


        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;


        //-->Y ahora para pintar las PROPIEDADES, lo haremos Refactorizando !!   
        //   Se hace colocandose sobre la variable y le damos al botón derecho - Opcion Refactorizar - Encapsular Campo 

        // GETer   Devuelve valores
        // SETer   Recibe valores.








    }
}
