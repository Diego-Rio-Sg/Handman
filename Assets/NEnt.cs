using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class NEnt
    {
        private int n;

        public NEnt()
        {
            n = 0;
        }

        public void Cargar(int N)
        {
            n = N;
        }

        public int Descargar()
        {
            return n;
        }

        public void CargarRandom(int a, int b)
        {
            Random random = new Random();
            n = random.Next(a, b);

        }


    }
}