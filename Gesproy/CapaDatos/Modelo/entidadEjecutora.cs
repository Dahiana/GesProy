//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class entidadEjecutora
    {
        public entidadEjecutora()
        {
            this.contactoEntidadEjecutora_has_entidadEjecutora = new HashSet<contactoEntidadEjecutora_has_entidadEjecutora>();
            this.proyecto = new HashSet<proyecto>();
        }
    
        public int idEntidadEjecutora { get; set; }
        public string nit { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<contactoEntidadEjecutora_has_entidadEjecutora> contactoEntidadEjecutora_has_entidadEjecutora { get; set; }
        public virtual ICollection<proyecto> proyecto { get; set; }
    }
}
