using System;
using System.Collections.Generic;

namespace NetCoreConsole
{
    public class TreeNode<T>
    {
        public T Val;
        public TreeNode<T> Left, Right;

        public TreeNode() { }
        public TreeNode(T v, TreeNode<T> left, TreeNode<T> right)
        {
            Val = v;
            Left = left;
            Right = right;
        }
    }

    public enum DepthFirstTraversalOrder
    {
        Inorder,    // Left, Root, Right
        Preorder,   // Root, Left, Right
        Postorder   // Left Right, Root
    }

    class BinaryTree
    {

        public static void Test()
        {
            //var tree = CreateTreeFromArray<string>(new[] { "a", "b", "c", "d", "e", "f" });
            var tree = CreateTreeFromArray<string>(new[] { "1", "2", "3", "4", null, null, "5" });

            Console.WriteLine("Tree height: {0}", GetHeight(tree));
            DepthFirstTraversal(tree);
            BreadthFirstTraversal(tree, DepthFirstTraversalOrder.Inorder);

            Console.WriteLine();
            Delete(tree, "2");
            DepthFirstTraversal(tree);
            BreadthFirstTraversal(tree, DepthFirstTraversalOrder.Inorder);

            Console.WriteLine();
            Insert(tree, "2");
            DepthFirstTraversal(tree);
            BreadthFirstTraversal(tree, DepthFirstTraversalOrder.Inorder);
        }

        public static TreeNode<T> CreateTreeFromArray<T>(T[] treeItems)
        {
            if (treeItems == null || treeItems.Length == 0)
                return null;

            var root = new TreeNode<T>(treeItems[0], null, null);

            //if (treeItems.Length == 1)
            //    return root;

            var que = new Queue<TreeNode<T>>();
            que.Enqueue(root);

            int idx = 1;
            while (idx < treeItems.Length)
            {
                var node = que.Dequeue();
                if (node == null)
                {
                    que.Enqueue(null);
                    que.Enqueue(null);
                }
                else
                {
                    node.Left = treeItems[idx] == null ? null : new TreeNode<T>(treeItems[idx], null, null);
                    node.Right= (idx + 1 >= treeItems.Length || treeItems[idx+1] == null) ? null : new TreeNode<T>(treeItems[idx+1], null, null);

                    que.Enqueue(node.Left);
                    que.Enqueue(node.Right);
                }

                idx += 2;
            }

            return root;
        }

        /// <summary>
        /// Breadth first (level order) traversal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        public static void BreadthFirstTraversal<T>(TreeNode<T> root, DepthFirstTraversalOrder to)
        {
            if (root == null)
                return;

            if (to == DepthFirstTraversalOrder.Inorder)
            {
                BreadthFirstTraversal(root.Left, to);
                Console.Write("{0}\t", root.Val);
                BreadthFirstTraversal(root.Right, to);
            }
            else if (to == DepthFirstTraversalOrder.Preorder)
            {
                Console.Write("{0}\t", root.Val);
                BreadthFirstTraversal(root.Left, to);
                BreadthFirstTraversal(root.Right, to);
            }
            else if (to == DepthFirstTraversalOrder.Postorder)
            {
                BreadthFirstTraversal(root.Left, to);
                BreadthFirstTraversal(root.Right, to);
                Console.Write("{0}\t", root.Val);
            }
        }

        public static void DepthFirstTraversal<T>(TreeNode<T> root)
        {
            var que = new Queue<TreeNode<T>>();
            que.Enqueue(root);

            int curLevel = 0;
            int curLevelSize = 1;
            int nextLevelSize = 0;

            while (que.Count>0)
            {
                var node = que.Dequeue();
                Console.Write("{0}:{1}\t", curLevel, node.Val);

                if (node.Left != null)
                {
                    que.Enqueue(node.Left);
                    nextLevelSize++;
                }
                if (node.Right != null)
                {
                    que.Enqueue(node.Right);
                    nextLevelSize++;
                }

                if (--curLevelSize == 0)
                {
                    curLevel++;
                    curLevelSize = nextLevelSize;
                    nextLevelSize = 0;
                }
            }

            Console.WriteLine();
        }

        public static int GetHeight<T>(TreeNode<T> root)
        {
            if (root == null)
                return 0;

            int leftHeight = GetHeight(root.Left);
            int rightHeight = GetHeight(root.Right);

            return Math.Max(leftHeight + 1, rightHeight + 1);
        }

        public static TreeNode<T> Delete<T>(TreeNode<T> root, T key)
        {
            if (root == null)
                return root;

            if (root.Val.Equals(key) && root.Left == null && root.Right == null)
            {
                return null;
            }

            TreeNode<T> keyNode = null;
            TreeNode<T> curNode = null, curNodeParent = null;

            // store node and node parent in a queue
            var que = new Queue<(TreeNode<T> parent, TreeNode<T> node)>();
            que.Enqueue((null, root));
            // breadth first traverse the tree to find
            // the node to be deleted(keyNode), and the deepest rightmost node(curNode, curNodeParent)
            while (que.Count >0)
            {
                (curNodeParent, curNode) = que.Dequeue();
                if (curNode.Val.Equals(key))
                    keyNode = curNode;

                if (curNode.Left != null)
                {
                    que.Enqueue((curNode, curNode.Left));
                }
                if (curNode.Right != null)
                {
                    que.Enqueue((curNode, curNode.Right));
                }    
            }

            if (keyNode != null)
            {
                // swap the node key between keyNode and rigtmost node (curNode)
                // then remove the rightmost node
                keyNode.Val = curNode.Val;
                if (curNodeParent.Left == curNode)
                    curNodeParent.Left = null;
                else if (curNodeParent.Right == curNode)
                    curNodeParent.Right = null;
            }

            return root;
        }

        /// <summary>
        /// Inserts a new node with key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns>The root node</returns>
        public static TreeNode<T> Insert<T>(TreeNode<T> root, T key)
        {
            var newNode = new TreeNode<T>
            {
                Val = key,
                Left = null,
                Right = null
            };

            if (root == null)
            {
                root = newNode;
                return root;
            }

            var que = new Queue<TreeNode<T>>();
            que.Enqueue(root);

            while (que.Count> 0)
            {
                var node = que.Dequeue();
                if (node.Left == null)
                {
                    node.Left = newNode;
                    break;
                }
                else
                {
                    que.Enqueue(node.Left);
                }

                if (node.Right == null)
                {
                    node.Right = newNode;
                    break;
                }
                else
                {
                    que.Enqueue(node.Right);
                }
            }

            return root;
        }
    }
}
