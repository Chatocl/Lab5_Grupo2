using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Nodo<T> where T : IComparable<T>
    {
        public Nodo<T> PriHijo { get; set; }
        public Nodo<T> SegHijo { get; set; }
        public Nodo<T> TerHijo { get; set; }
        public Nodo<T> Padre { get; set; }
        public T Val1 { get; set; }
        public T Val2 { get; set; }
        public int FE { get; set; }

    }
}
