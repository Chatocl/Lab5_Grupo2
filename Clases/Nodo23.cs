using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Nodo23<T> where T : IComparable<T>
    {
        public Nodo23<T> LHijo { get; set; }
        public Nodo23<T> CHijo { get; set; }
        public Nodo23<T> DHijo { get; set; }
        public T VIzq { get; set; }
        public T VDer { get; set; }

    }
}
