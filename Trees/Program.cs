// See https://aka.ms/new-console-template for more information


using Trees;
using Trees.Operations;

Node root = new Node(1);
root.right = new Node(2);
root.right.left = new Node(3);

var data = Operations.PreorderTraversal(root);
