using System;

namespace SkillsViewer
{
    public class HeroesInvalidArgumentException: Exception
    {
        public HeroesInvalidArgumentException() : base("Heroes names cannot be null or empty.")
        {
        }
    }   
}