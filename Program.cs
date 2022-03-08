using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharp
{
    using AStar;
    using Map;
    using Creature;

    class Program
    {
        private string sWolf = "狼";
        private string sSheep = "羊";
        private string sLamb = "小";
        private string sDog = "犬";
        private string sGrass = "草";
        private string sMapSpace = "一";
        static void Main()
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();//開始計時
            //stopWatch.Stop();//停止計時
            //Console.WriteLine(stopWatch.ElapsedMilliseconds);//顯示經過時間

            Program main = new Program();
            Random rnd = new Random();
            Map map = new Map(20, 20, main.sMapSpace);
            List<Creature> lCreature = new List<Creature>();
            AStar aStar = new AStar();
            int iNowTurn = 0;

            main.Init(rnd, lCreature, map);

            //map.SetMap(0, 0, "草");
            //map.SetMap(map.GetMap().GetLength(0) - 1, map.GetMap().GetLength(1) - 1, "草");
            main.WritwMap(map);

            while(true)
            {
                System.Console.WriteLine("按下Space進行一回合，按下Enter進行至第一百回合");
                var keyIn = Console.ReadKey().Key;
                if(keyIn == ConsoleKey.Spacebar)
                {
                    iNowTurn++;
                    System.Console.WriteLine("按下了Space，執行一回合，目前回合為 : " + iNowTurn);
                }
                else if(keyIn == ConsoleKey.Enter)
                {
                    while(iNowTurn < 100)
                    {
                        iNowTurn++;
                    }
                    System.Console.WriteLine("按下了Enter，執行至第一百回合，目前回合為 : " + iNowTurn);
                    break;
                }
            }

            System.Console.WriteLine("按任意鍵離開遊戲");
            System.Console.ReadLine();
            /*
            foreach ((int, int) item in map.GetIdleMap())
            {
                System.Console.WriteLine(item);
            }
            */
            //System.Console.WriteLine(map.GetIdleMap()[0].Item2);//取得LIST第一個內容
            //System.Console.WriteLine(map.GetIdleMap()[0].Item1);//取得LIST第一個內容的第一個值
            //System.Console.WriteLine(map.GetIdleMap().Count);//取得LIST長度
            //Console.WriteLine(aStar.Operation(t1, t2)[0]);
        }

        ///<summary>
        ///初始化有10羊 1犬 5草
        ///</summary>
        public void Init(Random rnd, List<Creature> lCreature, Map map, int iSheepNum = 10, int iDogNum = 1, int iGrassNum = 5)
        {
            List<(int, int)> idleMap = map.GetIdleMap();
            int rndNum;

            for(int i = 0; i < iSheepNum; i++)
            {
                rndNum = rnd.Next(map.GetIdleMap().Count);
                Create(sSheep, idleMap[rndNum].Item1, idleMap[rndNum].Item2, rndNum, lCreature, map);
            }

            for(int i = 0; i < iDogNum; i++)
            {
                rndNum = rnd.Next(map.GetIdleMap().Count);
                Create(sDog, idleMap[rndNum].Item1, idleMap[rndNum].Item2, rndNum, lCreature, map);
            }

            for(int i = 0; i < iGrassNum; i++)
            {
                rndNum = rnd.Next(map.GetIdleMap().Count);
                Create(sGrass, idleMap[rndNum].Item1, idleMap[rndNum].Item2, rndNum, lCreature, map);
            }
        }

        ///<summary>
        ///根據name創建生物加入至lCreature中
        ///</summary>
        public void Create(string name, int x, int y, int rndNum, List<Creature> lCreature, Map map)
        {
            Creature creature;
            map.SetMap(x, y, name, rndNum);
            switch(name)
            {
                case "草":
                    creature = new Grass();
                    break;
                case "小":
                    creature = new Lamb();
                    break;
                case "羊":
                    creature = new Sheep();
                    break;
                case "狼":
                    creature = new Wolf();
                    break;
                default:
                    creature = new Dog();
                    break;
            }

            lCreature.Add(creature);
        }

        ///<summary>
        ///列印地圖
        ///</summary>
        public void WritwMap(Map map)
        {
            for(int i = 0; i < map.GetMap().GetLength(0); i++)
            {
                for(int k = 0; k < map.GetMap().GetLength(1); k++)
                {
                    System.Console.Write(map.GetMap()[i, k]);
                }
                System.Console.WriteLine();
            }
        }
    }
}
