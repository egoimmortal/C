using System.Numerics;

namespace CSharp
{
    class Node
    {
        public Vector2 vPos;
        public Node(float X, float Y)
        {
            vPos.X = X;
            vPos.Y = Y;
        }
        public float CostFromStart { get; set; }
        public float CostFromGoal { get; set; }
        public float TotalCost { get; set; }
        public string Name { get; set; }
        public Node Parent{ get; set;}
        public Node Next { get; set; }
    }
}