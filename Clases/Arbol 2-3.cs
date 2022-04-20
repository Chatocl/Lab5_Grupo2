using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Arbol_2_3<T> : Nodo<T> where T : IComparable<T>
    {
        private Nodo<T> Raiz = new Nodo<T>();
        private Nodo<T> temp = new Nodo<T>();
        private T temp2;
        public int ObtenerFE(Nodo<T> n)
        {

            if (n == null)
            {
                return -1;
            }
            else
            {
                return n.FE;
            }

        }

        public void insert(T value, Nodo<T> nodo)
        {
            if (Raiz.Val1 != null || Raiz.Val2 != null)
            {
                if (Raiz.Val1 != null)
                {
                    Raiz.Val1 = value;
                }
                else if (Raiz.Val2 != null)
                {
                    if (Raiz.Val1.CompareTo(value) == -1) 
                    {
                        Raiz.Val2 = value;
                    }
                    else
                    {
                        temp2 = Raiz.Val1;
                        Raiz.Val1 = value;
                        Raiz.Val2 = temp2;
                    }
                   
                }
            }
            else if (nodo. ) 
            {
                
            }
        }
    }
}
