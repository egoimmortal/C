using System;
using System.Collections.Generic;

namespace AStar
{
    using CSharp;

    class AStar
    {
        private List<Node> resultList = new List<Node>();
        public AStar()
        {
            Console.WriteLine("Hello AStar!!!");
        }

        public List<Node> Operation(Node origin, Node goal)
        {
            List<Node> openset = new List<Node>();
            List<Node> closedset = new List<Node>();
            List<Node> cameFrom = new List<Node>();

            float fCostFromStart;
            float fCostFromGoal;
            float fTotalCost;

            fCostFromStart = 0;//該點到原點的距離
            fCostFromGoal = GetTwoPointsLength(origin, goal);//該點到終點的距離
            fTotalCost = fCostFromStart + fCostFromGoal;

            openset.Add(origin);

            while(openset.Count != 0)
            {
                Node nowPoint = openset[0];
                float fLowestCost = nowPoint.TotalCost;
                //在將被估算的值中尋找總耗費最少的值
                for (int i = 0; i < openset.Count; i++)
                {
                    if(openset[i].TotalCost < fLowestCost)
                    {
                        nowPoint = openset[i];
                        fLowestCost = nowPoint.TotalCost;
                    }
                }

                //如果該點等於終點
                if(nowPoint.vPos == goal.vPos)
                {
                    GetResultPath(cameFrom, goal);
                    return resultList;
                }

                openset.Remove(nowPoint);
                closedset.Add(nowPoint);

                //搜尋相鄰節點(相當於搜尋八個方位加自己，執行九次)
                for(int x = -1; x <= 1; x++)
                {
                    for(int y = -1; y <= 1; y++)
                    {
                        if(x == 0 && y == 0) continue;//如果是自己的話就跳過
                        Node neighborNode = new Node(nowPoint.vPos.X + x, nowPoint.vPos.Y + y);
                    }
                }
            }
            return null;
        }

        ///<summary>
        ///取得最終路徑
        ///</summary>
        private void GetResultPath(List<Node> cameFrom, Node currentNode)
        {
            if(cameFrom.Contains(currentNode))
            {
                cameFrom.Remove(currentNode);
                resultList.Add(currentNode);
                GetResultPath(cameFrom, currentNode.Parent);
            }
        }

        ///<summary>
        ///取得兩點距離
        ///</summary>
        private float GetTwoPointsLength(Node x, Node y)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow(Math.Abs(y.vPos.X - x.vPos.X), 2) + Math.Pow(Math.Abs(y.vPos.Y - x.vPos.Y), 2)));
        }
    }
}