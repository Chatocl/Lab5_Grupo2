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
                return Help.VIzq;
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
        private Nodo23<T> CreateNodo23(T Value1, T Value2, Nodo23<T> L, Nodo23<T> C, Nodo23<T> D) 
        {
            Nodo23<T> n = new Nodo23<T>();
            n.VIzq = Value1;
            n.VDer = Value2;
            n.LHijo = L;
            n.DHijo = D;
            n.CHijo = C;

            return n;
        }

        public T Remove(T deleteV)
        {

            Nodo23<T> aux = new Nodo23<T>();
            T temp = Find(deleteV);
            if(temp != null)
            {
                Delete(temp);
            }

            return deleteV;
        }

        void Delete(Nodo23<T> Hlp, T value)
        {

            


                /////////////
            if (Hlp.VDer != null && Hlp.VIzq != null) //Caso -> hay 2 elementos en el nodo
            {
                if (Hlp.LHijo == null && Hlp.CHijo == null && Hlp.DHijo == null)   //No tiene hijos (hoja)
                {
                    if (Hlp.VDer != null && Hlp.VIzq != null) //Caso -> hay 2 elementos en el nodo
                    {
                        if (value.Equals(Hlp.VIzq))
                        {
                            Hlp.VIzq = default(T);
                        }
                        if (value.Equals(Hlp.VDer))
                        {
                            Hlp.VDer = default(T);
                        }
                    }
                    else if (Hlp.VDer == null && Hlp.VIzq != null) //Caso: Hay solo 1 elemento en el nodo izquierdo 
                    {
                        if (value.Equals(Hlp.VIzq))//Sujeto a eliminación el if (creo que no sería util)
                        {
                            Hlp.VIzq = default(T);
                        }

                    }
                    else if (Hlp.VDer != null && Hlp.VIzq == null) //Caso: Hay solo 1 elemento en el nodo derecho
                    {

                        if (value.Equals(Hlp.VDer)) //Sujeto a eliminación el if
                        {
                            Hlp.VDer = default(T);
                        }
                    }
                }
                else if (Hlp.LHijo == null && Hlp.CHijo == null && Hlp.DHijo == null) // Tiene hijos    
                {

                }

            }
            else if(Hlp.VDer != null && Hlp.VIzq == null) //Caso: Hay solo 1 elemento en el nodo
            {

            }
          
        }

        Nodo23<T> RotDer(Nodo23<T> nodo)
        {

            return nodo;
        }

        private Nodo23<T> Insert(Nodo23<T> Help, T value) 
        {
            if (Help.VIzq == null)// Crear hoja si esta vacia 
            {
                return CreateNodo23(value,default(T) ,null,null,null);
            }
            if (Help.LHijo==null)
            {
                return InsertHelp(CreateNodo23(value, default(T), null, null, null));
            }
            if (value.CompareTo(Help.VIzq)<0)
            {
                temp = Insert(Help.LHijo, value);
                if (temp == Help.LHijo)
                {
                    return Help;
                }
                else
                {
                    return InsertHelp(temp);
                }
            }
            else if (Help.VDer.CompareTo(default(T)) == 0 || value.CompareTo(Help.VDer) < 0)
            {
                temp = Insert(Help.CHijo, value);
                if (temp == Help.CHijo)
                {
                    return Help;
                }
                else
                {
                    return InsertHelp(temp);
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
                    return InsertHelp(temp);
                }
            }
        }
        private Nodo23<T> InsertHelp(Nodo23<T> Help)
        {
            if (Root.VDer == null) //Valor derecho Vacio 
            {
                if (Root.VIzq.CompareTo(Help.VIzq) < 0)
                {
                    Root.VDer = Help.VIzq;
                    Root.CHijo = Help.LHijo;
                    Root.DHijo = Help.CHijo;
                }
                else
                {
                    Root.VDer = Root.VIzq;
                    Root.DHijo = Root.CHijo;
                    Root.VIzq = Help.VIzq;
                    Root.CHijo = Help.CHijo;
                }
                return Root;
            }
            else if (Root.VIzq.CompareTo(Help.VIzq) >= 0)//En Insertar Izquierda
            {
                Nodo23<T> Temp2 = new Nodo23<T>();
                Temp2 = CreateNodo23(Root.VDer,default(T),Help,Root,null);
                Help.LHijo = Root.LHijo;
                Root.LHijo=Root.CHijo;
                Root.CHijo=Root.DHijo;
                Root.DHijo = null;
                Root.VIzq = Root.VDer;
                Root.VDer = default(T);

                return Temp2;
            }
            else if (Root.VDer.CompareTo(Help.VIzq)>=0) // Insetar en el Centro
            {
                Nodo23<T> Temp3 = new Nodo23<T>();
                Temp3 = CreateNodo23(Root.VDer, default(T), Help.CHijo, Root.DHijo, null);
                Help.CHijo = Temp3;
                Help.LHijo= Root;
                Root.VDer = default(T);
                Root.DHijo = null;
                return Help;
            }
            else // Insertar en Derecha
            {
                Nodo23<T> Temp4 = new Nodo23<T>();
                Temp4 = CreateNodo23(Root.VDer, default(T),Root, Help, null);
                Help.LHijo = Root.DHijo;
                Root.DHijo = null; 
                Root.VDer= default(T);
                return Temp4;
            }
            
        }


        public T Find(T value) 
        {
            return FindHelp(Root, value);
        }
        public void add(T Values) 
        {
            Nodo23<T> nuevo = CreateNodo23(Values, default(T), null, null, null);
            if (Root.VIzq==null)
            {
                Root = nuevo;
            }
            else
            {
                Root = Insert(Root, Values);
            }
            
            
        }

        public List<T> GetList()
        {
            listaOrdenada.Clear();
            Route(Root);
            return listaOrdenada;
        }
        private void Route(Nodo23<T> nodo) 
        {

           if (nodo.VIzq != null)
           {
             Route(nodo.LHijo);
             listaOrdenada.Add(nodo.VIzq);
             if (nodo.VDer != null)
             {
               listaOrdenada.Add(nodo.VDer);
             }
             Route(nodo.CHijo);
             Route(nodo.DHijo); 

           }
        }
    }
}
