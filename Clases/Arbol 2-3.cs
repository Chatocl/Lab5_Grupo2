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
    ///////////////////////////////
    ///
     Arbol_23
    {
        public class Tree
    {
        public Node Root;
        public Tree()
        {
            Root = null;
        }

        public void Insert(ulong value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return;
            }

            Node curr = Root;
            Node parent = null;

            while (curr != null)
            {

                if (curr.Keys.Count == 3)
                {
                    if (parent == null)
                    {
                        ulong k = curr.Pop(1).Value;
                        Node newRoot = new Node(k);
                        Node[] newNodes = curr.Split();
                        newRoot.InsertEdge(newNodes[0]);
                        newRoot.InsertEdge(newNodes[1]);
                        Root = newRoot;

                        curr = newRoot;
                    }
                    else
                    {
                        ulong? k = curr.Pop(1);

                        if (k != null)
                        {
                            parent.Push(k.Value);
                        }

                        Node[] newNodes = curr.Split()

                            int pos1 = parent.FindEdgePosition(newNodes[1].Keys[0]);
                        parent.InsertEdge(newNodes[1]);

                        int posCurr = parent.FindEdgePosition(value);
                        curr = parent.GetEdge(posCurr);
                    }
                }

                parent = curr;
                curr = curr.Traverse(value);
                if (curr == null)
                {
                    parent.Push(value);
                }
            }
        }

        public Node Find(ulong k)
        {
            Node curr = Root;

            while (curr != null)
            {
                if (curr.HasKey(k) >= 0)
                {
                    return curr;
                }
                else
                {
                    int p = curr.FindEdgePosition(k);
                    curr = curr.GetEdge(p);
                }
            }

            return null;
        }

        public void Remove(ulong k)
        {

            Node curr = Root;
            Node parent = null;
            while (curr != null)
            {

                if (curr.Keys.Count == 1)
                {
                    if (curr != Root)
                    {
                        ulong cK = curr.Keys[0];
                        int edgePos = parent.FindEdgePosition(cK);

                        bool? takeRight = null;
                        Node sibling = null;

                        if (edgePos > -1)
                        {
                            if (edgePos < 3)
                            {
                                sibling = parent.GetEdge(edgePos + 1);
                                if (sibling.Keys.Count > 1)
                                {
                                    takeRight = true;
                                }
                            }

                            if (takeRight == null)
                            {
                                if (edgePos > 0)
                                {
                                    sibling = parent.GetEdge(edgePos - 1);
                                    if (sibling.Keys.Count > 1)
                                    {
                                        takeRight = false;
                                    }
                                }
                            }

                            if (takeRight != null)
                            {
                                ulong pK = 0;
                                ulong sK = 0;

                                if (takeRight.Value)
                                {
                                    pK = parent.Pop(edgePos).Value;
                                    sK = sibling.Pop(0).Value;

                                    if (sibling.Edges.Count > 0)
                                    {
                                        Node edge = sibling.RemoveEdge(0);
                                        curr.InsertEdge(edge);
                                    }
                                }
                                else
                                {
                                    pK = parent.Pop(edgePos).Value;
                                    sK = sibling.Pop(sibling.Keys.Count - 1).Value;

                                    if (sibling.Edges.Count > 0)
                                    {
                                        Node edge = sibling.RemoveEdge(sibling.Edges.Count - 1);
                                        curr.InsertEdge(edge);
                                    }
                                }

                                parent.Push(sK);
                                curr.Push(pK);
                            }
                            else
                            {
                                ulong? pK = null;
                                if (parent.Edges.Count >= 2)
                                {
                                    if (edgePos == 0)
                                    {
                                        pK = parent.Pop(0);
                                    }
                                    else if (edgePos == parent.Edges.Count)
                                    {
                                        pK = parent.Pop(parent.Keys.Count - 1);
                                    }
                                    else
                                    {
                                        pK = parent.Pop(1);
                                    }

                                    if (pK != null)
                                    {
                                        curr.Push(pK.Value);
                                        Node sib = null;
                                        if (edgePos != parent.Edges.Count)
                                        {
                                            sib = parent.RemoveEdge(edgePos + 1);
                                        }
                                        else
                                        {
                                            sib = parent.RemoveEdge(parent.Edges.Count - 1);
                                        }

                                        curr.Fuse(sib);
                                    }
                                }
                                else
                                {
                                    curr.Fuse(parent, sibling);
                                    Root = curr;
                                    parent = null;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
