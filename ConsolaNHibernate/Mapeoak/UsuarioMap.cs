using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Mapeoak
{
    using ConsolaNHibernate.Modeloak;
    using FluentNHibernate.Mapping;

    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("erabiltzaileak"); // ← Taularen izen erreala jarri
            Id(x => x.Idx).Column("idx").GeneratedBy.Identity();

            Map(x => x.UsuarioNombre).Column("usuario").Length(20).Not.Nullable();
            Map(x => x.Nombre).Column("nombre").Length(20);
            Map(x => x.Sexo).Column("sexo").Length(1);
            Map(x => x.Nivel).Column("nivel");
            Map(x => x.Email).Column("email").Length(50);
            Map(x => x.Telefono).Column("telefono").Length(20);
            Map(x => x.Marca).Column("marca").Length(20);
            Map(x => x.Compania).Column("compañia").Length(20);
            Map(x => x.Saldo).Column("saldo");
            Map(x => x.Activo).Column("activo");
        }
    }

}
