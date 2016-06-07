namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
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

        public void mantenimiento()
        {
            try
            {
                using (var db = new db_ventas())
                {
                    if (this.IDUSUARIO != "" && this.IDUSUARIO != null)
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
                    db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<USUARIO> buscar(string criterio)
        {
            var usuarios = new List<USUARIO>();

            string estado = "";
            estado = (criterio == "Activo") ? "A" : ((criterio == "Inactivo") ? "I" : "");

            try
            {
                using (var db = new db_ventas())
                {
                    usuarios = db.USUARIO
                                .Where(x => x.NOMBRE.Contains(criterio) || x.ESTADO == estado)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return usuarios;
        }

        public ResponseModel Acceder(string Email, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new db_ventas()) {
                    Password = HashHelper.MD5(Password);
                    var usuario = db.USUARIO.Where(x => x.EMAIL == Email)
                                            .Where(x => x.PASSWORD == Password)
                                            .SingleOrDefault();
                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.IDUSUARIO.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Email o Password incorrecto...");
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return rm;
        }
    }
}
