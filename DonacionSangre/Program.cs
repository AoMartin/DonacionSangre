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

            Console.WriteLine("----------SISTEMA DE DONACIÓN DE SANGRE----------");

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n\t1. Ingresar un nuevo donante\n\t2. Ingresar un nuevo paciente\n\t3. Listar donantes\n\t" +
                "4. Listar pacientes\n\t5. Donar\n\t6. Listar stock en banco\n\t7. Hacer una transfusion\n\t8. Cargar set de prueba\n\t9. Editar Donante \n\t10. Salir del sistema");

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
                    case 7:
                        HacerTransfusion(pacientes,stock);
                        break;
                    case 8:
                        CargarDatosDePrueba(donantes, pacientes, stock);
                        break;
                    case 9:
                        EditarDonante(donantes);
                        break;
                    case 10:
                        salir = true;
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

                Sangre grupoSanguineo = IngresarTipoSangre();

                Donante donante = new Donante(dni, nombre, apellido, fechaNacimiento, telefono, mail, direccion, grupoSanguineo);

                donantes.Add(donante);
                Console.WriteLine("-Donante ingresado-");
            };
        }

        //Esta funcion se usas cuando se le solicita al usuario ingresar un tipo de sangre
        static Sangre IngresarTipoSangre()
        {
            bool ingresoExitoso = false;

            //Se instancia un nuevo objeto Sangre y se usa para ir cargando los datos ingresados
            Sangre tipoIngresado = new Sangre(0,GrupoSangre.A,false);

            while (!ingresoExitoso)
            {
                Console.WriteLine("\n1- A \n2- B \n3- AB \n4- Cero");
                Console.WriteLine("Ingrese el grupo sanguíneo: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        tipoIngresado.GrupoSanguineo = GrupoSangre.A;
                        ingresoExitoso = true;
                        break;
                    case 2:
                        tipoIngresado.GrupoSanguineo = GrupoSangre.B;
                        ingresoExitoso = true;
                        break;
                    case 3:
                        tipoIngresado.GrupoSanguineo = GrupoSangre.AB;
                        ingresoExitoso = true;
                        break;
                    case 4:
                        tipoIngresado.GrupoSanguineo = GrupoSangre.Cero;
                        ingresoExitoso = true;
                        break;
                    default:
                        Console.WriteLine("\n-Ingrese una opción valida-\n ");
                        break;
                }
            }

            ingresoExitoso = false;

            while (!ingresoExitoso)
            {
                Console.WriteLine("Es factor RH positivo (S/N): ");
                string factor = Console.ReadLine().ToLower();

                if(factor=="si" || factor == "s")
                {
                    tipoIngresado.FactorRH = true;
                    ingresoExitoso = true;
                }
                if (factor == "no" || factor == "n")
                {
                    tipoIngresado.FactorRH = false;
                    ingresoExitoso = true;
                }

                if (!ingresoExitoso)
                 Console.WriteLine("\n-Ingrese una opción valida (S/N)-\n ");
            }

            return tipoIngresado;
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
            int telefono = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el mail: ");
            string mail = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección: ");
            string direccion = Console.ReadLine();

            Sangre grupoSanguineo = IngresarTipoSangre();

            Paciente paciente = new Paciente(nombre, apellido, dni, telefono, mail, direccion, grupoSanguineo);

            Console.WriteLine("\nCuantos litros de sangre necesita: ");
            int litros = Convert.ToInt32(Console.ReadLine());
            grupoSanguineo.Litros = litros;

            pacientes.Enqueue(paciente);
            Console.WriteLine("-Paciente ingresado-");
        }

        public static void ListarDonantes(List<Donante> donantes)
        {
            if (donantes.Count > 0)
            {
                Console.WriteLine("\n-Listado de Donantes:\n ");
                foreach (Donante d in donantes)
                {
                    Console.WriteLine("\nNombre: " + d.Nombre + "\nApellido: " + d.Apellido + "\nD.N.I: " + d.Dni);
                    Console.WriteLine("Sangre Grupo: " + d.TipoSangre.GrupoSanguineo + "\nFactor RH: " + FactorRH(d.TipoSangre.FactorRH));
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
                Console.WriteLine("\n-Listado de Pacientes:\n ");
                foreach (Paciente p in pacientes)
                {
                    Console.WriteLine("\nNombre: " + p.Nombre + "\nApellido: " + p.Apellido + "\nD.N.I: " + p.Dni);
                    Console.WriteLine("Sangre Grupo: " + p.TipoSangre.GrupoSanguineo + "\nFactor RH: " + FactorRH(p.TipoSangre.FactorRH));
                    Console.WriteLine("Necesita " + p.TipoSangre.Litros + " litros de sangre");
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

                Sangre s = new Sangre(litros, d.TipoSangre.GrupoSanguineo, d.TipoSangre.FactorRH);

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
                Console.WriteLine("\nGrupo: " + s.GrupoSanguineo);
                if(s.FactorRH)
                    Console.WriteLine("Factor: Positivo");
                else
                    Console.WriteLine("Factor: Negativo");
                Console.WriteLine("Litros: " + s.Litros);
            }
        }

        public static void EditarDonante(List<Donante> donantes)
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

                Sangre grupoSanguineo = IngresarTipoSangre();

                d.Nombre = nombre;
                d.Apellido = apellido;
                d.FechaNacimiento = fechaNacimiento;
                d.Telefono = telefono;
                d.Mail = mail;
                d.Direccion = direccion;
                d.TipoSangre = grupoSanguineo;


                Console.WriteLine("Datos modificados");
            }
        }

        static bool ChequearCompatibilidad(Sangre donante, Sangre receptor)
        {
            // Cero- puede donar a todos los tipos y factores
            if (donante.GrupoSanguineo == GrupoSangre.Cero && donante.FactorRH == false) return true;
            // AB+ puede recibir de todos los tipos y factorRH
            if (receptor.GrupoSanguineo == GrupoSangre.AB && receptor.FactorRH == true) return true;
            // Si el donante y el receptor tienen el mismo tipo y el factor es igual o positivo
            if (receptor.GrupoSanguineo == donante.GrupoSanguineo)
            {
                if (donante.FactorRH || donante.FactorRH == receptor.FactorRH) return true;
            }
            // AB- puede recibir de A- y B-
            if(receptor.GrupoSanguineo == GrupoSangre.AB && !receptor.FactorRH)
            {
                if (donante.GrupoSanguineo == GrupoSangre.A && !donante.FactorRH) return true;
                if (donante.GrupoSanguineo == GrupoSangre.B && !donante.FactorRH) return true;
            }
            // Si no se sumple ninguna condicion
            return false;
        }

        static void HacerTransfusion(Queue<Paciente> pacientes, List<Sangre> stock)
        {
            if(pacientes.Count == 0)
            {
                Console.WriteLine("-No hay pacientes en lista de espera.-");
                return;
            }
            if (stock.Count == 0)
            {
                Console.WriteLine("-Actualmente no hay reservas disponibles en el banco.-");
                return;
            }

            Paciente pacienteActual = pacientes.Peek();
            Sangre sangreCompatible = null;

            Console.WriteLine("\nEl paciente actual en la lista de espera es: ");
            Console.WriteLine(pacienteActual.Nombre +" " + pacienteActual.Apellido + " DNI: " + pacienteActual.Dni);
            Console.WriteLine("Sangre Grupo: " + pacienteActual.TipoSangre.GrupoSanguineo + " Factor RH: " + FactorRH(pacienteActual.TipoSangre.FactorRH));
            Console.WriteLine("El paciente necesita " + pacienteActual.TipoSangre.Litros + " litros de sangre.");

            foreach(Sangre s in stock)
            {
                if (ChequearCompatibilidad(s, pacienteActual.TipoSangre))
                {
                    if( s.Litros >= pacienteActual.TipoSangre.Litros)
                        sangreCompatible = s;
                }
            }

            if(sangreCompatible == null)
            {
                Console.WriteLine("\nNo hay stock disponible para la cantidad necesaria de litros del grupo y factor que necesita el paciente.");
            }
            else
            {
                sangreCompatible.Litros -= pacienteActual.TipoSangre.Litros;
                if (sangreCompatible.Litros <= 0)
                    stock.Remove(sangreCompatible);

                Console.WriteLine("\nLa transfusion fue realizada con exito.");
                pacientes.Dequeue();
                Console.WriteLine("Quedan " + pacientes.Count + " pacientes en lista de espera.");
            }

            return;
        }

        public static string FactorRH(bool factor)
        {
            if (factor)
                return "Positivo";
            else
                return "Negativo";
        }

        static void CargarDatosDePrueba(List<Donante> donantes, Queue<Paciente> pacientes, List<Sangre> stock)
        {
            Donante d1 = new Donante(38000000, "Juan", "Perez", "01/01/1990", 1558201451, "prueba1@hotmail.com", "Calle falsa 121", new Sangre(1,GrupoSangre.A,true));
            Donante d2 = new Donante(38000001, "Luis", "Ocres", "02/01/1990", 1558201452, "prueba2@hotmail.com", "Calle falsa 122", new Sangre(2, GrupoSangre.B, true));
            Donante d3 = new Donante(38000002, "José", "Pedro", "03/01/1990", 1558201453, "prueba3@hotmail.com", "Calle falsa 123", new Sangre(3, GrupoSangre.AB, false));
            Donante d4 = new Donante(38000003, "Luli", "Mines", "04/01/1990", 1558201454, "prueba4@hotmail.com", "Calle falsa 124", new Sangre(4, GrupoSangre.Cero, false));
            Donante d5 = new Donante(38000004, "Mili", "Tujio", "05/01/1990", 1558201455, "prueba5@hotmail.com", "Calle falsa 125", new Sangre(5, GrupoSangre.AB, true));
            Donante d6 = new Donante(38000005, "Pili", "Munic", "06/01/1990", 1558201456, "prueba6@hotmail.com", "Calle falsa 126", new Sangre(6, GrupoSangre.AB, false));

            donantes.Add(d1);
            donantes.Add(d2);
            donantes.Add(d3);
            donantes.Add(d4);
            donantes.Add(d5);
            donantes.Add(d6);

            Paciente p1 = new Paciente("Santi", "Silva",    37000000, 1555555551 , "paciente1@gmail.com", "direccion 1", new Sangre(1,GrupoSangre.A,true));
            Paciente p2 = new Paciente("Mati", "Suarez",    37000001, 1555555552, "paciente2@gmail.com", "direccion 1", new Sangre(2, GrupoSangre.B, true));
            Paciente p3 = new Paciente("Juli", "Borre",     37000002, 1555555553, "paciente3@gmail.com", "direccion 3", new Sangre(3, GrupoSangre.AB, false));
            Paciente p4 = new Paciente("Juani", "Pratto",   37000003, 1555555554, "paciente4@gmail.com", "direccion 4", new Sangre(4, GrupoSangre.Cero, false));
            Paciente p5 = new Paciente("Dalma", "Maradona", 37000004, 1555555555, "paciente5@gmail.com", "direccion 5", new Sangre(5, GrupoSangre.AB, true));
            Paciente p6 = new Paciente("Memi", "Mora",      37000005, 1555555556, "paciente6@gmail.com", "direccion 6", new Sangre(6, GrupoSangre.AB, false));

            pacientes.Enqueue(p1);
            pacientes.Enqueue(p2);
            pacientes.Enqueue(p3);
            pacientes.Enqueue(p4);
            pacientes.Enqueue(p5);
            pacientes.Enqueue(p6);

            AgregarSangre(d1.TipoSangre, stock);
            AgregarSangre(d1.TipoSangre, stock);
            AgregarSangre(d2.TipoSangre, stock);
            AgregarSangre(d3.TipoSangre, stock);
            AgregarSangre(d4.TipoSangre, stock);
            AgregarSangre(d5.TipoSangre, stock);
            AgregarSangre(d5.TipoSangre, stock);
            AgregarSangre(d6.TipoSangre, stock);

            Console.WriteLine("Datos Cargados!\nConsultar en la Opcion 3.");
        }
    }
}
