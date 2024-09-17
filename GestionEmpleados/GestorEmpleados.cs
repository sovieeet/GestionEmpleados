using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace GestionEmpleados
{
    public class GestorEmpleados
    {
        private List<Empleado> empleados = new List<Empleado>();
        private readonly string rutaArchivo = "empleados.json";

        public GestorEmpleados()
        {
            CargarEmpleados();
        }

        public void AñadirEmpleado(Empleado empleado)
        {
            empleado.ID = ObtenerProximoIDDisponible();
            empleados.Add(empleado);
            GuardarEmpleados();
            Console.WriteLine($"Empleado {empleado.Nombre} agregado correctamente.");   
        }

        private int ObtenerProximoIDDisponible()
        {
            if (empleados.Count == 0) return 1;
            
            var idsExistentes = empleados.Select (e => e.ID).OrderBy(id => id).ToList();

            int idDisponible = 1;
            foreach (int id in idsExistentes)
            {
                if (id != idDisponible)
                {
                    return idDisponible;
                }
                idDisponible++;
            }
            return idDisponible;
        }

        public void EliminarEmpleado(int id)
        {
            var empleadoAEliminar = empleados.FirstOrDefault(e => e.ID == id);
            if (empleadoAEliminar != null)
            {
                Console.WriteLine($"Empleado encontrado: {empleadoAEliminar.Nombre}, Edad: {empleadoAEliminar.Edad}, Salario: {empleadoAEliminar.Salario}");
                Console.Write("¿Estás seguro que deseas eliminar este empleado? (s/n): ");
                string confirmacion = Console.ReadLine().ToLower();

                if (confirmacion == "s")
                {
                    empleados.Remove(empleadoAEliminar);
                    GuardarEmpleados();
                    Console.WriteLine($"Empleado con ID {id} ha sido eliminado.");
                }
                else
                {
                    Console.WriteLine("Operación cancelada, el empleado no fue eliminado.");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró un empleado con el ID {id}.");
            }
        }

        public Empleado BuscarEmpleadoPorID(int id)
        {
            return empleados.FirstOrDefault(e => e.ID == id);
        }

        private void GuardarEmpleados()
        {
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string json = JsonSerializer.Serialize(empleados, opciones);
            File.WriteAllText(rutaArchivo, json);
        }

        private void CargarEmpleados()
        {
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string json = File.ReadAllText(rutaArchivo);

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        empleados = new List<Empleado>();
                    }
                    else
                    {
                        empleados = JsonSerializer.Deserialize<List<Empleado>>(json);
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El archivo JSON está dañado o tiene un formato incorrecto. Se inicializará una lista vacía.");
                    empleados = new List<Empleado>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error al cargar los empleados: {ex.Message}");
                    empleados = new List<Empleado>();
                }
            }
            else
            {
                empleados = new List<Empleado>(); // Si no existe el archivo, inicializar lista vacía
            }
        }
        public void MostrarTodosEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                Console.WriteLine("Lista de todos los empleados");
                foreach (var empleado in empleados.OrderBy(e => e.ID))
                {
                    Console.WriteLine($"ID: {empleado.ID}, Nombre: {empleado.Nombre}, Edad: {empleado.Edad}, Salario: {empleado.Salario}");
                }
            }
        }
    }
}
