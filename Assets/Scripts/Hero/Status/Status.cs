using System;
using UnityEngine.Serialization;

namespace Hero.Status
{
    [Serializable]
    public class Status
    {
        public double currentHp;
        public int xp;
        public int points;
    }
}