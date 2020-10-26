using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DonacionSangre
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Donante> donantes = new List<Donante>();

            Queue<Paciente> pacientes = new Queue<Paciente>();

            Console.WriteLine("SISTEMA DE DONACIÓN DE SANGRE");

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1. Ingresar un nuevo donante\n2. Ingresar un nuevo paciente\n3. Listar donantes.\n" +
                "4. Listar pacientes\n5. Salir del sistema");

                Console.WriteLine("Ingrese la opción deseada: ");

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
                    default: salir = true;
                        break;
                }
            }
        }

        //Metodo para ingresar al sistema un nuevo donante.
        private static void IngresarDonante(List<Donante> donantes)
        {
            Console.WriteLine("Ingrese el DNI (sin puntos): ");
            int dni = Convert.ToInt32(Console.ReadLine());

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
            
        }

        //Metodo para ingresar al sistema un nuevo paciente.
        private static void IngresarPaciente(Queue<Paciente> pacientes)
        {
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
                    Console.WriteLine("Nombre: " + d.Nombre + "\nApellido: " + d.Apellido + "\nD.N.I: " + d.Dni);
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
                    Console.WriteLine("Nombre: " + p.Nombre + "\nApellido: " + p.Apellido + "\nD.N.I: " + p.Dni);
                }
            }
            else
            {
                Console.WriteLine("¡No hay pacientes!");
            }
        }
    }
}
