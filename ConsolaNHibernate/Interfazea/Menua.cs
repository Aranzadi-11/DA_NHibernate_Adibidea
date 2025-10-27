using System;
using ConsolaNHibernate.Kontroler;
using ConsolaNHibernate.Modeloak;

namespace ConsolaNHibernate.Interfaz
{
    internal class Menua
    {
        private CRUD crud = new CRUD();

        public void Hasi()
        {
            bool irten = false;

            while (!irten)
            {
                Console.Clear();
                Console.WriteLine("=== MENU NAGUSIA ===");
                Console.WriteLine("1. Erabiltzailea Gehitu");
                Console.WriteLine("2. Erabiltzailea Ezabatu");
                Console.WriteLine("3. Erabiltzailea Eguneratu");
                Console.WriteLine("4. Erabiltzaileak Ikusi");
                Console.WriteLine("5. Erabiltzailea IDz Bilatu");
                Console.WriteLine("6. Erabiltzailea Maila eta Sexuarekin Bilatu");
                Console.WriteLine("7. Irten");
                Console.Write("\nAukeratu (1-7): ");

                string aukera = Console.ReadLine();

                switch (aukera)
                {
                    case "1":
                        GehituErabiltzailea();
                        break;
                    case "2":
                        EzabatuErabiltzailea();
                        break;
                    case "3":
                        EguneratuErabiltzailea();
                        break;
                    case "4":
                        crud.ErabiltzaileakLortu();
                        break;
                    case "5":
                        BilatuIdz();
                        break;
                    case "6":
                        BilatuMailaEtaSexua();
                        break;
                    case "7":
                        irten = true;
                        break;
                    default:
                        Console.WriteLine("Aukera okerra. Saiatu berriro.");
                        break;
                }

                if (!irten)
                {
                    Console.WriteLine("\nSakatu tekla bat jarraitzeko...");
                    Console.ReadKey();
                }
            }
        }

        private void GehituErabiltzailea()
        {
            var u = new Usuario();

            Console.Write("Usuario: ");
            u.UsuarioNombre = Console.ReadLine();

            Console.Write("Nombre: ");
            u.Nombre = Console.ReadLine();

            Console.Write("Sexo (M/F): ");
            u.Sexo = Console.ReadLine();

            Console.Write("Nivel: ");
            u.Nivel = byte.Parse(Console.ReadLine());

            Console.Write("Email: ");
            u.Email = Console.ReadLine();

            Console.Write("Telefono: ");
            u.Telefono = Console.ReadLine();

            Console.Write("Marca: ");
            u.Marca = Console.ReadLine();

            Console.Write("Compañía: ");
            u.Compania = Console.ReadLine();

            Console.Write("Saldo: ");
            u.Saldo = float.Parse(Console.ReadLine());

            Console.Write("Activo? (s/n): ");
            u.Activo = Console.ReadLine().ToLower() == "s";

            crud.ErabiltzaileakSortu(u);
            Console.WriteLine("\nErabiltzailea gehitu da!");
        }

        private void EzabatuErabiltzailea()
        {
            Console.Write("Idatzi ezabatu nahi duzun erabiltzailearen IDa: ");
            int id = int.Parse(Console.ReadLine());
            var u = crud.ErabiltzaileaBilatuIdz(id);

            if (u != null)
            {
                crud.ErabiltzaileakEzabatu(u);
                Console.WriteLine("Erabiltzailea ezabatuta!");
            }
            else
            {
                Console.WriteLine("Ez da aurkitu ID hori duen erabiltzailea.");
            }
        }

        private void EguneratuErabiltzailea()
        {
            Console.Write("Idatzi eguneratu nahi duzun erabiltzailearen IDa: ");
            int id = int.Parse(Console.ReadLine());
            var u = crud.ErabiltzaileaBilatuIdz(id);

            if (u != null)
            {
                Console.Write("Nombre berria (utzi hutsik ez aldatzeko): ");
                string izenBerria = Console.ReadLine();
                if (!string.IsNullOrEmpty(izenBerria)) u.Nombre = izenBerria;

                Console.Write("Email berria (utzi hutsik ez aldatzeko): ");
                string emailBerria = Console.ReadLine();
                if (!string.IsNullOrEmpty(emailBerria)) u.Email = emailBerria;

                crud.ErabiltzaileakEguneratu(u);
                Console.WriteLine("Erabiltzailea eguneratua!");
            }
            else
            {
                Console.WriteLine("Ez da aurkitu ID hori duen erabiltzailea.");
            }
        }

        private void BilatuIdz()
        {
            Console.Write("Idatzi erabiltzailearen IDa: ");
            int id = int.Parse(Console.ReadLine());
            var u = crud.ErabiltzaileaBilatuIdz(id);

            if (u != null)
            {
                Console.WriteLine($"Idx: {u.Idx}, Usuario: {u.UsuarioNombre}, Nombre: {u.Nombre}, Email: {u.Email}, Activo: {u.Activo}");
            }
            else
            {
                Console.WriteLine("Ez da aurkitu erabiltzailea.");
            }
        }

        private void BilatuMailaEtaSexua()
        {
            Console.Write("Maila: ");
            byte nivel = byte.Parse(Console.ReadLine());

            Console.Write("Sexo (M/F): ");
            string sexo = Console.ReadLine();

            crud.ErabiltzaileaBilatuMailaEtaSexua(nivel, sexo);
        }
    }
}
