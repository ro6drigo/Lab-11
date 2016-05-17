namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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

        public int? PRECIO { get; set; }

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
    }
}
