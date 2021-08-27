using System;

namespace NetCoreConsole
{
    // We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
    class Node
    {
        public int data;
        public Node left, right;

        public Node(int key)
        {
            data = key;
            left = right = null;
        }
    }


    class MedianStream
    {
        static void Main(string[] args)
        {
            var result = findMedian(new[] { 5, 15, 1, 3 });
            for (int i = 0; i < result.Length; i++)
                Console.Write("{0}\t", result[i]);
        }


        private static Node insert(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }

            if (key < node.data)
                node.left = insert(node.left, key);
            else if (key > node.data)
                node.right = insert(node.right, key);

            return node;
        }

        private static void findMedianBSTRecursive(Node curNode, Node[] medianNodes, int treeSize, ref int count)
        {
            if (curNode == null)
                return;

            findMedianBSTRecursive(curNode.left, medianNodes, treeSize, ref count);
            count++;

            if (treeSize % 2 == 0 && count == (treeSize / 2) + 1)
            {
                //medianNodes[0] has the immediate previous node;
                medianNodes[1] = curNode;
                return;
            }
            else if (treeSize % 2 != 0 && count == (treeSize + 1) / 2)
            {
                medianNodes[0] = curNode;
                medianNodes[1] = null;
                return;
            }
            else
            {
                // store the last visited node
                medianNodes[0] = curNode;
            }

            findMedianBSTRecursive(curNode.right, medianNodes, treeSize, ref count);
        }


        private static int[] findMedian(int[] arr)
        {
            int[] result = new int[arr.Length];

            Node root = null;
            Node[] medianNodes = new Node[2];
            for (int i = 0; i < arr.Length; i++)
            {
                root = insert(root, arr[i]);
                medianNodes[0] = medianNodes[1] = null;
                int count = 0;
                findMedianBSTRecursive(root, medianNodes, i + 1, ref count);
                if (medianNodes[1] == null)
                    result[i] = medianNodes[0].data;
                else
                    result[i] = (medianNodes[0].data + medianNodes[1].data) / 2;
            }
            // Write your code here
            return result;
        }
    }
}
