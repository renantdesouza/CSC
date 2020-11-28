using System;

namespace Hero.Item
{
    [Serializable]
    public class Item
    {
        public string name;

        public string image;

        public string type;

        public string slot;

        public string precision;

        public string[] usedBy;

        public string effect;

        public bool isEquipped;
    }
}