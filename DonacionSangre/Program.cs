using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DonacionSangre
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Donante> donantes = new List<Donante>();

            //Listado totalizador de sangre por tipo. Otra opción es acumular cada objeto "Sangre".
            List<Sangre> stock = new List<Sangre>();

            Queue<Paciente> pacientes = new Queue<Paciente>();

            Console.WriteLine("SISTEMA DE DONACIÓN DE SANGRE");

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n1. Ingresar un nuevo donante\n2. Ingresar un nuevo paciente\n3. Listar donantes.\n" +
                "4. Listar pacientes\n5. Donar\n6. Listar stock en banco\n9. Cargar set de prueba\n10. Editar Donante \n11. Salir del sistema");

                Console.WriteLine("\nIngrese la opción deseada: ");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarDonante(donantes);
                        break;
                    case 2:
                        IngresarPaciente(pacientes);
                        break;
                    case 3:
                        ListarDonantes(donantes);
                        break;
                    case 4:
                        ListarPacientes(pacientes);
                        break;
                    case 5:
                        Donar(donantes, stock);
                        break;
                    case 6:
                        ListarStock(stock);
                        break;
                    case 9:
                        CargarDatosDePrueba(donantes, pacientes, stock);
                        break;
                    case 10:
                        editarDonante(donantes);
                        break;
                    case 11:salir = true;
                        break;
                    default: 
                        Console.WriteLine("\n-Ingrese una opción valida-\n ");
                        break;
                }
            }
        }

        private static Donante BuscarDonante(List<Donante> donantes, int dni)
        {
            Donante donante = null;
            donante = donantes.FirstOrDefault(x => x.Dni == dni);

            return donante;
        }

        //Metodo para ingresar al sistema un nuevo donante.
        private static void IngresarDonante(List<Donante> donantes)
        {
            Console.WriteLine("\n-Ingresar Nuevo Donante:\n ");
            Console.WriteLine("Ingrese el DNI (sin puntos): ");
            int dni = Convert.ToInt32(Console.ReadLine());
            Donante d = BuscarDonante(donantes, dni);

            if (d != null)
            {
                Console.WriteLine("Ya existe el donante!");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido");
                string apellido = Console.ReadLine();

                Console.WriteLine("Ingrese la fecha de nacimiento: ");
                string fechaNacimiento = Console.ReadLine();

                Console.WriteLine("Ingrese el telefono (sin guiones ni paréntesis): ");
                int telefono = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el mail: ");
                string mail = Console.ReadLine();

                Console.WriteLine("Ingrese la dirección: ");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el grupo sanguíneo: ");
                string grupoSanguineo = Console.ReadLine();

                Donante donante = new Donante(dni, nombre, apellido, fechaNacimiento, telefono, mail, direccion, grupoSanguineo);

                donantes.Add(donante);
            };
        }

        //Metodo para ingresar al sistema un nuevo paciente.
        private static void IngresarPaciente(Queue<Paciente> pacientes)
        {
            Console.WriteLine("\n-Ingresar Nuevo Paciente:\n ");
            Console.WriteLine("Ingrese el DNI (sin puntos): ");
            int dni = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono (sin guiones ni paréntesis): ");
            string telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el mail: ");
            string mail = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección: ");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese el grupo sanguíneo: ");
            string grupoSanguineo = Console.ReadLine();

            Paciente paciente = new Paciente(nombre, apellido, dni, telefono, mail, direccion, grupoSanguineo);

            pacientes.Enqueue(paciente);
        }

        public static void ListarDonantes(List<Donante> donantes)
        {
            if (donantes.Count > 0)
            {
                foreach (Donante d in donantes)
                {
                    Console.WriteLine("\nNombre: " + d.Nombre + "\nApellido: " + d.Apellido + "\nD.N.I: " + d.Dni);
                }
            }
            else
            {
                Console.WriteLine("¡No hay donantes!");
            }
        }

        public static void ListarPacientes(Queue<Paciente> pacientes)
        {
            if (pacientes.Count > 0)
            {
                foreach (Paciente p in pacientes)
                {
                    Console.WriteLine("\nNombre: " + p.Nombre + "\nApellido: " + p.Apellido + "\nD.N.I: " + p.Dni);
                }
            }
            else
            {
                Console.WriteLine("¡No hay pacientes!");
            }
        }


        public static void Donar(List<Donante> donantes, List<Sangre> stock)
        {
            Console.WriteLine("Ingrese el DNI (sin puntos): ");

            int dni = Convert.ToInt32(Console.ReadLine());

            Donante d = BuscarDonante(donantes, dni);

            if (d == null)
            {
                Console.WriteLine("\nNo existe el donante");
            }
            else
            {
                Console.WriteLine("\nIngrese la cantidad de litros extraidos: ");
                
                int litros = int.Parse(Console.ReadLine());

                Sangre s = new Sangre(litros, d.GrupoSanguineo);

                AgregarSangre(s, stock);

                Console.WriteLine("\nSe ha agregado la extracción al banco!");
            }
        }

        static void AgregarSangre(Sangre s, List<Sangre> stock)
        {
            Sangre resultado = stock.FirstOrDefault(x => x.GrupoSanguineo == s.GrupoSanguineo);

            if (resultado != null)
            {
                stock.Remove(resultado);

                resultado.Litros = resultado.Litros + s.Litros;

                stock.Add(resultado);
            }
            else
            {
                stock.Add(s);
            };
        }

        static void ListarStock(List<Sangre> stock)
        {
            foreach(Sangre s in stock)
            {
                Console.WriteLine("\nGrupo: " + s.GrupoSanguineo + "\nLitros: " + s.Litros);
            }
        }

        public static void editarDonante(List<Donante> donantes)
        {
            Console.WriteLine("Ingrese el DNI (sin puntos): ");

            int dni = Convert.ToInt32(Console.ReadLine());

            Donante d = BuscarDonante(donantes, dni);

            if (d == null)
            {
                Console.WriteLine("\nNo existe el donante");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido");
                string apellido = Console.ReadLine();

                Console.WriteLine("Ingrese la fecha de nacimiento: ");
                string fechaNacimiento = Console.ReadLine();

                Console.WriteLine("Ingrese el telefono (sin guiones ni paréntesis): ");
                int telefono = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el mail: ");
                string mail = Console.ReadLine();

                Console.WriteLine("Ingrese la dirección: ");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el grupo sanguíneo: ");
                string grupoSanguineo = Console.ReadLine();

                d.Nombre = nombre;
                d.Apellido = apellido;
                d.FechaNacimiento = fechaNacimiento;
                d.Telefono = telefono;
                d.Mail = mail;
                d.Direccion = direccion;
                d.GrupoSanguineo = grupoSanguineo;


                Console.WriteLine("Datos modificados");
            }
        }





        static void CargarDatosDePrueba(List<Donante> donantes, Queue<Paciente> pacientes, List<Sangre> stock)
        {
            Donante d1 = new Donante(38000000, "Juan", "Perez", "01/01/1990", 1558201451, "prueba1@hotmail.com", "Calle falsa 121", "A+");
            Donante d2 = new Donante(38000001, "Luis", "Ocres", "02/01/1990", 1558201452, "prueba2@hotmail.com", "Calle falsa 122", "A+");
            Donante d3 = new Donante(38000002, "José", "Pedro", "03/01/1990", 1558201453, "prueba3@hotmail.com", "Calle falsa 123", "B+");
            Donante d4 = new Donante(38000003, "Luli", "Mines", "04/01/1990", 1558201454, "prueba4@hotmail.com", "Calle falsa 124", "B+");
            Donante d5 = new Donante(38000004, "Mili", "Tujio", "05/01/1990", 1558201455, "prueba5@hotmail.com", "Calle falsa 125", "AB+");
            Donante d6 = new Donante(38000005, "Pili", "Munic", "06/01/1990", 1558201456, "prueba6@hotmail.com", "Calle falsa 126", "AB+");

            donantes.Add(d1);
            donantes.Add(d2);
            donantes.Add(d3);
            donantes.Add(d4);
            donantes.Add(d5);
            donantes.Add(d6);

            Paciente p1 = new Paciente("Santi", "Silva",    37000000,"1555555551", "paciente1@gmail.com", "direccion 1", "A+");
            Paciente p2 = new Paciente("Mati", "Suarez",    37000001,"1555555552", "paciente2@gmail.com", "direccion 1", "A +");
            Paciente p3 = new Paciente("Juli", "Borre",     37000002,"1555555553", "paciente3@gmail.com", "direccion 3", "B +");
            Paciente p4 = new Paciente("Juani", "Pratto",   37000003,"1555555554", "paciente4@gmail.com", "direccion 4", "B +");
            Paciente p5 = new Paciente("Dalma", "Maradona", 37000004,"1555555555", "paciente5@gmail.com", "direccion 5", "AB +");
            Paciente p6 = new Paciente("Memi", "Mora",      37000005,"1555555556", "paciente6@gmail.com", "direccion 6", "AB +");

            pacientes.Enqueue(p1);
            pacientes.Enqueue(p2);
            pacientes.Enqueue(p3);
            pacientes.Enqueue(p4);
            pacientes.Enqueue(p5);
            pacientes.Enqueue(p6);

            AgregarSangre(new Sangre(1, d1.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(2, d1.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(3, d2.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(4, d3.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(5, d4.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(6, d5.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(7, d5.GrupoSanguineo), stock);
            AgregarSangre(new Sangre(8, d6.GrupoSanguineo), stock);

            Console.WriteLine("Datos Cargados!\nConsultar en la Opcion 3.");
        }
    }
}
