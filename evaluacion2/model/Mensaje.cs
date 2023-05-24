using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DTO
{
    public class Mensaje
    {
        private string nmedidor;
        private string fecha;
        private string valorcons;

        public string Nmedidor { get => nmedidor; set => nmedidor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Valorcons { get => valorcons; set => valorcons = value; }

        public override string ToString()
        {
            return nmedidor + " " + fecha + " " + valorcons;
        }
    }
}