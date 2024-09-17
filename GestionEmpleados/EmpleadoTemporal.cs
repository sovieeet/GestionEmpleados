using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public class EmpleadoTemporal : Empleado
    {
        private int duracionContrato;

        public int DuracionContrato { get => duracionContrato; set => duracionContrato = value; }

        public double CalcularSalarioTotal()
        {
            return Salario * DuracionContrato;
        }
    }
}
