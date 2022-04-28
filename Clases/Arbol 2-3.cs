using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class Arbol_2_3<T> : Nodo23<T> where T : IComparable<T>
    {
        private Nodo23<T> Root = new Nodo23<T>();
        private Nodo23<T> temp = new Nodo23<T>();
        private List<T> listaOrdenada = new List<T>();
        private T FindHelp(Nodo23<T> Help, T value ) 
        {
            if (Root == null)
            {
                return default(T);
            }
            if (Help.VIzq != null && value.CompareTo(Help.VIzq)==0)
            {
                return Help.VIzq;
            }
            if (Help.VDer != null && value.CompareTo(Help.VDer) == 0)
            {
                return Help.VIzq; //VDer
            }

            if (value.CompareTo(Help.VIzq) < 0)
            {
                return FindHelp(Help.LHijo, value);
            }
            else if (value.CompareTo(Help.VDer) < 0) 
            {
                return FindHelp(Help.CHijo, value);
            }
            else
            {
                return FindHelp(Help.DHijo, value);
            }
        }
        private Nodo23<T> FindNodo(Nodo23<T> Help, T value)
        {
            if (Root == null)
            {
                return default;
            }
            if (Help.VIzq != null && value.CompareTo(Help.VIzq) == 0)
            {
                return Help;
            }
            if (Help.VDer != null && value.CompareTo(Help.VDer) == 0)
            {
                return Help;
            }

            if (value.CompareTo(Help.VIzq) < 0)
            {
                return FindNodo(Help.LHijo, value);
            }
            else if (value.CompareTo(Help.VDer) < 0)
            {
                return FindNodo(Help.CHijo, value);
            }
            else
            {
                return FindNodo(Help.DHijo, value);
            }
        }
        private Nodo23<T> CreateNodo23(T Value1, T Value2, Nodo23<T> L, Nodo23<T> C, Nodo23<T> D) 
        {
            Nodo23<T> n = new Nodo23<T>();
            n.VIzq = Value1;
            n.VDer = Value2;
            n.LHijo = L;
            n.CHijo = C;
            n.DHijo = D;
           
            return n;
        }
        public T Edit(T value)
        {
            return FindHelp(Root, value);
        }
        public void Remove(T deleteV)
        {

            Nodo23<T> aux = new Nodo23<T>();
            aux = FindNodo(Root,deleteV);
            if (aux != null)
            {
                Delete(aux, deleteV);
            }

            //return deleteV;
        }
        void Delete(Nodo23<T> Hlp, T value)
        {


            /////---CAmbios del delete


            if (Hlp.DHijo == null && Hlp.CHijo == null && Hlp.LHijo == null) //Caso 1: Eliminación nodo sin hijos
            {
                if (Hlp.VDer != null || Hlp.VIzq != null) //Caso -> hay 2 elementos en el nodo
                {
                    if ((value.CompareTo(Hlp.VIzq) == 0)) 
                    {
                        Hlp.VIzq = default;
                    }
                    else if (value.CompareTo(Hlp.VDer) == 0)
                    {
                        Hlp.VDer = default;
                    }
                }
            }
            else if ((Hlp.DHijo == null && Hlp.CHijo == null && Hlp.LHijo != null) || (Hlp.DHijo == null && Hlp.CHijo != null && Hlp.LHijo == null) || (Hlp.DHijo != null && Hlp.CHijo == null && Hlp.LHijo == null))// Caso 2: Eliminación nodo con 1 hijo
            {
                if (Hlp.VDer != null || Hlp.VIzq != null) //Caso -> hay 2 elementos en el nodo
                {
                    if (value.CompareTo(Hlp.VIzq) == 0)
                    {

                        Hlp.VIzq = default;
                    }
                    if (value.CompareTo(Hlp.VDer) == 0)
                    {
                        Hlp.VDer = default(T);
                    }
                }
                else if ((Hlp.VDer != null && Hlp.VIzq == null) && (Hlp.DHijo.VIzq != null && Hlp.DHijo.VDer != null) && (Hlp.LHijo.VIzq != null || Hlp.LHijo.VDer != null))//El valor derecho del nodopadre, dos valores en el nodo derecho y uno en el izquiedo
                {
                    if (value.CompareTo(Hlp.LHijo.VIzq) == 0 || value.CompareTo(Hlp.LHijo.VDer) == 0)
                    {
                        Hlp.LHijo.VIzq = default;
                        Hlp.LHijo.VDer = Hlp.VDer;
                        Hlp.VDer = Hlp.CHijo.VDer;
                        Hlp.CHijo = null;
                    }
                }
                else if ((Hlp.VDer == null && Hlp.VIzq != null) && (Hlp.CHijo.VIzq != null || Hlp.CHijo.VDer != null) && (Hlp.LHijo.VIzq != null && Hlp.LHijo.VDer != null))//El valor derecho del nodopadre, dos valores en el nodo derecho y uno en el izquiedo
                {
                    if (value.CompareTo(Hlp.LHijo.VIzq) == 0 || value.CompareTo(Hlp.LHijo.VDer) == 0)
                    {
                        Hlp.LHijo.VIzq = default;
                        Hlp.LHijo.VDer = Hlp.VDer;
                        Hlp.VIzq = Hlp.CHijo.VDer;
                        Hlp.CHijo = null;
                    }
                }
                else if (Hlp.VIzq == null && Hlp.VDer == null)
                {
                    if (Hlp.CHijo.VIzq == null && Hlp.CHijo.VIzq == null)
                    {

                    }
                    else if ((Hlp.CHijo.VIzq != null && Hlp.CHijo.VIzq == null) && (Hlp.LHijo.VDer != null && Hlp.CHijo.VIzq == null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VDer;
                        Hlp.VDer = Hlp.CHijo.VIzq;
                    }
                    else if ((Hlp.CHijo.VIzq != null && Hlp.CHijo.VIzq == null) && (Hlp.LHijo.VDer == null && Hlp.CHijo.VIzq != null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VIzq;
                        Hlp.VDer = Hlp.CHijo.VIzq;
                    }
                    else if ((Hlp.CHijo.VIzq == null && Hlp.CHijo.VIzq != null) && (Hlp.LHijo.VDer != null && Hlp.CHijo.VIzq == null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VDer;
                        Hlp.VDer = Hlp.CHijo.VDer;
                    }
                    else if ((Hlp.CHijo.VIzq == null && Hlp.CHijo.VIzq != null) && (Hlp.LHijo.VDer == null && Hlp.CHijo.VIzq != null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VIzq;
                        Hlp.VDer = Hlp.DHijo.VDer;

                    }

                }

            }
            else if ((Hlp.DHijo != null && Hlp.CHijo != null && Hlp.LHijo != null) || (Hlp.DHijo != null && Hlp.CHijo != null && Hlp.LHijo == null) || (Hlp.DHijo != null && Hlp.CHijo == null && Hlp.LHijo != null) || (Hlp.DHijo == null && Hlp.CHijo != null && Hlp.LHijo != null))// Caso, hay un dos o tres hijos
            {
                if (Hlp.VDer != null || Hlp.VIzq != null) //Caso -> hay 2 elementos en el nodo
                {
                    if (value.CompareTo(Hlp.VIzq) == 0)
                    {

                        Hlp.VIzq = default;
                    }
                    if (value.CompareTo(Hlp.VDer) == 0)
                    {
                        Hlp.VDer = default(T);
                    }
                }
                else if ((Hlp.VDer != null && Hlp.VIzq == null) && (Hlp.CHijo.VIzq != null && Hlp.CHijo.VDer != null) && (Hlp.LHijo.VIzq != null || Hlp.LHijo.VDer != null))//El valor derecho del nodopadre, dos valores en el nodo derecho y uno en el izquiedo
                {
                    if (value.CompareTo(Hlp.LHijo.VIzq) == 0 || value.CompareTo(Hlp.LHijo.VDer) == 0)
                    {
                        Hlp.LHijo.VIzq = default;
                        Hlp.LHijo.VDer = Hlp.VDer;
                        Hlp.VDer = Hlp.CHijo.VDer;
                        Hlp.CHijo = null;
                    }
                }
                else if ((Hlp.VDer == null && Hlp.VIzq != null) && (Hlp.CHijo.VIzq != null || Hlp.CHijo.VDer != null) && (Hlp.LHijo.VIzq != null && Hlp.LHijo.VDer != null))//El valor derecho del nodopadre, dos valores en el nodo derecho y uno en el izquiedo
                {
                    if (value.CompareTo(Hlp.LHijo.VIzq) == 0 || value.CompareTo(Hlp.LHijo.VDer) == 0)
                    {
                        Hlp.LHijo.VIzq = default;
                        Hlp.LHijo.VDer = Hlp.VDer;
                        Hlp.VIzq = Hlp.CHijo.VDer;
                        Hlp.CHijo = null;
                    }
                }
                else if (Hlp.VIzq == null && Hlp.VDer == null)
                {
                    if (Hlp.CHijo.VIzq == null && Hlp.CHijo.VIzq == null)
                    {

                    }
                    else if ((Hlp.CHijo.VIzq != null && Hlp.CHijo.VIzq == null) && (Hlp.LHijo.VDer != null && Hlp.CHijo.VIzq == null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VDer;
                        Hlp.VDer = Hlp.CHijo.VIzq;
                    }
                    else if ((Hlp.CHijo.VIzq != null && Hlp.CHijo.VIzq == null) && (Hlp.LHijo.VDer == null && Hlp.CHijo.VIzq != null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VIzq;
                        Hlp.VDer = Hlp.CHijo.VIzq;
                    }
                    else if ((Hlp.CHijo.VIzq == null && Hlp.CHijo.VIzq != null) && (Hlp.LHijo.VDer != null && Hlp.CHijo.VIzq == null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VDer;
                        Hlp.VDer = Hlp.CHijo.VDer;
                    }
                    else if ((Hlp.CHijo.VIzq == null && Hlp.CHijo.VIzq != null) && (Hlp.LHijo.VDer == null && Hlp.CHijo.VIzq != null))
                    {
                        Hlp.VIzq = Hlp.LHijo.VIzq;
                        Hlp.VDer = Hlp.CHijo.VDer;

                    }

                }
            }



        }
        private Nodo23<T> Insert(Nodo23<T> Help, T value)
        {
            Nodo23<T> temp = new Nodo23<T>();
            if (Help.VIzq == null) 
            {
                return CreateNodo23(value, default(T), null, null, null);
            }
            if (Help.LHijo == null) // Crear hoja si esta vacia
            {
                return InsertHelp(Help , CreateNodo23(value, default(T), null, null, null));
            }

            if (value.CompareTo(Help.VIzq) < 0)
            {
                temp = Insert(Help.LHijo, value);
                if (temp == Help.LHijo)
                {
                    return Help;
                }
                else
                {
                    return InsertHelp(Help,temp);
                }
            }
            else if ((Help.VDer == null) || (value.CompareTo(Help.VDer) < 0))
            {
                    temp = Insert(Help.CHijo, value);
                    if (temp == Help.CHijo)
                    {
                        return Help;
                    }
                    else
                    {
                        return InsertHelp(Help,temp);
                    }

            }
            else
            {
                temp = Insert(Help.DHijo, value);
                if (temp == Help.DHijo)
                {
                    return Help;
                }
                else
                {
                    return InsertHelp(Help,temp);
                }
            }
        }
        private Nodo23<T> InsertHelp(Nodo23<T> Father, Nodo23<T> Help)
        {
            if (Father.VDer == null) //Valor derecho Vacio 
            {
                if (Father.VIzq.CompareTo(Help.VIzq) < 0)
                {
                    Father.VDer = Help.VIzq;
                    Father.CHijo = Help.LHijo;
                    Father.DHijo = Help.CHijo;
                }
                else
                {
                    Father.VDer = Father.VIzq;
                    Father.DHijo = Father.CHijo;
                    Father.VIzq = Help.VIzq;
                    Father.CHijo = Help.CHijo;
                }
                return Father;
            }
            else if (Father.VIzq.CompareTo(Help.VIzq) >= 0)//En Insertar Izquierda
            {
                Nodo23<T> Temp2 = new Nodo23<T>();
                Temp2 = CreateNodo23(Father.VIzq,default(T),Help,Father,null);
                Help.LHijo = Father.LHijo;
                Father.LHijo=Father.CHijo;
                Father.CHijo=Father.DHijo;
                Father.DHijo = null;
                Father.VIzq = Father.VDer;
                Father.VDer = default(T);

                return Temp2;
            }
            else if (Father.VDer.CompareTo(Help.VIzq)>=0) // Insetar en el Centro
            {
                Help.CHijo = CreateNodo23(Father.VDer, default(T), Help.CHijo, Father.DHijo, null);
                Help.LHijo= Father;
                Father.VDer = default(T);
                Father.DHijo = null;
                return Help;
            }
            else // Insertar en Derecha
            {
                Nodo23<T> Temp3 = new Nodo23<T>();
                Temp3 = CreateNodo23(Father.VDer, default(T),Father, Help, null);
                Help.LHijo = Father.DHijo;
                Father.DHijo = null; 
                Father.VDer= default(T);
                return Temp3;
            }
            
        }
        public T Find(T value) //Para encontrar
        {
            return FindHelp(Root, value);
        }
        public void add(T Values) 
        {
            Root = Insert(Root, Values);
        }
        public List<T> GetList()
        {
            listaOrdenada.Clear();
            Route(Root);
            return listaOrdenada;
        }
        private void Route(Nodo23<T> nodo) 
        {
            if (nodo != null)
            {
                if (nodo.VIzq != null)
                {
                    Route(nodo.LHijo);
                    listaOrdenada.Add(nodo.VIzq);
                    Route(nodo.CHijo);
                    if (nodo.VDer != null)
                    {
                        listaOrdenada.Add(nodo.VDer);
                    }
                    Route(nodo.DHijo);
                }
            }
        }
    }
}
