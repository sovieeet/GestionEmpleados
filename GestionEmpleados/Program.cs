using GestionEmpleados;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main()
    {
        GestorEmpleados gestor = new GestorEmpleados();
        bool continuar = true;

        while (continuar)
        {
            gestor.MostrarTodosEmpleados();

            Console.WriteLine("¿Deseas agregar, eliminar un empleado, o salir? (a/e/s para salir): ");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta == "a")
            {
                Console.WriteLine("¿El empleado es permanente o temporal? (p/t): ");
                string tipoEmpleado = Console.ReadLine().ToLower();

                Console.Write("Ingresa el nombre del empleado: ");
                string nombre = Empleado.ValidarNombre();

                Console.Write("Ingresa la edad del empleado: ");
                int edad = ConvertirAEntero("edad");

                Console.Write("Ingresa el salario del empleado: ");
                int salario = ConvertirAEntero("salario");

                if (tipoEmpleado == "p")
                {
                    Console.Write("Ingresa la antigüedad del empleado en años: ");
                    int antiguedad = ConvertirAEntero("antigüedad");

                    EmpleadoPermanente nuevoEmpleadoPermanente = new EmpleadoPermanente()
                    {
                        Nombre = nombre,
                        Edad = edad,
                        Salario = salario,
                        Antiguedad = antiguedad
                    };

                    gestor.AñadirEmpleado(nuevoEmpleadoPermanente);
                }
                else if (tipoEmpleado == "t")
                {
                    Console.Write("Ingresa la duración del contrato en meses: ");
                    int duracionContrato = ConvertirAEntero("duración del contrato");

                    EmpleadoTemporal nuevoEmpleadoTemporal = new EmpleadoTemporal()
                    {
                        Nombre = nombre,
                        Edad = edad,
                        Salario = salario,
                        DuracionContrato = duracionContrato
                    };

                    gestor.AñadirEmpleado(nuevoEmpleadoTemporal);
                }
                else
                {
                    Console.WriteLine("Opción no válida, no se agregó ningún empleado.");
                }
            }
            else if (respuesta == "e")
            {
                Console.Write("Ingresa el ID del empleado que deseas eliminar: ");
                int id = ConvertirAEntero("ID");

                gestor.EliminarEmpleado(id);
            }
            else if (respuesta == "s")
            {
                Console.WriteLine("¡Gracias por usar el sistema de gestión de empleados!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
            }

            Console.WriteLine();
        }
    }

    private static int ConvertirAEntero(string campo)
    {
        while (true)
        {
            try
            {
                int valor = int.Parse(Console.ReadLine());

                if (campo == "edad" && valor <= 0)
                {
                    Console.WriteLine("La edad debe ser mayor a 0.Inténtalo de nuevo: ");
                    continue;
                }

                if (campo == "salario" && valor <= 0)
                {
                    Console.WriteLine("El salario debe ser mayor a 0.Inténtalo de nuevo: ");
                    continue;
                }

                return valor;
            }
            catch
            {
                Console.WriteLine($"Valor inválido para {campo}. Inténtalo de nuevo:");
            }
        }
    }
}
