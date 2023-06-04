using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStructs 
{
    //Clase Pila
    public class Stack<T>
    {
        public class Node
        {
            public T value { get; set; }
            public Node Next { get; set; }
            public Node Previus { get; set; }
            public Node(T value)
            {
                this.value = value;
                Next = null;
                Previus = null;
            }
        }
        public Node Head;//primer nodo
        public Node Top;//ultimo nodo
        public int Count;
        public void Push(T value)
        {            
            if (Count == 0)
            {
                Node newNode = new Node(value);
                Head = newNode;
                Top = newNode;
                Count++;
            }
            else
            {
                Node newNode = new Node(value);
                newNode.Previus = Top;
                Top.Next = newNode;
                Top = newNode;
                Count++;
            }
        }
        public void Pop()
        {
            
            if (Count == 0)
            {
                Debug.Log("Esta vacia");
            }
            else if (Count == 1)
            {
                Top = null;
                Head = null;
                Count--;
            }
            else
            {
                Node tmp = Top.Previus;
                tmp.Next = null;
                Top.Previus = null;
                Top = tmp;
                Count--;
            }            
        }
     }
    //Clase Cola
    public class Queue<T>
    {
        public class Node
        {
            public T value { get; set; }
            public Node Next { get; set; }
            public Node Previus { get; set; }
            public Node(T value)
            {
                this.value = value;
                Next = null;
                Previus = null;
            }
        }
        public Node Head;//primer nodo
        public Node Tail;//ultimo nodo
        public int Count;
        public void Enqueue(T value)
        {
            if (Tail == null)
            {
                Node newNode = new Node(value);
                Head = newNode;
                Tail = newNode;
                Count++;
            }
            else
            {
                Node newNOde = new Node(value);
                Tail.Next = newNOde;//El siguiente del la cola es el nuevo nodo
                newNOde.Previus = Tail;//el anterior del nuevo nodo es la cola
                Tail = newNOde;//la cola se vuelve el nuevo nodo
                Count++;

            }
        }
        public void Dequeue()
        {
            if (Tail == null)
            {
                Debug.Log("No hay nodos a eliminar");
            }
            else
            {
                Node tmp = Head.Next;// 
                Head.Next = null;//El siguiente de cabeza es nulo
                tmp.Previus = null;//El anterior del siguiente de cabeza es nulo
                Head = tmp;//La nueva cabeza es igual al siguiente de la anterior cabeza
                Count--;
            }
        }
        public void PrintTail()
        {
            Node tmp = Head;
            while (tmp != null)
            {
                Debug.Log(tmp.value + " ");

                tmp = tmp.Next;
            }

            Debug.Log("");
        }
    }
    //Clase Cola de prioridad
    public class CleanQueue<T>
    {
        public class Node
        {
            public T value { get; set; }
            public int Priority { get; set; }
            public Node Next { get; set; }
            public Node Previus { get; set; }
            public Node(T value, int priority)
            {
                this.value = value;
                Priority = priority;
                Next = null;
                Previus = null;
            }
        }
        public Node Head;
        public Node Tail;
        public int count;
        public Node DefinirTail()
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            //Console.WriteLine(Head.Priority);
            return tmp;
        }
        public void AddEnqueue(T value, int priority)
        {
            if (count == 0)
            {
                Node newNode = new Node(value, priority);
                Head = newNode;
                Tail = newNode;
                count++;
            }
            else if (count > 0)
            {
                Node newNode = new Node(value, priority);
                //si la prioridad de mi cabeza es mayor al nuevo este se vuelve cabeza
                if (newNode.Priority < Head.Priority)
                {
                    Head.Previus = newNode;
                    newNode.Next = Head;
                    Tail = DefinirTail();
                    Head = newNode;

                    count++;
                }
                else
                {
                    if (newNode.Priority > Tail.Priority)
                    {
                        Tail.Next = newNode;
                        newNode.Previus = Tail;
                        Tail = newNode;
                        count++;
                    }
                    //  25-8    ->15-5
                    //  13-0    15-5    25-8    ->12-7
                    else
                    {
                        Node tmp = Head;
                        while (newNode.Priority > tmp.Priority)
                        {
                            tmp = tmp.Next;
                        }
                        Node previusNode = tmp.Previus;
                        tmp.Previus = newNode;
                        previusNode.Next = newNode;
                        newNode.Previus = previusNode;
                        newNode.Next = tmp;
                        Tail = DefinirTail();
                        count++;
                        //Console.WriteLine(newNode.Next.Priority);
                        //Console.WriteLine(newNode.Previus.Priority);
                        //Console.WriteLine(newNode.Priority);
                        //Console.WriteLine(tmp.Priority);
                        //Console.WriteLine(tmp.Previus.Priority);
                        //Console.WriteLine(Tail.Priority);
                        //Console.WriteLine(Tail.Previus.Priority);
                        //Console.WriteLine(Tail.value);
                    }
                }
            }
        }
        public void Dequeue()
        {
            if (Head == null)
            {
                Debug.Log("No se puede eliminar, esta vacio");
            }
            else
            {
                Node tmp = Head.Next;
                tmp.Previus = null;
                Head.Next = null;
                Head = tmp;

            }
        }
        public void PrintAllNodes()
        {
            Node tmp = Head;
            while (tmp != null)
            {
                Debug.Log(tmp.value + "-" + tmp.Priority + " \t");
                tmp = tmp.Next;
            }
            Debug.Log("");
        }
    }
    //Clase Lista doble Circular
    public class CircularDoublyList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previus { get; set; }
            public Node(T value)
            {
                Value = value;
                Next = null;
                Previus = null;
            }

        }
        public Node Head { get; set; }
        public int Count = 0;

        public void InsertAtStart(T value)
        {
            if (Head == null)
            {
                Node newNode = new Node(value);
                Head = newNode;
                newNode.Next = Head;
                newNode.Previus = Head;
                Count++;
            }
            else
            {
                //3 -4 -5
                Node newNode = new Node(value);//2
                Node lastNode = Head.Previus;//5

                lastNode.Next = newNode;// El siguiente de 5 es 2
                newNode.Previus = lastNode;//Antes del 2 esta el 5                    
                Head.Previus = newNode;//El anterior de 3 es 2

                newNode.Next = Head;//El siguiente de 2 es 3
                Head = newNode;//Mi nueva cabeza es 2
                lastNode.Next = Head;//El siguiente de 5 es Cabeza
                Count++;
            }
        }
        public void InsertAtEnd(T value)
        {
            if (Head == null)
            {
                InsertAtStart(value);
            }
            else
            {
                //2 -3 -4 -5
                Node lastNode = Head.Previus;//5
                Node newNode = new Node(value);//6

                lastNode.Next = newNode;//El siguiente de 5 es 6
                newNode.Next = Head;//El siguiente de 6 es 2
                Head.Previus = newNode;//El anterior de 2 es 6
                newNode.Previus = lastNode;//Antes del 6 esta el 5   
                Count++;
            }
        }
        public void InsertarAtPosition(T value, int position)
        {
            if (position == 0)
            {
                InsertAtStart(value);
            }
            else if (position == Count - 1)
            {
                InsertAtEnd(value);
            }
            else if (position >= Count || position < 0)
            {
                Debug.Log("No se puede acceder");
            }
            else
            {
                Node tmp = Head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    tmp = tmp.Next;
                    iterator++;
                }
                //tmp = 4
                Node newNode = new Node(value);//11
                newNode.Next = tmp.Next;//El siguiente de 11 es 5(q era el siguiente de 4)
                tmp.Next.Previus = newNode;//El anterior de 5 es 11
                tmp.Next = newNode;//El siguiente de 4 es 11           
                newNode.Previus = tmp;//El anterior de 11 es 4
                                      //Console.WriteLine("el siguiente  : " + tmp.Next.Next.Next.Value + " ");
                                      //Console.WriteLine("el anterior : " + tmp.Next.Next.Previus.Value + " ");
                Count++;
            }
        }

        public void ModifyAtStart(T value)
        {
            if (Head != null)
            {
                Head.Value = value;
            }
            else
            {
                Debug.Log("No se puede modificar , vacío");
            }
        }
        public void ModifyAtEnd(T value)
        {
            if (Head == null)
            {
                Debug.Log("No se puede modificar el ultimo,xq esta vacio");
            }
            else
            {
                Node lastNode = Head.Previus;
                lastNode.Value = value;
            }
        }
        public void ModifyAtPosition(T value, int position)
        {
            if (position == 0)
            {
                ModifyAtStart(value);
            }
            else if (position == Count - 1)
            {
                ModifyAtEnd(value);
            }
            else if (position >= Count || position == 0)
            {
                Debug.Log("No se puede, no esta dentro del rango");
            }
            else
            {
                Node tmp = Head;
                int iterator = 0;
                while (iterator < position)
                {
                    tmp = tmp.Next;
                    iterator++;
                }
                //Console.WriteLine(" vaer " + tmp.Value);
                tmp.Value = value;
            }
        }

        public T GetNodeAtStart()
        {
            if (Head == null)
            {
                Debug.Log("Acceso denegado, esta vacio");
                return Head.Value;
            }
            else
            {
                return Head.Value;
            }
        }
        public T GetNodeAtEnd()
        {
            if (Head == null)
            {
                Debug.Log("No hay cabeza, menos cola");
                return Head.Previus.Value;
            }
            else
            {
                return Head.Previus.Value;
            }
        }
        public T GetNodeAtPosition(int position)
        {
            if (position == 0)
            {
                return GetNodeAtStart();
            }
            else if (position == Count - 1)
            {
                return GetNodeAtEnd();
            }
            else if (position >= Count || position == 0)
            {
                Debug.Log("Nopi,excedes a las cantidades");
                return Head.Value;
            }
            else
            {
                Node tmp = Head;
                int iterator = 0;
                while (iterator < position)
                {
                    tmp = tmp.Next;
                    iterator++;
                }
                return tmp.Value;
            }
        }

        public void DeleteNodeAtStart()
        {
            if (Head == null)
            {
                Debug.Log("No hay cabeza q cortar");
            }
            else
            {
                //2 -3 -9 -11 -5 -6 -7 -8
                Node lastNode = Head.Previus;//8
                Node newHead = Head.Next;//3
                Head.Next = null;//El siguiente de 2 es null          
                newHead.Previus = null;//El anterior a 3 es null
                Head = newHead;//3 es la nueva cabeza
                Head.Previus = lastNode;//El anterior de 3 es 8 ||
                lastNode.Next = Head;//El sigueinte de 8 es 3 **
                Count--;
                //Console.WriteLine("el siguiente de la Head es : "+ Head.Next.Value + " ");
                //Console.WriteLine("el anterior de la Head es : " + Head.Previus.Value + " ");
            }
        }
        public void DeleteNodeAtEnd()
        {
            if (Head == null)
            {
                Debug.Log("No hay cabeza q eliminar, menos cola");
            }
            else
            {
                //3 -9 -11 -5 -6 -7 -8
                Node PenultimoNode = Head.Previus.Previus;
                //Console.WriteLine(previusNode.Value);
                Node lastNode = Head.Previus;
                lastNode.Next = null;//El siguiente de 8 es nulo
                lastNode.Previus = null;//El anterior de 8 es nulo
                PenultimoNode.Next = Head;//El siguiente de 7 es 3
                Head.Previus = PenultimoNode;//El anterior a 3 es 7
                                             //Console.WriteLine("el siguiente de la Head es : "+ PenultimoNode.Next.Value + " ");
                                             //Console.WriteLine("el anterior de la Head es : " + PenultimoNode.Previus.Value + " ");

                Count--;
            }
        }
        public void DeleteAtNodeAtPosition(int position)
        {
            if (position == 0)
            {
                DeleteNodeAtStart();
            }
            else if (position == Count - 1)
            {
                DeleteNodeAtEnd();
            }
            else if (position >= Count || position < 0)
            {
                Debug.Log("Npo se peudeeee");
            }
            else
            {
                //3 -9 -11 -5 -6 -7
                Node previusNode = Head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    iterator++;
                    previusNode = previusNode.Next;
                }
                //Console.WriteLine(" a ver " + previusNode.Value);
                //previusNode es 11
                Node deleteNode = previusNode.Next;//5
                previusNode.Next = deleteNode.Next;//El siguiente de 11 es 6                  
                deleteNode.Next.Previus = previusNode;// el anterior de 6 es 11
                deleteNode.Next = null;//el siguiente de 5 es null
                deleteNode.Previus = null;//el anterior de 5 es null
                                          //Console.WriteLine("el siguiente de la Head es : "+ previusNode.Previus.Next.Value + " ");
                                          //Console.WriteLine("el anterior de la Head es : " + previusNode.Previus.Previus.Value + " ");
                Count--;
            }
        }

        public void Print()
        {
            Node tmp = Head;
            if (Head == null)
            {
                Debug.Log("List is empty.");                
            }
            while (tmp.Next != Head)
            {
                Debug.Log(tmp.Value + " ");
                tmp = tmp.Next;
            }
            Debug.Log(tmp.Value + " ");
            Debug.Log("");

            //Console.WriteLine("el siguiente del ultimo es : "+ tmp.Next.Next.Value + " ");
            //Console.WriteLine("el anterior del ultimo es : "+tmp.Next.Previus.Value + " ");
        }
    }

}
