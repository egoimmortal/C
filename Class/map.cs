using System.Collections.Generic;

namespace Map
{
    class Map
    {
        private string mapSpace;
        private string[,] aMap;
        private List<(int, int)> iIdleMap;

        public Map(int x, int y, string mapSpace)
        {
            aMap = new string[x, y];
            iIdleMap = new List<(int, int)>();
            this.mapSpace = mapSpace;

            for(int i = 0; i < x; i++)
            {
                for(int k = 0; k < y; k++)
                {
                    aMap[i, k] = this.mapSpace;
                    iIdleMap.Add((i, k));
                }
            }
        }

        public string GetMapSpace() => mapSpace;
        public string[,] GetMap() => aMap;
        public void SetMap(int x, int y, string name, int idleMapPos)
        {
            aMap[x, y] = name;
            if(name == mapSpace)
                AddItemToIdleMap(x, y);
            else
                RemoveItemFromIdleMap(idleMapPos);
        }

        public List<(int, int)> GetIdleMap() => iIdleMap;
        private void AddItemToIdleMap(int x, int y)
        {
            iIdleMap.Insert((x * aMap.GetLength(1)) + y, (x, y));
        }
        private void RemoveItemFromIdleMap(int pos)
        {
            iIdleMap.RemoveAt(pos);
        }
    }
}