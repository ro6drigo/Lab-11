namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
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

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPCION { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        public List<CATEGORIA> listar(string nombre = "")
        {
            var categorias = new List<CATEGORIA>();

            try
            {
                using (var db = new db_ventas())
                {
                    if (this.IDCATEGORIA > 0)
                    {
                        categorias = db.CATEGORIA.ToList();
                    }
                    else
                    {
                        categorias = db.CATEGORIA
                                    .Where(x => x.NOMBRE == nombre)
                                    .ToList();
                    }
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

        public void mantenimiento()
        {
            try
            {
                using(var db = new db_ventas())
                {
                    if(this.IDCATEGORIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void eliminar()
        {
            try
            {
                using(var db = new db_ventas())
                {
                    db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<CATEGORIA> buscar(string criterio)
        {
            var categorias = new List<CATEGORIA>();

            string estado = "";
            estado = (criterio == "Activo") ? "A" : ((criterio == "Inactivo") ? "I" : "");

            try
            {
                using (var db = new db_ventas())
                {
                    categorias = db.CATEGORIA
                                //.Where(x => x.NOMBRE.Contains(criterio))
                                .Where(x => x.NOMBRE.Contains(criterio) || x.ESTADO == estado)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return categorias;
        }

        public List<CATEGORIA> consultar()
        {
            List<CATEGORIA> cat3 = new List<CATEGORIA>();
            try
            {
                using (var db = new db_ventas())
                {
                    //var cat1 = db.CATEGORIA
                    //            .GroupJoin(db.PRODUCTO,
                    //                p => p.IDCATEGORIA,
                    //                c => c.IDCATEGORIA,
                    //                (pro, cat) => new {
                    //                    IDCATEGORIA,
                    //                    cate = cat.NOMBRE,
                    //                    total = pro.PRODUCTO.Count()
                    //                });

                    var cat2 = from c in db.CATEGORIA
                               join p in db.PRODUCTO
                               on c.IDCATEGORIA equals p.IDCATEGORIA into g
                               select new
                               {
                                   IDCATEGORIA = c.IDCATEGORIA,
                                   NOMBRE = c.NOMBRE,
                                   total = g.Count()
                               };

                    cat3 = db.CATEGORIA
                                .Include(x => x.PRODUCTO)
                                .GroupBy(g => new { g.IDCATEGORIA, g.NOMBRE })
                                .Select(g => new CATEGORIA
                                {
                                    IDCATEGORIA = g.Key.IDCATEGORIA,
                                    NOMBRE = g.Key.NOMBRE
                                })
                                .ToList();

                }

                return cat3;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
