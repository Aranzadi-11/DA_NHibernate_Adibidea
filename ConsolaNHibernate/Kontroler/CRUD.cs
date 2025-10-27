using ConsolaNHibernate.Modeloak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Kontroler
{
    internal class CRUD
    {
        public void ErabiltzaileakSortu(Usuario erabiltzaileGehitu)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(erabiltzaileGehitu);
                    transaction.Commit();
                }
            }
        }

        public void ErabiltzaileakEguneratu(Usuario erabiltzaileEguneratu)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(erabiltzaileEguneratu);
                    transaction.Commit();
                }
            }
        }

        public void ErabiltzaileakEzabatu(Usuario erabiltzaileEzabatu)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(erabiltzaileEzabatu);
                    transaction.Commit();
                }
            }
        }
        public void ErabiltzaileakLortu()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var erabiltzaileak = session.Query<Usuario>().ToList();
                foreach (var erabiltzaile in erabiltzaileak)
                {
                    Console.WriteLine($"Idx: {erabiltzaile.Idx}, Usuario: {erabiltzaile.UsuarioNombre}, Nombre: {erabiltzaile.Nombre}, Sexo: {erabiltzaile.Sexo}, Nivel: {erabiltzaile.Nivel}, Email: {erabiltzaile.Email}, Telefono: {erabiltzaile.Telefono}, Marca: {erabiltzaile.Marca}, Compañía: {erabiltzaile.Compania}, Saldo: {erabiltzaile.Saldo}, Activo: {erabiltzaile.Activo}");
                }
            }
        }

        public Usuario ErabiltzaileaBilatuIdz(int idx)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Usuario>(idx);
            }
        }

        public void ErabiltzaileaBilatuMailaEtaSexua(byte nivel, string sexo)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var erabiltzaileak = session.Query<Usuario>()
                    .Where(e => e.Nivel == nivel && e.Sexo == sexo)
                    .ToList();
                foreach (var erabiltzaile in erabiltzaileak)
                {
                    Console.WriteLine($"Idx: {erabiltzaile.Idx}, Usuario: {erabiltzaile.UsuarioNombre}, Nombre: {erabiltzaile.Nombre}, Sexo: {erabiltzaile.Sexo}, Nivel: {erabiltzaile.Nivel}, Email: {erabiltzaile.Email}, Telefono: {erabiltzaile.Telefono}, Marca: {erabiltzaile.Marca}, Compañía: {erabiltzaile.Compania}, Saldo: {erabiltzaile.Saldo}, Activo: {erabiltzaile.Activo}");
                }
            }
        }
    }
}
