// See https://aka.ms/new-console-template for more information


using Trees;
using Trees.Operations;

Node root = new Node(1);
root.left=new Node(2);
root.right = new Node(3);
root.left.left = new Node(4);
root.left.right = new Node(5);
root.right.right = new Node(6);

Operations.Postorder(root);
var data3 = Operations.PostorderTraversal1Stack(root);
var a = Operations.BoundaryTraversal(root);
var b = a;


//Operations.Postorder(root);
//var data1 = Operations.LevelOrder(root);
//var data3 = Operations.PostorderTraversal(root);
//var a = data3;