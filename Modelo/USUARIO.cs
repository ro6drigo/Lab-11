namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            PEDIDO = new HashSet<PEDIDO>();
        }

        [Key]
        [StringLength(20)]
        public string IDUSUARIO { get; set; }

        public int IDTIPOUSUARIO { get; set; }

        [StringLength(20)]
        public string PASSWORD { get; set; }

        [StringLength(20)]
        public string NOMBRE { get; set; }

        [StringLength(20)]
        public string APELLIDOS { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }

        public List<USUARIO> listar()
        {
            var usuario = new List<USUARIO>();

            try
            {
                using (var db = new db_ventas())
                {
                    usuario = db.USUARIO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return usuario;
        }

        public USUARIO obtener(string id)
        {
            var usuario = new USUARIO();

            try
            {
                using (var db = new db_ventas())
                {
                    usuario = db.USUARIO.Include("PEDIDO")
                                .Where(x => x.IDUSUARIO == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return usuario;
        }
    }
}
