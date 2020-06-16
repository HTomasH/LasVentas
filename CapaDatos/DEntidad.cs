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

        public string CTextoBuscar
        {
            get { return _cTextoBuscar;  }
            set { _cTextoBuscar = value; }
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
            this.CTextoBuscar = cTextoBuscar;
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


        //--->>    METODO PARA LISTAR/MOSTRAR LA INFORMACION EN EL DATAGRID PRINCIPAL -------------------------------
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

        //--->>    METODO PARA BORRAR ------------------------------------
        public string Eliminar(DEntidad datoAborrar)
        {
            
            string rpta = "";
            try  //--->Control de Errores                    
            {
                rpta = "NO se pudo eliminar el registro";

                using (VentasTOMASEntities db = new VentasTOMASEntities())
                {

                    //El valor de lo que busco para borrar, utilizar Find  si es el ID lo que vamos a buscar, sino utiliza where 
                    Entidad oEntidad = db.Entidad.Find(datoAborrar.Identifica); 
                    db.Entidad.Remove(oEntidad);
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



        //--->>    METODO PARA EL BOTON DE BUSQUEDA  ------------------------------------
        public string BuscarNombre(DEntidad datoAbuscar)
        {
            string rpta = "";
            try  //--->Control de Errores                    
            {
               rpta = "NO se ha localizado el registro";

                using (VentasTOMASEntities db = new VentasTOMASEntities())
                {
                    //Si vamos a buscar el  ID de la tabla utilizar  FIND  
                    //Si vamos a buscar otro campo utilizar          WHERE                     
                    //--------------------------------------------------------------------------------------------------------------
                    //Entidad oEntidad = db.Entidad.Where(d => d.nombre == Convert.ToString(datoAbuscar.CTextoBuscar)).First();
                    //Entidad oEntidad = db.Entidad.Where(d => d.nombre.Contains(Convert.ToString(datoAbuscar.CTextoBuscar))).First();

                    //Ejemplo de busquedas con  like
                    //------------------------------------------------
                    //customers.where(c => c.Name * *like * *"john");
                    //customers.Where(c => c.Name.Contains("john"));

                    /*
                        CONTAINS(column, '"text*"')   TIENE MAS POSIBILIDADES QUE  LIKE
                    
                        El asterisco representa cero, uno o más caracteres 
                        (de la palabra raíz o de las palabras de la palabra o la frase). 
                        Si el texto y el asterisco no se delimitan con comillas dobles de modo que 
                        el predicado sea CONTAINS(column, 'text*'), 
                        la búsqueda de texto completo considera el asterisco un carácter
                        y busca coincidencias exactas con text*.
                    
                        El motor de texto completo no encontrará palabras con el carácter de asterisco (*) 
                        porque los separadores de palabras suelen omitir dichos caracteres.
                    
                     */


                    Entidad oEntidad = db.Entidad.Where(d => d.nombre.Contains(datoAbuscar.CTextoBuscar)).First();

                    
                    rpta = Convert.ToString(oEntidad.identifica);

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


        //-------------------    METODO  MODIFICAR/EDITAR -----------------------------------------------------------------
        public string Editar(DEntidad datoAlocalizar)
        {
            string rpta = "";
            try  //--->Control de Errores                    
            {
                rpta = "NO se pudo editar el registro";

                using (VentasTOMASEntities db = new VentasTOMASEntities())
                {

                    //Entidad oEntidad = new Entidad();
                    //El valor de lo que busco para borrar, utilizar Find  si es el ID lo que vamos a buscar, sino utiliza where 
                    Entidad oEntidad = db.Entidad.Find(datoAlocalizar.Identifica);
                    
                    oEntidad.nombre = this.Nombre;
                    oEntidad.departamento = this.Departamento;


                    //->Esta linea sirve para informar de que este objeto tuvo una modificación, esto
                    //  va bien cuando se trabaja con muchas concurrencias de objetos,etc.., por integridad
                    //  pero a mi no me funciona...
                    //
                    //              Db.Entry(oEntidad).State = System.Data.Entity.EntityState.Modified;

                    //--> A cambio tengo esta que tiene pinta tambien de informar, esto deL EntityState creo que vale para jugar 
                    //    con el estado de la información antes de hacerle el SaveChanges()  que es como el viejo Commit 
                    db.Entry(oEntidad).State = EntityState.Modified;                     
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







    }
}