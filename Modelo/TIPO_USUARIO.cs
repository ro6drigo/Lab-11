namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class TIPO_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_USUARIO()
        {
            USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int IDTIPOUSUARIO { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }

        public List<TIPO_USUARIO> listar()
        {
            var tipo_usuario = new List<TIPO_USUARIO>();

            try
            {
                using (var db = new db_ventas())
                {
                    tipo_usuario = db.TIPO_USUARIO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return tipo_usuario;
        }

        public List<TIPO_USUARIO> ListarTipUsuario()
        {
            var tipo = new List<TIPO_USUARIO>();

            try
            {
                using (var db = new db_ventas())
                {
                    tipo = db.TIPO_USUARIO.OrderBy(x => x.IDTIPOUSUARIO).ToList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return tipo;
        }

        public TIPO_USUARIO obtener(int id)
        {
            var tipo_usuario = new TIPO_USUARIO();

            try
            {
                using (var db = new db_ventas())
                {
                    tipo_usuario = db.TIPO_USUARIO.Include("USUARIO")
                                .Where(x => x.IDTIPOUSUARIO == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return tipo_usuario;
        }

        public void mantenimiento()
        {
            try
            {
                using (var db = new db_ventas())
                {
                    if (this.IDTIPOUSUARIO > 0)
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

        public List<TIPO_USUARIO> buscar(string criterio) //Buscar por nombre y estado
        {
            var tipo_usuario = new List<TIPO_USUARIO>();
            string estado = "";
            estado = (criterio == "Activo") ? "A" : ((criterio == "Inactivo") ? "I" : "");

            try
            {
                using (var db = new db_ventas())
                {
                    tipo_usuario = db.TIPO_USUARIO
                                .Where(x => x.NOMBRE.Contains(criterio) || x.ESTADO == estado)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipo_usuario;
        }

        public List<TIPO_USUARIO> listarTipoUsuario()
        {
            var tipo_usuario = new List<TIPO_USUARIO>();
            try
            {
                using (var db = new db_ventas())
                {
                    tipo_usuario = db.TIPO_USUARIO.OrderBy(x => x.IDTIPOUSUARIO).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipo_usuario;
        }
    }
}
