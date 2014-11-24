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
    
    public partial class actividad
    {
        public actividad()
        {
            this.actividad_detalle = new HashSet<actividad_detalle>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }
        public Nullable<double> cantidad_total { get; set; }
        public Nullable<double> valor_total { get; set; }
        public Nullable<double> por_ponderacion { get; set; }
        public int actividad_mga_id { get; set; }
        public int lis_detalle_id { get; set; }
    
        public virtual actividad_mga actividad_mga { get; set; }
        public virtual ICollection<actividad_detalle> actividad_detalle { get; set; }
        public virtual lis_detalle lis_detalle { get; set; }
    }
}
