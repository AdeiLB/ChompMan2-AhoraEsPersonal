using System;
using System.Collections.Generic;

public class AStar
{
    public class Node
    {
        public int X;
        public int Y;
        public int G;
        public int H;
        public int F => G + H;
        public Node Parent;

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Node node && node.X == X && node.Y == Y;
        }

        public override int GetHashCode()
        {
            return X * 1000 + Y;
        }
    }

    private static List<Node> GetNeighbors(Node node, MapMatrix matriz)
    {
        var neighbors = new List<Node>();
        int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        for (int i = 0; i < 4; i++)
        {
            int nx = node.X + directions[i, 0];
            int ny = node.Y + directions[i, 1];

            if (nx >= 0 && ny >= 0 && nx < matriz.GetColumnCount() && ny < matriz.GetRowCount() && (matriz[nx, ny] == 2 || matriz[nx, ny] == 0))
            {
                neighbors.Add(new Node(nx, ny));
            }
        }

        return neighbors;
    }

    private static int Heuristic(Node a, Node b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    public static List<Node> FindPath(MapMatrix matrix, Node start, Node goal)
    {
        var openSet = new SortedSet<Node>(Comparer<Node>.Create((a, b) =>
        {
            int compare = a.F.CompareTo(b.F);
            if (compare == 0) compare = a.H.CompareTo(b.H); // Tie-breaker
            if (compare == 0) compare = a.X.CompareTo(b.X);
            if (compare == 0) compare = a.Y.CompareTo(b.Y);
            return compare;
        }));

        var cameFrom = new Dictionary<Node, Node>();
        var gScore = new Dictionary<Node, int>();
        var fScore = new Dictionary<Node, int>();

        start.G = 0;
        start.H = Heuristic(start, goal);
        openSet.Add(start);
        gScore[start] = 0;
        fScore[start] = start.H;

        while (openSet.Count > 0)
        {
            Node current = null;
            foreach (var n in openSet)
            {
                current = n;
                break;
            }

            if (current.Equals(goal))
            {
                var path = new List<Node>();
                while (current != null)
                {
                    path.Add(current);
                    current = current.Parent;
                }
                path.Reverse();
                return path;
            }

            openSet.Remove(current);

            foreach (var neighbor in GetNeighbors(current, matrix))
            {
                int tentativeG = current.G + 1;

                if (!gScore.ContainsKey(neighbor) || tentativeG < gScore[neighbor])
                {
                    neighbor.Parent = current;
                    neighbor.G = tentativeG;
                    neighbor.H = Heuristic(neighbor, goal);
                    gScore[neighbor] = neighbor.G;
                    fScore[neighbor] = neighbor.F;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null; // No path found
    }
}
