Console.WriteLine("Invert Binary Trees");

Node tree1 = new(4, new(2, new(1), new(3)), new(7, new(6), new(9)));
Node tree2 = new(2, new(1), new(3));

Node expectedTree1 = new(4, new(7, new(9), new(6)), new(2, new(3), new(1)));
Node expectedTree2 = new(2, new(3), new(1));

var treeInverted1 = Solution.InvertTreeInteratively(tree1);
var treeInverted2 = Solution.InvertTreeInteratively(tree2);

if (Compare.CompareTree.Equals(treeInverted1, expectedTree1))
    Console.WriteLine("tree 1 ok");
else
    Console.WriteLine("tree 1 deu ruim :/");

if (Compare.CompareTree.Equals(treeInverted2, expectedTree2))
    Console.WriteLine("tree 2 ok");
else
    Console.WriteLine("tree 2 deu ruim :/");


class Node
{
    public Node(int value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}

static class Solution
{
    public static Node? InvertTreeRecursively(Node? rootNode)
    {
        if (rootNode == null)
            return null;

        Node? holdingNode = rootNode.Left;
        rootNode.Left = rootNode.Right;
        rootNode.Right = holdingNode;

        InvertTreeRecursively(rootNode.Left);
        InvertTreeRecursively(rootNode.Right);

        return rootNode;
    }

    public static Node? InvertTreeInteratively(Node? rootNode)
    {
        Queue<Node?> queue = new Queue<Node?>();
        queue.Enqueue(rootNode);

        while (queue.Count > 0)
        {
            Node? node = queue.Dequeue();
            if (node is null)
                continue;

            Node? holdingNode = node.Left;
            node.Left = node.Right;
            node.Right = holdingNode;

            queue.Enqueue(node.Left);
            queue.Enqueue(node.Right);
        }

        return rootNode;
    }
}
