using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Vector
    {
        const int MAX = 201;
        private int[] V;
        private int ne;
        public Vector()
        {
            V = new int[MAX];
            ne = 0;
        }
        public void CargarNum(int n)
        {
            ne++;
            V[ne] = n;
        }
        public bool XenVector(int X)
        {
            bool b = false;

            for (int i = 1; i <= ne; i++)
            {
                if (V[i] == X)
                {
                    b = true;
                }
            }
            return b;
        }
        public int DimV()
        {
            return ne;
        }
        public void ElimX(int i)
        {
            for (i = 1; i < ne; i++)
            {
                V[i] = i + 1;
            }
            ne--;
        }
        public void ResetV()
        {
            for (int i = 1; i <= ne; i++)
            {
                ElimX(i);
            }
        }
    }
}