using System;

namespace DonacionSangre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE DONACIÓN DE SANGRE");

            Console.WriteLine("1. Ingresar un nuevo donante\n2. Ingresar un nuevo paciente\n3. Listar donantes.\n" +
                "4. Listar pacientes\n5. Salir del sistema");

            Console.WriteLine("Ingrese la opción deseada: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch(opcion)
            {
                case 1:
                    IngresarDonante();
                    break;
                case 2:
                    IngresarPaciente();
                    break;
                case 3:
                    //todo listar donantes
                    break;
                case 4:
                    //todo listar pacientes
                    break;
                case 5:
                default:
                    break;
            }
        }

        //Metodo para ingresar al sistema un nuevo donante.
        private static void IngresarDonante()
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
        }

        //Metodo para ingresar al sistema un nuevo paciente.
        private static void IngresarPaciente()
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
        }
    }
}
