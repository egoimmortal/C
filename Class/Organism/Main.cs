enum CreatureType
{
    GRASS = 0,
    LAMB = 1,
    SHEEP = 2,
    WOLF = 3,
    DOG = 4
}

namespace Creature
{
    abstract class Creature
    {
        public int x { get; set; }
        public int y { get; set; }
        protected string name;
        protected int iActionNum;
        public Creature() => iActionNum = 0;
        public abstract void Action();
        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}