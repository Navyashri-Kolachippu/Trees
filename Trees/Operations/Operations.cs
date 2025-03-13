using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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

        //Time complexity O(n) space complexity O(2N)
        public static IList<int> PostorderTraversal1Stack(Node root)
        {
            List<int> traversed = new List<int>();

            Stack<Node> stack = new Stack<Node>();

            Node curr = root;

            while (curr != null || stack.Count != 0)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                else
                {
                    Node temp = stack.Peek().right;
                    if (temp == null)
                    {
                        temp = stack.Pop();
                        traversed.Add(temp.data);
                        while (stack.Count() > 0 && stack.Peek().right == temp)
                        {
                            temp = stack.Pop();
                            traversed.Add(temp.data);
                        }
                    }
                    else
                    {
                        curr = temp;
                    }
                }
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
            int rr = CheckMaxDia(root.right, diam);
            diam[0] = Math.Max(diam[0], lr + rr);
            return 1 + Math.Max(lr, rr);

        }

        //Time complexity O(n) space complexity O(N)
        public static int MaxPathSum(Node root)
        {
            int max = root.data;
            PathSum(root, ref max);
            return max;
        }

        public static int PathSum(Node root, ref int max)
        {
            if (root == null) return 0;

            int lr = Math.Max(0, PathSum(root.left, ref max));
            int rr = Math.Max(0, PathSum(root.right, ref max));
            max = Math.Max(max, (root.data + (lr + rr)));

            return root.data + Math.Max(lr, rr);
        }

        //Time complexity O(n) space complexity O(N)
        public static bool SameTree(Node root1, Node root2)
        {
            if (root1 == null && root2 == null) return root1 == root2;
            return SameTree(root1.left, root2.left) && SameTree(root1.right, root2.right) && (root1.data == root2.data);
        }

        //Time complexity O(n) space complexity O(N)
        public static List<List<int>> Zigzagtraversal(Node root)
        {
            List<List<int>> zigzag = new List<List<int>>();
            if (root == null) return zigzag;
            bool flag = true;// true l->r,r->l false
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int capacity = queue.Count;
                List<int> list = new List<int>();
                for (int i = 0; i < capacity; i++)
                {
                    Node temp = queue.Dequeue();
                    if (flag)
                        list.Add(temp.data); // Normal order
                    else
                        list.Insert(0, temp.data); // Reverse order (Insert at front)

                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                    }
                }
                zigzag.Add(list);
                flag = !flag;
            }

            return zigzag;
        }

        //Time complexity O(n) space complexity O(N)
        public static bool isLeaf(Node root)
        {
            if (root.right == null && root.left == null) return true;
            else return false;
        }

        public static void lefttraversal(Node root, List<int> list)
        {
            Node curr = root.left;
            while (curr != null)
            {
                if (!isLeaf(curr)) list.Add(curr.data);
                if (curr.left != null) { curr = curr.left; }
                else { curr = curr.right; }
            }
        }
        public static void righttraversal(Node root, List<int> list)
        {
            Node curr = root.right;
            List<int> tmp = new List<int>();
            while (curr != null)
            {
                if (!isLeaf(curr)) tmp.Add(curr.data);
                if (curr.right != null) { curr = curr.right; }
                else { curr = curr.left; }
            }
            for (int i = tmp.Count - 1; i >= 0; i--)
            {
                list.Add(tmp[i]);
            }

        }

        public static void leaftraversal(Node root, List<int> list)
        {
            if (isLeaf(root))
            {
                list.Add(root.data);
                return;
            }

            if (root.left != null) leaftraversal(root.left, list);
            if (root.right != null) leaftraversal(root.right, list);

        }
        public static List<int> BoundaryTraversal(Node root)
        {
            List<int> list = new List<int>();
            if (root == null) return list;
            if (isLeaf(root) == false) list.Add(root.data);

            lefttraversal(root, list);
            leaftraversal(root, list);
            righttraversal(root, list);
            return list;

        }

        //Vertical traversal

        public class Traverse
        {
            public Node node;
            public int level;
            public Traverse(Node node, int level)
            {
                this.node = node;
                this.level = level;
            }
        }

        public static List<List<int>> VerticalTraversal(Node root)
        {
            List<List<int>> result = new List<List<int>>();
            if (root == null) return result;

            // Dictionary to store nodes based on horizontal distance
            SortedDictionary<int, List<int>> map = new SortedDictionary<int, List<int>>();

            Queue<Traverse> queue = new Queue<Traverse>();
            queue.Enqueue(new Traverse(root, 0));

            while (queue.Count > 0)
            {
                int size = queue.Count;
                Dictionary<int, List<int>> temp = new Dictionary<int, List<int>>();

                for (int i = 0; i < size; i++)
                {
                    Traverse check = queue.Dequeue();

                    // Store nodes in a temporary dictionary to maintain row order
                    if (!temp.ContainsKey(check.level))
                        temp[check.level] = new List<int>();

                    temp[check.level].Add(check.node.data);

                    if (check.node.left != null) queue.Enqueue(new Traverse(check.node.left, check.level - 1));
                    if (check.node.right != null) queue.Enqueue(new Traverse(check.node.right, check.level + 1));
                }

                // Sort each level's nodes before adding to map
                foreach (var key in temp.Keys)
                {
                    if (!map.ContainsKey(key))
                        map[key] = new List<int>();

                    temp[key].Sort();
                    map[key].AddRange(temp[key]);
                }
            }

            // Convert map to list of lists
            foreach (var key in map.Keys)
                result.Add(map[key]);

            return result;
        }

        public static List<int> TopTraversal(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            SortedDictionary<int, int> data = new SortedDictionary<int, int>();
            Queue<Traverse> queue = new Queue<Traverse>();
            queue.Enqueue(new Traverse(root, 0));
            while (queue.Count > 0)
            {
                Traverse current = queue.Dequeue();

                if (!data.ContainsKey(current.level))
                    data.Add(current.level, current.node.data);
                if (current.node.left != null) queue.Enqueue(new Traverse(current.node.left, current.level - 1));
                if (current.node.right != null) queue.Enqueue(new Traverse(current.node.right, current.level + 1));

            }

            foreach (var key in data.Keys)
            {
                result.Add(data[key]);
            }

            return result;
        }

        public static List<int> BottomView(Node root)
        {
            List<int> result = new List<int>();
            SortedDictionary<int, int> data = new SortedDictionary<int, int>();
            Queue<Traverse> queue = new Queue<Traverse>();
            queue.Enqueue(new Traverse(root, 0));
            while (queue.Count > 0)
            {
                Traverse current = queue.Dequeue();

                data[current.level] = current.node.data;

                if (current.node.left != null) queue.Enqueue(new Traverse(current.node.left, current.level - 1));
                if (current.node.right != null) queue.Enqueue(new Traverse(current.node.right, current.level + 1));
            }
            foreach (var item in data.Keys)
            {
                result.Add(data[item]);
            }
            return result;
        }

    }
}
