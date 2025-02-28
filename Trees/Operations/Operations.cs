using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Operations
{
    public class Operations
    {
        public static Node CreateTree()
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            return root;
        }

        //Space complexity O(n) Time complexity O(n)
        public static IList<int> PreorderTraversal(Node root)
        {
            List<int> data = new List<int>();
            if (root == null) return data;
            Stack<Node> st = new Stack<Node>();
            st.Push(root);
            while (st.Any())
            {
                root = st.Pop();
                data.Add(root.data);
                if (root.right != null)
                {
                    st.Push(root.right);
                }
                if (root.left != null)
                {
                    st.Push(root.left);
                }

            }
            return data;
        }

        //Time complexity O(n) space complexity O(logN)
        public void Preorder(Node root)
        {
            if (root == null) return;
            Console.Write(root.data + ",");
            Preorder(root.left);
            Preorder(root.right);
        }

        //Time complexity O(n) space complexity O(logN)
        public void Inorder(Node root)
        {
            if (root == null) return;
            Inorder(root.left);
            Console.Write(root.data + ",");
            Inorder(root.right);
        }

        //Time complexity O(n) space complexity O(logN)
        public void Postorder(Node root)
        {
            if (root == null) return;
            Postorder(root.left);
            Postorder(root.right);
            Console.Write(root.data + ",");
        }

        //BFS
        //Time complexity O(n) space complexity O(N)
        public static List<List<int>> LevelOrder(Node root)
        {
            List<List<int>> traversed = new List<List<int>>();
            Queue<Node> queue = new Queue<Node>();
            if (root == null) return traversed;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int level = queue.Count();
                List<int> sublist = new List<int>();
                for (int i = 0; i < level; i++)
                {
                    Node value = queue.Peek();
                    queue.Dequeue();
                    if (value.left != null)
                    {
                        queue.Enqueue(value.left);
                    }
                    if (value.right != null)
                    {
                        queue.Enqueue(value.right);
                    }
                    sublist.Add(value.data);
                }
                traversed.Add(sublist);
            }
            return traversed;
        }
    }
}
