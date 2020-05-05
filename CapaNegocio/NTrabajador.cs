using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NTrabajador
    {
        
        //-->Método Insertar que llama al método Insertar de la clase Drabajador  de la CapaDatos
        //---------------------------------------------------------------------------------------
        public static string Insertar(string cNombreTraba, string cApellidos, string cAcceso, string Password, string cUsuario  )
        {
            DTrabajadores Obj = new DTrabajadores();

            Obj.CNombreTraba = cNombreTraba;
            Obj.CApellidos = cApellidos;
            Obj.CAcceso = cAcceso;
            Obj.Password = Password;
            Obj.CUsuario = cUsuario;
            
            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DTrabajador de la CapaDatos
        //-----------------------------------------------------------------------------------------------------
        public static string Editar(int idTrabajador, string cNombreTraba, string cApellidos, string cAcceso, string Password, string cUsuario)
        {
            DTrabajadores Obj = new DTrabajadores();

            Obj.IdTrabajador = idTrabajador;
            Obj.CNombreTraba = cNombreTraba;
            Obj.CApellidos = cApellidos;
            Obj.CAcceso = cAcceso;
            Obj.Password = Password;
            Obj.CUsuario = cUsuario;

            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DTrabajador de la CapaDatos
        //------------------------------------------------------------------------------------
        public static string Eliminar(int idtrabajador)
        {
            DTrabajadores Obj = new DTrabajadores();
            Obj.IdTrabajador = idtrabajador;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DTrabajador de la CapaDatos
        //----------------------------------------------------------------------------------
        public static DataTable Mostrar()
        {
            return new DTrabajadores().Mostrar();
        }


        //Método BuscarApellidos que llama al método BuscarApellidos de la clase DTrabajador de la CapaDatos

        public static DataTable BuscarNombreTrabajador(string textobuscar)
        {
            DTrabajadores Obj = new DTrabajadores();
            Obj.CTextoBuscar = textobuscar;            
            return Obj.BuscarNombreTrabajador(Obj);
        }

        



        //----- ESTE METODO VENDRA EXPLICADO UNA VEZ EMPECEMOS CON LOS ACCESOS 
        //      NO TENGO CLARO COMO SERA LO DEL PERFIL 


        //        //public static DataTable Login(string usuario, string password)
        //       public static DataTable Login(string cNombreTraba, string password)
        //      {
        //            DTrabajadores Obj = new DTrabajadores();
        //            //Obj.Usuario = cUsuario;
        //            Obj.CNombreTraba = cNombreTraba;
        //            Obj.Password = password;
        //            return Obj.Login(Obj);
        //        }




    }

}
