//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarritoQuinto.BackEnd.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_DIRECCIONES
    {
        public int dir_id { get; set; }
        public string dir_principal { get; set; }
        public string dir_secundaria { get; set; }
        public string dir_numeracion { get; set; }
        public string dir_referencia { get; set; }
        public string dir_status { get; set; }
        public string dir_codigopostal { get; set; }
        public System.DateTime dir_fechacreacion { get; set; }
        public Nullable<long> cli_id { get; set; }
        public string cli_identificacion { get; set; }
    
        public virtual TBL_CLIENTE TBL_CLIENTE { get; set; }
    }
}
