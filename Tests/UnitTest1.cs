namespace Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void TestBinaryTreeLevelOrderTraversal()
        {
            var root = new Node(1,
                new Node(2,
                    new Node(4,
                        new Node(8),
                        new Node(9)
                    ),
                    new Node(5,
                        new Node(10),
                        new Node(11)
                    )),
                new Node(3,
                    new Node(6,
                        new Node(12),
                        new Node(13)
                    ),
                    new Node(7,
                        new Node(14),
                        new Node(15)
                    ))
            );

            var output = GetLevelOrderTraversalOutput(root);

            var expectedOutput = "1 \n2 3 \n4 5 6 7 \n8 9 10 11 12 13 14 15 ";

            Assert.Equal(expectedOutput, output);
        }

        private string GetLevelOrderTraversalOutput(Node root)
        {
            Queue<(Node Current, int Level)> queue = new();
            queue.Enqueue((root, 1));
            int currentLevel = 1;
            string result = "";

            while (queue.Count > 0)
            {
                var (current, level) = queue.Dequeue();
                if (currentLevel < level)
                {
                    result += "\n";
                    currentLevel++;
                }

                result += $"{current.Value} ";

                if (current.Left != null)
                {
                    queue.Enqueue((current.Left, level + 1));
                }

                if (current.Right != null)
                {
                    queue.Enqueue((current.Right, level + 1));
                }
            }

            return result;
        }
    }

    public record Node(int Value, Node? Left = default, Node? Right = default);
}
