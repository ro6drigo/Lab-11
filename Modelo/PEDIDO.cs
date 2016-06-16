namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    [Table("PEDIDO")]
    public partial class PEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PEDIDO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        [Key]
        public int IDPEDIDO { get; set; }

        [Required]
        public DateTime? FECHA { get; set; }

        [Required]
        [StringLength(20)]
        public string ESTADO { get; set; }

        [Required]
        public int IDUSUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        public List<PEDIDO> listar()
        {
            var pedido = new List<PEDIDO>();

            try
            {
                using (var db = new db_ventas())
                {
                    pedido = db.PEDIDO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pedido;
        }

        public PEDIDO obtener(int id)
        {
            var pedido = new PEDIDO();

            try
            {
                using (var db = new db_ventas())
                {
                    pedido = db.PEDIDO.Include("DETALLE_PEDIDO")
                                .Where(x => x.IDPEDIDO == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pedido;
        }

        public void mantenimiento()
        {
            try
            {
                using (var db = new db_ventas())
                {
                    if (this.IDPEDIDO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void eliminar()
        {
            try
            {
                using (var db = new db_ventas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PEDIDO> buscar(string criterio) //Buscar por nombre y estado
        {
            var pedidos = new List<PEDIDO>();
            string estado = "";
            estado = (criterio == "Activo") ? "A" : ((criterio == "Inactivo") ? "I" : "");

            try
            {
                using (var db = new db_ventas())
                {
                    pedidos = db.PEDIDO
                                .Where(x => Convert.ToString(x.FECHA).Contains(criterio) || x.ESTADO == estado)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return pedidos;
        }
    }
}
