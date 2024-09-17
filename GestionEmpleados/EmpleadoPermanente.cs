using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public class EmpleadoPermanente : Empleado
    {
        public int antiguedad;

        public int Antiguedad { get => antiguedad; set => antiguedad = value; }

        public double CalcularSalarioAnual()
        {
            return Salario * 12 * (1 + 0.1 * Antiguedad);
        }
    }
}
