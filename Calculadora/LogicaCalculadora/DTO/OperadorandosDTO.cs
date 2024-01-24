using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaCalculadora.DTO
{
    public class OperadorandosDTO
    {
        public string Value { get; set; }
        public OperadorandosDTO Izquierda { get; set; }
        
        public OperadorandosDTO Derecha { get; set; }
    }
}
