namespace Trees.BinaryTree
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public override string ToString() => Value.ToString();

        public bool IsLeaf => Left == null && Right == null;
    }
}
