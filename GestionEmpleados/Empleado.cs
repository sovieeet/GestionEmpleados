using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public class Empleado
    {
        public int ID { get; set; }
        private string nombre;
        private int edad;
        private int salario;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salario { get => salario; set => salario = value; }

        public static string ValidarNombre()
        {
            while (true)
            {
                string nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío. Inténtalo de nuevo:");
                    continue;
                }

                if (!Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"))
                {
                    Console.WriteLine("El nombre solo puede contener letras y espacios. Inténtalo de nuevo:");
                    continue;
                }

                return nombre;
            }
        }
    }
}
