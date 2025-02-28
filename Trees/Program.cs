// See https://aka.ms/new-console-template for more information


using Trees;
using Trees.Operations;

Node root = new Node(1);
root.left=new Node(4);
root.right = new Node(2);
root.right.left = new Node(3);

var data = Operations.PreorderTraversal(root);
var data1 =Operations.LevelOrder(root);
var data3 = 0;
