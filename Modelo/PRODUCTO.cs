namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        [Key]
        public int IDPRODUCTO { get; set; }

        public int IDCATEGORIA { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [StringLength(50)]
        public string DESCRIPCION { get; set; }

        public int PRECIO { get; set; }

        public int STOCK { get; set; }

        [Required]
        [StringLength(1)]
        public string PORTADA { get; set; }

        public int IMPORTANCIA { get; set; }

        [StringLength(50)]
        public string IMAGEN { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        public List<PRODUCTO> listar()
        {
            var producto = new List<PRODUCTO>();

            try
            {
                using (var db = new db_ventas())
                {
                    producto = db.PRODUCTO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return producto;
        }

        public PRODUCTO obtener(int id)
        {
            var producto = new PRODUCTO();

            try
            {
                using (var db = new db_ventas())
                {
                    producto = db.PRODUCTO.Include("DETALLE_PEDIDO")
                                .Where(x => x.IDPRODUCTO == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return producto;
        }
    }
}
