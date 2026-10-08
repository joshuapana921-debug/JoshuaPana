using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshuaPana
{
    internal class Program
    {
        static int cantidad = 0;

        static void Main()
        {
            int N = 19;

            string[] nombres = new string[N];
            string[] cedulas = new string[N];
            int[] edades = new int[N];
            int[] gravedad = new int[N];

            Inicializar(nombres, cedulas, edades, gravedad, N);

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("       AISLAMIENTO CRITICO");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Actualizar gravedad");
                Console.WriteLine("3. Mostrar pacientes");
                Console.WriteLine("4. Mostrar paciente prioritario");
                Console.WriteLine("5. Inicializar registros");
                Console.WriteLine("6. Salir");
                Console.WriteLine("=================================");
                Console.Write("Seleccione una opcion: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarPaciente(nombres, cedulas, edades, gravedad, N);
                        break;

                    case 2:
                        ActualizarGravedad(nombres, gravedad);
                        break;

                    case 3:
                        MostrarPacientes(nombres, cedulas, edades, gravedad);
                        break;

                    case 4:
                        MostrarPrioritario(nombres, cedulas, edades, gravedad);
                        break;

                    case 5:
                        Inicializar(nombres, cedulas, edades, gravedad, N);
                        Console.WriteLine("Registros inicializados correctamente.");
                        break;

                    case 6:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcion != 6);
        }


        static void Inicializar(
            string[] nombres,
            string[] cedulas,
            int[] edades,
            int[] gravedad,
            int N)
        {
            for (int i = 0; i < N; i++)
            {
                nombres[i] = "";
                cedulas[i] = "";
                edades[i] = 0;
                gravedad[i] = 0;
            }

            cantidad = 0;
        }


        static void AgregarPaciente(
            string[] nombres,
            string[] cedulas,
            int[] edades,
            int[] gravedad,
            int N)
        {
            if (cantidad >= N)
            {
                Console.WriteLine("No se pueden agregar mas pacientes.");
                Console.WriteLine("El maximo es de 19 pacientes.");
                return;
            }

            Console.WriteLine("\n=== AGREGAR PACIENTE ===");

            // Nombre
            Console.Write("Ingrese el nombre: ");
            nombres[cantidad] = Console.ReadLine();

            // Cedula
            Console.Write("Ingrese la cedula: ");
            cedulas[cantidad] = Console.ReadLine();

            // Edad
            Console.Write("Ingrese la edad: ");
            edades[cantidad] = int.Parse(Console.ReadLine());

            while (edades[cantidad] < 0)
            {
                Console.Write("Ingrese una edad valida: ");
                edades[cantidad] = int.Parse(Console.ReadLine());
            }

            // Gravedad
            Console.Write("Ingrese la gravedad (1-10): ");
            gravedad[cantidad] = int.Parse(Console.ReadLine());

            while (gravedad[cantidad] < 1 || gravedad[cantidad] > 10)
            {
                Console.Write("La gravedad debe estar entre 1 y 10: ");
                gravedad[cantidad] = int.Parse(Console.ReadLine());
            }

            cantidad++;

            Console.WriteLine("\nPaciente agregado correctamente.");
        }


        static void ActualizarGravedad(
            string[] nombres,
            int[] gravedad)
        {
            if (cantidad == 0)
            {
                Console.WriteLine("Debe agregar pacientes primero.");
                return;
            }

            Console.Write("Ingrese el numero del paciente: ");
            int posicion = int.Parse(Console.ReadLine());

            if (posicion < 1 || posicion > cantidad)
            {
                Console.WriteLine("Paciente no encontrado.");
                return;
            }

            posicion--;

            Console.WriteLine("Paciente: " + nombres[posicion]);

            Console.Write("Ingrese la nueva gravedad (1-10): ");
            gravedad[posicion] = int.Parse(Console.ReadLine());

            while (gravedad[posicion] < 1 || gravedad[posicion] > 10)
            {
                Console.Write("La gravedad debe estar entre 1 y 10: ");
                gravedad[posicion] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Gravedad actualizada correctamente.");
        }


        static void MostrarPacientes(
            string[] nombres,
            string[] cedulas,
            int[] edades,
            int[] gravedad)
        {
            if (cantidad == 0)
            {
                Console.WriteLine("Debe agregar pacientes primero.");
                return;
            }

            Console.WriteLine("\n=== PACIENTES REGISTRADOS ===");

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("\nPaciente " + (i + 1));
                Console.WriteLine("Nombre: " + nombres[i]);
                Console.WriteLine("Cedula: " + cedulas[i]);
                Console.WriteLine("Edad: " + edades[i]);
                Console.WriteLine("Gravedad: " + gravedad[i]);
            }
        }


        static void MostrarPrioritario(
            string[] nombres,
            string[] cedulas,
            int[] edades,
            int[] gravedad)
        {
            if (cantidad == 0)
            {
                Console.WriteLine("Debe agregar pacientes primero.");
                return;
            }

            int mayor = gravedad[0];
            int posicion = 0;

            for (int i = 1; i < cantidad; i++)
            {
                if (gravedad[i] > mayor)
                {
                    mayor = gravedad[i];
                    posicion = i;
                }
            }

            Console.WriteLine("\n=== PRIORIDAD DE ATENCION ===");
            Console.WriteLine("Nombre: " + nombres[posicion]);
            Console.WriteLine("Cedula: " + cedulas[posicion]);
            Console.WriteLine("Edad: " + edades[posicion]);
            Console.WriteLine("Gravedad: " + gravedad[posicion]);
        }
    }
}
