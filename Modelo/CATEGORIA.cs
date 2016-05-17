namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    [Table("CATEGORIA")]
    public partial class CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        [Key]
        public int IDCATEGORIA { get; set; }

        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPCION { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        public List<CATEGORIA> listar()
        {
            var categorias = new List<CATEGORIA>();

            try
            {
                using (var db = new db_ventas())
                {
                    categorias = db.CATEGORIA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return categorias;
        }

        public CATEGORIA obtener(int id)
        {
            var categoria = new CATEGORIA();

            try
            {
                using (var db = new db_ventas())
                {
                    categoria = db.CATEGORIA.Include("PRODUCTO")
                                .Where(x => x.IDCATEGORIA == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return categoria;
        }
    }
}
