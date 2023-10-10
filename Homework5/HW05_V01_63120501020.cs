using System;
using System.Reflection.Metadata.Ecma335;

namespace HelloWorld
{

    public class Node
    {
        public string Data;
        public Node Next;

        public Node(string data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList
    {
        private Node _head;

        public LinkedList()
        {
            _head = null;
        }

        // Add a new node to the end of the linked list
        public void Add(Node node)
        {
            Console.WriteLine("Node with data : " + node.Data + " was added");
            if (_head == null)
            {
                _head = node;
                return;
            }
            Node currNode = _head;

            while (currNode.Next != null) // Not Found last Node
            {
                currNode = currNode.Next; //Move currNode
            }

            // Assume that currNode is the last Node
            currNode.Next = node;


            // if (currNode.Next == null)//Found text Node
            // {
            //     currNode.Next = node;
            // }
            // else
            // {
            //     currNode = currNode.Next;
            // }

        }

        // Print the linked list
        public void Print()
        {
            Console.WriteLine("Head: " + _head.Data); // แสดงค่า _head
            Console.WriteLine("Method Print called");
            Node currNode = _head;

            while (currNode != null)
            {
                Console.Write(currNode.Data + ">");
                currNode = currNode.Next;
            }
            Console.WriteLine("");


        }

        // Insert a new node with the given data at a specific position
        public void Insert(Node node, int position)
        {
            if (position == 0)
            {
                if (_head == null)
                {
                    _head = node;
                }
                else
                {
                    node.Next = _head;
                    _head = node;
                }
                Console.WriteLine("Inserted Node with data '" + node.Data + "' at position " + position); // แสดงค่า Node ที่ถูก Insert
                return;
            }

            Node currNode = _head;
            int count = 0;
            while (currNode != null && count < position - 1)
            {
                currNode = currNode.Next;
                count++;
            }

            if (currNode == null || position < 0)
            {
                Console.WriteLine("Cannot add node at position");
                return;
            }

            node.Next = currNode.Next;
            currNode.Next = node;
            Console.WriteLine("Inserted Node with data '" + node.Data + "' at position " + position); // แสดงค่า Node ที่ถูก Insert
        }

        // Delete the first occurrence of a node with the given data
        public void Delete(Node nodeToDelete)
        {
            Node currNode = _head;
            Node prevNode = null;

            // ค้นหา Node ที่ต้องการลบและ Node ก่อนหน้า
            while (currNode != null && currNode != nodeToDelete)
            {
                prevNode = currNode;
                currNode = currNode.Next;
            }

            // ถ้าไม่พบ Node ที่ต้องการลบ
            if (currNode == null)
            {
                Console.WriteLine("Node not found");
                return;
            }

            // ถ้าต้องการลบ Node ตัวแรก
            if (currNode == _head)
            {
                _head = currNode.Next;
            }
            else
            {
                // ถ้าไม่ใช่ Node ตัวแรก ให้กำหนด Node ก่อนหน้า Next ไปยัง Node ที่ต้องการลบ
                prevNode.Next = currNode.Next;
            }

            Console.WriteLine("Node with data '" + nodeToDelete.Data + "' was deleted");
        }

        public Node Find(string searchData)
        {
            Node currNode = _head;

            while (currNode != null)
            {
                if (currNode.Data == searchData)
                {
                    return currNode;
                }
                currNode = currNode.Next;
            }

            return null; // ไม่พบ Node ที่ต้องการ
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList = new LinkedList();

            //Add Node
            Node node1 = new Node("1 Cat");
            Node node2 = new Node("2 Dog");
            Node node3 = new Node("3 Monkey");

            myList.Add(node1);
            myList.Add(node2);
            myList.Add(node3);


            //PrintNode
            Console.WriteLine("Linked List:");
            myList.Print();

            //InsertNode
            Node node0 = new Node("0 Capybara");//ลองดู
            myList.Insert(node0, 0);//ลองดู
            // myList.Insert(new Node("Capybara"), 0);


            Node node4 = new Node("4 Bee Bear");//ลองดู
            myList.Insert(node4, 4);//ลองดู

            Console.WriteLine("After Insertions:");
            myList.Print();//Print


            //DeleteNode
            myList.Delete(node0);

            Console.WriteLine("After Deletions:");

            myList.Print();



            Node foundNode = myList.Find("2 Dog");
            Console.WriteLine("Search for Dog");
            if (foundNode != null)
            {
                Console.WriteLine("Found Node: " + foundNode.Data);
            }
            else
            {
                Console.WriteLine("Node not found");
            }

            foundNode = myList.Find("Lion");
            Console.WriteLine("Search for Lion");
            if (foundNode != null)
            {
                Console.WriteLine("Found Node: " + foundNode.Data);
            }
            else
            {
                Console.WriteLine("Node not found");
            }
        }
    }
}