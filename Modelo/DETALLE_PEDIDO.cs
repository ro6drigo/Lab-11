namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class DETALLE_PEDIDO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPEDIDO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPRODUCTO { get; set; }

        [Required]
        public int? PRECIO { get; set; }

        [Required]
        public int? CANTIDAD { get; set; }

        public virtual PEDIDO PEDIDO { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }

        public List<DETALLE_PEDIDO> listar()
        {
            var detalle_pedido = new List<DETALLE_PEDIDO>();

            try
            {
                using (var db = new db_ventas())
                {
                    detalle_pedido = db.DETALLE_PEDIDO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return detalle_pedido;
        }

        public DETALLE_PEDIDO obtener(int id)
        {
            var detalle_pedido = new DETALLE_PEDIDO();
            try
            {
                using (var db = new db_ventas())
                {
                    detalle_pedido = db.DETALLE_PEDIDO
                        //.Include("PRODUCTO.NOMBRE")
                        .Where(x => x.IDPEDIDO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return detalle_pedido;
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
    }
}
