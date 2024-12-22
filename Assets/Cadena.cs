using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    class Cadena
    {
        private String s;

        public Cadena()
        {
            s = "";
        }

        public void Cargar(String cad)
        {
            s = cad;
        }
        public string Descargar()
        {
            return s;
        }
        public int Dim()
        {
            return s.Length;
        }
        public void ConverMay()
        {
            s = s.ToUpper();
        }
        public void ElimSpace()
        {
            s = s.Trim();
        }
        public void ToUpTrim()
        {
            ConverMay();
            ElimSpace();
        }
    }
}
