using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public static void Preorder(Node root)
        {
            if (root == null) return;
            Console.Write(root.data + ",");
            Preorder(root.left);
            Preorder(root.right);
        }

        //Time complexity O(n) space complexity O(logN)
        public static void Inorder(Node root)
        {
            if (root == null) return;
            Inorder(root.left);
            Console.Write(root.data + ",");
            Inorder(root.right);
        }

        //Time complexity O(n) space complexity O(logN)
        public static void Postorder(Node root)
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

        //Time complexity O(n) space complexity O(N)
        public static IList<int> InorderTraversal(Node root)
        {
            List<int> traversed = new List<int>();

            Stack<Node> stack = new Stack<Node>();

            Node node = root;

            while (true)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    if (stack.Count == 0) break;
                    node = stack.Pop();
                    traversed.Add(node.data);
                    node = node.right;
                }

            }

            return traversed;
        }

        //Time complexity O(n) space complexity O(2N)
        public static IList<int> PostorderTraversal2Stack(Node root)
        {
            List<int> traversed = new List<int>();

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            if (root == null) return traversed;

            stack1.Push(root);

            while (stack1.Count() > 0)
            {
                Node node = stack1.Pop();
                stack2.Push(node);
                if (node.left != null)
                {
                    stack1.Push(node.left);
                }
                if (node.right != null)
                {
                    stack1.Push(node.right);
                }
            }
            while (stack2.Count() > 0)
            {
                traversed.Add(stack2.Pop().data);
            }

            return traversed;
        }

        //Time complexity O(n) space complexity O(N)
        public static int Maxheight(Node root)
        {
            if (root == null) return 0;
            int lr = Maxheight(root.left);
            int rr = Maxheight(root.right);
            return 1 + Math.Max(lr, rr);
        }

        //Time complexity O(n) space complexity O(N)
        public static bool CheckBalance(Node root)
        {
            if (root == null) return true;
            if (CheckHeight(root) == -1)
            {
                return false;
            }
            else { return true; }
        }

        public static int CheckHeight(Node root)
        {
            if (root == null) return 0;
            int lr = CheckHeight(root.left);
            if (lr == -1) return -1;
            int rr = CheckHeight(root.right);
            if (rr == -1) return 1;
            if (Math.Abs(lr - rr) > 1) return -1;
            return 1 + Math.Max(lr, rr);

        }

        //Time complexity O(n) space complexity O(N)
        public static int Diameter(Node root)
        {
            int[] diam = new int[0];
            CheckMaxDia(root, diam);
            return diam[0];
        }

        public static int CheckMaxDia(Node root, int[] diam)
        {
            if (root == null) return 0;
            int lr = CheckMaxDia(root.left, diam);
            int rr= CheckMaxDia(root.right, diam);
            diam[0] = Math.Max(diam[0], lr + rr);
            return 1+ Math.Max(lr, rr);

        }
    }
}
