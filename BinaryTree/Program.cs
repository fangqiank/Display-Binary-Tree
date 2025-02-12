using System.Collections;

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

Queue<(Node Current, int Level)> queue = new();

queue.Enqueue((root, 1));
int currentLevel = 1;

while (queue.Count > 0)
{
    var (current, level) = queue.Dequeue();
    if(currentLevel < level)
    {
        Console.WriteLine();
        currentLevel++;
    }

    Console.Write($"{current.Value} ");
    
    if (current.Left != null)
    {
        queue.Enqueue((current.Left, level + 1));
    }

    if (current.Right != null)
    {
        queue.Enqueue((current.Right, level + 1));
    }
}
public record Node(int Value, Node? Left = default, Node? Right = default);