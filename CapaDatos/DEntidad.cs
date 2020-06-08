using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class DEntidad
    {

        private int _identifica;
        private string _nombre;
        private string _departamento;


        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;




        //-->Y ahora para pintar las PROPIEDADES, lo haremos Refactorizando !!   
        //   Se hace colocandose sobre la variable y le damos al botón derecho - Opcion Refactorizar - Encapsular Campo 

        // GETer   Devuelve valores
        // SETer   Recibe valores.


        public int Identifica
        {
            get { return _identifica; }
            set { _identifica = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }

        //------------------- CONSTRUCTORES   ----------------------------------------------
        //----------------------------------------------------------------------------------

        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DEntidad()
        {
        }

        //----------------------------------------------------------------------------------        
        //-->Constructor  CON PARAMETROS (Vamos a indicar los parametros con  minúsculas )
        //----------------------------------------------------------------------------------        
        public DEntidad(int identifica, string nombre, string departamento, string cTextoBuscar)
        {

            //Enviar los datos que llegan en estos parametros a nuestras propiedades 

            this.Identifica = identifica;
            this.Nombre = nombre;
            this.Departamento = departamento;
        }



        //-------------------    METODO  ALTAS  ------------------------------------------------------------------

        public string Insertar(DEntidad Entidadex)
        {
            string rpta = "";
            try  //--->Control de Errores                    
            {
                rpta = "NO se Ingreso el Registro";

                using (VentasTOMASEntities db = new VentasTOMASEntities())
                {
                    Entidad oEntidad = new Entidad();
                    oEntidad.nombre = this.Nombre;
                    oEntidad.departamento = this.Departamento;

                    db.Entidad.Add(oEntidad);
                    db.SaveChanges();
                    rpta = "OK";
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;   //-->Mostramos el mensaje.
            }
            finally  //Se ejecuta siempre   
            {
                //->Con este sistema no hace falta cerrar la conexión el ambito del USING la cierra automáticamente 
                //               if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        //-------------------  METODO  PARA EL RELLENO DEL DATADGRID PRINCIPAL -----------------------------------------
        //--------------------------------------------------------------------------------------------------------------

        /*
           Notas sobre este metodo que me costo un huevo crearlo 
           =====================================================

           Se esta utilinado una Coleccion-lista, esto lo vi en el curso del  Gallego y lo volví a repasar  en  C:\aa_CAMPUS  MVP\curso de   C#\MODULO 5\


           IQueryable : Evalua consultas con un origen de datos concreto donde se conoce el tipo de datos,  
                        claro es la tabla Entidad

           El  IQueryable es un Interface( que son contratos que deben de cumplir las clases que los aplican, es decir
                                           si indican tal o cual campo, hay que ponerlo, si tiene un método hay que ponerlo
                                           el interface solo tiene la "firma" el desarrollo con el contenido lo tenemos que 
                                           poner en la clases donde hubieramos indicado el Interface. )


          En todo el proceso de busqueda encontre esto :
          ============================================
                    
            OYE OYE  ESTO ES MAS LEGIBLE 
            --------------------------------------------------------------------------------
            
            var query = from p in db.Usuarios_   where   p.Cargo == "Maestro"     select p;

            ESTA ES LA MISMA QUE EN GUAY  expresión  LAMBDA(lambda), es decir:
            ---------------------------------------------------------------------------------
            var query = db.Usuarios_.Where( x  =>  x.cargo  == "Maestro" ).ToList();


            Luego  se coloca  dataGridView1.AutoGenerateColumns = false;     
            por ultimo:
            
            dataGridView1.DataSource = query;


        */

        public List<Entidad> Listar()
        {

            string rpta = "";
            List<Entidad> parts = new List<Entidad>();

            try  //--->Control de Errores                    
            {
                rpta = "Error al abrir la tabla de Entidades";
                using (VentasTOMASEntities oOjete = new VentasTOMASEntities())
                 {
                    Entidad oEntidad = new Entidad();
                    IQueryable<Entidad> qEntidad = from q in oOjete.Entidad select q;
                    
                    //-->En este momento al List  solo le puedo añadir elementos del tipo Entidad(la tabla) 
                    List<Entidad> lista2 = qEntidad.ToList(); //inserto en la variable lista del tipo List< nombre de tabla>  la informacion pillada en qEntidad

                    rpta = "OK";
                    parts = lista2;
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;   //-->Mostramos el mensaje.
            }
            finally  //Se ejecuta siempre   
            {
                //->Con este sistema no hace falta cerrar la conexión el ambito del USING la cierra automáticamente 
                //               if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return parts;
         }




            //-------------------    METODO  MODIFICAR/EDITAR -----------------------------------------------------------------
            //public string Editar(DEntidad Entidad)
            //{
            //}



            //public string Eliminar(DEntidad Entidad)
            //{
            //}


            

        }
    }