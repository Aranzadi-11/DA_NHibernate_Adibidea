using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Modeloak
{
    public class Usuario
    {
        public virtual int Idx { get; set; }
        public virtual string UsuarioNombre { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Sexo { get; set; }
        public virtual byte Nivel { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Marca { get; set; }
        public virtual string Compania { get; set; }
        public virtual float Saldo { get; set; }
        public virtual bool Activo { get; set; }

    }
}
