//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CABECERA_ALBAS
    {
        public CABECERA_ALBAS()
        {
            this.LINEAS_ALBARAN = new HashSet<LINEAS_ALBARAN>();
        }
    
        public int idNumAlba { get; set; }
        public Nullable<System.DateTime> dFecAlb { get; set; }
        public int idCodCli { get; set; }
        public Nullable<bool> lFacturado { get; set; }
        public string cObserva { get; set; }
        public Nullable<decimal> nDto { get; set; }
        public Nullable<decimal> nTotBruto { get; set; }
        public Nullable<decimal> nTotNeto { get; set; }
        public Nullable<decimal> nTotAlb { get; set; }
        public Nullable<decimal> nTotalIva { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual ICollection<LINEAS_ALBARAN> LINEAS_ALBARAN { get; set; }
    }
}