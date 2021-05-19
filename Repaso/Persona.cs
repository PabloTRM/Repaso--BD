using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{   
    public class Persona
    {
        private String nombre;
        private String cp;

        public Persona()
        {
        }

        public Persona(string nombre, string cp)
        {
            this.Nombre = nombre;
            this.Cp = cp;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Cp { get => cp; set => cp = value; }
    }
}
