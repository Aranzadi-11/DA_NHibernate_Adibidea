using ConsolaNHibernate.Modeloak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Erabiltzaile berriaren datuak eskatu
            Console.WriteLine("=== Erabiltzaile berria sartzea ===");
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Sexo (M/F): ");
            string sexo = Console.ReadLine();

            Console.Write("Nivel (zenbaki bat): ");
            string nivelInput = Console.ReadLine();
            byte nivel = 0;
            if (string.IsNullOrEmpty(nivelInput))
            {
                Console.WriteLine("Nivel no puede estar vacío. Introduce un valor válido.");
            }
            else
            {
                nivel = byte.Parse(nivelInput);
            }


            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Telefonoa: ");
            string telefono = Console.ReadLine();

            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            Console.Write("Compañía: ");
            string compania = Console.ReadLine();

            Console.Write("Saldoa: ");
            string saldoInput = Console.ReadLine();
            float saldo = 0;
            if (string.IsNullOrEmpty(nivelInput))
            {
                Console.WriteLine("Nivel no puede estar vacío. Introduce un valor válido.");
            }
            else
            {
                saldo = float.Parse(saldoInput);
            }


            Console.Write("Activo? (s/n): ");
            bool activo = true;
            string activoInput = Console.ReadLine();

            if (string.IsNullOrEmpty(activoInput))
            {
                Console.WriteLine("Nivel no puede estar vacío. Introduce un valor válido.");
            }
            else
            {
                activo = activoInput.ToLower() == "s";
            }


            // Objektua sortu
            var nuevoUsuario = new Usuario
            {
                UsuarioNombre = usuario,
                Nombre = nombre,
                Sexo = sexo,
                Nivel = nivel,
                Email = email,
                Telefono = telefono,
                Marca = marca,
                Compania = compania,
                Saldo = saldo,
                Activo = activo
            };

            // NHibernate bidez gorde eta gero guztiak inprimatu
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // 1️⃣ Gorde erabiltzaile berria
                session.Save(nuevoUsuario);
                transaction.Commit();
            }

            // 2️⃣ Guztiak inprimatu
            using (var session = NHibernateHelper.OpenSession())
            {
                var usuarios = session.Query<Usuario>().ToList();

                Console.WriteLine("\n=== Datu-baseko erabiltzaile guztiak ===");
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"{u.Idx}: {u.Nombre} ({u.UsuarioNombre}) - Email: {u.Email} - Activo: {u.Activo}");
                }
            }

            Console.WriteLine("\nSakatu tekla bat amaitzeko...");
            Console.ReadKey();
        }
    }
}
