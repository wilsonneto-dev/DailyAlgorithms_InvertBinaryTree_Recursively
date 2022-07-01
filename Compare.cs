namespace Compare;

static class CompareTree
{
    public static bool Equals(Node rootNode1, Node rootNode2)
    {
        var queue = new Queue<(Node?, Node?)>();
        queue.Enqueue((rootNode1, rootNode2));

        while (queue.TryPeek(out var nil))
        {
            var (node1, node2) = queue.Dequeue();
            if (node1 is null || node2 is null)
                if (node1 == node2) continue;
                else return false;

            if (node1.Value != node2.Value)
                return false;

            queue.Enqueue((node1.Left, node2.Left));
            queue.Enqueue((node1.Right, node2.Right));
        }
        return true;
    }
}