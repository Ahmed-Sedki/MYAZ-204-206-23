﻿namespace LinkedList.Doubly
{
    public class DbNode<T>
    {
        public T? Value { get; set; }

        public DbNode<T> Next { get; set; }
        public DbNode<T> Prev { get; set; }

        public DbNode(T? value)
        {
            Value = value;
        }

        public DbNode()
        {
        }

        public override string? ToString()
        {
            return $"{Value}";
        }
    }
}
